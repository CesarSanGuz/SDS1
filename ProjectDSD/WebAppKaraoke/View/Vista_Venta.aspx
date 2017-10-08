<%@ Page Title="" Language="C#" MasterPageFile="~/View/MrPageKaraoke.Master" AutoEventWireup="true" CodeBehind="Vista_Venta.aspx.cs" Inherits="WebAppKaraoke.View.Vista_Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:Table runat="server" HorizontalAlign="Left">
        <asp:TableRow>
            <asp:TableCell>
                <div style="float: left">
                    <telerik:RadButton RenderMode="Lightweight" ID="imgBtn3" OnClick="RadImageCocteles_Click" runat="server" Width="200px" Height="150px" Text="Download">
                        <Image ImageUrl="../fonts/cocteles.jpg"></Image>
                    </telerik:RadButton>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <div style="float: left">
                    <telerik:RadButton RenderMode="Lightweight" ID="imgBtn4" OnClick="RadImageEntradas_Click" runat="server" Width="200px" Height="150px" Text="Download">
                        <Image ImageUrl="../fonts/entradas.jpg"></Image>
                    </telerik:RadButton>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table runat="server" HorizontalAlign="Center" Width="50%">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblTipProdcuto" Text="Tipo Bebida"></telerik:RadLabel>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox RenderMode="Lightweight" runat="server" ID="cbxTipoProducto"
                    AutoPostBack="true" OnSelectedIndexChanged="RadComboBox1_SelectedIndexChanged"></telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblProducto" Text="Bebida"></telerik:RadLabel>
                </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox RenderMode="Lightweight" runat="server" ID="cbxProducto"></telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblCantidad" Text="Cantidad"></telerik:RadLabel>
                </asp:TableCell>
            <asp:TableCell>
                <telerik:RadNumericTextBox RenderMode="Lightweight" runat="server" ID="txtCantidad" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblMesa" Text="Mesa"></telerik:RadLabel>
                </asp:TableCell>
            <asp:TableCell>
                <telerik:RadNumericTextBox RenderMode="Lightweight" runat="server" ID="txtMesa" MinValue="1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="RadLabel1" Text="Precio Unit."></telerik:RadLabel>
                </asp:TableCell>
            <asp:TableCell>
                <telerik:RadNumericTextBox RenderMode="Lightweight" runat="server" ID="txtPreUnit" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblError" Text="" ForeColor="Red"></telerik:RadLabel>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadLabel RenderMode="Lightweight" runat="server" ID="lblExito" ForeColor="Green"></telerik:RadLabel>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell ColumnSpan="2">
                <telerik:RadButton RenderMode="Lightweight" runat="server" Text="Cancelar" OnClick="Cancelar_Click" Primary="false" BorderWidth="15" BorderColor="White"></telerik:RadButton>
                <telerik:RadButton RenderMode="Lightweight" runat="server" Text="Comprar" OnClick="Comprar_Click" Primary="true" BorderWidth="15" BorderColor="White"></telerik:RadButton>    
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
