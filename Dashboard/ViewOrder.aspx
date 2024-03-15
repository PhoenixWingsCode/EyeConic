<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="EyeConic_Solution.Dashboard.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Order</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display:none">Id</th>
                                    <th>Name</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterOrderItems" OnItemDataBound="RepeaterOrderItems_ItemDataBound">
                                    <ItemTemplate>
                                        <tr style="align-items:center;justify-content:center">
                                            <td style="width: 25%; text-align: initial">
                                                <asp:Label runat="server" ID="lblSerialNo"></asp:Label>
                                            </td>
                                            <td style="width: 10%;display:none">
                                                <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 25%">
                                                <asp:Label runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label runat="server" Text='<%# Eval("quantity")%>'></asp:Label>
                                            </td>
                                            <td style="width: 30%">
                                                <asp:Label runat="server" Text='<%# Eval("total")%>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
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
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Bill</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display: none">Id</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>State</th>
                                    <th>City</th>
                                    <th>Postal Code</th>
                                    <th>Country</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterBillItems">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; display: none">
                                                <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("lastName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                            </td>
                                            <td style="width: 15%">
                                                <asp:Label runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("postalCode") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("country") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("total") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View User</h4>
                    <div class="table-responsive">
                        <table>
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display: none">Id</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Username</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>State</th>
                                    <th>City</th>
                                    <th>Postal Code</th>
                                    <th>Country</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterUserItems">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 5%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%; display: none">
                                                <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("lastName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("username") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                            </td>
                                            <td style="width: 15%">
                                                <asp:Label runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("postal_code") %>'></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:Label runat="server" Text='<%# Eval("country") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
