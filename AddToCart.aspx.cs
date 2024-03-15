using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution
{
    public partial class AddToCart : System.Web.UI.Page
    {
        private decimal OriginalProductPrice;
        private string userId;
        decimal newPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["Id"] == null)
                {
                    Response.Redirect("UserHome.aspx");
                }
                else
                {
                    string id = Session["Id"].ToString();

                    GetProductDetails(id);
                    GetImages(id);
                }
            }
        }

        private void GetProductDetails(string id)
        {
            string query = "select categoryId,subCategoryId,name,description,price,frameSize,frameWidth,frameDimensions,frameColor from products WHERE id = @id AND IsDeleted = 0";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@id", id }
    };
            DataTable productDetailsTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (productDetailsTable.Rows.Count > 0)
            {
                string name = productDetailsTable.Rows[0]["name"].ToString();
                string description = productDetailsTable.Rows[0]["description"].ToString();
                string price = productDetailsTable.Rows[0]["price"].ToString();
                string size = productDetailsTable.Rows[0]["frameSize"].ToString();
                string width = productDetailsTable.Rows[0]["frameWidth"].ToString();
                string dimensions = productDetailsTable.Rows[0]["frameDimensions"].ToString();
                string color = productDetailsTable.Rows[0]["frameColor"].ToString();

                //LabelProductId.Text = id;
                LabelProductName.Text = name;
                LabelDescription.Text = description;
                txtPrice.Text= price;
                LabelFrameSize.Text = size;
                LabelFrameWidth.Text = width;
                LabelFrameDimensions.Text = dimensions;
                LabelFrameColor.Text = color;
            }

        }

        private void GetImages(string productId)
        {
            string query = "select imageName from image WHERE productId = @productId AND IsDeleted = 0";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@productId", productId }
    };

            string productName = LabelProductName.Text;
            DataTable imageTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (imageTable.Rows.Count > 0)
            {
                string image1Name = imageTable.Rows[0]["imageName"].ToString();
                string image2Name = imageTable.Rows[1]["imageName"].ToString();
                string image3Name = imageTable.Rows[2]["imageName"].ToString();
                string image4Name = imageTable.Rows[3]["imageName"].ToString();

                Image1.ImageUrl = $"~/assets/product-images/{productName}/{image1Name}";
                Image2.ImageUrl = $"~/assets/product-images/{productName}/{image2Name}";
                Image3.ImageUrl = $"~/assets/product-images/{productName}/{image3Name}";
                Image4.ImageUrl = $"~/assets/product-images/{productName}/{image4Name}";

                LinkButton1.CommandArgument = image1Name;
                LinkButton2.CommandArgument = image2Name;
                LinkButton3.CommandArgument = image3Name;
                LinkButton4.CommandArgument = image4Name;

                ZoomImage.ImageUrl = $"~/assets/product-images/{productName}/{image1Name}";
            }
        }

        protected void SetZoomImage(string imageName)
        {
            string productName = LabelProductName.Text;
            ZoomImage.ImageUrl = $"~/assets/product-images/{productName}/{imageName}";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string imageName = ((LinkButton)sender).CommandArgument;
            SetZoomImage(imageName);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string imageName = ((LinkButton)sender).CommandArgument;
            SetZoomImage(imageName);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string imageName = ((LinkButton)sender).CommandArgument;
            SetZoomImage(imageName);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string imageName = ((LinkButton)sender).CommandArgument;
            SetZoomImage(imageName);
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();

            // Use parameterized query to prevent SQL injection
            string getUserIdQuery = "SELECT id FROM users WHERE username = @username";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@username", username }
    };

            // Execute the query
            DataTable userIdTable = DatabaseHelper.ExecuteQueryParameterized(getUserIdQuery, parameters);

            if (userIdTable.Rows.Count > 0)
            {
                // Retrieve the user ID from the DataTable
                userId = userIdTable.Rows[0]["id"].ToString();

                string productId = Session["Id"].ToString();
                string quantity = QuantityDropDown.SelectedValue.ToString();
                newPrice = Convert.ToDecimal(quantity) * Convert.ToDecimal(txtPrice.Text);
                string price = Convert.ToString(newPrice);

                if (IsCartExists(userId, productId))
                {
                    ShowSweetAlert("Error", "Cart Already Exists", "error");
                }
                else
                {
                    string insertQuery = "INSERT INTO cart(userId, productId, quantity, totalPrice) VALUES(@userId, @productId, @quantity, @price)";
                    Dictionary<string, object> insertParameters = new Dictionary<string, object>
            {
                { "@userId", userId },
                { "@productId", productId },
                { "@quantity", quantity },
                { "@price", price }
            };

                    // Execute the query to insert into the cart table
                    DatabaseHelper.ExecuteNonQueryParameterized(insertQuery, insertParameters);
                    ShowSweetAlert("Success", "Added to cart", "success");
                    Response.Redirect("CartPage.aspx");
                }
            }
            else
            {
                // Handle the case where the user ID is not found
                ShowSweetAlert("Error", "User ID not found", "error");
            }
        }


        private bool IsCartExists(string userId, string productId)
        {
            string query = "select * from cart where userId=@userId AND productId=@productId";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@userId", userId },
        {"@productId",productId }
    };
            DataTable cartTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if(cartTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }  

        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }

        protected void QuantityDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedQuantity = int.Parse(QuantityDropDown.SelectedValue);

            if (selectedQuantity == 1)
            {
                // If quantity is 1, set LabelPrice text to OriginalProductPrice
                txtPrice.Text = OriginalProductPrice.ToString();
            }
            else if (selectedQuantity >= 2 && selectedQuantity <= 10)
            {
                string id = Session["Id"].ToString();

                string getPriceQuery = "SELECT price FROM products WHERE id = @id AND IsDeleted = 0";
                Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@id", id }
    };
                DataTable dataTable = DatabaseHelper.ExecuteQueryParameterized(getPriceQuery, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    decimal price = Convert.ToDecimal(dataTable.Rows[0]["price"]); // Retrieve price from DataTable
                    newPrice = price * selectedQuantity;
                    //txtPrice.Text = newPrice.ToString();
                }
            }

            else
            {
                // Handle other cases, such as if selected quantity is not within expected range
                // You may display an error message or take other appropriate action
            }
        }


        protected void LabelPrice_DataBinding(object sender, EventArgs e)
        {

        }
    }
}