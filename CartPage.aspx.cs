using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindCartData();
                CalculateSubtotalFromCart();
            }
        }



        private void BindCartData()
        {
            string username = Session["Username"].ToString();
            string userIdQuery = "select id from users where username=@Username";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@Username", username }
    };

            DataTable userIdDataTable = DatabaseHelper.ExecuteQueryParameterized(userIdQuery, parameters);

            int userId = Convert.ToInt32(userIdDataTable.Rows[0]["id"]);

            string query = @"
    SELECT DISTINCT 
        c.id AS CartID, 
        c.productId AS ProductID, 
        c.quantity, 
        c.totalPrice,
        p.name AS ProductName,
        p.price AS ProductPrice,
        p.frameSize,
        i.imageName AS imageName
    FROM 
        cart c
    INNER JOIN 
        products p ON c.productId = p.id
    INNER JOIN 
        image i ON p.id = i.productId
    WHERE 
        userId = " + userId + @"
    ORDER BY 
        c.id";

            //DataTable cartData = DatabaseHelper.ExecuteQueryParameterized(query, parameters);
            // Order by CartID to maintain order


            // Execute the query and get the DataTable
            DataTable cartData = DatabaseHelper.ExecuteQueryParameterized(query, new Dictionary<string, object>());

            // Create a new DataTable to store the grouped cart items
            DataTable groupedCartTable = cartData.Clone();


            // Iterate through each row of the cartData DataTable
            foreach (DataRow row in cartData.Rows)
            {
                // Check if the productId exists in the groupedCartTable
                string productId = row["ProductID"].ToString();
                DataRow[] existingRows = groupedCartTable.Select($"ProductID = '{productId}'");
                if (existingRows.Length == 0)
                {
                    // If the productId does not exist, import the row to groupedCartTable
                    groupedCartTable.ImportRow(row);
                }
                else
                {
                    // If the productId exists, update the totalPrice in the existing row
                    DataRow existingRow = existingRows[0];

                    existingRow["TotalPrice"] = Convert.ToDecimal(existingRow["TotalPrice"]);
                }
            }

            // Bind the DataTable to the Repeater
            CartRepeater.DataSource = groupedCartTable;
            CartRepeater.DataBind();
        }

        protected void CartRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Find the ProductImage control in the Repeater item
                Image productImage = (Image)e.Item.FindControl("ProductImage");

                if (productImage != null)
                {
                    // Get the data item bound to the current Repeater item
                    DataRowView rowView = (DataRowView)e.Item.DataItem;

                    if (rowView != null)
                    {
                        // Extract the product name and image name from the data item
                        string productName = rowView["ProductName"].ToString();
                        string imageName = rowView["imageName"].ToString();

                        // Construct the image path
                        string imagePath = $"~/assets/product-images/{productName}/{imageName}";

                        // Set the ImageUrl property of the ProductImage control
                        productImage.ImageUrl = imagePath;
                    }
                }

                Label totalPriceLabel = (Label)e.Item.FindControl("TotalPriceLabel");
                TextBox quantityTextBox = (TextBox)e.Item.FindControl("QtyTextBox");

                if (totalPriceLabel != null && quantityTextBox != null)
                {
                    // Get the data item bound to the current Repeater item
                    DataRowView rowView = (DataRowView)e.Item.DataItem;

                    if (rowView != null)
                    {
                        // Extract the quantity and total price from the data item
                        int quantity = Convert.ToInt32(rowView["quantity"]);
                        decimal totalPrice = Convert.ToDecimal(rowView["totalPrice"]);

                        // Set the initial total price in the label
                        totalPriceLabel.Text = totalPrice.ToString();

                        // Set the initial quantity in the text box
                        quantityTextBox.Text = quantity.ToString();
                    }
                }
            }
        }

        protected void MinusButton_Click(object sender, EventArgs e)
        {
            LinkButton minusButton = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)minusButton.NamingContainer;
            TextBox quantityTextBox = (TextBox)item.FindControl("QtyTextBox");



            int quantity = Convert.ToInt32(quantityTextBox.Text);
            if (quantity > 1)
            {
                quantity--;
                quantityTextBox.Text = quantity.ToString();
                UpdateTotalPrice(item, quantity);
            }
        }

        protected void PlusButton_Click(object sender, EventArgs e)
        {
            LinkButton plusButton = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)plusButton.NamingContainer;
            TextBox quantityTextBox = (TextBox)item.FindControl("QtyTextBox");

            int quantity = Convert.ToInt32(quantityTextBox.Text);
            if (quantity < 10) // Assuming the maximum quantity is 10
            {
                quantity++;
                quantityTextBox.Text = quantity.ToString();
                UpdateTotalPrice(item, quantity);
            }
        }

        private void UpdateTotalPrice(RepeaterItem item, int quantity)
        {
            Label totalPriceLabel = (Label)item.FindControl("TotalPriceLabel");
            decimal productPrice = GetProductPrice(item); // Replace this with your logic to get the product price
            decimal totalPrice = quantity * productPrice;
            totalPriceLabel.Text = totalPrice.ToString();

            // You can also update the quantity and total price in your database here
        }


        private decimal GetProductPrice(RepeaterItem item)
        {
            // Implement logic to fetch product price from the row data
            Label PriceLabel = (Label)item.FindControl("PriceLabel");
            return Convert.ToDecimal(PriceLabel.Text);
        }




        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            string userIdQuery = "select id from users where username=@Username";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@Username", username }
    };

            DataTable userIdDataTable = DatabaseHelper.ExecuteQueryParameterized(userIdQuery, parameters);

            if (userIdDataTable.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(userIdDataTable.Rows[0]["id"]);

                string deleteCartQuery = "delete from cart where userId=@userId";
                Dictionary<string, object> deleteParameters = new Dictionary<string, object>
        {
            { "@userId", userId }
        };

                DatabaseHelper.ExecuteNonQueryParameterized(deleteCartQuery, deleteParameters);
                ShowSweetAlert("Success", "Cart Cleared Successfully", "success");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                // Handle the case where no user with the given username is found
                ShowSweetAlert("Error", "User not found", "error");
            }
        }

        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in CartRepeater.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox quantityTextBox = (TextBox)item.FindControl("QtyTextBox");
                    Label totalPriceLabel = (Label)item.FindControl("TotalPriceLabel");

                    int quantity = Convert.ToInt32(quantityTextBox.Text);
                    decimal totalPrice = Convert.ToDecimal(totalPriceLabel.Text);

                    // Assuming you have a column named CartID to uniquely identify each cart item
                    Label CartIdValueLabel = (Label)item.FindControl("CartIdValueLabel");
                    int cartId = Convert.ToInt32(CartIdValueLabel.Text);

                    // Update the cart item in the database with the new quantity and total price
                    UpdateCartItem(cartId, quantity, totalPrice);
                }
            }

            // Optionally, you can rebind the cart data to reflect the changes in the UI
            BindCartData();

            // Optionally, show a success message to the user
            ShowSweetAlert("Success", "Cart Updated Successfully", "success");
        }

        private void UpdateCartItem(int cartId, int quantity, decimal totalPrice)
        {
            // Define your SQL update query to update the cart item
            string updateQuery = "UPDATE cart SET quantity = @Quantity, totalPrice = @TotalPrice WHERE id = @CartID";

            // Define the parameters for the update query
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@Quantity", quantity },
        { "@TotalPrice", totalPrice },
        { "@CartID", cartId }
    };

            // Execute the update query
            DatabaseHelper.ExecuteNonQueryParameterized(updateQuery, parameters);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            // Get the clicked LinkButton control
            LinkButton removeButton = (LinkButton)sender;

            // Get the RepeaterItem that contains the clicked LinkButton
            RepeaterItem item = (RepeaterItem)removeButton.NamingContainer;

            // Find the Label control in the RepeaterItem to retrieve the cart ID
            Label CartIdValueLabel = (Label)item.FindControl("CartIdValueLabel");

            // Retrieve the cart ID from the Label
            int cartId = Convert.ToInt32(CartIdValueLabel.Text); // Access Text property to get the value

            // Call a method to delete the cart item from the database based on the cart ID
            DeleteOrderCart(cartId);
            DeleteCartItem(cartId);

            // Rebind the cart data to reflect the changes in the UI
            BindCartData();

            // Optionally, show a success message to the user
            ShowSweetAlert("Success", "Item removed from cart", "success");
        }

        private void DeleteCartItem(int cartId)
        {
            // Define the SQL delete query to remove the cart item based on the cart ID
            string deleteQuery = "DELETE FROM cart WHERE id = @CartID";

            // Define the parameters for the delete query
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@CartID", cartId }
    };

            // Execute the delete query
            DatabaseHelper.ExecuteNonQueryParameterized(deleteQuery, parameters);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void DeleteOrderCart(int cartId)
        {
            string deleteQuery = "Delete from orders where cartId = @CartID";

            // Define the parameters for the delete query
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@CartID", cartId }
    };

            // Execute the delete query
            DatabaseHelper.ExecuteNonQueryParameterized(deleteQuery, parameters);
        }
        protected void cartCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
            // Proceed with the checkout process using the totalPriceSum
        }

        private void CalculateSubtotalFromCart()
        {
            string username = Session["Username"].ToString();
            string userIdQuery = "select id from users where username=@Username";
            decimal totalPriceSum = 0;

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@Username", username }
    };

            DataTable userIdDataTable = DatabaseHelper.ExecuteQueryParameterized(userIdQuery, parameters);

            if (userIdDataTable.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(userIdDataTable.Rows[0]["id"]);

                try
                {
                    // Define the SQL query to retrieve the total price of each row in the cart
                    string query = "SELECT totalPrice FROM cart where userId=" + userId;

                    // Execute the query to get the total price of each row
                    DataTable totalPriceData = DatabaseHelper.ExecuteQuery(query);

                    // Iterate through each row in the result set and calculate the sum
                    foreach (DataRow row in totalPriceData.Rows)
                    {
                        // Extract the total price from the current row and add it to the sum
                        decimal totalPrice = Convert.ToDecimal(row["totalPrice"]);
                        totalPriceSum += totalPrice;
                    }

                    SubtotalLabel.Text = totalPriceSum.ToString();
                    GrandTotalLabel.Text = totalPriceSum.ToString();


                    // Now totalPriceSum contains the sum of total prices of all rows in the cart
                    // You can use totalPriceSum as needed, such as for further processing or displaying to the user
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, such as database errors
                    // Optionally, display an error message to the user
                    //ShowSweetAlert("Error", "An error occurred while calculating the total price sum.", "error");
                }
            }
            // Initialize sum variable to store the total price sum
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