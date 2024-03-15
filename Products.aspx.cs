using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution
{
    public partial class Products : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["menCategoryId"] != null && Session["menSubCategoryId"] != null && Session["menSubCategoryName"] != null)
            {
                LoadProducts(Session["menCategoryId"].ToString(), Session["menSubCategoryId"].ToString());

                ClearSessionVariables("menCategoryId", "menSubCategoryId", "menSubCategoryName");
            }
            else if (Session["womenCategoryId"] != null && Session["womenSubCategoryId"] != null && Session["womenSubCategoryName"] != null)
            {
                LoadProducts(Session["womenCategoryId"].ToString(), Session["womenSubCategoryId"].ToString());

                ClearSessionVariables("womenCategoryId", "womenSubCategoryId", "womenSubCategoryName");
            }
            else if (Session["kidsCategoryId"] != null && Session["kidsSubCategoryId"] != null && Session["kidsSubCategoryName"] != null)
            {
                LoadProducts(Session["kidsCategoryId"].ToString(), Session["kidsSubCategoryId"].ToString());

                ClearSessionVariables("kidsCategoryId", "kidsSubCategoryId", "kidsSubCategoryName");
            }
            else
            {
               
            }
        }

        private void ClearSessionVariables(params string[] sessionKeys)
        {
            foreach (string key in sessionKeys)
            {
                Session.Remove(key);
            }
        }
        private void LoadProducts(string categoryId, string subCategoryId)
        {
            // Load products based on the provided category and subcategory
            List<Product> products = GetProductsByCategory(categoryId, subCategoryId);

            // Bind the product data to the repeater
            rptCards.DataSource = products;
            rptCards.DataBind();
        }

        private List<Product> GetProductsByCategory(string categoryId, string subCategoryId)
        {
            List<Product> products = new List<Product>();

            string query = @"
        SELECT 
    p.id, 
    p.name, 
    p.frameSize, 
    p.price, 
    MAX(CASE WHEN i.row_num = 1 THEN i.imageName END) AS ImageName1, 
    MAX(CASE WHEN i.row_num = 2 THEN i.imageName END) AS ImageName2
FROM products p
LEFT JOIN (
    SELECT 
        productId, 
        imageName, 
        ROW_NUMBER() OVER (PARTITION BY productId ORDER BY (SELECT NULL)) AS row_num
    FROM image
    WHERE isDeleted = 0
) i ON p.id = i.productId
WHERE p.categoryId = @CategoryId AND p.subCategoryId = @SubCategoryId AND p.isDeleted = 0
GROUP BY p.id, p.name, p.frameSize, p.price

    ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "CategoryId", categoryId },
        { "SubCategoryId", subCategoryId }
    };

            DataTable productData = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            foreach (DataRow row in productData.Rows)
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    Size = "Size : " + row["frameSize"].ToString(),
                    Price = Convert.ToDecimal(row["price"]),
                    ImagePaths = new List<string>
            {
                $"~/assets/product-images/{row["name"]}/{row["ImageName1"]}",
                $"~/assets/product-images/{row["name"]}/{row["ImageName2"]}"
            }
                };

                products.Add(product);
            }

            return products;
        }


        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Size { get; set; }
            public decimal Price { get; set; }
            public List<string> ImagePaths { get; set; }
        }

        protected void rptCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Retrieve the product data for the current item
                Product product = (Product)e.Item.DataItem;

                // Find controls within the repeater item
                Image primaryImage = (Image)e.Item.FindControl("PrimaryImage");
                Image hoverImage = (Image)e.Item.FindControl("HoverImage");
                Label productIdLabel = (Label)e.Item.FindControl("ProductId");
                Label productNameLabel = (Label)e.Item.FindControl("ProductName");
                Label productSizeLabel = (Label)e.Item.FindControl("ProductSize");
                Label productPriceLabel = (Label)e.Item.FindControl("ProductPrice");

                // Set properties of controls based on product data
                primaryImage.ImageUrl = product.ImagePaths[0];
                hoverImage.ImageUrl = product.ImagePaths[1];
                productIdLabel.Text = product.Id.ToString();
                productNameLabel.Text = product.Name;
                productSizeLabel.Text = product.Size;
                productPriceLabel.Text = product.Price.ToString("C");
            }
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string productId = btn.CommandArgument;

            Session["Id"] = productId;
            Response.Redirect("AddToCart.aspx");
        }

        protected void rptCards_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}