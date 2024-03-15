<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/Dashboard.Master" AutoEventWireup="true" CodeBehind="SubCategories.aspx.cs" Inherits="EyeConic_Solution.Dashboard.SubCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="col-12 grid-margin">
            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="AddSubCategory" Style="width: 100%; font-size: large; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif" OnClick="AddCategory_Click">
                <i class="mdi justify-content-md-center mdi-18px mdi-plus" style="vertical-align: middle; margin-right: 5px;"></i>
                <span class="menu-title">Create New</span>
            </asp:LinkButton>
        </div>

        <div class="col-12 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">View Sub Category</h4>
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th style="display:none">Category Id</th>
                                    <th>Category Name</th>
                                    <th>Name</th>
                                    <th>Description</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="RepeaterItems" OnItemDataBound="RepeaterItems_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 10%; text-align: initial">
                                                <asp:Label runat="server" ID="lblSerialNo"></asp:Label></td>
                                            <td style="width: 10%; text-align: initial;display:none">
                                                <asp:Label runat="server" Text='<%# Eval("categoryId") %>'></asp:Label></td>
                                            <td style="width: 15%; text-align: initial">
                                                <asp:Label runat="server" Text='<%# Eval("categoryName") %>'></asp:Label></td>
                                            <td style="width: 15%">
                                                <asp:Label runat="server" Text='<%# Eval("subcategoryName") %>'></asp:Label></td>
                                            <td style="width: 40%">
                                                <asp:Label TextMode="MultiLine" runat="server" Text='<%# Eval("Description") %>' BorderStyle="None"></asp:Label></td>
                                            <td style="width: 10%; text-align: left">
                                                <asp:LinkButton runat="server" ID="Edit" CommandArgument='<%# Eval("ID") + ";" + Eval("CategoryId") %>'
                                                    Style="align-items: center; justify-content: center" OnClick="BtnEdit_Click">
                                                    <i class="mdi mdi-pencil mdi-18px" style="margin:5px"></i> 
                                                </asp:LinkButton>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:LinkButton runat="server" ID="Delete" CommandArgument='<%# Eval("ID") + ";" + Eval("CategoryId") %>' OnClick="BtnDelete_Click">
                                                    <i class="mdi mdi-delete mdi-18px" style="margin:12px;color:orangered"></i> 
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater runat="server" ID="RepeaterPager" OnItemCommand="RepeaterPager_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="Page" CommandArgument='<%# Container.DataItem %>'
                                            Text='<%# Container.DataItem %>' CssClass='<%# Convert.ToInt32(Container.DataItem) == Convert.ToInt32(ViewState["CurrentPage"]) + 1 ? "active" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div class="d-flex justify-content-end">
                            <asp:LinkButton runat="server" ID="PreviousPage" OnClick="BtnPreviousPage_Click" Visible="true" CssClass="btn btn-primary ml-2">
                                <i class="mdi mdi-chevron-left mdi-24px" style="color:white;margin:-15px;"></i> 
                            </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="NextPage" Text="Next" OnClick="BtnNextPage_Click" Visible="true" CssClass="btn btn-primary ml-2">
                                <i class="mdi mdi-chevron-right mdi-24px" style="color:white;margin:-15px;"></i> 
                            </asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
