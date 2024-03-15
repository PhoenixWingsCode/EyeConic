using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in for the day
            if (Request.Cookies["Email"] != null && Request.Cookies["Password"] != null)
            {
                string email = Request.Cookies["Email"].Value;
                string password = Request.Cookies["Password"].Value;

                string encryptPassword = PasswordUtility.EncryptPassword(password);

                // Check if the user exists in the database with the provided credentials
                string query = "SELECT * FROM users WHERE email='" + email + "' AND password='" + encryptPassword + "'";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    string username = dataTable.Rows[0]["username"].ToString();

                    // Set session and redirect to UserHome.aspx
                    Session["Username"] = username;
                    Response.Redirect("~/UserHome.aspx");
                }
            }

        }

        protected void BtnSignIn_Click(object sender, EventArgs e)
        {
            if (Isformvalid())
            {
                string encryptPassword = PasswordUtility.EncryptPassword(txtPassword.Text);
                string query = "select * from users where email='" + txtEmail.Text + "' and password='" + encryptPassword + "'";
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                if (dataTable.Rows.Count > 0)
                {
                    string username = dataTable.Rows[0]["username"].ToString();
                    ShowSweetAlert("Login", "Login Successful", "success");

                    Response.Cookies["Email"].Value = txtEmail.Text;
                    Response.Cookies["Password"].Value = txtPassword.Text;
                    Response.Cookies["Username"].Value = username;

                    Response.Cookies["Email"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["Username"].Expires = DateTime.Now.AddDays(1);


                    Session["Username"] = username;
                    Response.Redirect("~/UserHome.aspx");
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

            if (!IsEmailValid(txtEmail.Text))
            {
                ShowSweetAlert("Oops...", "Invalid email format", "error");
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
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Email", "error");
                txtEmail.Focus();
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

        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        private bool IsPasswordValid(string password)
        {
            // Password should have at least 1 capital alphabet, 1 small alphabet, 1 number, 1 special character, and be at least 8 characters.
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        private void Clr()
        {
            txtEmail.Text = string.Empty;
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