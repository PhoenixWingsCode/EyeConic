<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="EyeConic_Solution.Dashboard.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">

        <div class="col-12 grid-margin">
            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="AddCategory" Style="width: 100%; font-size: large; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif" OnClick="AddCategory_Click">
                <i class="mdi justify-content-md-center mdi-18px mdi-plus" style="vertical-align: middle; margin-right: 5px;"></i>
                <span class="menu-title">Create New</span>
            </asp:LinkButton>
        </div>

        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Category</h4>
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th>Name</th>
                                    <th>Description</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterItems">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 10%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label></td>
                                            <td style="width: 15%">
                                                <asp:Label runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                                            <td style="width: 55%">
                                                <asp:Label  runat="server" Text='<%# Eval("Description") %>' BorderStyle="None"></asp:Label></td>
                                            <td style="width: 10%; text-align: left">
                                                <asp:LinkButton runat="server" ID="Edit" CommandArgument='<%# Eval("id") %>' 
                                                    style="align-items:center;justify-content:center" OnClick="BtnEdit_Click">
                                                        <i class="mdi mdi-pencil mdi-18px" style="margin:5px"></i> 
                                                </asp:LinkButton>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:LinkButton runat="server" ID="Delete" CommandArgument='<%# Eval("id") %>' OnClick="BtnDelete_Click">
                                                        <i class="mdi mdi-delete mdi-18px" style="margin:12px;color:orangered"></i> 
                                                </asp:LinkButton>
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
