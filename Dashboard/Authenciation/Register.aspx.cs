using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if (Isformvalid())
            {
                int categoryId = GetAdminIdByUsername(username);

                if (categoryId > 0)
                {
                    // Category already exists, show message
                    ShowSweetAlert("Oops...", "Admin already exists", "error");
                }
                else
                {
                    string encryptPassword = PasswordUtility.EncryptPassword(txtPassword.Text);
                    string query = "insert into admin(username,password) values('" + username + "','" + encryptPassword + "')";
                    DatabaseHelper.ExecuteNonQuery(query);
                    ShowSweetAlert("Good job!", "Registration successful. You can now sign in with your credentials!", "success");
                    Clr();

                    Response.Redirect("Authenciation/Login.aspx");
                }
            }
        }

        private int GetAdminIdByUsername(string username)
        {
            string selectQuery = "SELECT id FROM admin WHERE username = '" + username + "'";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(selectQuery);

            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt32(dataTable.Rows[0]["id"]);
            }
            else
            {
                return 0;
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }
    }
}