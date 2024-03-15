using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable viewCategory = ViewCategory();

                RepeaterItems.DataSource = viewCategory;
                RepeaterItems.DataBind();
            }
        }

        private DataTable ViewCategory()
        {
            string query = "SELECT id, name, description FROM categories WHERE isDeleted = 0";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if(sender is LinkButton BtnEdit)
            {
                string itemId = BtnEdit.CommandArgument;

                Session["EditItemId"] = itemId;
                Console.Write(itemId);

                Response.Redirect("EditCategory.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton BtnDelete)
            {
                string categoryId = BtnDelete.CommandArgument;

                // Update IsDeleted flag for images associated with products
                UpdateProductImagesIsDeleted(categoryId);

                // Update IsDeleted flag for products associated with the category
                UpdateProductsIsDeleted(categoryId);

                // Update IsDeleted flag for subcategories associated with the category
                UpdateSubcategoriesIsDeleted(categoryId);

                // Update IsDeleted flag for the category itself
                UpdateCategoryIsDeleted(categoryId);

                Session["DeleteItemId"] = categoryId;

                Response.Redirect(Request.Url.AbsoluteUri, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        // Function to update IsDeleted flag for images associated with products
        private void UpdateProductImagesIsDeleted(string categoryId)
        {
            string productImageQuery = @"
        UPDATE image
        SET isDeleted = 1
        WHERE productId IN (SELECT id FROM products WHERE categoryId = " + categoryId + ")";
            DatabaseHelper.ExecuteNonQuery(productImageQuery);
        }

        // Function to update IsDeleted flag for products associated with the category
        private void UpdateProductsIsDeleted(string categoryId)
        {
            string productQuery = "UPDATE products SET isDeleted = 1 WHERE categoryId = " + categoryId;
            DatabaseHelper.ExecuteNonQuery(productQuery);
        }

        // Function to update IsDeleted flag for subcategories associated with the category
        private void UpdateSubcategoriesIsDeleted(string categoryId)
        {
            string subcategoryQuery = "UPDATE subcategories SET isDeleted = 1 WHERE categoryId = " + categoryId;
            DatabaseHelper.ExecuteNonQuery(subcategoryQuery);
        }

        // Function to update IsDeleted flag for the category
        private void UpdateCategoryIsDeleted(string categoryId)
        {
            string categoryQuery = "UPDATE categories SET isDeleted = 1 WHERE id = " + categoryId;
            DatabaseHelper.ExecuteNonQuery(categoryQuery);
        }
    }
}