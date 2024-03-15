    <%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="EyeConic_Solution.UserHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Body Content-->
    <div id="page-content">

        <!--Home slider-->
        <div class="slideshow slideshow-wrapper pb-section">
            <div class="home-slideshow">
                <div class="slide">
                    <div class="blur-up lazyload">
                        <img class="blur-up lazyload" data-src="assets/images/slideshow-banners/eyeconic-banner1.jpg" src="assets/images/slideshow-banners/eyeconic-banner1.jpg" alt="Shop New Collection" title="Shop New Collection" />
                    </div>
                </div>
                <div class="slide">
                    <div class="blur-up lazyload">
                        <img class="blur-up lazyload" data-src="assets/images/slideshow-banners/eyeconic-banner2.jpg" src="assets/images/slideshow-banners/eyeconic-banner2.jpg" alt="More Color More Life" title="More Color More Life" />
                    </div>
                </div>
            </div>
        </div>
        <!--End Home slider-->

        <!--Small Banners-->
        <div class="section imgBanners">
            <div class="container">
                <div class="imgBnrOuter">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="section-header text-center">
                                <h2 class="h2 heading-font">New Collections</h2>
                                <p>Modern and classic designs to suit every style.</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 col-sm-6 col-md-6 col-lg-6 pr-0">
                            <div class="inner center">
                                <a href="UserHome.aspx">
                                    <img data-src="assets/images/collection/eyeconic-collection3.jpg" src="assets/images/collection/eyeconic-collection3.jpg" alt="" class="blur-up lazyload" />
                                </a>
                            </div>
                        </div>
                        <div class="col-12 col-sm-6 col-md-6 col-lg-6 pr-0">
                            <div class="inner center">
                                <a href="UserHome.aspx">
                                    <img data-src="assets/images/collection/eyeconic-collection7.png" src="assets/images/collection/eyeconic-collection7.png" alt="" class="blur-up lazyload" />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--End Small Banners-->

        <!--Hot picks-->
        <div class="section">
            <div class="container">
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="section-header text-center">
                            <h2 class="h2 heading-font">Trendy Eyewear Picks</h2>
                            <p>Discover the latest eyewear styles for a fashionable look!</p>
                        </div>
                    </div>
                </div>
                <div class="productSlider-style2 grid-products">
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products1.jpg" src="assets/images/eyeconic-products/eyeconic-products1.jpg" alt="image" title="product">
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products1.jpg" src="assets/images/eyeconic-products/eyeconic-products1.jpg" alt="image" title="product">
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->
                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->
                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="UserHome.aspx">Black Full Rim Rounded</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹1500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products2.jpg" src="assets/images/eyeconic-products/eyeconic-products2.jpg" alt="image" title="product">
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products2.jpg" src="assets/images/eyeconic-products/eyeconic-products2.jpg" alt="image" title="product">
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->

                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->

                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="UserHome.aspx">Blue Transparent Full Rim Square</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹3500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products3.jpg" src="assets/images/eyeconic-products/eyeconic-products3.jpg" alt="image" title="product">
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products3.jpg" src="assets/images/eyeconic-products/eyeconic-products3.jpg" alt="image" title="product">
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->

                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->

                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="product-layout-1.html">Orange Transparent Full Rim Round</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹3500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products4.jpg" src="assets/images/eyeconic-products/eyeconic-products4.jpg" alt="image" title="product" />
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products4.jpg" src="assets/images/eyeconic-products/eyeconic-products4.jpg" alt="image" title="product" />
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->

                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->

                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="UserHome.aspx">Grey Transparent Full Rim Round</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹3500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products5.jpg" src="assets/images/eyeconic-products/eyeconic-products5.jpg" alt="image" title="product" />
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products5.jpg" src="assets/images/eyeconic-products/eyeconic-products5.jpg" alt="image" title="product" />
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->

                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->

                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="UserHome.aspx">Black Gunmetal Full Rim Round</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹3500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                    <div class="col-12 item">
                        <!-- start product image -->
                        <div class="product-image">
                            <!-- start product image -->
                            <a href="UserHome.aspx" class="grid-view-item__link">
                                <!-- image -->
                                <img class="primary blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products6.jpg" src="assets/images/eyeconic-products/eyeconic-products6.jpg" alt="image" title="product" />
                                <!-- End image -->
                                <!-- Hover image -->
                                <img class="hover blur-up lazyload" data-src="assets/images/eyeconic-products/eyeconic-products6.jpg" src="assets/images/eyeconic-products/eyeconic-products6.jpg" alt="image" title="product" />
                                <!-- End hover image -->
                            </a>
                            <!-- end product image -->

                            <!-- Start product button -->
                            <div class="button-set">
                                <a href="javascript:void(0)" title="Quick View" class="quick-view-popup quick-view" data-toggle="modal" data-target="#content_quickview">
                                    <i class="icon anm anm-search-plus-r"></i>
                                </a>
                                <div class="wishlist-btn">
                                    <a class="wishlist add-to-wishlist" href="UserHome.aspx">
                                        <i class="icon anm anm-heart-l"></i>
                                    </a>
                                </div>
                                <div class="compare-btn">
                                    <a class="compare add-to-compare" href="UserHome.aspx" title="Add to Compare">
                                        <i class="icon anm anm-random-r"></i>
                                    </a>
                                </div>
                            </div>
                            <!-- end product button -->
                        </div>
                        <!-- end product image -->

                        <!--start product details -->
                        <div class="product-details text-center">
                            <!-- product name -->
                            <div class="product-name">
                                <a href="UserHome.aspx">Blue Full Rim Round</a>
                            </div>
                            <!-- End product name -->
                            <!-- product price -->
                            <div class="product-price">
                                <span class="price">₹3500</span>
                            </div>
                            <!-- End product price -->
                        </div>
                        <!-- End product details -->
                    </div>
                </div>
            </div>
        </div>
        <!--End Hot picks-->

        <div class="section collection-box-style1">
            <div class="container">
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="section-header text-center">
                            <h2 class="h2">Eyewear collection for all</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid">
                <div class="row">
                    <div class="col-6 col-sm-4 col-md-4 col-lg-4">
                        <div class="collection-grid-item">
                            <a href="UserHome.aspx" class="collection-grid-item__link">
                                <img data-src="assets/images/collection/eyeconic-collection4.png" src="assets/images/collection/eyeconic-collection4.png" alt="Hot" class="blur-up lazyload" style="width:499px;height:625px" />
                            </a>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-4 col-lg-4">
                        <div class="collection-grid-item">
                            <a href="UserHome.aspx" class="collection-grid-item__link">
                                <img data-src="assets/images/collection/eyeconic-collection5.jpg" src="assets/images/collection/eyeconic-collection5.jpg" alt="Denim" class="blur-up lazyload" />
                            </a>
                        </div>
                    </div>
                    <div class="col-6 col-sm-4 col-md-4 col-lg-4">
                        <div class="collection-grid-item">
                            <a href="UserHome.aspx" class="collection-grid-item__link">
                                <img data-src="assets/images/collection/eyeconic-collection6.jpg" src="assets/images/collection/eyeconic-collection6.jpg" alt="Summer" class="blur-up lazyload" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--Store Feature-->
        <div class="store-feature section">
            <div class="container">
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                        <ul class="display-table store-info">
                            <li class="display-table-cell">
                                <i class="icon anm anm-truck-l"></i>
                                <h5>Experience Free Global Delivery</h5>
                                <span class="sub-text">Discover the brilliance in boundless shipping</span>
                            </li>
                            <li class="display-table-cell">
                                <i class="icon anm anm-money-bill-ar"></i>
                                <h5>Money Back Guarantee</h5>
                                <span class="sub-text">Guaranteed Refunds Available</span>
                            </li>
                            <li class="display-table-cell">
                                <i class="icon anm anm-comments-l"></i>
                                <h5>24/7 Help Center</h5>
                                <span class="sub-text">Always Here to Assist</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!--End Store Feature-->

        <!--Hero Banner With Text-->
        <div class="section hero hero--medium hero__overlay bg-size">
            <img class="bg-img" src="assets/images/parallax-banners/eyeconic-parallax.jpg" alt="" />
        </div>
        <!--End Hero Banner With Text-->

        <!-- Instagram Section-->
        <div class="section instagram-feed-section">
            <div class="container">
                <div class="section-header text-center">
                    <h2 class="h2 heading-font">EyeConic On Instagram</h2>
                    <p>Explore our stylish eyewear collection showcased through captivating Instagram moments.</p>
                </div>
                <!--Instagram ID-->
                <div id="instafeed" class="imlow_resolution"></div>
                <!--End Instagram ID-->
            </div>
        </div>
        <!--End Instagram Section-->

    </div>
    <!--End Body Content-->
</asp:Content>
