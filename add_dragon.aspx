<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_dragon.aspx.cs" Inherits="job.add_dragon" %>

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
            <h2>Add New Dragon</h2>
            <form class="form-horizontal" id="form1" runat="server">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="email">Dragon Name:</label>
                    <div class="col-sm-10">                        
                        <asp:TextBox ID="txt_Name" class="form-control" placeholder="Enter Dragon Name" runat="server" required="true"></asp:TextBox>
                    </div>
                </div>



                <div class="form-group">
                    <label class="control-label col-sm-2" for="pwd">Dragon Color:</label>
                    <div class="col-sm-10">          
                        <asp:DropDownList ID="ddl_Colors" runat="server" class="form-control">
                            <asp:ListItem>Red</asp:ListItem>
                            <asp:ListItem>Green</asp:ListItem>
                            <asp:ListItem>Blue</asp:ListItem>
                            <asp:ListItem>Black</asp:ListItem>
                        </asp:DropDownList>

                        
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="pwd">Dragon Locations</label>
                    <div class="col-sm-10">          
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
   
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    &nbsp;</div>
                <div class="form-group">        
                    <div class="col-sm-offset-2 col-sm-10">
                        <button type="submit" class="btn btn-default">Submit</button>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </form>
        </div>
    </body>
</html>

