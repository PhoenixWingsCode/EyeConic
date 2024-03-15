using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        public int globalCounter { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrderData();

                DataTable viewBill = ViewBillData();

                RepeaterBillItems.DataSource = viewBill;
                RepeaterBillItems.DataBind();

                DataTable viewUser = ViewUserData();

                RepeaterUserItems.DataSource = viewUser;
                RepeaterUserItems.DataBind();
            }
        }

        private void BindOrderData()
        {
            try
            {
                DataTable viewOrders = ViewOrdersData();

                RepeaterOrderItems.DataSource = viewOrders;
                RepeaterOrderItems.DataBind();

                // Set up DataView
                DataView dataView = new DataView(viewOrders);
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
                RepeaterOrderItems.DataSource = pds;
                RepeaterOrderItems.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Handle exceptions, log errors, etc.
                // Display an error message or perform any other action
            }
        }

        protected void RepeaterOrderItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    BindOrderData();
                }
            }
        }
        private DataTable ViewOrdersData()
        {
            DataTable ordersData = new DataTable();
            string billId = Session["billId"].ToString();

            // Fetch orders data based on billId
            string query = "SELECT id, name, quantity, price, total FROM orders WHERE billId ="+billId;
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }

        protected void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            if (currentPage > 0)
            {
                ViewState["CurrentPage"] = currentPage - 1;
                BindOrderData();
            }
        }

        protected void BtnNextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(ViewState["CurrentPage"]);
            int totalPages = Convert.ToInt32(ViewState["TotalPages"]);
            if (currentPage < totalPages - 1)
            {
                ViewState["CurrentPage"] = currentPage + 1;
                BindOrderData();
            }
        }
        private DataTable ViewBillData()
        {
            string id = Session["billId"].ToString();
            string query = "select id,firstName,lastName,email,address,state,city,postalCode,country,total from bill where id=" + id; ;

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }

        private DataTable ViewUserData()
        {
            string id = Session["billUserId"].ToString();
            string query = "select id,firstName,lastName,username,email,address,city,state,postal_code,country from users where id=" + id;

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return dataTable;
        }
    }
}