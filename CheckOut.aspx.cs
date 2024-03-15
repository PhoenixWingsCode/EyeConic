using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

namespace EyeConic_Solution
{
    public partial class CheckOut : System.Web.UI.Page
    {
        private string state;
        private int globalCounter = 0;
        private bool IsOrderDataBound
        {
            get { return ViewState["OrderDataBound"] != null && (bool)ViewState["OrderDataBound"]; }
            set { ViewState["OrderDataBound"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string username = Session["Username"].ToString();

                    GetUserDetails(username);
                    ViewState["StateDropdownClicked"] = false;
                    LoadStateAndCityData();
                    BindStates();
                    BindOrderData(); // Call BindOrderData only on initial page load
                    CalculateSubtotalFromCart();
                    IsOrderDataBound = true; // Set the flag to true indicating data is bound
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // Store the value of IsOrderDataBound in a hidden field
            hfIsOrderDataBound.Value = IsOrderDataBound.ToString();
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            // Restore the value of IsOrderDataBound from the hidden field
            if (!IsPostBack && !string.IsNullOrEmpty(hfIsOrderDataBound.Value))
            {
                IsOrderDataBound = bool.Parse(hfIsOrderDataBound.Value);
            }
        }


        private void GetUserDetails(string username)
        {
            string query = "select firstName,lastName,email,address,city,state,postal_code from users where username=@username";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@username", username }
    };

            DataTable userDataTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (userDataTable.Rows.Count > 0)
            {
                string firstName = userDataTable.Rows[0]["firstName"].ToString();
                string lastName = userDataTable.Rows[0]["lastName"].ToString();
                string email = userDataTable.Rows[0]["email"].ToString();
                string address = userDataTable.Rows[0]["address"].ToString();
                string city = userDataTable.Rows[0]["city"].ToString();
                string userState = userDataTable.Rows[0]["state"].ToString();
                string postal_code = userDataTable.Rows[0]["postal_code"].ToString();

                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtEmail.Text = email;
                txtAddress.Text = address;
                txtCity.Text = city;
                txtState.Text = userState;
                txtPostalCode.Text = postal_code;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtState.Visible = false;
            txtCity.Visible = false;
            lblState.Visible = false;
            lblCity.Visible = false;
            // Set a flag indicating that the dropdown has been clicked
            ViewState["StateDropdownClicked"] = true;
            state = ddlState.SelectedItem.Text;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string[]> stateData = serializer.Deserialize<Dictionary<string, string[]>>(hdnStateData.Value);

            if (stateData.ContainsKey(state))
            {
                ddlCity.DataSource = stateData[state];
                ddlCity.DataBind();
            }
            else
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Insert(0, new ListItem("Select City", ""));
            }

            // Call ddlCity_SelectedIndexChanged to update the textboxes immediately
            ddlCity_SelectedIndexChanged(sender, e);
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the dropdown state has been clicked
            if (ViewState["StateDropdownClicked"] != null && (bool)ViewState["StateDropdownClicked"])
            {
                string selectedCity = ddlCity.SelectedItem.Text;
                string selectedState = ddlState.SelectedItem.Text;

                txtState.Text = selectedState;
                txtCity.Text = selectedCity;
            }
        }

        protected void LoadStateAndCityData()
        {
            Dictionary<string, string[]> stateData = new Dictionary<string, string[]>();
            stateData.Add("Select State", new string[] { "Select City" });
            stateData.Add("Andaman and Nicobar Islands", new string[] { "Select City", "Port Blair" });
            stateData.Add("Andhra Pradesh", new string[] { "Select City", "Anantapur", "Chittoor", "East Godavari", "Guntur", "Krishna", "Kurnool", "Nellore", "Prakasam", "Srikakulam", "Visakhapatnam", "Vizianagaram", "West Godavari", "Y.S.R. Kadapa" });
            stateData.Add("Arunachal Pradesh", new string[] { "Select City", "Itanagar", "Tawang", "Ziro", "Naharlagun" });
            stateData.Add("Assam", new string[] { "Select City", "Guwahati", "Dibrugarh", "Silchar", "Jorhat", "Nagaon", "Tinsukia" });
            stateData.Add("Bihar", new string[] { "Select City", "Patna", "Gaya", "Bhagalpur", "Muzaffarpur", "Purnia", "Darbhanga" });
            stateData.Add("Chandigarh", new string[] { "Select City", "Chandigarh" });
            stateData.Add("Chhattisgarh", new string[] { "Select City", "Raipur", "Bhilai", "Bilaspur", "Korba", "Durg", "Raigarh" });
            stateData.Add("Dadra and Nagar Haveli and Daman and Diu", new string[] { "Select City", "Daman", "Diu" });
            stateData.Add("Delhi", new string[] { "Select City", "New Delhi", "Delhi" });
            stateData.Add("Goa", new string[] { "Select City", "Panaji", "Margao", "Vasco da Gama" });
            stateData.Add("Gujarat", new string[] { "Select City", "Ahmedabad", "Surat", "Vadodara", "Rajkot", "Bhavnagar", "Jamnagar" });
            stateData.Add("Haryana", new string[] { "Select City", "Faridabad", "Gurgaon", "Panipat", "Ambala", "Yamunanagar", "Rohtak" });
            stateData.Add("Himachal Pradesh", new string[] { "Select City", "Shimla", "Mandi", "Solan", "Dharamshala", "Kullu", "Chamba" });
            stateData.Add("Jammu and Kashmir", new string[] { "Select City", "Srinagar", "Jammu", "Anantnag", "Baramulla", "Kathua", "Pulwama" });
            stateData.Add("Jharkhand", new string[] { "Select City", "Ranchi", "Jamshedpur", "Dhanbad", "Bokaro Steel City", "Deoghar", "Hazaribagh" });
            stateData.Add("Karnataka", new string[] { "Select City", "Bengaluru", "Mysuru", "Hubballi", "Mangaluru", "Belagavi", "Shivamogga" });
            stateData.Add("Kerala", new string[] { "Select City", "Thiruvananthapuram", "Kochi", "Kozhikode", "Thrissur", "Malappuram", "Kannur" });
            stateData.Add("Ladakh", new string[] { "Select City", "Leh", "Kargil" });
            stateData.Add("Lakshadweep", new string[] { "Select City", "Kavaratti" });
            stateData.Add("Madhya Pradesh", new string[] { "Select City", "Bhopal", "Indore", "Jabalpur", "Gwalior", "Ujjain", "Sagar" });
            stateData.Add("Maharashtra", new string[] { "Select City", "Mumbai", "Pune", "Nagpur", "Thane", "Nashik", "Aurangabad" });
            stateData.Add("Manipur", new string[] { "Select City", "Imphal", "Thoubal", "Kakching", "Ukhrul", "Churachandpur", "Senapati" });
            stateData.Add("Meghalaya", new string[] { "Select City", "Shillong", "Tura", "Jowai", "Nongpoh", "Nongstoin", "Williamnagar" });
            stateData.Add("Mizoram", new string[] { "Select City", "Aizawl", "Lunglei", "Saiha", "Champhai", "Kolasib", "Serchhip" });
            stateData.Add("Nagaland", new string[] { "Select City", "Kohima", "Dimapur", "Mokokchung", "Tuensang", "Wokha", "Zunheboto" });
            stateData.Add("Odisha", new string[] { "Select City", "Bhubaneswar", "Cuttack", "Rourkela", "Berhampur", "Sambalpur", "Puri" });
            stateData.Add("Puducherry", new string[] { "Select City", "Puducherry", "Karaikal", "Mahe", "Yanam" });
            stateData.Add("Punjab", new string[] { "Select City", "Ludhiana", "Amritsar", "Jalandhar", "Patiala", "Bathinda", "Hoshiarpur" });
            stateData.Add("Rajasthan", new string[] { "Select City", "Jaipur", "Jodhpur", "Kota", "Bikaner", "Ajmer", "Udaipur" });
            stateData.Add("Sikkim", new string[] { "Select City", "Gangtok", "Namchi", "Mangan", "Gyalshing", "Singtam", "Rangpo" });
            stateData.Add("Tamil Nadu", new string[] { "Select City", "Chennai", "Coimbatore", "Madurai", "Tiruchirappalli", "Salem", "Tiruppur" });
            stateData.Add("Telangana", new string[] { "Select City", "Hyderabad", "Warangal", "Nizamabad", "Karimnagar", "Ramagundam", "Khammam" });
            stateData.Add("Tripura", new string[] { "Select City", "Agartala", "Dharmanagar", "Udaipur", "Ambassa", "Kailasahar", "Belonia" });
            stateData.Add("Uttar Pradesh", new string[] { "Select City", "Lucknow", "Kanpur", "Ghaziabad", "Agra", "Varanasi", "Meerut" });
            stateData.Add("Uttarakhand", new string[] { "Select City", "Dehradun", "Haridwar", "Roorkee", "Haldwani", "Rudrapur", "Kashipur" });
            stateData.Add("West Bengal", new string[] { "Select City", "Kolkata", "Asansol", "Siliguri", "Durgapur", "Bardhaman", "Malda" });
            // Add other states and territories and their respective cities similarly...

            // Serialize state data to JSON
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            hdnStateData.Value = serializer.Serialize(stateData);
        }

        protected void BindStates()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string[]> stateData = serializer.Deserialize<Dictionary<string, string[]>>(hdnStateData.Value);
            ddlState.DataSource = stateData.Keys;
            ddlState.DataBind();
        }

        private void BindOrderData()
        {
            if (!IsPostBack)
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

                    string query = @"
    SELECT DISTINCT 
        c.id AS CartID, 
        c.productId AS ProductID, 
        p.name AS ProductName,
        p.price AS ProductPrice,
        p.frameSize,
        c.quantity,
        c.totalPrice AS Subtotal
    FROM 
        cart c
    INNER JOIN 
        products p ON c.productId = p.id
    WHERE 
        userId = " + userId + @"
    ORDER BY 
        c.id";



                    DataTable orderDataTable = DatabaseHelper.ExecuteQueryParameterized(query, new Dictionary<string, object>());

                    // Create a set to store unique CartIDs
                    HashSet<string> uniqueCartIDs = new HashSet<string>();

                    DataTable orderData = orderDataTable.Clone();

                    foreach (DataRow row in orderDataTable.Rows)
                    {
                        string CartID = row["CartID"].ToString();

                        // Check if the CartID is already in the set
                        if (!uniqueCartIDs.Contains(CartID))
                        {
                            DataRow[] existingRows = orderData.Select($"CartID = '{CartID}'");
                            if (existingRows.Length == 0)
                            {
                                // If the CartID does not exist in the set, add it to the set and import the row
                                uniqueCartIDs.Add(CartID);
                                orderData.ImportRow(row);
                            }
                        }
                    }

                    OrderRepeater.DataSource = orderData;
                    OrderRepeater.DataBind();

                }
            }
        }


        protected void OrderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!IsPostBack)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    // Find the labels within the repeater item and set their properties accordingly
                    Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
                    Label LabelCartId = (Label)e.Item.FindControl("LabelCartId");
                    Label LabelProductId = (Label)e.Item.FindControl("LabelProductId");
                    Label LabelProductName = (Label)e.Item.FindControl("LabelProductName");
                    Label LabelPrice = (Label)e.Item.FindControl("LabelPrice");
                    Label LabelSize = (Label)e.Item.FindControl("LabelSize");
                    Label LabelQty = (Label)e.Item.FindControl("LabelQty");
                    Label LabelSubtotal = (Label)e.Item.FindControl("LabelSubtotal");

                    DataRowView rowView = (DataRowView)e.Item.DataItem;

                    if (rowView != null)
                    {
                        // Set the text of each label to the corresponding data from the DataRowView
                        if (lblSerialNo != null)
                        {
                            lblSerialNo.Text = (globalCounter + e.Item.ItemIndex + 1).ToString();
                        }
                        LabelCartId.Text = rowView["CartID"].ToString(); // Assuming "CartID" is the column name in your query
                        LabelProductId.Text = rowView["ProductID"].ToString();
                        LabelProductName.Text = rowView["ProductName"].ToString();
                        LabelPrice.Text = rowView["ProductPrice"].ToString();
                        LabelSize.Text = rowView["frameSize"].ToString();
                        LabelQty.Text = rowView["quantity"].ToString();
                        LabelSubtotal.Text = rowView["Subtotal"].ToString();
                    }
                }
            }
        }

        private void CalculateSubtotalFromCart()
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
                decimal totalPriceSum = 0;

                try
                {
                    // Define the SQL query to retrieve the total price of each row in the cart
                    string query = "SELECT totalPrice FROM cart where userId="+userId;

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

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string id = GetUserId();

            InsertBillData(id);

            string email = txtEmail.Text;

            GetBillId(email);

            InsertOrderData();
        }

        private string GetUserId()
        {
            string userId = "";

            string username = Session["Username"].ToString();

            string query = "SELECT id FROM users WHERE username = @username";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@username", username }
    };

            DataTable userIdDataTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (userIdDataTable.Rows.Count > 0)
            {
                userId = userIdDataTable.Rows[0]["id"].ToString();
            }

            return userId;
        }

        private void InsertBillData(string id)
        {
            decimal sum = 0;
            if(sum == Convert.ToDecimal(SubtotalLabel.Text))
            {
                ShowSweetAlert("Error", "Please add products to cart", "error");
            }
            else
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                string state = txtState.Text;
                string city = txtCity.Text;
                int postalCode = Convert.ToInt32(txtPostalCode.Text);
                string country = txtCountry.Text;
                decimal total = Convert.ToDecimal(SubtotalLabel.Text);

                string query = "insert into bill(firstName,lastName,email,address,state,city,postalCode,country,userId,total) " +
                    "values(@firstName,@lastName,@email,@address,@state,@city,@postalCode,@country,@id,@total)";
                Dictionary<string, object> insertParameters = new Dictionary<string, object>
            {
                { "@firstName", firstName },
                { "@lastName", lastName },
                { "@email", email },
                { "@address", address },
                { "@state",state },
                { "@city", city },
                { "@postalCode",postalCode },
                { "@country", country},
                { "@id", id },
                { "@total", total }
            };

                DatabaseHelper.ExecuteNonQueryParameterized(query, insertParameters);
            }
        }

        private void GetBillId(string email)
        {
            string query = "select id from bill where email=@email";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@email", email }
    };

            DataTable billIdTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (billIdTable.Rows.Count > 0)
            {
                string billId = billIdTable.Rows[0]["id"].ToString();
                txtBillId.Text = billId;
            }
        }

        private void InsertOrderData()
        {
            foreach (RepeaterItem item in OrderRepeater.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label cartIdLabel = (Label)item.FindControl("LabelCartId");
                    Label LabelProductName = (Label)item.FindControl("LabelProductName");
                    Label LabelPrice = (Label)item.FindControl("LabelPrice");
                    Label LabelSize = (Label)item.FindControl("LabelSize");
                    Label LabelQty = (Label)item.FindControl("LabelQty");
                    Label LabelSubtotal = (Label)item.FindControl("LabelSubtotal");
                    if (cartIdLabel != null)
                    {
                        string cartId = cartIdLabel.Text;
                        string billId = txtBillId.Text;
                        string name = LabelProductName.Text;
                        string price = LabelPrice.Text;
                        string quantity = LabelQty.Text;
                        string total = LabelSubtotal.Text;

                        // Execute the insert query for each cart ID
                        string query = "INSERT INTO orders (name,price,quantity,total,cartId, billId) VALUES (@name,@price,@quantity,@total,@cartId, @billId)";
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@name", name },
                    { "@price", price },
                    { "@quantity", quantity },
                    { "@cartId", cartId },
                    { "@total", total },
                    { "@billId", billId }
                };

                        DatabaseHelper.ExecuteNonQueryParameterized(query, parameters);

                        ShowSweetAlert("Success", "Orders placed successfully", "success");
                    }
                }
            }
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