using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace EyeConic_Solution.Dashboard
{
    public partial class AddProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCategoryDropDown();
            }

        }

        protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategoryId.Text = ddlCategory.SelectedValue;
            PopulateSubCategoryDropDown(txtCategoryId.Text);
        }

        private void PopulateSubCategoryDropDown(string categoryId)
        {
            // Fetch subcategories for the selected category from the database
            string subCategoryQuery = "SELECT id, name FROM subcategories WHERE categoryId = @CategoryId AND IsDeleted = 0";
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
            ddlSubCategory.Items.Insert(0, new ListItem("Select Subcategory", "0"));

            // Set the first subcategory details in the textbox (optional)
            if (ddlSubCategory.Items.Count > 0)
            {
                txtSubCategoryId.Text = ddlSubCategory.SelectedValue;
            }
        }

        protected void DdlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubCategoryId.Text = ddlSubCategory.SelectedValue;
        }

        private void PopulateCategoryDropDown()
        {
            string categoryQuery = "SELECT id, name FROM categories WHERE IsDeleted = 0";
            DataTable categoryDataTable = DatabaseHelper.ExecuteQuery(categoryQuery);

            if (categoryDataTable.Rows.Count > 0)
            {
                ddlCategory.DataSource = categoryDataTable;
                ddlCategory.DataTextField = "name";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }

            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));

            if (ddlCategory.Items.Count > 0)
            {
                txtCategoryId.Text = ddlCategory.SelectedValue;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsNull())
                {
                    string name = txtName.Text;

                    // Check if a product with the same name already exists
                    if (ProductExists(name))
                    {
                        ShowSweetAlert("Error", "Product with the same name already exists", "error");
                    }
                    else
                    {
                        // If product doesn't exist, proceed with the insertion
                        int categoryId = Convert.ToInt32(txtCategoryId.Text);
                        int subCategoryId = Convert.ToInt32(txtSubCategoryId.Text);
                        string description = txtDescription.Text;
                        decimal price = decimal.Parse(txtPrice.Text);
                        string size = ddlFrameSize.SelectedValue;
                        string width = txtFrameWidth.Text + " mm";
                        string dimensions = txtFrameDimensions.Text;
                        string color = txtFrameColor.Text;

                        // Perform the insertion
                        InsertProduct(categoryId, subCategoryId, name, description, price, size, width, dimensions, color);

                        // Display success message or redirect to another page
                        ShowSweetAlert("Success", "Product added successfully", "success");

                        Session["Name"] = name;

                        Response.Redirect("AddImages.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Handle exceptions, log errors, etc.
                ShowSweetAlert("Error", "An error occurred while adding the product", "error");
            }
        }

        private bool ProductExists(string productName)
        {
            // Check if a product with the same name already exists in the database
            // You need to implement your database access logic here
            // Replace the following code with your actual database query

            string selectQuery = "SELECT COUNT(*) FROM Products WHERE name = @ProductName AND isDeleted = 0;";

            // Parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@ProductName", productName }
    };

            DataTable result = DatabaseHelper.ExecuteQueryParameterized(selectQuery, parameters);

            // Check if any rows are returned
            return result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0;
        }

        private void InsertProduct(int categoryId, int subCategoryId, string name, string description, decimal price, string size, string width, string dimensions, string color)
        {
            // Perform the actual insertion
            // You need to implement your database access logic here
            // Replace the following code with your actual database query

            string insertQuery = "INSERT INTO Products (categoryId, subCategoryId, name, description, price, frameSize, frameWidth, frameDimensions, frameColor) " +
                                 "VALUES (@CategoryId, @SubCategoryId, @Name, @Description, @Price, @FrameSize, @FrameWidth, @FrameDimensions, @FrameColor);";

            // Parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@CategoryId", categoryId },
        { "@SubCategoryId", subCategoryId },
        { "@Name", name },
        { "@Description", description },
        { "@Price", price },
        { "@FrameSize", size },
        { "@FrameWidth", width },
        { "@FrameDimensions", dimensions },
        { "@FrameColor", color }
    };

            // Execute the query
            DatabaseHelper.ExecuteNonQueryParameterized(insertQuery, parameters);
        }
        private bool IsNull()
        {
            if (txtCategoryId.Text == "0")
            {
                ShowSweetAlert("Error", "Please select category", "error");
                return false;
            }
            else if (txtSubCategoryId.Text == "0")
            {
                ShowSweetAlert("Error", "Please select sub category", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowSweetAlert("Error", "Please enter Name", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowSweetAlert("Error", "Please enter Description", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPrice.Text) || !IsNumeric(txtPrice.Text))
            {
                ShowSweetAlert("Error", "Please enter a valid Price", "error");
                return false;
            }
            else if (ddlFrameSize.SelectedValue == "")
            {
                ShowSweetAlert("Error", "Please select size", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameWidth.Text) || !IsNumeric(txtFrameWidth.Text))
            {
                ShowSweetAlert("Error", "Please enter a valid Width", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameDimensions.Text) || !IsValidDimensions(txtFrameDimensions.Text))
            {
                ShowSweetAlert("Error", "Please enter valid Dimensions", "error");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtFrameColor.Text))
            {
                ShowSweetAlert("Error", "Please enter Color", "error");
                return false;
            }
            return true;
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

        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void GoBackToCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }
    }
}