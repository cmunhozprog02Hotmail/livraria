﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="363px" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="NUM_EDICAO" HeaderText="NUM_EDICAO" SortExpression="NUM_EDICAO" />
                        <asp:BoundField DataField="CAPA" HeaderText="CAPA" SortExpression="CAPA" />
                        <asp:BoundField DataField="NIVEL" HeaderText="NIVEL" SortExpression="NIVEL" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateInsertButton="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="NUM_EDICAO" DefaultMode="Insert" ForeColor="#333333" GridLines="None" Height="50px" Width="125px" DataSourceID="ObjectDataSource1">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                    <EditRowStyle BackColor="#999999" />
                    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                    <Fields>
                        <asp:BoundField DataField="NUM_EDICAO" HeaderText="NUM_EDICAO" ReadOnly="True" SortExpression="NUM_EDICAO" />
                        <asp:BoundField DataField="CAPA" HeaderText="CAPA" SortExpression="CAPA" />
                        <asp:BoundField DataField="NIVEL" HeaderText="NIVEL" SortExpression="NIVEL" />
                    </Fields>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                </asp:DetailsView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Editora.Domain.Revista"
                     DeleteMethod="Delete" 
                     InsertMethod="Insert" 
                     SelectMethod="Select" 
                     TypeName="Editora.DataAccess.Repository"
                     UpdateMethod="Update"></asp:ObjectDataSource>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        
    </div>
    </form>
</body>
</html>
