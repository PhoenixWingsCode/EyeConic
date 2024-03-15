<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="EyeConic_Solution.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <!--Page Title-->
        <div class="page section-header text-center">
            <div class="page-title">
                <div class="wrapper">
                    <h1 class="page-width">Shopping Cart</h1>
                </div>
            </div>
        </div>
        <!--End Page Title-->

        <div class="container">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 main-col">
                    <div class="alert alert-success text-uppercase" role="alert">
                        <i class="icon anm anm-truck-l icon-large"></i>&nbsp;<strong>Congratulations!</strong> You've got free shipping!
                    </div>
                    <div class="cart style2">
                        <table>
                            <thead class="cart__row cart__header">
                                <tr>
                                    <th colspan="2" class="text-center">Product</th>
                                    <th class="text-center">Price</th>
                                    <th class="text-center">Quantity</th>
                                    <th class="text-right">Total</th>
                                    <th class="action">&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="CartUpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:Repeater ID="CartRepeater" runat="server" OnItemDataBound="CartRepeater_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="cart__row border-bottom line1 cart-flex border-top">
                                                    <td class="cart__image-wrapper cart-flex-item" style="border-color: black; border: 1px">
                                                        <asp:Image ID="ProductImage" runat="server" CssClass="cart__image" />
                                                    </td>
                                                    <td class="cart__meta small--text-left cart-flex-item">
                                                        <div class="list-view-item__title">
                                                            <div>
                                                                <asp:Label ID="CartIdLabel" runat="server" Text="Cart ID: " CssClass="cart-label" style="display:none"></asp:Label>
                                                                <asp:Label ID="CartIdValueLabel" runat="server" Text='<%# Eval("CartID") %>' CssClass="cart-value" style="display:none"></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="ProductIdLabel" runat="server" Text="Product ID: " CssClass="cart-label" style="display:none"></asp:Label>
                                                                <asp:Label ID="ProductIdValueLabel" runat="server" Text='<%# Eval("ProductID") %>' CssClass="cart-value" style="display:none"></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="ProductNameLabel" runat="server" Text="Product Name: " CssClass="cart-label" style="display:none"></asp:Label>
                                                                <asp:Label ID="ProductNameValueLabel" runat="server" Text='<%# Eval("ProductName") %>' CssClass="cart-value"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="cart__meta-text">
                                                            <asp:Label ID="ImageNameLabel" runat="server" Text="Image Name:" CssClass="cart-label" style="display:none"></asp:Label>
                                                            <asp:Label ID="ImageNameValueLabel" runat="server" Text='<%# Eval("ImageName") %>' CssClass="cart-value" style="display:none"></asp:Label>
                                                            <asp:Label ID="FrameSizeLabel" runat="server" Text="Frame Size: " CssClass="cart-label" style="display:none"></asp:Label>
                                                            <asp:Label ID="FrameSizeValueLabel" runat="server" Text='<%# Eval("FrameSize") %>' CssClass="cart-value" style="display:none"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td class="cart__price-wrapper cart-flex-item">
                                                        <asp:Label ID="LabelRupeeSymbol" runat="server" Text="₹" CssClass="priceColor"></asp:Label>
                                                        <asp:Label ID="PriceLabel" runat="server" CssClass="money" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                                    </td>
                                                    <td class="cart__update-wrapper cart-flex-item text-right">
                                                        <div class="cart__qty text-center">
                                                            <div class="qtyField">
                                                                <asp:LinkButton runat="server" CssClass="qtyBtn minus" ID="MinusButton" OnClick="MinusButton_Click"><i class="icon icon-minus"></i></asp:LinkButton>
                                                                <triggers><asp:AsyncPostBackTrigger ControlID="MinusButton" EventName="Click" /></triggers>
                                                                <asp:TextBox runat="server" CssClass="cart__qty-input qty" ID="QtyTextBox" Text='<%# Eval("Quantity") %>' pattern="[0-9]*" MaxLength="2"></asp:TextBox>
                                                                <asp:LinkButton runat="server" CssClass="qtyBtn plus" ID="PlusButton" OnClick="PlusButton_Click"><i class="icon icon-plus"></i></asp:LinkButton>
                                                                <triggers><asp:AsyncPostBackTrigger ControlID="PlusButton" EventName="Click" /></triggers>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="text-right small--hide cart-price">
                                                        <asp:Label ID="Label1" runat="server" Text="₹" CssClass="priceColor"></asp:Label>
                                                        <asp:Label ID="totalPriceLabel" runat="server" CssClass="money" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                                    </td>
                                                    <td class="text-center small--hide">
                                                        <asp:LinkButton runat="server" ID="RemoveLinkButton" CssClass="btn btn--secondary cart__remove"
                                                            OnClick="RemoveLinkButton_Click" ToolTip="Remove item">
                                                                <i class="icon icon anm anm-times-l"></i>
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                        
                                        <asp:AsyncPostBackTrigger ControlID="PlusButton" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="3" class="text-left">
                                        <asp:Button ID="btnContinueShopping" runat="server" CssClass="btn btn-secondary btn--small cart-continue" Text="Continue shopping" OnClick="btnContinueShopping_Click" />
                                    </td>
                                    <td colspan="3" class="text-right">
                                        <asp:Button ID="btnClearCart" runat="server" CssClass="btn btn-secondary btn--small small--hide" Text="Clear Cart" OnClick="btnClearCart_Click" />
                                        <asp:Button ID="btnUpdateCart" runat="server" CssClass="btn btn-secondary btn--small cart-continue ml-2" Text="Update Cart" OnClick="btnUpdateCart_Click" />
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>


                <div class="container mt-4">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 mb-4">
                            <h5>Discount Codes</h5>
                            <form action="#" method="post">
                                <div class="form-group">
                                    <label for="address_zip">Enter your coupon code if you have one.</label>
                                    <input type="text" name="coupon">
                                </div>
                                <div class="actionRow">
                                    <div>
                                        <input type="button" class="btn btn-secondary btn--small" value="Apply Coupon">
                                    </div>
                                </div>
                            </form>
                        </div>

                        <div class="col-12 col-sm-12 col-md-8 col-lg-8 cart__footer">
                            <div class="solid-border">
                                <div class="row border-bottom pb-6">
                                    <span class="col-12 col-sm-6 cart__subtotal-title">Subtotal</span>
                                    <asp:Label runat="server" CssClass="col-12 col-sm-6 text-right">
                                        <span>₹</span>
                                        <asp:Label ID="SubtotalLabel" runat="server"></asp:Label>
                                    </asp:Label>
                                </div>
                                <div class="row border-bottom pb-2 pt-2">
                                    <span class="col-12 col-sm-6 cart__subtotal-title">Tax</span>
                                    <span class="col-12 col-sm-6 text-right">18% GST included</span>
                                </div>
                                <div class="row border-bottom pb-2 pt-2">
                                    <span class="col-12 col-sm-6 cart__subtotal-title">Shipping</span>
                                    <span class="col-12 col-sm-6 text-right">Free shipping</span>
                                </div>
                                <div class="row border-bottom pb-4 pt-4">
                                    <span class="col-12 col-sm-6 cart__subtotal-title"><strong>Grand Total</strong></span>
                                    <asp:Label runat="server" CssClass="col-12 col-sm-6 cart__subtotal-title cart__subtotal text-right">₹
                                    <asp:Label ID="GrandTotalLabel" runat="server"></asp:Label>
                                    </asp:Label>
                                </div>
                                <div class="cart__shipping">Shipping &amp; taxes calculated at checkout</div>
                                <asp:Button runat="server" ID="cartCheckout" CssClass="btn btn--small-wide checkout" Text="Proceed To Checkout" Enabled="true" OnClick="cartCheckout_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
