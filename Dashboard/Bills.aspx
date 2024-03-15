<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="EyeConic_Solution.Dashboard.Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Bills</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display:none">Bill Id</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>State</th>
                                    <th>City</th>
                                    <th>Postal Code</th>
                                    <th>Country</th>
                                    <th style="display:none">UserId</th>
                                    <th>Total</th>
                                    <th>View Orders</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterItems"  OnItemDataBound="RepeaterItems_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" ID="lblSerialNo"></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial;display:none">
                                                <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("lastName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                            </td>
                                            <td style="width: 15%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("postalCode") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("country") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial; display:none">
                                                <asp:Label runat="server" Text='<%# Eval("userId") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("total") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:LinkButton runat="server" ID="ViewOrders" CommandArgument='<%# Eval("id") + ";" + Eval("userId")%> ' OnClick="BtnViewImage_Click">
                                                    <i class="mdi mdi-eye mdi-18px" style="margin:15px"></i>
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
