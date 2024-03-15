<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditSubCategory.aspx.cs" Inherits="EyeConic_Solution.Dashboard.EditSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Update Sub Category</h4>
                    <div class="forms-sample">
                        <div class="form-group">
                            <label for="ddlCategory">Category</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCategory" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName1" style="display:none">Category ID</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCategoryId" autocomplete="off" ReadOnly="true" Style="display:none"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName1">Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtName" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleTextarea1">Description</label>
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" autocomplete="off"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" ID="BtnSubmit" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="BtnSubmit_Click" />
                        <asp:Button runat="server" ID="BtnCancel" Text="Cancel" CssClass="btn btn-light" OnClick="BtnCancel_Click" />
                    </div>
                </div>
            </div>


        </div>

        <div class="col-12 grid-margin">
            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="GoBackToCategories" Style="width: 100%; font-size: large; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif" OnClick="GoBackToCategories_Click">
                <i class="mdi justify-content-md-center mdi-18px mdi-arrow-left" style="vertical-align: middle; margin-right: 5px;"></i>
                <span class="menu-title">Go Back</span>
            </asp:LinkButton>
        </div>
    </div>

</asp:Content>
