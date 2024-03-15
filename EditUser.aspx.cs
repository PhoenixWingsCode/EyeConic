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
    public partial class EditUser : System.Web.UI.Page
    {
        private string state;
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
                }
            }
        }

        private void GetUserDetails(string username)
        {
            string query = "select id,firstName,lastName,username,email,address,city,state,postal_code from users where username=@username";
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@username", username }
    };

            DataTable userDataTable = DatabaseHelper.ExecuteQueryParameterized(query, parameters);

            if (userDataTable.Rows.Count > 0)
            {
                string id = userDataTable.Rows[0]["id"].ToString();
                string firstName = userDataTable.Rows[0]["firstName"].ToString();
                string lastName = userDataTable.Rows[0]["lastName"].ToString();
                string email = userDataTable.Rows[0]["email"].ToString();
                string address = userDataTable.Rows[0]["address"].ToString();
                string city = userDataTable.Rows[0]["city"].ToString();
                string userState = userDataTable.Rows[0]["state"].ToString();
                string postal_code = userDataTable.Rows[0]["postal_code"].ToString();

                txtUserId.Text = id;
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtUsername.Text = username;
                txtEmail.Text = email; ;
                txtAddress.Text = address;
                txtSelectedState.Text = userState;
                txtSelectedCity.Text = city;
                txtPostalCode.Text = postal_code;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set a flag indicating that the dropdown has been clicked
            ViewState["StateDropdownClicked"] = true;
            txtSelectedState.Text = string.Empty;
            txtSelectedCity.Text = string.Empty;
            txtSelectedState.Text = ddlState.SelectedItem.Text;
            state = txtSelectedState.Text;
            SelectedStateLabel.Visible = false;
            SelectedCityLabel.Visible = false;
            txtSelectedState.Visible = false;
            txtSelectedCity.Visible = false;

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
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = ddlCity.SelectedItem.Text;

            // Update the selected city text
            txtSelectedCity.Text = selectedCity;
            txtSelectedState.Text = ddlState.SelectedItem.Text;
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

        private bool IsFormValid()
        {
            if (IsNull())
            {
                return false;
            }

            if (!IsEmailValid(email: txtEmail.Text))
            {
                ShowSweetAlert("Oops...", "Invalid email format", "error");
                return false;
            }

            if (!IsValidPostalCode(txtPostalCode.Text))
            {
                ShowSweetAlert("Oops...", "Postal code must be a 6-digit number", "error");
                txtPostalCode.Focus();
                return false;
            }
            return true;
        }

        private bool IsNull()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter First Name", "error");
                txtFirstName.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Last Name", "error");
                txtLastName.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Username", "error");
                txtUsername.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Email", "error");
                txtEmail.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Address", "error");
                txtAddress.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtSelectedState.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                ddlCity.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtSelectedCity.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                ddlCity.Focus();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                txtPostalCode.Focus();
                return false;
            }

            return true;
        }

        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        private bool IsValidPostalCode(string postalCode)
        {
            // Check if the postal code is not null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return false;
            }

            // Check if the postal code consists of exactly 6 digits
            if (postalCode.Length != 6)
            {
                return false;
            }

            // Check if the postal code contains only digits
            foreach (char c in postalCode)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // If all checks pass, the postal code is valid
            return true;
        }

        private void ShowSweetAlert(string title, string text, string type)
        {
            // Register the SweetAlert script for showing messages
            string script = $@"<script>
                                  Swal.fire('{title}', '{text}', '{type}');
                               </script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", script, false);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtUserId.Text);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string city = txtSelectedCity.Text;
            string state = txtSelectedState.Text;
            int postalCode = Convert.ToInt32(txtPostalCode.Text);

            string query = "update users set firstName=@firstName, lastName=@lastName, username=@username, email=@email, address=@address, city=@city, state=@state, postal_code=@postalCode where id=@id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@firstName", firstName },
        { "@lastName", lastName },
        { "@username", username },
        { "@email", email },
        { "@address", address },
        { "@city", city },
        { "@state", state },
        { "@postalCode", postalCode },
        { "@id", id }
    };

            DatabaseHelper.ExecuteNonQueryParameterized(query, parameters);

            ShowSweetAlert("Updated", "User details updated successfully", "success");

            Response.Redirect("UserHome.aspx");
        }
    }
}