using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class AddSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCategoryDropDown();
            }
        }

        private void PopulateCategoryDropDown()
        {
            string query = "SELECT id, name FROM categories WHERE isDeleted = 0";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                ddlCategory.DataSource = dataTable;
                ddlCategory.DataTextField = "name";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }

            // Set the first item as selected (optional)
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));

            // Set the first subcategory details in the textbox (optional)
            if (ddlCategory.Items.Count > 0)
            {
                txtCategoryId.Text = ddlCategory.SelectedValue;
            }
        }

        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategoryId.Text = ddlCategory.SelectedValue;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(txtCategoryId.Text);
            string name = txtName.Text;
            string description = txtDescription.Text;

            if (IsNull() == false)
            {
                int subCategoryId = SubCategoryExists(categoryId, name);

                if (subCategoryId > 0)
                {
                    ShowSweetAlert("Oops...", "Sub Category already exists", "error");
                }
                else
                {
                    string query = "insert into subcategories(categoryId,name,description) values(@CategoryId,@Name,@Description)";
                    Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@CategoryId", categoryId },
                { "@Name", name },
                { "@Description", description }
            };

                    DatabaseHelper.ExecuteNonQueryParameterized(query, parameters);
                    Clr();

                    ShowSweetAlert("Good job!", "Sub Category inserted successfully", "success");
                }
            }
        }

        private int SubCategoryExists(int categoryId, string name)
        {
            string selectQuery = "SELECT id FROM subcategories WHERE categoryId='" + categoryId + "' AND name='" + name + "' AND IsDeleted = 0";

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

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Clr();
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
            Response.Redirect("SubCategories.aspx");
        }
    }
}