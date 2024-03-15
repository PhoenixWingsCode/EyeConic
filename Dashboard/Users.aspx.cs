using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class Users : System.Web.UI.Page
    {
        public int globalCounter { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindUserData();     
        }

        private void BindUserData()
        {
            try
            {
                DataTable viewUser = ViewUserData();

                RepeaterUserItems.DataSource = viewUser;
                RepeaterUserItems.DataBind();

                // Set up DataView
                DataView dataView = new DataView(viewUser);
                dataView.Sort = "id"; // Change the sort field as needed

                // Set up PagedDataSource
                PagedDataSource pds = new PagedDataSource
                {
                    DataSource = dataView,
                    AllowPaging = true,
                    PageSize = 2 // Number of rows per page
                };

                // Save the total number of pages in ViewState
                ViewState["TotalPages"] = pds.PageCount;

                // Set the current page index based on query parameter or ViewState
                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                {
                    int pageIndex = Convert.ToInt32(Request.QueryString["page"]) - 1;
                    pds.CurrentPageIndex = pageIndex;
                }
                else if (ViewState["CurrentPage"] != null)
                {
                    pds.CurrentPageIndex = Convert.ToInt32(ViewState["CurrentPage"]);
                }

                // Save the current page index in ViewState
                ViewState["CurrentPage"] = pds.CurrentPageIndex;

                // Calculate the globalCounter based on the current page index and page size
                globalCounter = pds.CurrentPageIndex * pds.PageSize;

                // Bind the Repeater with the PagedDataSource
                RepeaterUserItems.DataSource = pds;
                RepeaterUserItems.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Handle exceptions, log errors, etc.
                // Display an error message or perform any other action
            }
        }

        private DataTable ViewUserData()
        {
            string query = "select id,firstName,lastName,username,email,address,city,state,postal_code,country from users";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }

        protected void RepeaterUserItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Update the serial numbers to be continuous
                Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
                if (lblSerialNo != null)
                {
                    lblSerialNo.Text = (globalCounter + e.Item.ItemIndex + 1).ToString();
                }
            }
        }

        protected void RepeaterPager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int pageIndex = Convert.ToInt32(e.CommandArgument) - 1;
                int totalPages = Convert.ToInt32(ViewState["TotalPages"]);

                if (pageIndex >= 0 && pageIndex < totalPages)
                {
                    ViewState["CurrentPage"] = pageIndex;
                    BindUserData();
                }
            }
        }

        protected void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            if (currentPage > 0)
            {
                ViewState["CurrentPage"] = currentPage - 1;
                BindUserData();
            }
        }

        protected void BtnNextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            int totalPages = Convert.ToInt32(ViewState["TotalPages"]);
            if (currentPage < totalPages - 1)
            {
                ViewState["CurrentPage"] = currentPage + 1;
                BindUserData();
            }
        }
    }
}