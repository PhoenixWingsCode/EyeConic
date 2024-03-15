<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="ViewImage.aspx.cs" Inherits="EyeConic_Solution.Dashboard.ViewImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Images</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th style="width:20%;text-align:center">Sr.No.</th>
                                    <th style="width:10%;text-align:center;display:none">Product Id</th>
                                    <%--<th style="width:25%;text-align:center;">Product Name</th>--%>
                                    <th style="width:10%;text-align:center;display:none">Image Id</th>
                                    <th style="width:20%;text-align:center">Image Name</th>
                                    <th style="width:20%;text-align:center">Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterItems">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align:center;width:20%">
                                                <asp:Label runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                            </td>
                                            <td style="text-align:center; width:10%;display:none">
                                                <asp:Label runat="server" CssClass="form-control" ID="txtProductId" Text='<%# Eval("productId") %>' BorderStyle="None" Visible="false"></asp:Label>
                                            </td>
                                            <%--<td style="text-align:center; width:25%">
                                                <asp:Label runat="server" CssClass="form-control" ID="txtProductName" BorderStyle="None"></asp:Label>
                                            </td>--%>
                                            <td style="text-align:center; width:10%;display:none">
                                                <asp:Label runat="server" CssClass="form-control" ID="txtImageId" Text='<%# Eval("ImageId") %>' BorderStyle="None" Visible="false"></asp:Label>
                                            </td>
                                            <td style="text-align:center; width:20%">
                                                <asp:Label runat="server" CssClass="form-control" ID="txtImageName" Text='<%# Eval("ImageName") %>' BorderStyle="None"></asp:Label>
                                            </td>
                                            <td style="text-align:center; width:20%">
                                                <asp:LinkButton runat="server" ID="Edit" CommandArgument='<%# Eval("productId")  + ";" + Eval("productName") + ";" + Eval("ImageId") + ";" + Eval("ImageName")%>' OnClick="BtnEdit_Click">
                                                    <i class="mdi mdi-pencil mdi-18px" style="margin:5px"></i>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
