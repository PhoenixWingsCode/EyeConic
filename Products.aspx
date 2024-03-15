<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="EyeConic_Solution.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fw-bolder {
            font-weight: bolder;
            font-size: large;
            color: black;
            text-align: left
        }

        .size {
            color: grey;
            font-size: small;
        }

        .price {
            color: black;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <!--Collection Banner-->
        <div class="collection-header">
            <div class="collection-hero">
                <div class="collection-hero__image" style="height:500px">
                    <img class="blur-up lazyload" data-src="assets/images/medium-shot-people-with-glasses-posing-studio.jpg" src="assets/images/medium-shot-people-with-glasses-posing-studio.jpg" alt="Women" title="Women" />
                </div>
                <div class="collection-hero__title-wrapper">
                    <h1 class="collection-hero__title page-width">Kids<br />Eyewear Fashion</h1>
                </div>
            </div>
        </div>
        <!--End Collection Banner-->
        <br />
        <br />

        <div class="container">
            <div class="row">
                <!--Main Content-->
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 main-col">
                    <div class="productList">
                        <div class="grid-products grid--view-items">
                            <asp:Repeater ID="rptCards" runat="server" OnItemDataBound="rptCards_ItemDataBound" OnItemCommand="rptCards_ItemCommand">
                                <ItemTemplate>
                                    <%# Container.ItemIndex % 3 == 0 ? "<div class='row'>" : ""%>
                                    <div class="col-6 col-sm-6 col-md-4 col-lg-4 item">
                                        <div class="card h-100">
                                            <!-- start product image -->
                                            <div class="product-image" style="width: 100%; height: 250px">
                                                <!-- start product image -->
                                                <label>
                                                    <!-- image -->
                                                    <asp:Image ID="PrimaryImage" runat="server" CssClass="primary blur-up lazyload"
                                                        AlternateText="image"
                                                        Title="product"
                                                        Style="width: 90%; height: 250px" />
                                                    <!-- End image -->
                                                    <!-- Hover image -->
                                                    <asp:Image ID="HoverImage" runat="server" CssClass="hover blur-up lazyload"
                                                        AlternateText="image"
                                                        Title="product"
                                                        Style="width: 90%; height: 250px" />
                                                    <!-- End hover image -->
                                                </label>

                                                <!-- end product image -->

                                                <!-- Start product button -->

                                                <div class="button-set">
                                                    <span title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                                        <i class="icon anm anm-search-plus-r"></i>
                                                    </span>
                                                    <div class="wishlist-btn">
                                                        <span class="wishlist add-to-wishlist" title="Add to Wishlist">
                                                            <i class="icon anm anm-heart-l"></i>
                                                        </span>
                                                    </div>
                                                    <div class="compare-btn">
                                                        <span class="compare add-to-compare" title="Add to Compare">
                                                            <i class="icon anm anm-random-r"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                                <!-- end product button -->
                                            </div>
                                            <!-- end product image -->
                                            <!-- Product details-->
                                            <div class="card-body p-4">
                                                <div class="text-left">
                                                    <!-- Product name-->
                                                    <asp:Label runat="server" ID="ProductId" Style="display:none"></asp:Label>
                                                    <h4>
                                                        <span class="fw-bolder">
                                                            <asp:Label runat="server" ID="ProductName"></asp:Label>
                                                        </span>
                                                    </h4>
                                                    <span class="size">
                                                        <asp:Label runat="server" ID="ProductSize"></asp:Label>
                                                    </span><br />
                                                    <span class="price">
                                                        <asp:Label runat="server" ID="ProductPrice"></asp:Label>
                                                    </span>
                                                </div>
                                            </div>
                                            <!-- Product actions-->
                                            <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                                                <div class="text-center">
                                                    <asp:Button ID="BtnAddToCart" runat="server" CssClass="btn btn-outline-dark mt-auto" 
                                                        Text="View Details" OnClick="BtnAddToCart_Click" CommandArgument='<%# Eval("Id") %>'/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%# (Container.ItemIndex + 1) % 3 == 0 ? "</div>" : "" %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <!--End Main Content-->
            </div>
        </div>

    </div>
</asp:Content>
