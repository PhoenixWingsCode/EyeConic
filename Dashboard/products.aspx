<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="EyeConic_Solution.Dashboard.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin">
            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="AddProducts" Style="width: 100%; font-size: large; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif" OnClick="AddProducts_Click">
                <i class="mdi justify-content-md-center mdi-18px mdi-plus" style="vertical-align: middle; margin-right: 5px;"></i>
                <span class="menu-title">Create New</span>
            </asp:LinkButton>
        </div>
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Products</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display: none">Category
                                        <br />
                                        Id</th>
                                    <th>Category
                                        <br />
                                        Name</th>
                                    <th style="display: none">Sub Category
                                        <br />
                                        Id</th>
                                    <th>Sub Category
                                        <br />
                                        Name</th>
                                    <th style="display: none">Product
                                        <br />
                                        Id</th>
                                    <th>Product
                                        <br />
                                        Name</th>
                                    <th>Description</th>
                                    <th>Price</th>
                                    <th>Frame
                                        <br />
                                        Size</th>
                                    <th>Frame
                                        <br />
                                        Width</th>
                                    <th>Frame
                                        <br />
                                        Dimensions</th>
                                    <th>Frame
                                        <br />
                                        Color</th>
                                    <th>View
                                        <br />
                                        Image</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterItems" OnItemDataBound="RepeaterItems_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" ID="lblSerialNo"></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial; display: none">
                                                <asp:Label runat="server" Text='<%# Eval("categoryId") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("categoryName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial; display: none">
                                                <asp:Label runat="server" Text='<%# Eval("subcategoryId") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("subcategoryName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial; display: none">
                                                <asp:Label runat="server" Text='<%# Eval("productId") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%; text-align: initial">
                                                <asp:Label TextMode="MultiLine" runat="server" Text='<%# Eval("Description") %>' BorderStyle="None"></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("FrameSize") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("FrameWidth") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("FrameDimensions") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("FrameColor") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:LinkButton runat="server" ID="ViewImage" CommandArgument='<%# Eval("productId") + ";" + Eval("productName")%> ' OnClick="BtnViewImage_Click">
                                                    <i class="mdi mdi-eye mdi-18px" style="margin:10px"></i>
                                                </asp:LinkButton>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:LinkButton runat="server" ID="Edit" CommandArgument='<%# Eval("productId")  + ";" + Eval("subcategoryId") + ";" + Eval("categoryId") + ";" + Eval("categoryName")  + ";" +  Eval("subcategoryName") %>' OnClick="BtnEdit_Click">
                                                    <i class="mdi mdi-pencil mdi-18px" style="margin:5px"></i>
                                                </asp:LinkButton>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:LinkButton runat="server" ID="Delete" CommandArgument='<%# Eval("productId") %>' OnClick="BtnDelete_Click">
                                                    <i class="mdi mdi-delete mdi-18px" style="margin:12px;color:orangered"></i>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <!-- Pagination controls -->
                        <asp:Repeater runat="server" ID="RepeaterPager" OnItemCommand="RepeaterPager_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandName="Page" CommandArgument='<%# Container.DataItem %>'
                                    Text='<%# Container.DataItem %>' CssClass='<%# Convert.ToInt32(Container.DataItem) == Convert.ToInt32(ViewState["CurrentPage"]) + 1 ? "active" : "" %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="d-flex justify-content-end">
                            <asp:LinkButton runat="server" ID="BtnPreviousPage" OnClick="BtnPreviousPage_Click" Visible="true" CssClass="btn btn-primary ml-2">
                                <i class="mdi mdi-chevron-left mdi-24px" style="color:white;margin:-15px;"></i> 
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="BtnNextPage" Text="Next" OnClick="BtnNextPage_Click" Visible="true" CssClass="btn btn-primary ml-2">
                                <i class="mdi mdi-chevron-right mdi-24px" style="color:white;margin:-15px;"></i> 
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
