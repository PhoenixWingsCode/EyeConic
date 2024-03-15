using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class ViewImage : System.Web.UI.Page
    {
        List<ImageData> imageDataList = new List<ImageData>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productId"] == null || Session["productName"] == null)
            {
                Response.Redirect("Products.aspx");
            }
            else
            {
                try
                {
                    var productId = Session["productId"].ToString();
                    var productName = Session["productName"].ToString();

                    // Use parameterized query to avoid SQL injection
                    string query = "SELECT imageId, productId, imageName FROM image WHERE productId = @productId";

                    // Parameters
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@productId", productId }
                    };

                    DataTable dataTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Clear the list before populating
                        string image1 = dataTable.Rows[0]["imageName"].ToString();
                        SetImagePreview1(productName, image1);

                        string image2 = dataTable.Rows[1]["imageName"].ToString();
                        SetImagePreview2(productName, image2);

                        string image3 = dataTable.Rows[2]["imageName"].ToString();
                        SetImagePreview3(productName,image3);

                        string image4 = dataTable.Rows[3]["imageName"].ToString();
                        SetImagePreview4(productName, image4);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string imageId = row["imageId"].ToString();
                            string imageName = row["imageName"].ToString();

                            imageDataList.Add(new ImageData
                            {
                                ProductId = productId,
                                ProductName = productName,
                                ImageId = imageId,
                                ImageName = imageName
                            });
                        }

                        // Bind the list to the Repeater
                        RepeaterItems.DataSource = imageDataList;
                        RepeaterItems.DataBind();

                        
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log errors, etc.
                    // Add logging or error message to understand issues during execution
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public class ImageData
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ImageId { get; set; }
            public string ImageName { get; set; }
        }

      

        private void SetImagePreview1(string productName, string ImageName)
        {
            if (productName == null || ImageName == null)
            {
                imgPreview1.ImageUrl = $"~/assets/product-images/default-image.png";
            }
            else
            {
                imgPreview1.ImageUrl = $"~/assets/product-images/{productName}/{ImageName}";
            }
        }

        private void SetImagePreview2(string productName, string ImageName)
        {
            if (productName == null || ImageName == null)
            {
                imgPreview2.ImageUrl = $"~/assets/product-images/default-image.png";
            }
            else
            {
                imgPreview2.ImageUrl = $"~/assets/product-images/{productName}/{ImageName}";
            }
        }

        private void SetImagePreview3(string productName, string ImageName)
        {
            if (productName == null || ImageName == null)
            {
                imgPreview3.ImageUrl = $"~/assets/product-images/default-image.png";
            }
            else
            {
                imgPreview3.ImageUrl = $"~/assets/product-images/{productName}/{ImageName}";
            }
        }

        private void SetImagePreview4(string productName, string ImageName)
        {
            if (productName == null || ImageName == null)
            {
                imgPreview4.ImageUrl = $"~/assets/product-images/default-image.png";
            }
            else
            {
                imgPreview4.ImageUrl = $"~/assets/product-images/{productName}/{ImageName}";
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton BtnEdit)
            {
                string[] args = BtnEdit.CommandArgument.Split(';');
                string productId = args[0];
                string productName = args[1];
                string imageId = args[2];
                string imageName = args[3];

                Session["EditProductId"] = productId;
                Session["EditProductName"] = productName;
                Session["EditImageId"] = imageId;
                Session["EditImageName"] = imageName;

                Response.Redirect("EditImage.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

    }
}