<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dragons.aspx.cs" Inherits="job.Dragons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script> 
    </head>
    <body>
        <div class="container">
            <h2>Dragons</h2>
            <form class="form-horizontal" id="form1" runat="server">
<div class="form-group">

       <div class="col-sm-10"> 
                        <asp:GridView runat="server" ID="gvDragons" AutoGenerateColumns="false" CssClass="table table-hover table-striped" GridLines="None">
                            <Columns>

                                <asp:BoundField DataField="Dragon_name" HeaderText="Dragon Name" />
                                <asp:BoundField DataField="Dragon_color" HeaderText="Dragon Color" />
                                <asp:BoundField DataField="Dragon_location" HeaderText="Dragon Location" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" OnClick="edit" CommandArgument='<%# Eval("Dragon_Id") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" OnClick="Delete" CommandArgument='<%# Eval("Dragon_Id") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
           </div>
    <div class="form-group">
        <asp:Button ID="btn_addLocation" runat="server" Text="Add New Dragon" OnClick="btn_addLocation_Click" />
        </div>
            </form>
        </div>
    </body>
</html>
