using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyeConic_Solution.Dashboard
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../Dashboard/Authenciation/Login.aspx");
            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            // Remove cookies
            if (Request.Cookies["Admin"] != null)
            {
                HttpCookie emailCookie = new HttpCookie("Admin");
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
            Session["Admin"] = null;

            // Redirect to Home.aspx
            string usersPagePath = Server.MapPath("../Dashboard/Authenciation/Login.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("../Dashboard/Authenciation/Login.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }

        protected void BtnCategories_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("Categories.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("Categories.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("Home.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("Home.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }

        protected void BtnSubCategories_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("SubCategories.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("SubCategories.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }

        protected void BtnProducts_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("products.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("products.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }
        protected void BtnUsers_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("Users.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("Users.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }

        protected void BtnBills_Click(object sender, EventArgs e)
        {
            string usersPagePath = Server.MapPath("Bills.aspx");
            if (System.IO.File.Exists(usersPagePath))
            {
                try
                {
                    // Redirect to Users.aspx page
                    Response.Redirect("Bills.aspx");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                // Users.aspx page not found, redirect to Error404.aspx
                Server.Transfer("Error404.aspx");
            }
        }
        private void HandleError(Exception ex)
        {
            if (ex is HttpException httpEx)
            {
                if (httpEx.GetHttpCode() == 404)
                {
                    // Page Not Found (404) - Redirect to custom error page
                    Server.Transfer("Error404.aspx");
                }
                else
                {
                    // Internal Server Error (500) - Redirect to custom error page
                    Server.Transfer("Error500.aspx");
                }
            }
            else
            {
                // Other exceptions - Redirect to custom error page
                Server.Transfer("Error500.aspx");
            }
        }
    }
}