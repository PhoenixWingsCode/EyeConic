using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class EditSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EditItemId"] == null || Session["EditCategoryId"] == null)
                {
                    Response.Redirect("SubCategories.aspx");
                }
                else
                {
                    var editItemId = Session["EditItemId"].ToString();
                    var editCategoryId = Session["EditCategoryId"].ToString();

                    // Populate the category dropdown
                    PopulateCategoryDropDown();

                    // Fetch subcategory details based on editItemId
                    string query = "SELECT categoryId, name, description FROM subcategories WHERE id=" + editItemId;
                    DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                    if (dataTable.Rows.Count > 0)
                    {
                        string name = dataTable.Rows[0]["name"].ToString();
                        string description = dataTable.Rows[0]["description"].ToString();

                        // Set values to the controls
                        txtName.Text = name;
                        txtDescription.Text = description;

                        // Set the selected value for the category dropdown
                        ddlCategory.SelectedValue = editCategoryId;

                        // Manually trigger the SelectedIndexChanged event
                        DdlCategory_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the selected category ID in the txtCategoryId TextBox
            txtCategoryId.Text = ddlCategory.SelectedValue;
        }

        private void PopulateCategoryDropDown()
        {
            string categoryQuery = "SELECT id, name FROM categories";
            DataTable categoryDataTable = DatabaseHelper.ExecuteQuery(categoryQuery);

            if (categoryDataTable.Rows.Count > 0)
            {
                ddlCategory.DataSource = categoryDataTable;
                ddlCategory.DataTextField = "name";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }
        }



        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Name", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Description", "error");
                return;
            }
            else
            {
                var editItemId = Session["EditItemId"].ToString();
                var editCategoryId = Session["EditCategoryId"].ToString();

                string editquery = "UPDATE subcategories SET categoryId=@editCategoryId,name=@Name, description=@Description " +
                    "WHERE id=@EditItemId";

                Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@editCategoryId", txtCategoryId.Text },
        { "@Name", txtName.Text },
        { "@Description", txtDescription.Text },
        { "@EditItemId", editItemId }
    };

                DatabaseHelper.ExecuteNonQueryParameterized(editquery, parameters);

                ShowSweetAlert("Updated", "Category Updated Successfully", "success");
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            // Clear the name and description
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        protected void GoBackToCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubCategories.aspx");
        }

    }
}
