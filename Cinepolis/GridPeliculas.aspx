<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GridPeliculas.aspx.cs" Inherits="GridPeliculas" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-xs-6">   
            <h1>PRUEBA Uno</h1>
            <a href="content/img/civil-war.jpg">content</a>
            <h1>PRUEBA Dos</h1>
            <a href="content/img/xmen.jpg">content</a>
            <h1>PRUEBA Tres</h1>
            <a href="content/img/iron_man4 port.jpg">content</a>
<<<<<<< HEAD
             <h1>PRUEBA GUS DOS</h1>
            <a href="content/img/iron_man4 port.jpg">content</a>
             <h1>PRUEBA GUS TRES</h1>
=======
             <h1>PRUEBA GIT DOS</h1>
            <a href="content/img/iron_man4 port.jpg">content</a>
             <h1>PRUEBA GIT TRES</h1>
>>>>>>> origin/master
            <a href="content/img/iron_man4 port.jpg">content</a>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12" style="overflow: scroll; width:100%; height:500px">
            <asp:GridView runat="server" ID="gvPeliculas" CssClass="table table-responsive table-hover" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvPeliculas_RowCancelingEdit" OnRowDeleting="gvPeliculas_RowDeleting" OnRowEditing="gvPeliculas_RowEditing" OnRowUpdating="gvPeliculas_RowUpdating" DataKeyNames="id,clasificacionId,generoId,anio,fotomini,fotoport,video" PageSize="3" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvPeliculas_PageIndexChanging" OnSorting="gvPeliculas_Sorting">
                <Columns>
                    <asp:TemplateField HeaderText="[Nombre]" SortExpression="nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtNombre" placeholder="Nombre" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Sinopsis]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtSinopsis" runat="server" Text='<%# Bind("sinopsis") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ITlblSinopsis" runat="server" Text='<%# Bind("sinopsis") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtSinopsis" placeholder="Sinopsis" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Genero]">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="EITddlGenero" AppendDataBoundItems="true">
                                <asp:ListItem Text="Genero" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("genero.nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList runat="server" ID="FTddlGenero" AppendDataBoundItems="true">
                                <asp:ListItem Text="Genero" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Clasificación]">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="EITddlClasificacion" AppendDataBoundItems="true">
                                <asp:ListItem Text="Clasificacion" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("clas.nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList runat="server" ID="FTddlClasificacion" AppendDataBoundItems="true">
                                <asp:ListItem Text="Clasificacion" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Foto Mini]">
                        <EditItemTemplate>
                            <asp:FileUpload ID="EITfuFotoMini" runat="server"></asp:FileUpload>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Label5" runat="server" ImageUrl='<%# Bind("fotoMini") %>' Width="80px"></asp:Image>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload runat="server" ID="FTfuFotoMini" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Foto Port]">
                        <EditItemTemplate>
                            <asp:FileUpload ID="EITfuFotoPort" runat="server"></asp:FileUpload>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Label6" runat="server" ImageUrl='<%# Bind("fotoPort") %>' Width="150px"></asp:Image>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload runat="server" ID="FTfuFotoPort" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Año]">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="EITddlAnio" AppendDataBoundItems="true">
                                <asp:ListItem Text="Anio" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("anio") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList runat="server" ID="FTddlAnio">
                                <asp:ListItem Text="Año" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha Alta]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtAlta" runat="server" Text='<%# Bind("fechaAlta", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("fechaAlta", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox runat="server" ID="FTtxtFecha" Width="150" class="form-control" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Estatus]">
                        <EditItemTemplate>
                            <asp:CheckBox ID="EITchkEstatus" runat="server" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="Label9" runat="server" Enabled="false" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="FTchkEstatus" Text="Estatus" runat="server" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Video]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtVideo" runat="server" Text='<%# Bind("video") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <iframe src='<%# Bind("video") %>' runat="server" id="IfVideo" class="img-responsive" frameborder="0" allowfullscreen style="width: 100%"></iframe>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtVideo" placeholder="Video" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Productor]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtProductor" runat="server" Text='<%# Bind("productor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("productor") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtProductor" placeholder="Productor" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Editar]" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton Text="Agregar" ID="lnkAgregar" runat="server" OnClick="lnkAgregar_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Eliminar]" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtEliminar" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
    	<div class="col-xs-12">
        <h1>Hola Git Hub</h1>
    	</div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScrips" runat="Server">
    <script src="js/moment-with-locales.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
    <script>
        $(document).ready(function () {
            $('#body_gvPeliculas_FTtxtFecha').datetimepicker({
                format: 'L',
                locale: 'es'
            });
        });
    </script>
</asp:Content>

