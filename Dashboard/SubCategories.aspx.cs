using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class SubCategories : System.Web.UI.Page
    {
        private int globalCounter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            DataTable viewSubCategory = ViewSubCategory();

            // Set up DataView
            DataView dataView = new DataView(viewSubCategory);
            dataView.Sort = "categoryId";  // Change the sort field as needed

            // Set up PagedDataSource
            PagedDataSource pds = new PagedDataSource
            {
                DataSource = dataView,
                AllowPaging = true,
                PageSize = 5  // Number of rows per page
            };

            // Save the total number of pages in ViewState
            ViewState["TotalPages"] = pds.PageCount;

            // Set the current page index based on query parameter or ViewState
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                int pageIndex = Convert.ToInt32(Request.QueryString["page"]) - 1;
                pds.CurrentPageIndex = pageIndex;
            }
            else if (ViewState["CurrentPage"] != null)
            {
                pds.CurrentPageIndex = Convert.ToInt32(ViewState["CurrentPage"]);
            }

            // Save the current page index in ViewState
            ViewState["CurrentPage"] = pds.CurrentPageIndex;

            // Calculate the cumulative count of items from previous pages
            globalCounter = pds.CurrentPageIndex * pds.PageSize;

            // Bind the Repeater with the PagedDataSource
            RepeaterItems.DataSource = pds;
            RepeaterItems.DataBind();
        }

        protected void RepeaterItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Update the serial numbers to be continuous
                Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
                if (lblSerialNo != null)
                {
                    lblSerialNo.Text = (globalCounter + e.Item.ItemIndex + 1).ToString();
                }
            }
        }



        protected void RepeaterPager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int pageIndex = Convert.ToInt32(e.CommandArgument) - 1;
                int totalPages = Convert.ToInt32(ViewState["TotalPages"]);

                if (pageIndex >= 0 && pageIndex < totalPages)
                {
                    ViewState["CurrentPage"] = pageIndex;
                    BindRepeater();
                }
            }
        }


        private DataTable ViewSubCategory()
        {
            string query = "SELECT sub.id, sub.categoryId, sub.name AS subcategoryName, sub.description, cat.name AS categoryName " +
                           "FROM subcategories sub " +
                           "INNER JOIN categories cat ON sub.categoryId = cat.id " +
                           "WHERE sub.isDeleted = 0";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }


        protected void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            if (currentPage > 0)
            {
                ViewState["CurrentPage"] = currentPage - 1;
                BindRepeater();
            }
        }

        protected void BtnNextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            int totalPages = Convert.ToInt32(ViewState["TotalPages"]);
            if (currentPage < totalPages - 1)
            {
                ViewState["CurrentPage"] = currentPage + 1;
                BindRepeater();
            }
        }


        protected void AddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSubCategory.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton btnEdit)
            {
                string[] args = btnEdit.CommandArgument.Split(';');
                string itemId = args[0];
                string categoryId = args[1];

                Session["EditItemId"] = itemId;
                Session["EditCategoryId"] = categoryId;
                Console.Write(itemId);

                Response.Redirect("EditSubCategory.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton BtnDelete)
            {
                string[] args = BtnDelete.CommandArgument.Split(';');
                string itemId = args[0];
                string categoryId = args[1];

                Session["DeleteItemId"] = itemId;
                Session["DeleteCategoryId"] = categoryId;

                // Update IsDeleted flag for all images associated with the products
                UpdateImagesIsDeleted(categoryId, itemId);

                // Update IsDeleted flag for all products associated with the category and subcategory
                UpdateProductsIsDeleted(categoryId, itemId);

                // Update IsDeleted flag for the subcategory
                string subCategoryQuery = $"UPDATE subcategories SET isDeleted = 1 WHERE id = {itemId}";
                DatabaseHelper.ExecuteNonQuery(subCategoryQuery);

                Response.Redirect(Request.Url.AbsoluteUri, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        // Function to update IsDeleted flag for all products associated with the category and subcategory
        private void UpdateProductsIsDeleted(string categoryId, string subcategoryId)
        {
            string productQuery = $"UPDATE products SET isDeleted = 1 WHERE categoryId = {categoryId} AND subCategoryId = {subcategoryId}";
            DatabaseHelper.ExecuteNonQuery(productQuery);
        }

        // Function to update IsDeleted flag for all images associated with the products
        private void UpdateImagesIsDeleted(string categoryId, string subcategoryId)
        {
            // Fetch all product IDs associated with the category and subcategory
            DataTable productIds = GetProductIds(categoryId, subcategoryId);

            // Update IsDeleted flag for images associated with each product
            foreach (DataRow row in productIds.Rows)
            {
                int productId = Convert.ToInt32(row["productId"]);
                string imageQuery = $"UPDATE image SET isDeleted = 1 WHERE productId = {productId}";
                DatabaseHelper.ExecuteNonQuery(imageQuery);
            }
        }

        // Function to get product IDs associated with the category and subcategory
        private DataTable GetProductIds(string categoryId, string subcategoryId)
        {
            string query = $"SELECT id AS productId FROM products WHERE categoryId = {categoryId} AND subCategoryId = {subcategoryId}";
            return DatabaseHelper.ExecuteQuery(query);
        }
    }
}