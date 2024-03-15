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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStateAndCityData();
                BindStates();
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = ddlState.SelectedItem.Text;
            txtSelectedState.Text = selectedState;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string[]> stateData = serializer.Deserialize<Dictionary<string, string[]>>(hdnStateData.Value);

            if (stateData.ContainsKey(selectedState))
            {
                ddlCity.DataSource = stateData[selectedState];
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
            txtSelectedCity.Text = selectedCity;
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

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (Isformvalid())
            {
                string email = txtEmail.Text;
                int categoryId = GetCategoryIdByEmail(email);

                if (categoryId > 0)
                {
                    // Category already exists, show message
                    ShowSweetAlert("Oops...", "Users already exists", "error");
                }
                else
                {
                    string encryptPassword = PasswordUtility.EncryptPassword(txtPassword.Text);
                    string query = "insert into users(firstName,lastName,username,email,password,address,city,state,country,postal_code) values('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtUsername.Text + "','" + txtEmail.Text + "', '" + encryptPassword + "','" + txtAddress.Text + "','" + txtSelectedCity.Text + "','" + txtSelectedState.Text + "','" + txtCountry.Text + "','" + txtPostalCode.Text + "')";
                    DatabaseHelper.ExecuteNonQuery(query);
                    ShowSweetAlert("Good job!", "Registration successful. You can now sign in with your credentials!", "success");
                    Clr();

                    Response.Redirect("Login.aspx");
                }
            }
        }

        private bool Isformvalid()
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

            if (!IsPasswordValid(txtPassword.Text))
            {
                ShowSweetAlert("Oops...", "Password requirement not met", "error");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowSweetAlert("Oops...", "Password and confirm password do not match", "error");
                return false;
            }

            if (!IsValidPostalCode(txtPostalCode.Text))
            {
                ShowSweetAlert("Oops...", "Postal code must be a 6-digit number", "error");
                txtPostalCode.Focus();
                return true;
            }
            return true;
        }

        private bool IsNull()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter First Name", "error");
                txtFirstName.Focus();
                return true;
            }
            else if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Last Name", "error");
                txtLastName.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Username", "error");
                txtUsername.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Email", "error");
                txtEmail.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Password", "error");
                txtPassword.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Confirm Password", "error");
                txtConfirmPassword.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Address", "error");
                txtAddress.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(ddlState.SelectedValue = "Select State"))
            {
                ShowSweetAlert("Oops...", "Please select state", "error");
                ddlState.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(ddlCity.SelectedValue = "Select City"))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                ddlCity.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtSelectedState.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                ddlCity.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtSelectedCity.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                ddlCity.Focus();
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                ShowSweetAlert("Oops...", "Please select city", "error");
                txtPostalCode.Focus();
                return true;
            }

            return false;
        }

        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        private bool IsPasswordValid(string password)
        {
            // Password should have at least 1 capital alphabet, 1 small alphabet, 1 number, 1 special character, and be at least 8 characters.
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
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

        private void Clr()
        {
            //txtFullName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private int GetCategoryIdByEmail(string email)
        {
            string selectQuery = "SELECT id FROM users WHERE email = '" + email + "'";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(selectQuery);

            if (dataTable.Rows.Count > 0)
            {
                return Convert.ToInt32(dataTable.Rows[0]["id"]);
            }
            else
            {
                return 0;
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