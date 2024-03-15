using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class Images : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Name"] == null)
                {
                    // Session is null, redirect back to AddProducts.aspx
                    Response.Redirect("AddProducts.aspx");
                }
                else
                {
                    // Session is not null, retrieve the product name
                    string productName = Session["Name"].ToString();
                    txtProductName.Text = productName;

                    // Retrieve product ID using the product name
                    int productId = GetProductIdByName(productName);

                    // Set the product ID in the txtProductId TextBox
                    txtProductId.Text = productId.ToString();

                    // Fetch image names and populate dropdown lists
                    PopulateImageDropdowns();
                }
            }
        }

        private int GetProductIdByName(string productName)
        {
            // You need to implement your database access logic here
            // Replace the following code with your actual database query

            string selectQuery = "SELECT id FROM Products WHERE name = @ProductName AND isDeleted = 0;";

            // Parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@ProductName", productName }
    };

            // Execute the query and get the result in a DataTable
            DataTable resultTable = DatabaseHelper.ExecuteQueryParameterized(selectQuery, parameters);

            // Check if any rows are returned
            if (resultTable.Rows.Count > 0)
            {
                // Extract and return the product ID from the first row
                return Convert.ToInt32(resultTable.Rows[0]["id"]);
            }

            // Return a default value (you may choose -1 or another appropriate default)
            return -1;
        }


        // Inside PopulateImageDropdowns
        private void PopulateImageDropdowns()
        {
            // Fetch image names with JPG or PNG extension
            List<string> imageNames = GetImageNames();

            // Set the data source for all dropdowns
            ddlImage1.DataSource = imageNames;
            ddlImage1.DataBind();

            // Set default value for ddlImage1
            ddlImage1.Items.Insert(0, new ListItem("Select Image1", "default-image.png"));
            imgPreview1.ImageUrl = $"~/assets/product-images/default-image.png";

            // Set data source for ddlImage2, excluding "Select Image1"
            ddlImage2.DataSource = imageNames.Except(new[] { "Select Image1" });
            ddlImage2.DataBind();

            // Set default value for ddlImage2
            ddlImage2.Items.Insert(0, new ListItem("Select Image2", "default-image.png"));
            imgPreview2.ImageUrl = $"~/assets/product-images/default-image.png";

            // Set data source for ddlImage3, excluding "Select Image1" and "Select Image2"
            ddlImage3.DataSource = imageNames.Except(new[] { "Select Image1", "Select Image2" });
            ddlImage3.DataBind();

            // Set default value for ddlImage3
            ddlImage3.Items.Insert(0, new ListItem("Select Image3", "default-image.png"));
            imgPreview3.ImageUrl = $"~/assets/product-images/default-image.png";

            // Set data source for ddlImage4, excluding "Select Image1", "Select Image2", and "Select Image3"
            ddlImage4.DataSource = imageNames.Except(new[] { "Select Image1", "Select Image2", "Select Image3" });
            ddlImage4.DataBind();

            // Set default value for ddlImage4
            ddlImage4.Items.Insert(0, new ListItem("Select Image4", "default-image.png"));
            imgPreview4.ImageUrl = $"~/assets/product-images/default-image.png";
        }



        private List<string> GetImageNames()
        {
            string productName = txtProductName.Text;

            // You need to implement logic to fetch image names from your directory
            // This is a placeholder, replace it with your actual logic

            // Example: Get all JPG and PNG files from a directory using productName in the path
            string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");
            string[] imageFiles = Directory.GetFiles(productImagePath, "*.jpg")
                                              .Union(Directory.GetFiles(productImagePath, "*.png"))
                                              .ToArray();

            // Extract only the file names
            List<string> imageNames = imageFiles.Select(Path.GetFileName).ToList();

            return imageNames;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Your existing code

                // Fetch selected image names from dropdowns
                string image1 = ddlImage1.SelectedValue;
                string image2 = ddlImage2.SelectedValue;
                string image3 = ddlImage3.SelectedValue;
                string image4 = ddlImage4.SelectedValue;
                int productId = Convert.ToInt32(txtProductId.Text);

                // Insert images into the Image table
                InsertImage(productId, image1);
                InsertImage(productId, image2);
                InsertImage(productId, image3);
                InsertImage(productId, image4);

                // Display success message or redirect to another page
                ShowSweetAlert("Success", "Product and images added successfully", "success");

                Response.Redirect("Products.aspx");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                ShowSweetAlert("Error", "An error occurred while adding the product", "error");
            }
        }

        protected void DDlImage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the method to set the image preview
            SetImagePreview1();
        }

        private void SetImagePreview1()
        {
            // Get the selected image name from ddlImage1
            string selectedImageName1 = ddlImage1.SelectedItem.Text;

            // Get the product name from txtProductName
            string productName = txtProductName.Text;

            // Check if the selected image is not "Select Image1"
            if (selectedImageName1 != "Select Image1")
            {
                // Construct the product image path
                string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");

                // Combine the path with the selected image name to get the full path
                string fullPath = Path.Combine(productImagePath, selectedImageName1);

                // Set the src attribute of imgPreview1
                imgPreview1.ImageUrl = File.Exists(fullPath) ? $"~/assets/product-images/{productName}/{selectedImageName1}" : "";
            }
            else
            {
                // Set default image URL if "Select Image1" is selected
                imgPreview1.ImageUrl = $"~/assets/product-images/default-image.png";
            }
        }

        protected void DDlImage2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImagePreview2();
        }

        private void SetImagePreview2()
        {
            // Get the selected image name from ddlImage1
            string selectedImageName2 = ddlImage2.SelectedItem.Text;

            // Get the product name from txtProductName
            string productName = txtProductName.Text;

            // Check if the selected image is not "Select Image1"
            if (selectedImageName2 != "Select Image2")
            {
                // Construct the product image path
                string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");

                // Combine the path with the selected image name to get the full path
                string fullPath = Path.Combine(productImagePath, selectedImageName2);

                // Set the src attribute of imgPreview1
                imgPreview2.ImageUrl = File.Exists(fullPath) ? $"~/assets/product-images/{productName}/{selectedImageName2}" : "";
            }
            else
            {
                // Set default image URL if "Select Image1" is selected
                imgPreview2.ImageUrl = $"~/assets/product-images/default-image.png";
            }
        }


        protected void DDlImage3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImagePreview3();
        }

        private void SetImagePreview3()
        {
            // Get the selected image name from ddlImage1
            string selectedImageName3 = ddlImage3.SelectedItem.Text;

            // Get the product name from txtProductName
            string productName = txtProductName.Text;

            // Check if the selected image is not "Select Image1"
            if (selectedImageName3 != "Select Image3")
            {
                // Construct the product image path
                string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");

                // Combine the path with the selected image name to get the full path
                string fullPath = Path.Combine(productImagePath, selectedImageName3);

                // Set the src attribute of imgPreview1
                imgPreview3.ImageUrl = File.Exists(fullPath) ? $"~/assets/product-images/{productName}/{selectedImageName3}" : "";
            }
            else
            {
                // Set default image URL if "Select Image1" is selected
                imgPreview3.ImageUrl = $"~/assets/product-images/default-image.png";
            }
        }

        protected void DDlImage4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImagePreview4();
        }

        private void SetImagePreview4()
        {
            // Get the selected image name from ddlImage1
            string selectedImageName4 = ddlImage4.SelectedItem.Text;

            // Get the product name from txtProductName
            string productName = txtProductName.Text;

            // Check if the selected image is not "Select Image1"
            if (selectedImageName4 != "Select Image4")
            {
                // Construct the product image path
                string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");

                // Combine the path with the selected image name to get the full path
                string fullPath = Path.Combine(productImagePath, selectedImageName4);

                // Set the src attribute of imgPreview1
                imgPreview4.ImageUrl = File.Exists(fullPath) ? $"~/assets/product-images/{productName}/{selectedImageName4}" : "";
            }
            else
            {
                // Set default image URL if "Select Image1" is selected
                imgPreview4.ImageUrl = $"~/assets/product-images/default-image.png";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void InsertImage(int productId, string imageName)
        {
            // You need to implement your database access logic here
            // Replace the following code with your actual database query

            string insertQuery = "INSERT INTO Image (productId, imageName) VALUES (@ProductId, @ImageName);";

            // Parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@ProductId", productId },
        { "@ImageName", imageName }
    };

            // Execute the insert query
            DatabaseHelper.ExecuteNonQueryParameterized(insertQuery, parameters);
        }

        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }
    }
}
