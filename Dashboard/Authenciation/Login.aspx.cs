using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Admin"] != null && Request.Cookies["Password"] != null)
            {
                string username = Request.Cookies["Admin"].Value;
                string password = Request.Cookies["Password"].Value;

                string encryptPassword = PasswordUtility.EncryptPassword(password);

                // Check if the user exists in the database with the provided credentials
                string query = "SELECT * FROM admin WHERE username='" + username + "' AND password='" + encryptPassword + "'";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    string usernametext = dataTable.Rows[0]["username"].ToString();

                    // Set session and redirect to UserHome.aspx
                    Session["Admin"] = usernametext;
                    Response.Redirect("../Home.aspx");
                }
            }

        }

        protected void BtnSignIn_Click(object sender, EventArgs e)
        {
            if (Isformvalid())
            {
                string encryptPassword = PasswordUtility.EncryptPassword(txtPassword.Text);
                string query = "select * from admin where username='" + txtUsername.Text + "' and password='" + encryptPassword + "'";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                if (dataTable.Rows.Count > 0)
                {
                    string username = dataTable.Rows[0]["username"].ToString();
                    ShowSweetAlert("Login", "Login Successful", "success");

                    Response.Cookies["Password"].Value = txtPassword.Text;
                    Response.Cookies["Admin"].Value = username;

                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["Admin"].Expires = DateTime.Now.AddDays(1);

                    Session["Admin"] = username;
                    Response.Redirect("../Home.aspx");
                }
                else
                {
                    ShowSweetAlert("Login", "Login Failed", "error");
                }
                Clr();
            }
        }


        private bool Isformvalid()
        {
            if (IsNull())
            {
                return false;
            }

            if (!IsPasswordValid(txtPassword.Text))
            {
                ShowSweetAlert("Oops...", "Password requirement not met", "error");
                return false;
            }
            return true;
        }

        private bool IsNull()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Username", "error");
                txtUsername.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Password", "error");
                txtPassword.Focus();
                return true;
            }

            return false;
        }

        private bool IsPasswordValid(string password)
        {
            // Password should have at least 1 capital alphabet, 1 small alphabet, 1 number, 1 special character, and be at least 8 characters.
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        private void Clr()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }
    }
}