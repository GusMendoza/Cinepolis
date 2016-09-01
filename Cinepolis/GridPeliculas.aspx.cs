using Cinepolis.Cine.Business;
using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class GridPeliculas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                EntUsuario user = (EntUsuario)Session["USUARIO"];
                if (user != null)
                {
                    Label lbl = (Label)Master.FindControl("lblUsuario");
                    lbl.Text = "Bienvenido " + user.nombre;
                    HtmlContainerControl lblModal = (HtmlContainerControl)Master.FindControl("lblModal");
                    lblModal.InnerText = "";
                }
                else
                {
                    Response.Redirect("Cinepol.aspx");
                }
                ViewState["ORDEN"] = "ASC";         //Aqui guaramos el orden ascendente de las peliculas para el gridview
                ViewState["COLUM"] = "nombre";
                CargarGridPelicula(null, "", "");
            }

        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void CargarGridPelicula(int? fila, string columna, string direccion)
    {

        List<EntCine> lst = new BusCine().ObtenerPelicula();
        if (columna != "" && direccion != "")
        {
            if (direccion == "ASC")
                gvPeliculas.DataSource = lst.OrderBy(X => X.nombre).ToList();//aqui se ordena la lista de nombres con una exprecion lamda
            else
                gvPeliculas.DataSource = lst.OrderByDescending(X => X.nombre).ToList();
            gvPeliculas.DataBind(); 
        }
        else
        {
            gvPeliculas.DataSource = lst;
            gvPeliculas.DataBind();
        }

        


        int contador = 0;
        foreach (GridViewRow dr in gvPeliculas.Rows)
        {
            if (fila == contador && fila != null)
            {
                contador++;
                continue;
            }

            else
            {
                Label lbl = (Label)gvPeliculas.Rows[contador].FindControl("ITlblSinopsis");
                lbl.Text = lbl.Text.Length > 50 ? lbl.Text.Substring(0, 50) : lbl.Text;
                contador++;
            }

        }

        CargarDDLS();



    }

    private void CargarDDLS()
    {
        try
        {
            DropDownList ddlGenero = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlGenero");
            ddlGenero.DataSource = new BusCatalogos().ObtenerGenero();
            ddlGenero.DataValueField = "id";
            ddlGenero.DataTextField = "nombre";
            ddlGenero.DataBind();

            DropDownList ddlClasificacion = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlClasificacion");
            ddlClasificacion.DataSource = new BusCatalogos().ObtenerClas();
            ddlClasificacion.DataValueField = "id";
            ddlClasificacion.DataTextField = "nombre";
            ddlClasificacion.DataBind();

            List<EntGenero> lista = new List<EntGenero>();

            for (int i = DateTime.Now.Year + 1; i > DateTime.Now.Year - 49; i--)
            {
                EntGenero ent = new EntGenero();
                ent.id = i;
                lista.Add(ent);
            }
            DropDownList ddlAnio = (DropDownList)gvPeliculas.FooterRow.FindControl("FTddlAnio");
            ddlAnio.DataSource = lista;
            ddlAnio.DataTextField = "id";
            ddlAnio.DataValueField = "id";
            ddlAnio.DataBind();
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void MostrarMensaje(string mensaje)
    {
        string alerta = mensaje.Replace("\r", "").Replace("\n", "").Replace("'", "");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
    protected void gvPeliculas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvPeliculas.EditIndex = -1;
            CargarGridPelicula(null, "", "");
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void gvPeliculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            ent.id = Convert.ToInt32(gvPeliculas.DataKeys[e.RowIndex].Values["id"]);
            new BusCine().Borrar(ent);
            Response.Redirect("Cinepol.aspx");

        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void gvPeliculas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvPeliculas.EditIndex = e.NewEditIndex;
            CargarGridPelicula(e.NewEditIndex, "", "");

            DropDownList ddlGenero = (DropDownList)gvPeliculas.Rows[e.NewEditIndex].FindControl("EITddlGenero");
            ddlGenero.DataSource = new BusCatalogos().ObtenerGenero();
            ddlGenero.DataTextField = "nombre";
            ddlGenero.DataValueField = "id";
            ddlGenero.DataBind();
            ddlGenero.SelectedValue = gvPeliculas.DataKeys[e.NewEditIndex].Values["generoId"].ToString();

            DropDownList ddlClas = (DropDownList)gvPeliculas.Rows[e.NewEditIndex].FindControl("EITddlClasificacion");
            ddlClas.DataSource = new BusCatalogos().ObtenerClas();
            ddlClas.DataTextField = "nombre";
            ddlClas.DataValueField = "id";
            ddlClas.DataBind();
            ddlClas.SelectedValue = gvPeliculas.DataKeys[e.NewEditIndex].Values["clasificacionId"].ToString();

            List<EntGenero> lista = new List<EntGenero>();

            for (int i = DateTime.Now.Year + 1; i > DateTime.Now.Year - 49; i--)
            {
                EntGenero ent = new EntGenero();
                ent.id = i;
                lista.Add(ent);
            }
            DropDownList ddlAnio = (DropDownList)gvPeliculas.Rows[e.NewEditIndex].FindControl("EITddlAnio");
            ddlAnio.DataSource = lista;
            ddlAnio.DataTextField = "id";
            ddlAnio.DataValueField = "id";
            ddlAnio.DataBind();
            ddlAnio.SelectedValue = gvPeliculas.DataKeys[e.NewEditIndex].Values["anio"].ToString();



        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void gvPeliculas_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            string ruta = Server.MapPath(@"content\img\");
            ent.id = Convert.ToInt32(gvPeliculas.DataKeys[e.RowIndex].Values["id"]);
            ent.nombre = ((TextBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITtxtNombre")).Text;
            ent.sinopsis = ((TextBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITtxtSinopsis")).Text;
            ent.generoId = Convert.ToInt32(((DropDownList)gvPeliculas.Rows[e.RowIndex].FindControl("EITddlGenero")).SelectedValue);
            ent.clasificacionId = Convert.ToInt32(((DropDownList)gvPeliculas.Rows[e.RowIndex].FindControl("EITddlClasificacion")).SelectedValue);

            FileUpload fuFotoMini = (FileUpload)gvPeliculas.Rows[e.RowIndex].FindControl("EITfuFotoMini");
            if (fuFotoMini.HasFile && fuFotoMini.FileName != gvPeliculas.DataKeys[e.RowIndex].Values["fotomini"].ToString())
            {
                ent.fotoMini = @"content\img\" + fuFotoMini.FileName;
                fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
            }
            else
            {
                ent.fotoMini = gvPeliculas.DataKeys[e.RowIndex].Values["fotomini"].ToString();
            }


            FileUpload fuFotoPort = (FileUpload)gvPeliculas.Rows[e.RowIndex].FindControl("EITfuFotoPort");
            if (fuFotoPort.HasFile && fuFotoPort.FileName != gvPeliculas.DataKeys[e.RowIndex].Values["fotoport"].ToString())
            {
                ent.fotoPort = @"content\img\" + fuFotoPort.FileName;
                fuFotoPort.SaveAs(ruta + fuFotoPort.FileName);
            }
            else
            {
                ent.fotoPort = gvPeliculas.DataKeys[e.RowIndex].Values["fotoport"].ToString();
            }


            ent.anio = Convert.ToInt32(((DropDownList)gvPeliculas.Rows[e.RowIndex].FindControl("EITddlAnio")).SelectedValue);
            ent.fechaAlta = Convert.ToDateTime(((TextBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITtxtAlta")).Text);
            ent.estatus = ((CheckBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITchkEstatus")).Checked;
            ent.video = ((TextBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITtxtVideo")).Text;
            ent.productor = ((TextBox)gvPeliculas.Rows[e.RowIndex].FindControl("EITtxtProductor")).Text;
            new BusCine().Actualizar(ent);
            Response.Redirect("Cinepol.aspx");

        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            string ruta = Server.MapPath(@"content\img\");
            //TextBox txtNombre = new TextBox();
            //txtNombre = (TextBox)gvPeliculas.FooterRow.FindControl("FTtxtNombre");
            //ent.nombre = txtNombre.Text;
            // Estas 3 lineas hacen la misma accion que la siguiente linea
            ent.nombre = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtNombre")).Text;
            ent.sinopsis = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtSinopsis")).Text;
            ent.generoId = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlGenero")).SelectedValue);
            ent.clasificacionId = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlClasificacion")).SelectedValue);

            FileUpload fuFotoMini = (FileUpload)gvPeliculas.FooterRow.FindControl("FTfuFotoMini");
            ent.fotoMini = @"content\img\" + fuFotoMini.FileName;
            fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);

            FileUpload fuFotoPort = (FileUpload)gvPeliculas.FooterRow.FindControl("FTfuFotoPort");
            ent.fotoPort = @"content\img\" + fuFotoPort.FileName;
            fuFotoPort.SaveAs(ruta + fuFotoPort.FileName);


            ent.anio = Convert.ToInt32(((DropDownList)gvPeliculas.FooterRow.FindControl("FTddlAnio")).SelectedValue);
            ent.fechaAlta = Convert.ToDateTime(((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtFecha")).Text);
            ent.estatus = ((CheckBox)gvPeliculas.FooterRow.FindControl("FTchkEstatus")).Checked;
            ent.video = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtVideo")).Text;
            ent.productor = ((TextBox)gvPeliculas.FooterRow.FindControl("FTtxtProductor")).Text;
            new BusCine().Insertar(ent);
            Response.Redirect("Cinepol.aspx");


        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    protected void gvPeliculas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvPeliculas.SelectedIndex = -1;
            gvPeliculas.PageIndex = e.NewPageIndex;
            CargarGridPelicula(null, ViewState["COLUM"].ToString(), ViewState["ACTUAL"].ToString());
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void gvPeliculas_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string columna = e.SortExpression;    //aqui recuperamos la columna con la que vamos a hacer el ordenamiento
            string direccion = ViewState["ORDEN"].ToString();

            if (direccion == "ASC")
                ViewState["ORDEN"] = "DES";
            else
                ViewState["ORDEN"] = "ASC";
            ViewState["COLUM"] = columna;
            ViewState["ACTUAL"] = direccion;
            CargarGridPelicula(null, columna, direccion);

        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
}