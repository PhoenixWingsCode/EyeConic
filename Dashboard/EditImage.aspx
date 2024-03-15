<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditImage.aspx.cs" Inherits="EyeConic_Solution.Dashboard.EditImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Update Image</h4>
                    <div class="forms-sample">
                        <div class="form-group">
                            <asp:label runat="server" for="exampleInputName1" Visible="false">Product Id</asp:label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductId" autocomplete="off" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName1">Product Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductName" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:label runat="server" for="exampleInputName1" Visible="false">Image Id</asp:label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtImageId" autocomplete="off" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputName1">Image Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtImageName" autocomplete="off" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ddlCategory">Select Image</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlImage" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DdlImage_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlImage1">Image</label>
                            <asp:Image runat="server" ID="imgPreview" CssClass="img-preview" Width="200px" Height="200px" />
                        </div>
                        <asp:Button runat="server" ID="BtnSubmit" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="BtnSubmit_Click" />
                        <asp:Button runat="server" ID="BtnCancel" Text="Cancel" CssClass="btn btn-light" OnClick="BtnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
