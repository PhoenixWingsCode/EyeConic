using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EditItemId"] == null || Session["EditSubCategoryId"] == null ||
                    Session["EditCategoryId"] == null || Session["EditCategoryName"] == null ||
                    Session["EditSubCategoryName"] == null)
                {
                    Response.Redirect("Products.aspx");
                }
                else
                {
                    txtCategoryId.Text = Session["EditCategoryId"].ToString();
                    txtCategoryName.Text = Session["EditCategoryName"].ToString();
                    txtSubCategoryId.Text = Session["EditSubCategoryId"].ToString();
                    txtSubCategoryName.Text = Session["EditSubCategoryName"].ToString();
                    var editItemId = Session["EditItemId"].ToString();

                    PopulateCategoryDropDown();

                    string query = "select name,description,price,frameSize,frameWidth,frameDimensions,frameColor from products where id=" + editItemId;
                    DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                    if (dataTable.Rows.Count > 0)
                    {
                        string name = dataTable.Rows[0]["name"].ToString();
                        string description = dataTable.Rows[0]["description"].ToString();
                        string price = dataTable.Rows[0]["price"].ToString();
                        string size = dataTable.Rows[0]["frameSize"].ToString();
                        string width = dataTable.Rows[0]["frameWidth"].ToString();
                        string dimensions = dataTable.Rows[0]["frameDimensions"].ToString();
                        string color = dataTable.Rows[0]["frameColor"].ToString();

                        txtName.Text = name;
                        txtDescription.Text = description;
                        txtPrice.Text = price;
                        ddlFrameSize.SelectedValue = size;
                        txtFrameWidth.Text = width;
                        txtFrameDimensions.Text = dimensions;
                        txtFrameColor.Text = color;
                    }
                }
            }
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

            ddlCategory.Items.Insert(0, new ListItem("Select Category"));

            if (ddlCategory.SelectedValue != "Select Category")
            {
                txtCategoryId.Text = ddlCategory.SelectedValue;
                txtSubCategoryId.ReadOnly = false;
                txtSubCategoryName.ReadOnly = false;
                txtSubCategoryId.Text = string.Empty;
                txtSubCategoryName.Text = string.Empty;
                PopulateSubCategoryDropDown(txtCategoryId.Text);
            }
        }

        private void PopulateSubCategoryDropDown(string categoryId)
        {
            // Fetch subcategories for the selected category from the database
            string subCategoryQuery = "SELECT id, name FROM subcategories WHERE categoryId = @CategoryId";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@CategoryId", categoryId }
    };

            DataTable subCategoryDataTable = DatabaseHelper.ExecuteQueryParameterized(subCategoryQuery, parameters);

            if (subCategoryDataTable.Rows.Count > 0)
            {
                ddlSubCategory.DataSource = subCategoryDataTable;
                ddlSubCategory.DataTextField = "name";
                ddlSubCategory.DataValueField = "id";
                ddlSubCategory.DataBind();
            }
            else
            {
                ddlSubCategory.Items.Clear(); // Clear the dropdown if no subcategories found
            }

            // Set the first item as selected (optional)
            ddlSubCategory.Items.Insert(0, new ListItem("Select Subcategory"));

            // Set the first subcategory details in the textbox (optional)
            if (ddlSubCategory.SelectedValue != "Select Subcategory")
            {
                txtSubCategoryId.Text = ddlSubCategory.SelectedValue;
                txtSubCategoryName.Text = ddlSubCategory.SelectedItem.Text;
            }
        }

        protected void DdlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedValue != "Select Subcategory")
            {
                txtSubCategoryId.Text = ddlSubCategory.SelectedValue;
                txtSubCategoryName.Text = ddlSubCategory.SelectedItem.Text;
            }
        }

        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != "Select Category")
            {
                txtCategoryId.Text = ddlCategory.SelectedValue;
                txtCategoryName.Text = ddlCategory.SelectedItem.Text;
                txtSubCategoryId.Text = string.Empty;
                txtSubCategoryName.Text = string.Empty;
                PopulateSubCategoryDropDown(txtCategoryId.Text);
            }
        }



        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                ShowSweetAlert("Oops...", "Please select category", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSubCategoryId.Text))
            {
                ShowSweetAlert("Oops...", "Please select sub category", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Name", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Description", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPrice.Text) || !IsNumeric(txtPrice.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Price", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(ddlFrameSize.SelectedValue = "Select Size"))
            {
                ShowSweetAlert("Oops...", "Please select Frame Size", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameWidth.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Frame Width", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameDimensions.Text) || !IsValidDimensions(txtFrameDimensions.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Frame Dimensions", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameColor.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Frame Color", "error");
                return;
            }
            else
            {
                int categoryId = Convert.ToInt32(txtCategoryId.Text);
                int subCategoryId = Convert.ToInt32(txtSubCategoryId.Text);
                string name = txtName.Text;
                string description = txtDescription.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                string size = ddlFrameSize.SelectedValue;
                string width = txtFrameWidth.Text;
                string dimensions = txtFrameDimensions.Text;
                string color = txtFrameColor.Text;
                var editItemId = Session["EditItemId"].ToString();

                string query = "update products set categoryId=@CategoryId,subCategoryId=@SubCategoryId,name=@Name,description=@Description," +
                    "price=@Price,frameSize=@Size,frameWidth=@Width,frameDimensions=@Dimensions,frameColor=@Color WHERE id=@EditItemId";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@CategoryId", categoryId },
                    { "@SubCategoryId", subCategoryId },
                    { "@Name", name },
                    { "@Description", description},
                    { "@Price", price },
                    { "@Size", size },
                    { "@Width", width },
                    { "@Dimensions", dimensions },
                    { "@Color", color},
                    { "@EditItemId", editItemId }
                };

                DatabaseHelper.ExecuteNonQueryParameterized(query, parameters);

                ShowSweetAlert("Updated", "Product Updated Successfully", "success");

                Response.Redirect("Products.aspx");
            }
        }

        private bool IsNumeric(string value)
        {
            // Check if the given string is numeric
            return double.TryParse(value, out _);
        }

        private bool IsValidDimensions(string value)
        {
            // Check if the given string is valid for dimensions (numbers, '-' or '/')
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && c != '-' && c != '/')
                {
                    return false;
                }
            }
            return true;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

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
            Response.Redirect("products.aspx");
        }
    }
}