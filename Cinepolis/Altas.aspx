<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Altas.aspx.cs" Inherits="Altas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .form-control {
            margin:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
  <div class="container">
    <div class="row">
        <div class="col-xs-12">
            <asp:Image ImageUrl="~/content/img/sin-imagen-port.jpg" ID="imgFotoPort" runat="server" Style="width:800px; margin:auto" class="img-responsive img-rounded" /><br />
            <asp:FileUpload  runat="server" CssClass="form-control" ID="FuFotoPort" Style="width:800px; margin:auto"/>
        </div>
    </div>
    <hr />  
    <div class ="row">
        <div class="col-xs-3">
            <asp:Image ImageUrl="~/content/img/sin-imagen-mini.png" ID="ImgFotoMini" runat="server" Style="margin:auto" class="img-responsive img-rounded" />
            <asp:FileUpload runat="server" ID="fuFotoMini" CssClass="form-control" />
        </div>
        <div class="col-xs-9">
            <div class="row">
                <div class="col-xs-4">
                    <asp:TextBox runat="server" ID="txtNomb" CssClass="form-control" placeholder="Nombre"/>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox runat="server" ID="txtProd" CssClass="form-control" placeholder="Productor"/>
                </div>
                <div class="col-xs-4">
                    <asp:CheckBox Text="&nbsp;&nbsp;Estatus" runat="server" ID="chkEsta" CssClass="form-control"/>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlClas" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Clasificacion" />                        
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlGenero" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Genero" />                        
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlAnio" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Año" />                        
                    </asp:DropDownList>
                </div>
                <div class="col-xs-12">
                    <asp:TextBox runat="server" ID="txtSino" CssClass="form-control" placeholder="Sinopsis" TextMode="MultiLine" Rows="5" />
                </div>
                <div class="col-xs-4">
                    <asp:Button Text="Actualizar" class="form-control btn-info" runat="server" ID="btnActualizar" ToolTip="Actualizar Pelicula" OnClick="btnActualizar_Click" />
                </div>
                 <div class="col-xs-4">
                    <asp:Button Text="Agregar"  CssClass="form-control btn-success" runat="server" ID="btnAgregar" ToolTip="Agregar Pelicula" OnClick="btnAgregar_Click"  />
                </div>
                <div class="col-xs-4">
                    <asp:Button Text="Borrar" CssClass="form-control btn-danger" runat="server" ID="btnBorrar" ToolTip="Borrar Pelicula" OnClick="btnBorrar_Click"  />
                </div>
            </div>
        </div>
    </div>
    
    <hr />
    <div class="row">
        <div>
            <asp:TextBox runat="server" ID="txtVideo" CssClass="form-control" placeholder="URL de video" AutoPostBack="True" OnTextChanged="txtVideo_TextChanged"/>
        </div>
        <div class="col-xs-12">
            <iframe src="https://www.youtube.com/embed/E5tBneF_fu0" runat="server" id="IfVideo" width="800" height="600" frameborder="0" allowfullscreen style="width:100%"></iframe> 
        </div>
    </div>
  </div>
    <asp:HiddenField runat="server" ID="hfFotoPort"/>
    <asp:HiddenField   runat="server" ID="hfFotoMini" />
</asp:Content>

