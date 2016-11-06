<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

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
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NUM_EDICAO" DataSourceID="SqlDataSource1" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="NUM_EDICAO" HeaderText="NUM_EDICAO" ReadOnly="True" SortExpression="NUM_EDICAO" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateInsertButton="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="NUM_EDICAO" DataSourceID="SqlDataSource1" DefaultMode="Insert" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
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
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EDITORA %>" 
            DeleteCommand="DELETE FROM [REVISTAS] WHERE [NUM_EDICAO] = @NUM_EDICAO" 
            InsertCommand="INSERT INTO [REVISTAS] ([NUM_EDICAO], [CAPA], [NIVEL]) VALUES (@NUM_EDICAO, @CAPA, @NIVEL)" 
            SelectCommand="SELECT [NUM_EDICAO], [CAPA], [NIVEL] FROM [REVISTAS] ORDER BY [NUM_EDICAO]" 
            UpdateCommand="UPDATE [REVISTAS] SET [CAPA] = @CAPA, [NIVEL] = @NIVEL WHERE [NUM_EDICAO] = @NUM_EDICAO">
            <DeleteParameters>
                <asp:Parameter Name="NUM_EDICAO" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="NUM_EDICAO" Type="Int32" />
                <asp:Parameter Name="CAPA" Type="String" />
                <asp:Parameter Name="NIVEL" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CAPA" Type="String" />
                <asp:Parameter Name="NIVEL" Type="Decimal" />
                <asp:Parameter Name="NUM_EDICAO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
