<%@ Page Title="" Language="C#" MasterPageFile="~/View/MrPageKaraoke.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="WebAppKaraoke.View.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function keyPressed_textbox(sender, args) {
            debugger;
            if (13 == args.get_keyCode()) {

                /* never gets here for RadDatePicker's DateInput OnKeyPress event */
            }
        } 
</script>
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <span style="display: block;font: 100 30px 'Segoe UI', Arial, Helvetica, sans-serif;text-align: center;"><sub>Validar Stock</sub></span>
                <br />
                <br />
             </asp:TableCell>
        </asp:TableRow>
        
        <%--<asp:TableRow>
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblfecIni" Text="Fecha Inicio"></telerik:RadLabel>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="dpFecIni"></telerik:RadDatePicker>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblfecFin" Text="Fecha Fin"></telerik:RadLabel>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadDatePicker RenderMode="Lightweight" runat="server" ID="dpFecFin"></telerik:RadDatePicker>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <telerik:RadButton RenderMode="Lightweight" runat="server" Text="Buscar" OnClick="Filtrar_Click" Primary="true" BorderWidth="15" BorderColor="White"></telerik:RadButton>    
            </asp:TableCell>
        </asp:TableRow>--%>
    </asp:Table>
    <br />
    <asp:Table runat="server" HorizontalAlign="Center" Width="70%">
        <asp:TableRow>
            <asp:TableCell>
                <telerik:RadGrid Skin="Glow" ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0"
                        OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCreated="RadGrid1_ItemCreated"
                        MasterTableView-CommandItemSettings-ShowRefreshButton="false" OnItemDataBound="RadGrid1_ItemDataBound"
                        GridLines="None" Width="100%" PageSize="15" AllowMultiRowEdit="false">
                        <MasterTableView AutoGenerateColumns="false">
                            <CommandItemSettings ShowExportToExcelButton="true" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="TP" DataType="System.String" FilterControlAltText="Filter TP column"
                                    HeaderText="Tipo Producto" SortExpression="TP" UniqueName="TP" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="40%">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PR" DataType="System.String" FilterControlAltText="Filter PR column"
                                    HeaderText="Producto" SortExpression="PR" UniqueName="PR" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="40%">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CA" DataType="System.String" FilterControlAltText="Filter CA column"
                                    HeaderText="Cantidad" SortExpression="CA" UniqueName="CA" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="20%">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
