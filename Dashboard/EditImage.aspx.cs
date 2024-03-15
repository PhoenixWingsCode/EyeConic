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
    public partial class EditImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EditProductId"] == null || Session["EditProductName"] == null ||
                    Session["EditImageId"] == null || Session["EditImageName"] == null)
                {
                    Response.Redirect("ViewImage.aspx");
                }
                else
                {
                    txtProductId.Text = Session["EditProductId"].ToString();
                    txtProductName.Text = Session["EditProductName"].ToString();
                    txtImageId.Text = Session["EditImageId"].ToString();
                    txtImageName.Text = Session["EditImageName"].ToString();

                    PopulateImageDropDown();
                    SetImagePreview(txtProductName.Text, txtImageName.Text);
                }
            }
        }

        private void PopulateImageDropDown()
        {
            List<string> imageNames = GetImageNames();

            ddlImage.DataSource = imageNames;
            ddlImage.DataBind();
            ddlImage.Items.Insert(0, new ListItem("Select Image")); 
        }

        private List<string> GetImageNames()
        {
            string productName = txtProductName.Text;

            // You need to implement logic to fetch image names from your directory
            // This is a placeholder, replace it with your actual logic

            // Example: Get all JPG and PNG files from a directory using productName in the path
            string productImagePath = Server.MapPath($"~/assets/product-images/{productName}/");

            // Check if the directory exists
            if (Directory.Exists(productImagePath))
            {
                string[] imageFiles = Directory.GetFiles(productImagePath, "*.jpg")
                                                  .Union(Directory.GetFiles(productImagePath, "*.png"))
                                                  .ToArray();

                // Extract only the file names
                List<string> imageNames = imageFiles.Select(Path.GetFileName).ToList();

                return imageNames;
            }
            else
            {
                // Return an empty list if the directory doesn't exist
                return new List<string>();
            }
        }


        private void SetImagePreview(string productName,string ImageName)
        {
            imgPreview.ImageUrl = $"~/assets/product-images/{productName}/{ImageName}";
        }

        protected void DdlImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlImage.SelectedValue != "Select Image")
            {
                txtImageName.Text = ddlImage.SelectedItem.Text;

                SetImagePreview(txtProductName.Text, txtImageName.Text);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string query = "update image set imageName='" + txtImageName.Text + "' where imageId='" + txtImageId.Text + "' AND where isDeleted=0";
            DatabaseHelper.ExecuteNonQuery(query);

            ShowSweetAlert("Update", "Image Update Successfully", "success");
            Response.Redirect("ViewImage.aspx");
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
    }
}