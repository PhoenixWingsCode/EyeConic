using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            if (IsNull() == false)
            {
                int categoryId = GetCategoryIdByName(name);

                if (categoryId > 0)
                {
                    ShowSweetAlert("Oops...", "Category already exists", "error");
                }
                else
                {
                    string insertQuery = "INSERT INTO categories (name, description) VALUES(@Name, @Description)";

                    // Use parameterized query to avoid SQL injection
                    Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Name", name },
                { "@Description", description }
            };

                    DatabaseHelper.ExecuteNonQueryParameterized(insertQuery, parameters);
                    Clr();

                    ShowSweetAlert("Inserted", "Category Inserted Successfully", "success");
                }
            }
        }

        private int GetCategoryIdByName(string categoryName)
        {
            string selectQuery = "SELECT id FROM categories WHERE name = '" + categoryName + "' AND IsDeleted = 0";

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

        private bool IsNull()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Name", "error");
                txtName.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Description", "error");
                txtDescription.Focus();
                return true;
            }

            else
                return false;
        }

        private void Clr()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }

        protected void GoBackToCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Clr();
        }
    }
}