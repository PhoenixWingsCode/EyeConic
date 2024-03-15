<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="EyeConic_Solution.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row billing-fields">
            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 sm-margin-30px-bottom">
                <div class="create-ac-content bg-light-gray padding-20px-all">
                    <div runat="server">
                        <fieldset>
                            <h2 class="login-title mb-3">Billing details</h2>
                            <div class="row">
                                <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                    <label for="input-firstname">First Name <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                    <label for="input-lastname">Last Name <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12 col-lg-12 col-xl-12 required">
                                    <label for="input-email">E-Mail <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <div class="row">
                                <div class="form-group col-md-12 col-lg-12 col-xl-12 required">
                                    <label for="input-address-1">Address <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <asp:HiddenField ID="hdnStateData" runat="server" />
                            <asp:HiddenField ID="hdnCityData" runat="server" />
                            <asp:HiddenField ID="hfIsOrderDataBound" runat="server" />
                            <asp:ScriptManager runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                            <asp:Label ID="lblState" runat="server" Text="State *" CssClass="required-f">
                                            <%--<span class="required-f">*</span>--%>
                                            </asp:Label>
                                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                            <asp:Label ID="lblCity" runat="server" CssClass="required-f" Text="City *">
                                                <%--<span class="required-f">*</span>--%>
                                            </asp:Label>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                            <asp:Label runat="server" Text="Changed State/Union Territory" ID="LabelState"></asp:Label>
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                <asp:ListItem Text="Select State" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                            <asp:Label runat="server" Text="Changed City" ID="LabelCity"></asp:Label>
                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                <asp:ListItem Text="Select City" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlCity" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div class="row">
                                <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                    <label for="input-postcode">Post Code <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6 col-lg-6 col-xl-6 required">
                                    <label for="input-postcode">Country <span class="required-f">*</span></label>
                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Text="India" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>


                        </fieldset>
                    </div>

                </div>
            </div>

            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                <div class="your-order-payment">
                    <div class="your-order">
                        <h2 class="order-title mb-4">Your Order</h2>
                        <div class="row">
                            <div class="form-group col-md-12 col-lg-12 col-xl-12 required">
                                <asp:Label ID="lblBillId" runat="server" Text="Bill Id" Style="display:none"></asp:Label>
                                <asp:TextBox ID="txtBillId" runat="server" CssClass="form-control" Style="display:none"></asp:TextBox>

                            </div>
                        </div>
                        <div class="table-responsive-sm order-table">
                            <table class="bg-white table table-bordered table-hover text-center">
                                <thead>
                                    <tr>
                                        <th>Sr.No.</th>
                                        <th style="display: none">Cart Id</th>
                                        <th style="display: none">Product Id</th>
                                        <th>Product Name</th>
                                        <th>Price(₹)</th>
                                        <th>Size</th>
                                        <th>Qty</th>
                                        <th>Subtotal(₹)</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="OrderRepeater" runat="server" OnItemDataBound="OrderRepeater_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label runat="server" ID="lblSerialNo"></asp:Label>
                                                </td>
                                                <td style="display: none">
                                                    <asp:Label ID="LabelCartId" runat="server" Text='<%# Eval("CartID") %>'></asp:Label></td>
                                                <td style="display: none">
                                                    <asp:Label ID="LabelProductId" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="LabelProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="LabelPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="LabelSize" runat="server" Text='<%# Eval("frameSize") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="LabelQty" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="LabelSubtotal" runat="server" Text='<%# Eval("Subtotal") %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot class="font-weight-600">
                                    <tr>
                                        <td colspan="5" class="text-right">Total</td>
                                        <td>
                                            <asp:Label runat="server" CssClass="col-12 col-sm-6 text-right">₹
                                    <asp:Label ID="SubtotalLabel" runat="server"></asp:Label>
                                            </asp:Label></td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>

                    <hr />

                    <div class="your-payment">
                        <div class="payment-method">
                            <div class="order-button-payment">
                                <asp:Button ID="btnPlaceOrder" runat="server" Text="Place order" CssClass="btn" OnClick="btnPlaceOrder_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
