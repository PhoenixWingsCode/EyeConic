using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class products : System.Web.UI.Page
    {
        private int globalCounter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    BindProductData();
            }
        }

        private void BindProductData()
        {
            try
            {
                DataTable productDataTable = ViewProducts();

                // Set up DataView
                DataView dataView = new DataView(productDataTable);
                dataView.Sort = "categoryId"; // Change the sort field as needed

                // Set up PagedDataSource
                PagedDataSource pds = new PagedDataSource
                {
                    DataSource = dataView,
                    AllowPaging = true,
                    PageSize = 5 // Number of rows per page
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

                // Calculate the globalCounter based on the current page index and page size
                globalCounter = pds.CurrentPageIndex * pds.PageSize;

                // Bind the Repeater with the PagedDataSource
                RepeaterItems.DataSource = pds;
                RepeaterItems.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Handle exceptions, log errors, etc.
                // Display an error message or perform any other action
            }
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
                    BindProductData();
                }
            }
        }

        private DataTable ViewProducts()
        {
            // Your SQL query to fetch data
            string query = @"
            SELECT 
    p.id AS productId,
    c.id AS categoryId,
    c.name AS categoryName,
    s.id AS subcategoryId,
    s.name AS subcategoryName,
    p.name AS productName,
    p.description AS Description,
    p.price AS Price,
    p.frameSize,
    p.frameWidth,
    p.frameDimensions,
    p.frameColor
FROM 
    products p
    INNER JOIN categories c ON p.categoryId = c.id
    INNER JOIN subcategories s ON p.subCategoryId = s.id
WHERE
    p.isDeleted = 0";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }

        protected void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            if (currentPage > 0)
            {
                ViewState["CurrentPage"] = currentPage - 1;
                BindProductData();
            }
        }

        protected void BtnViewImage_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton btnView)
            {
                string[] args = btnView.CommandArgument.Split(';');
                string productId = args[0];
                string productName = args[1];

                Session["productId"] = productId;
                Session["productName"] = productName;

                Response.Redirect("ViewImage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        protected void BtnNextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            int totalPages = Convert.ToInt32(ViewState["TotalPages"]);
            if (currentPage < totalPages - 1)
            {
                ViewState["CurrentPage"] = currentPage + 1;
                BindProductData();
            }
        }

        protected void AddProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton btnEdit)
            {
                string[] args = btnEdit.CommandArgument.Split(';');
                string itemId = args[0];
                string subCategoryId = args[1];
                string categoryId = args[2];
                string categoryName = args[3];
                string subCategoryName = args[4];

                Session["EditItemId"] = itemId;
                Session["EditSubCategoryId"] = subCategoryId;
                Session["EditCategoryId"] = categoryId;
                Session["EditCategoryName"] = categoryName;
                Session["EditSubCategoryName"] = subCategoryName;

                Response.Redirect("EditProduct.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton btnDelete)
            {
                string itemId = btnDelete.CommandArgument;

                Session["DeleteItemId"] = itemId;

                // Update isDeleted flag for all images associated with the product
                UpdateImagesIsDeleted(itemId);

                // Delete the product
                string query = "UPDATE products SET isDeleted = 1 WHERE id=" + itemId;
                DatabaseHelper.ExecuteNonQuery(query);

                Response.Redirect(Request.Url.AbsoluteUri, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        // Function to update isDeleted flag for all images associated with the product
        private void UpdateImagesIsDeleted(string productId)
        {
            string imageQuery = $"UPDATE image SET isDeleted = 1 WHERE productId = {productId}";
            DatabaseHelper.ExecuteNonQuery(imageQuery);
        }
    }
}