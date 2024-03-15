using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string menCategory = "Men";

                int menCategoryId = GetCategoryId(menCategory);

                if (menCategoryId != -1)
                {
                    // Bind subcategories for Men category
                    BindSubcategories(menCategoryId);
                    Session["menCategoryId"] = menCategoryId;
                }

                string womenCategory = "Women";

                int womenCategoryId = GetWomenCategoryId(womenCategory);

                if (womenCategoryId != -1)
                {
                    // Bind subcategories for Men category
                    BindWomenSubcategories(womenCategoryId);
                    Session["womenCategoryId"] = womenCategoryId;
                }

                string kidsCategory = "Kids";

                int kidsCategoryId = GetKidsCategoryId(kidsCategory);

                if (kidsCategoryId != -1)
                {
                    // Bind subcategories for Men category
                    BindKidsSubcategories(kidsCategoryId);
                    Session["kidsCategoryId"] = kidsCategoryId;
                }

                LoadMenSubcategories();
                LoadWomenSubcategories();
                LoadKidsSubcategories();
            }
        }

        private int GetCategoryId(string menCategory)
        {
            if (!string.IsNullOrEmpty(menCategory))
            {
                string query = "SELECT id FROM categories WHERE name = '" + menCategory + "' AND isDeleted = 0";

                DataTable resultTable = DatabaseHelper.ExecuteQuery(query);

                if (resultTable.Rows.Count > 0)
                {
                    // Assuming "id" is an integer, you might want to handle conversion accordingly
                    int categoryId = Convert.ToInt32(resultTable.Rows[0]["id"]);
                    return categoryId;
                }
            }
            return -1; // Return a default value or handle appropriately
        }

        private int GetWomenCategoryId(string womenCategory)
        {
            if (!string.IsNullOrEmpty(womenCategory))
            {
                string query = "SELECT id FROM categories WHERE name = '" + womenCategory + "' AND isDeleted = 0";

                DataTable resultTable = DatabaseHelper.ExecuteQuery(query);

                if (resultTable.Rows.Count > 0)
                {
                    // Assuming "id" is an integer, you might want to handle conversion accordingly
                    int categoryId = Convert.ToInt32(resultTable.Rows[0]["id"]);
                    return categoryId;
                }
            }
            return -1; // Return a default value or handle appropriately
        }

        private int GetKidsCategoryId(string kidsCategory)
        {
            if (!string.IsNullOrEmpty(kidsCategory))
            {
                string query = "SELECT id FROM categories WHERE name = '" + kidsCategory + "' AND isDeleted = 0";

                DataTable resultTable = DatabaseHelper.ExecuteQuery(query);

                if (resultTable.Rows.Count > 0)
                {
                    // Assuming "id" is an integer, you might want to handle conversion accordingly
                    int categoryId = Convert.ToInt32(resultTable.Rows[0]["id"]);
                    return categoryId;
                }
            }
            return -1; // Return a default value or handle appropriately
        }

        private void BindSubcategories(int menCategoryId)
        {
            // Fetch subcategories for Men category
            string subcategoryQuery = "SELECT id AS MensubcategoryId, name AS Mensubcategory, description AS Mendescription FROM subcategories WHERE categoryId = " + menCategoryId + " AND isDeleted = 0";

            DataTable subcategoryTable = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            // Separate data into three DataView for ID, Name, and Description
            DataView idData = new DataView(subcategoryTable);
            DataView nameData = new DataView(subcategoryTable);
            DataView descriptionData = new DataView(subcategoryTable);

            // Set RowFilter for each DataView to filter based on the ID
            idData.RowFilter = "MensubcategoryId IS NOT NULL";
            nameData.RowFilter = "MensubcategoryId IS NOT NULL";
            descriptionData.RowFilter = "MensubcategoryId IS NOT NULL";

            // Bind subcategories to the repeaters
            rptSubcategoriesID.DataSource = idData;
            rptSubcategoriesID.DataBind();

            rptSubcategoriesName.DataSource = nameData;
            rptSubcategoriesName.DataBind();

            rptSubcategoriesDescription.DataSource = descriptionData;
            rptSubcategoriesDescription.DataBind();
        }

        private void BindWomenSubcategories(int womenCategoryId)
        {
            // Fetch subcategories for Men category
            string subcategoryQuery = "SELECT id AS WomensubcategoryId, name AS Womensubcategory, description AS Womendescription FROM subcategories WHERE categoryId = " + womenCategoryId + " AND isDeleted = 0";

            DataTable subcategoryTable = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            // Separate data into three DataView for ID, Name, and Description
            DataView idData = new DataView(subcategoryTable);
            DataView nameData = new DataView(subcategoryTable);
            DataView descriptionData = new DataView(subcategoryTable);

            // Set RowFilter for each DataView to filter based on the ID
            idData.RowFilter = "WomensubcategoryId IS NOT NULL";
            nameData.RowFilter = "WomensubcategoryId IS NOT NULL";
            descriptionData.RowFilter = "WomensubcategoryId IS NOT NULL";

            // Bind subcategories to the repeaters
            rptWomenSubcategoriesID.DataSource = idData;
            rptWomenSubcategoriesID.DataBind();

            rptWomenSubcategoriesName.DataSource = nameData;
            rptWomenSubcategoriesName.DataBind();

            rptWomenSubcategoriesDescription.DataSource = descriptionData;
            rptWomenSubcategoriesDescription.DataBind();
        }

        private void BindKidsSubcategories(int kidsCategoryId)
        {
            // Fetch subcategories for Men category
            string subcategoryQuery = "SELECT id AS KidsSubcategoryId, name AS KidsSubcategory, description AS KidsDescription FROM subcategories WHERE categoryId = " + kidsCategoryId + " AND isDeleted = 0";

            DataTable subcategoryTable = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            // Separate data into three DataView for ID, Name, and Description
            DataView idData = new DataView(subcategoryTable);
            DataView nameData = new DataView(subcategoryTable);
            DataView descriptionData = new DataView(subcategoryTable);

            // Set RowFilter for each DataView to filter based on the ID
            idData.RowFilter = "KidsSubcategoryId IS NOT NULL";
            nameData.RowFilter = "KidsSubcategoryId IS NOT NULL";
            descriptionData.RowFilter = "KidsSubcategoryId IS NOT NULL";

            // Bind subcategories to the repeaters
            rptKidsSubcategoriesID.DataSource = idData;
            rptKidsSubcategoriesID.DataBind();

            rptKidsSubcategoriesName.DataSource = nameData;
            rptKidsSubcategoriesName.DataBind();

            rptKidsSubcategoriesDescription.DataSource = descriptionData;
            rptKidsSubcategoriesDescription.DataBind();
        }

        protected void BtnLogout_Click1(object sender, EventArgs e)
        {
            // Remove cookies
            if (Request.Cookies["Email"] != null)
            {
                HttpCookie emailCookie = new HttpCookie("Email");
                emailCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(emailCookie);
            }

            if (Request.Cookies["Password"] != null)
            {
                HttpCookie passwordCookie = new HttpCookie("Password");
                passwordCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(passwordCookie);
            }

            // Clear session
            Session["Username"] = null;

            // Redirect to Home.aspx
            Response.Redirect("~/Home.aspx");
        }

        protected void rptSubcategoriesName_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string menSubCategoryName = values[0];
                    string menSubCategoryId = values[1];

                    // Store values in session
                    Session["menSubCategoryId"] = menSubCategoryId;
                    Session["menSubCategoryName"] = menSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int menCategoryId = Convert.ToInt32(Session["menCategoryId"]);
                    Session["menCategoryId"] = menCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void rptWomenSubcategoriesName_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string womenSubCategoryName = values[0];
                    string womenSubCategoryId = values[1];

                    // Store values in session
                    Session["womenSubCategoryId"] = womenSubCategoryId;
                    Session["womenSubCategoryName"] = womenSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int womenCategoryId = Convert.ToInt32(Session["womenCategoryId"]);
                    Session["womenCategoryId"] = womenCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void rptKidsSubcategoriesName_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string womenSubCategoryName = values[0];
                    string womenSubCategoryId = values[1];

                    // Store values in session
                    Session["kidsSubCategoryId"] = womenSubCategoryId;
                    Session["kidsSubCategoryName"] = womenSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int kidsCategoryId = Convert.ToInt32(Session["kidsCategoryId"]);
                    Session["kidsCategoryId"] = kidsCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void BtnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        private void LoadMenSubcategories()
        {
            // Fetch subcategories data from the database
            DataTable menSubcategories = FetchMenSubcategoriesFromDatabase();

            // Bind data to the repeater
            MenSubcategoriesRepeater.DataSource = menSubcategories;
            MenSubcategoriesRepeater.DataBind();
        }

        private DataTable FetchMenSubcategoriesFromDatabase()
        {
            // Fetch subcategories data from the database
            string menIdQuery = "SELECT id FROM categories WHERE name='Men' AND isDeleted = 0";
            string menId = DatabaseHelper.ExecuteQuery(menIdQuery).Rows[0]["id"].ToString();

            string subcategoryQuery = $"SELECT id AS menSubCategoryId, name AS menSubCategoryName, description AS menSubCategoryDescription FROM subcategories WHERE categoryId = {menId} AND isDeleted = 0";

            // Execute the query and get the data
            DataTable subcategories = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            return subcategories;
        }

        protected void MenSubcategoriesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string menSubCategoryName = values[0];
                    string menSubCategoryId = values[1];

                    // Store values in session
                    Session["menSubCategoryId"] = menSubCategoryId;
                    Session["menSubCategoryName"] = menSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int menCategoryId = Convert.ToInt32(Session["menCategoryId"]);
                    Session["menCategoryId"] = menCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        private void LoadWomenSubcategories()
        {
            // Fetch subcategories data from the database
            DataTable womenSubcategories = FetchWomenSubcategoriesFromDatabase();

            // Bind data to the repeater
            WomenSubcategoriesRepeater.DataSource = womenSubcategories;
            WomenSubcategoriesRepeater.DataBind();
        }

        private DataTable FetchWomenSubcategoriesFromDatabase()
        {
            // Fetch subcategories data from the database
            string womenIdQuery = "SELECT id FROM categories WHERE name='Women' AND isDeleted = 0";
            string womenId = DatabaseHelper.ExecuteQuery(womenIdQuery).Rows[0]["id"].ToString();

            string subcategoryQuery = $"SELECT id AS womenSubCategoryId, name AS womenSubCategoryName, description AS womenSubCategoryDescription FROM subcategories WHERE categoryId = {womenId} AND isDeleted = 0";

            // Execute the query and get the data
            DataTable subcategories = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            return subcategories;
        }

        protected void WomenSubcategoriesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string womenSubCategoryName = values[0];
                    string womenSubCategoryId = values[1];

                    // Store values in session
                    Session["womenSubCategoryId"] = womenSubCategoryId;
                    Session["womenSubCategoryName"] = womenSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int womenCategoryId = Convert.ToInt32(Session["womenCategoryId"]);
                    Session["womenCategoryId"] = womenCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        private void LoadKidsSubcategories()
        {
            // Fetch subcategories data from the database
            DataTable kidsSubcategories = FetchKidsSubcategoriesFromDatabase();

            // Bind data to the repeater
            KidsSubcategoriesRepeater.DataSource = kidsSubcategories;
            KidsSubcategoriesRepeater.DataBind();
        }

        private DataTable FetchKidsSubcategoriesFromDatabase()
        {
            // Fetch subcategories data from the database
            string kidsIdQuery = "SELECT id FROM categories WHERE name='Kids' AND isDeleted = 0";
            string kidsId = DatabaseHelper.ExecuteQuery(kidsIdQuery).Rows[0]["id"].ToString();

            string subcategoryQuery = $"SELECT id AS kidsSubCategoryId, name AS kidsSubCategoryName, description AS kidsSubCategoryDescription FROM subcategories WHERE categoryId = {kidsId} AND isDeleted = 0";

            // Execute the query and get the data
            DataTable subcategories = DatabaseHelper.ExecuteQuery(subcategoryQuery);

            return subcategories;
        }

        protected void KidsSubcategoriesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "CategoryClick")
            {
                string[] values = e.CommandArgument.ToString().Split(';');
                if (values.Length == 2)
                {
                    string kidsSubCategoryName = values[0];
                    string kidsSubCategoryId = values[1];

                    // Store values in session
                    Session["kidsSubCategoryId"] = kidsSubCategoryId;
                    Session["kidsSubCategoryName"] = kidsSubCategoryName;

                    // Retrieve and store menCategoryId from session
                    int kidsCategoryId = Convert.ToInt32(Session["kidsCategoryId"]);
                    Session["kidsCategoryId"] = kidsCategoryId;

                    Response.Redirect("Products.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}