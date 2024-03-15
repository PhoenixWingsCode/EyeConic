<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="AddImages.aspx.cs" Inherits="EyeConic_Solution.Dashboard.Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Add Images</h4>
                    <div class="forms-sample">
                        <div class="form-group">
                            <label for="exampleInputName1">Product Name</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductName" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:label runat="server" for="exampleInputName1" Visible="false">Product ID</asp:label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductId" autocomplete="off" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ddlImage1">Image 1</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlImage1" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DDlImage1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlImage2">Image 2</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlImage2" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DDlImage2_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlImage3">Image 3</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlImage3" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DDlImage3_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlImage4">Image 4</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlImage4" AutoPostBack="true" Style="color: black" OnSelectedIndexChanged="DDlImage4_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlImage1">Image 1</label>
                                    <asp:Image runat="server" ID="imgPreview1" CssClass="img-preview" Width="200px" Height="200px" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlImage2">Image 2</label>
                                    <asp:Image runat="server" ID="imgPreview2" CssClass="img-preview" Width="200px" Height="200px" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlImage3">Image 3</label>
                                    <asp:Image runat="server" ID="imgPreview3" CssClass="img-preview" Width="200px" Height="200px" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlImage4">Image 4</label>
                                    <asp:Image runat="server" ID="imgPreview4" CssClass="img-preview" Width="200px" Height="200px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button runat="server" ID="BtnSubmit" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="BtnSubmit_Click" />
                    <asp:Button runat="server" ID="BtnCancel" Text="Cancel" CssClass="btn btn-light" OnClick="BtnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
