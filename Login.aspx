<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EyeConic_Solution.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="assets/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript">
        var isFirstTimePasswordFocus = true;

        function showFirstTimePasswordAlert() {
            if (isFirstTimePasswordFocus) {
                Swal.fire('Password Requirements', 'Your password should have at least 1 capital letter, 1 small letter, 1 number, 1 special character, and be at least 8 characters long.', 'info');
                isFirstTimePasswordFocus = false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12 col-sm-12 col-md-6 col-lg-6 main-col offset-md-3">
                <div class="mb-4">
                    <div>
                        <div class="row">
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                                <div class="form-group">
                                    <label for="CustomerEmail">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br />
                                </div>
                            </div>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12">
                                <div class="form-group">
                                    <label for="CustomerPassword">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" onfocus="showFirstTimePasswordAlert()">
                                    </asp:TextBox>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="text-center col-12 col-sm-12 col-md-12 col-lg-12">
                                <asp:Button runat="server" Text="Sign in" CssClass="btn mb-3" OnClick="BtnSignIn_Click" ID="BtnSignIn"></asp:Button>
                                <p class="mb-4">
                                    <a href="#" id="RecoverPassword">Forgot your password?</a> &nbsp; | &nbsp;
								    <a href="Register.aspx" id="customer_register_link">Create account</a>
                                </p>      
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
