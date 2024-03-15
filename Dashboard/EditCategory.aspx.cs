using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EyeConic_Solution.Dashboard
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EditItemId"] == null)
                {
                    Response.Redirect("Categories.aspx");

                }
                else
                {
                    var editItemId = Session["EditItemId"].ToString();
                    string query = "SELECT name, description FROM categories WHERE id=" + editItemId;
                    DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                    if (dataTable.Rows.Count > 0)
                    {
                        string name = dataTable.Rows[0]["name"].ToString();
                        string description = dataTable.Rows[0]["description"].ToString();

                        txtName.Text = name;
                        txtDescription.Text = description;
                    }
                }

            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Name", "error");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowSweetAlert("Oops...", "Please enter Description", "error");
                return;
            }
            else
            {
                var editItemId = Session["EditItemId"].ToString();
                string editquery = "UPDATE categories SET name=@Name, description=@Description WHERE id=@EditItemId";

                Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@Name", txtName.Text },
        { "@Description", txtDescription.Text },
        { "@EditItemId", editItemId }
    };

                DatabaseHelper.ExecuteNonQueryParameterized(editquery, parameters);

                ShowSweetAlert("Updated", "Category Updated Successfully", "success");
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Clr();
        }
        private void Clr()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        protected void GoBackToCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
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