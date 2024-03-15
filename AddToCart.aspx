<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="EyeConic_Solution.AddToCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide {
            display: none;
        }

        .priceColor {
            color: black;
        }
    </style>
    <script src="assets/js/sweetalert2.all.min.js"></script>
    <link href="assets/fontawesome-free-6.5.1-web/css/all.css" rel="stylesheet" />
    <link href="assets/fontawesome-free-6.5.1-web/css/all.min.css" rel="stylesheet" />
    <script src="assets/fontawesome-free-6.5.1-web/js/all.js"></script>
    <script src="assets/fontawesome-free-6.5.1-web/js/all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <div id="MainContent" class="main-content" role="main">

            <div id="ProductSection-product-template" class="product-template__container prstyle1 container">
                <!--product-single-->
                <div class="product-single">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12 col-12">
                            <div class="product-details-img">
                                <div class="product-thumb">
                                    <div id="gallery" class="product-dec-slider-2 product-tab-left">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="slick-slide slick-cloned" data-slick-index="-4" aria-hidden="true" TabIndex="-1" OnClick="LinkButton1_Click">
                                            <asp:Image ID="Image1" CssClass="blur-up lazyload" AlternateText="" runat="server" />
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="slick-slide slick-cloned" data-slick-index="-3" aria-hidden="true" TabIndex="-1" OnClick="LinkButton2_Click">
                                            <asp:Image ID="Image2" CssClass="blur-up lazyload" AlternateText="" runat="server" />
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="slick-slide slick-cloned" data-slick-index="-2" aria-hidden="true" TabIndex="-1" OnClick="LinkButton3_Click">
                                            <asp:Image ID="Image3" CssClass="blur-up lazyload" AlternateText="" runat="server" />
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="slick-slide slick-cloned" data-slick-index="-1" aria-hidden="true" TabIndex="-1" OnClick="LinkButton4_Click">
                                            <asp:Image ID="Image4" CssClass="blur-up lazyload" AlternateText="" runat="server" />
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div class="zoompro-wrap product-zoom-right pl-10">
                                    <div class="zoompro-span">
                                        <asp:Image ID="ZoomImage" runat="server" Height="450px" Width="700px" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-12">
                            <div class="product-single__meta">
                                <%--<asp:Label ID="LabelProductId" runat="server" Text="Product Id" CssClass="hide"></asp:Label><br />--%>
                                <asp:Label ID="LabelProductName" runat="server" CssClass="product-single__title" Text="Product Name"></asp:Label>

                                <div class="prInfoRow">
                                    <div class="product-stock"><span class="instock ">In Stock</span> <span class="outstock hide">Unavailable</span> </div>
                                    <div class="product-sku">SKU: <span class="variant-sku">19115-rdxs</span></div>
                                    <div class="product-review"><a class="reviewLink" href="#"><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-solid fa-star"></i><i class="fa-regular fa-star"></i><i class="fa-regular fa-star"></i><span class="spr-badge-caption">6 reviews</span></a></div>
                                </div>
                                <span class="product-price__price product-price__price-product-template product-price__sale product-price__sale--single">
                                    <asp:Label ID="LabelRupeeSymbol" runat="server" Text="₹" CssClass="priceColor"></asp:Label>
                                    <asp:Label runat="server" ID="txtPrice" CssClass="priceColor"></asp:Label>
                                </span>
                                <div class="product-single__description rte">
                                    <ul>
                                        <li>
                                            <label for="FrameSize">Frame Size :</label>
                                            <asp:Label ID="LabelFrameSize" runat="server" Text="Frame Size Value"></asp:Label></li>
                                        <li>
                                            <label for="FrameWidth">Frame Width :</label>
                                            <asp:Label ID="LabelFrameWidth" runat="server" Text="Frame Width Value"></asp:Label></li>
                                        <li>
                                            <label for="FrameDimensions">Frame Dimensions :</label>
                                            <asp:Label ID="LabelFrameDimensions" runat="server" Text="Frame Dimensions Value"></asp:Label></li>
                                        <li>
                                            <label for="FrameColor">Frame Color :</label>
                                            <asp:Label ID="LabelFrameColor" runat="server" Text="Frame Color Value"></asp:Label></li>
                                    </ul>
                                    <asp:Label ID="LabelDescription" runat="server" Text="Description of product"></asp:Label>
                                </div>
                                <div>
                                    <!-- Product Action -->
                                    <div class="product-action clearfix">
                                        <div class="product-form__item--quantity" style="margin-right: 20px">
                                            <asp:DropDownList ID="QuantityDropDown" runat="server" OnSelectedIndexChanged="QuantityDropDown_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="product-form__item--submit" style="margin-left: 5px">
                                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to cart" CssClass="btn product-form__cart-submit" OnClick="BtnAddToCart_Click" />
                                        </div>
                                        <br />
                                        <div class="shopify-payment-button" data-shopify="payment-button">
                                            <asp:Button ID="btnBuyNow" runat="server" Text="Buy it now" CssClass="shopify-payment-button__button shopify-payment-button__button--unbranded" />
                                        </div>
                                    </div>
                                    <!-- End Product Action -->
                                </div>
                                <div class="display-table shareRow">
                                    <div class="display-table-cell medium-up--one-third">
                                        <div class="wishlist-btn">
                                            <a class="wishlist add-to-wishlist" href="#" title="Add to Wishlist"><i class="icon anm anm-heart-l" aria-hidden="true"></i><span>Add to Wishlist</span></a>
                                        </div>
                                    </div>
                                    <div class="display-table-cell text-right">
                                        <div class="social-sharing">
                                            <a target="_blank" href="#" class="btn btn--small btn--secondary btn--share share-facebook" title="Share on Facebook">
                                                <i class="fa-brands fa-facebook-f" aria-hidden="true"></i><span class="share-title" aria-hidden="true"> Share</span>
                                            </a>
                                            <a target="_blank" href="#" class="btn btn--small btn--secondary btn--share share-twitter" title="Tweet on Twitter">
                                                <i class="fa-brands fa-x-twitter" aria-hidden="true"></i><span class="share-title" aria-hidden="true"> Tweet</span>
                                            </a>
                                            <a href="#" title="Share on google+" class="btn btn--small btn--secondary btn--share">
                                                <i class="fa-brands fa-google-plus-g" aria-hidden="true"></i><span class="share-title" aria-hidden="true"> Google+</span>
                                            </a>
                                            <a target="_blank" href="#" class="btn btn--small btn--secondary btn--share share-pinterest" title="Pin on Pinterest">
                                                <i class="fa-brands fa-pinterest-p" aria-hidden="true"></i><span class="share-title" aria-hidden="true"> Pin it</span>
                                            </a>
                                            <a href="#" class="btn btn--small btn--secondary btn--share share-pinterest" title="Share by Email" target="_blank">
                                                <i class="fa-solid fa-envelope" aria-hidden="true"></i><span class="share-title" aria-hidden="true"> Email</span>
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <p id="freeShipMsg" class="freeShipMsg" data-price="199"><i class="fa-solid fa-truck-fast" aria-hidden="true"></i> GETTING CLOSER! <b> FREE SHIPPING!</b></p>
                                <p class="shippingMsg"><i class="fa-solid fa-clock" aria-hidden="true"></i> ESTIMATED DELIVERY BETWEEN <b id="fromDate">Wed. May 1</b> and <b id="toDate">Tue. May 7</b>.</p>
                                <div class="userViewMsg" data-user="20" data-time="11000"><i class="fa-solid fa-users" aria-hidden="true"></i><strong class="uersView" style="margin-left:4px">14</strong> PEOPLE ARE LOOKING FOR THIS PRODUCT</div>
                            </div>
                        </div>
                    </div>
                    <!--End-product-single-->
                    <!--Product Fearure-->
                    <div class="prFeatures">
                        <div class="row">
                            <div class="col-12 col-sm-6 col-md-3 col-lg-3 feature">
                                <img src="assets/images/credit-card.png" alt="Safe Payment" title="Safe Payment" />
                                <div class="details">
                                    <h3>Safe Payment</h3>
                                    Pay with the world's most payment methods.
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-3 col-lg-3 feature">
                                <img src="assets/images/shield.png" alt="Confidence" title="Confidence" />
                                <div class="details">
                                    <h3>Confidence</h3>
                                    Protection covers your purchase and personal data.
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-3 col-lg-3 feature">
                                <img src="assets/images/worldwide.png" alt="Worldwide Delivery" title="Worldwide Delivery" />
                                <div class="details">
                                    <h3>Worldwide Delivery</h3>
                                    FREE &amp; fast shipping to over 200+ countries &amp; regions.
                                </div>
                            </div>
                            <div class="col-12 col-sm-6 col-md-3 col-lg-3 feature">
                                <img src="assets/images/phone-call.png" alt="Hotline" title="Hotline" />
                                <div class="details">
                                    <h3>Hotline</h3>
                                    Talk to help line for your question on 4141 456 789, 4125 666 888
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--End Product Fearure-->
                    <!--Product Tabs-->
                    <div class="tabs-listing">
                        <ul class="product-tabs">
                            <li rel="tab1"><a class="tablink">Product Details</a></li>
                            <li rel="tab2"><a class="tablink">Product Reviews</a></li>
                            <li rel="tab3"><a class="tablink">Shipping &amp; Returns</a></li>
                        </ul>
                        <div class="tab-container">
                            <div id="tab1" class="tab-content">
                                <div class="product-description rte">
                                    <p>Discover the perfect eyewear that combines style and functionality with EyeConic's wide range of products. Our eyewear collection is meticulously crafted to suit your unique taste and lifestyle.</p>
                                    <ul>
                                        <li>Explore our diverse selection of frames and lenses designed to meet your vision needs.</li>
                                        <li>Experience unparalleled comfort and durability with our premium-quality materials.</li>
                                        <li>Express your personal style with our trendy designs and classic silhouettes.</li>
                                        <li>Protect your eyes from harmful UV rays while looking effortlessly chic.</li>
                                        <li>Enjoy exceptional clarity and precision with our cutting-edge lens technology.</li>
                                    </ul>
                                    <h3>Elevate Your Look</h3>
                                    <p>Transform your appearance and boost your confidence with our stylish eyewear options. Whether you prefer sleek and sophisticated or bold and expressive, we have the perfect pair for every occasion.</p>
                                    <h3>Experience Superior Quality</h3>
                                    <p>At EyeConic, we are committed to providing you with eyewear that exceeds your expectations. Each pair is expertly crafted using the finest materials and innovative techniques to ensure maximum comfort and durability.</p>
                                    <h3>Find Your Perfect Fit</h3>
                                    <p>With a wide range of sizes, shapes, and styles to choose from, finding the perfect fit has never been easier. Our knowledgeable staff is here to help you select the ideal pair that complements your unique facial features and lifestyle.</p>
                                    <h3>Shop with Confidence</h3>
                                    <p>Enjoy a hassle-free shopping experience with our easy-to-navigate website and secure payment options. Plus, with our generous return policy and dedicated customer support team, you can shop with confidence knowing that your satisfaction is our top priority.</p>
                                    <h3>Discover EyeConic</h3>
                                    <p>Experience the difference with EyeConic eyewear. Shop now and elevate your eyewear game with the perfect blend of style, quality, and affordability.</p>
                                    <h3>Stay Fashionable</h3>
                                    <p>Stay ahead of the fashion curve with our latest eyewear trends and collections. Whether you're looking for timeless classics or contemporary designs, EyeConic has everything you need to stay stylish all year round.</p>
                                </div>
                            </div>

                            <div id="tab2" class="tab-content">
                                <div id="shopify-product-reviews">
                                    <div class="spr-container">
                                        <div class="spr-header clearfix">
                                            <div class="spr-summary">
                                                <span class="product-review"><a class="reviewLink"><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star-o"></i><i class="font-13 fa fa-star-o"></i></a><span class="spr-summary-actions-togglereviews">Based on 6 reviews456</span></span>
                                                <span class="spr-summary-actions">
                                                    <a href="#" class="spr-summary-actions-newreview btn">Write a review</a>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="spr-content">
                                            <div class="spr-form clearfix">
                                                <form method="post" action="#" id="new-review-form" class="new-review-form">
                                                    <h3 class="spr-form-title">Write a review</h3>
                                                    <fieldset class="spr-form-contact">
                                                        <div class="spr-form-contact-name">
                                                            <label class="spr-form-label" for="review_author_10508262282">Name</label>
                                                            <input class="spr-form-input spr-form-input-text " id="review_author_10508262282" type="text" name="review[author]" value="" placeholder="Enter your name">
                                                        </div>
                                                        <div class="spr-form-contact-email">
                                                            <label class="spr-form-label" for="review_email_10508262282">Email</label>
                                                            <input class="spr-form-input spr-form-input-email " id="review_email_10508262282" type="email" name="review[email]" value="" placeholder="john.smith@example.com">
                                                        </div>
                                                    </fieldset>
                                                    <fieldset class="spr-form-review">
                                                        <div class="spr-form-review-rating">
                                                            <label class="spr-form-label">Rating</label>
                                                            <div class="spr-form-input spr-starrating">
                                                                <div class="product-review"><a class="reviewLink" href="#"><i class="fa fa-star-o"></i><i class="font-13 fa fa-star-o"></i><i class="font-13 fa fa-star-o"></i><i class="font-13 fa fa-star-o"></i><i class="font-13 fa fa-star-o"></i></a></div>
                                                            </div>
                                                        </div>

                                                        <div class="spr-form-review-title">
                                                            <label class="spr-form-label" for="review_title_10508262282">Review Title</label>
                                                            <input class="spr-form-input spr-form-input-text " id="review_title_10508262282" type="text" name="review[title]" value="" placeholder="Give your review a title">
                                                        </div>

                                                        <div class="spr-form-review-body">
                                                            <label class="spr-form-label" for="review_body_10508262282">Body of Review <span class="spr-form-review-body-charactersremaining">(1500)</span></label>
                                                            <div class="spr-form-input">
                                                                <textarea class="spr-form-input spr-form-input-textarea " id="review_body_10508262282" data-product-id="10508262282" name="review[body]" rows="10" placeholder="Write your comments here"></textarea>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                    <fieldset class="spr-form-actions">
                                                        <input type="submit" class="spr-button spr-button-primary button button-primary btn btn-primary" value="Submit Review">
                                                    </fieldset>
                                                </form>
                                            </div>
                                            <div class="spr-reviews">
                                                <div class="spr-review">
                                                    <div class="spr-review-header">
                                                        <span class="product-review spr-starratings spr-review-header-starratings">
                                                            <span class="reviewLink"><i class="fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i></span>
                                                        </span>
                                                        <h3 class="spr-review-header-title">Exceptional Quality and Style!</h3>
                                                        <span class="spr-review-header-byline"><strong>User123</strong> on <strong>Jan 15, 2023</strong></span>
                                                    </div>
                                                    <div class="spr-review-content">
                                                        <p class="spr-review-content-body">I recently purchased a pair of glasses from EyeConic and I'm extremely satisfied with my purchase! The glasses are of exceptional quality and the style is perfect for my face shape. The frames are sturdy yet lightweight, providing all-day comfort. The lenses are crystal clear and offer excellent UV protection. I've received numerous compliments on my new eyewear and I couldn't be happier with my decision to buy from EyeConic.</p>
                                                    </div>
                                                </div>
                                                <div class="spr-review">
                                                    <div class="spr-review-header">
                                                        <span class="product-review spr-starratings spr-review-header-starratings">
                                                            <span class="reviewLink"><i class="fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i></span>
                                                        </span>
                                                        <h3 class="spr-review-header-title">Great Value for Money!</h3>
                                                        <span class="spr-review-header-byline"><strong>HappyCustomer456</strong> on <strong>Feb 28, 2023</strong></span>
                                                    </div>
                                                    <div class="spr-review-content">
                                                        <p class="spr-review-content-body">I've been a loyal customer of EyeConic for years and they never disappoint! Their eyewear offers great value for money without compromising on quality. The variety of styles available ensures that there's something for everyone. Plus, their customer service is exceptional - always friendly and helpful. I highly recommend EyeConic to anyone in search of stylish, affordable eyewear!</p>
                                                    </div>
                                                </div>
                                                <div class="spr-review">
                                                    <div class="spr-review-header">
                                                        <span class="product-review spr-starratings spr-review-header-starratings">
                                                            <span class="reviewLink"><i class="fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i><i class="font-13 fa fa-star"></i></span>
                                                        </span>
                                                        <h3 class="spr-review-header-title">Highly Recommend!</h3>
                                                        <span class="spr-review-header-byline"><strong>Fashionista789</strong> on <strong>Mar 10, 2023</strong></span>
                                                    </div>
                                                    <div class="spr-review-content">
                                                        <p class="spr-review-content-body">EyeConic is my go-to destination for all things eyewear! Their website is easy to navigate, making it a breeze to find the perfect pair of glasses. I've purchased multiple frames from them and have never been disappointed. The quality is top-notch and the prices are unbeatable. Plus, their shipping is fast and reliable. I highly recommend EyeConic to anyone looking for stylish and affordable eyewear!</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="tab3" class="tab-content">
                                <h3>Returns Policy</h3>
                                <p>At EyeConic, we want you to be completely satisfied with your purchase. If for any reason you are not happy with your order, we offer a hassle-free returns policy to ensure your peace of mind.</p>
                                <p>Our returns policy allows you to return any unused and undamaged items within 30 days of delivery for a full refund or exchange. Simply contact our customer service team to initiate the return process.</p>
                                <p>Please note that returned items must be in their original packaging and accompanied by proof of purchase. We reserve the right to refuse returns that do not meet these criteria.</p>
                                <p>Once your return is received and inspected, we will process your refund or exchange promptly. Refunds will be issued to the original payment method used for the purchase.</p>
                                <p>If you have any questions or concerns about our returns policy, feel free to contact us. We are here to assist you every step of the way!</p>

                                <h3>Shipping</h3>
                                <p>At EyeConic, we strive to provide fast and reliable shipping services to ensure your order arrives in a timely manner. We partner with trusted shipping carriers to deliver your eyewear safely to your doorstep.</p>
                                <p>Once your order is placed, our team works diligently to process and dispatch it as quickly as possible. You will receive a shipping confirmation email with tracking information once your order is on its way.</p>
                                <p>Standard shipping typically takes 3-5 business days for domestic orders and 7-14 business days for international orders. However, expedited shipping options are available for those who need their eyewear sooner.</p>
                                <p>We also offer free shipping on orders over a certain amount, making it even more convenient to shop with us. If you have any questions about shipping or need assistance with your order, don't hesitate to reach out to our customer service team.</p>
                            </div>
                        </div>
                    </div>
                    <!--End Product Tabs-->
                </div>
                <!--#ProductSection-product-template-->
            </div>
            <!--MainContent-->
        </div>
    </div>
</asp:Content>
