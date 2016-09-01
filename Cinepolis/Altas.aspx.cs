using Cinepolis.Cine.Business;
using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Altas : System.Web.UI.Page
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

                CargarDDLClas();
                CargarDDLGene();
                CargarDDLAnio();
                int id = Convert.ToInt32(Request.QueryString["id"]); //recupera el id de la pelicula seleccionada
                if (id != 0)
                {
                    btnActualizar.Visible = true;
                    btnAgregar.Visible = false;
                    btnBorrar.Visible = true;

                    EntCine ent = new BusCine().obtener(id);
                    imgFotoPort.ImageUrl = ent.fotoPort;
                    hfFotoPort.Value = ent.fotoPort;             //recupera el valor de foto de portada para poder usarla en algun otro lado
                    ImgFotoMini.ImageUrl = ent.fotoMini;
                    hfFotoMini.Value = ent.fotoMini;
                    IfVideo.Src = ent.video;
                    txtVideo.Text = ent.video;
                    txtNomb.Text = ent.nombre;
                    txtProd.Text = ent.productor;
                    chkEsta.Checked = ent.estatus;
                    txtSino.Text = ent.sinopsis;
                    ddlClas.SelectedValue = ent.clasificacionId.ToString();
                    ddlGenero.SelectedValue = ent.generoId.ToString();
                }
                else
                {
                    btnActualizar.Visible = false;
                    btnAgregar.Visible = true;
                    btnBorrar.Visible = false;

                }
            }
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void CargarDDLAnio()
    {
        List<EntGenero> lista = new List<EntGenero>();
        for (int i = DateTime.Now.Year + 1; i > DateTime.Now.Year - 49; i--)
        {
            EntGenero ent = new EntGenero();
            ent.id = i;
            lista.Add(ent);
        }
        ddlAnio.DataSource = lista;
        ddlAnio.DataTextField = "id";
        ddlAnio.DataValueField = "id";
        ddlAnio.DataBind();

    }

    private void CargarDDLGene()
    {
        ddlGenero.DataSource = new BusCatalogos().ObtenerGenero();
        ddlGenero.DataTextField = "nombre";
        ddlGenero.DataValueField = "id";
        ddlGenero.DataBind();
    }

    private void CargarDDLClas()
    {
        ddlClas.DataSource = new BusCatalogos().ObtenerClas();
        ddlClas.DataTextField = "nombre";
        ddlClas.DataValueField = "id";
        ddlClas.DataBind();
    }

    private void MostrarMensaje(string mensaje)
    {
        string alerta = mensaje.Replace("\r", "").Replace("\n", "").Replace("'", "");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            ent.id = Convert.ToInt32(Request.QueryString["id"]);
            ent.nombre = txtNomb.Text.ToString();
            ent.productor = txtProd.Text.ToString();
            ent.sinopsis = txtSino.Text.ToString();
            ent.estatus = chkEsta.Checked;
            ent.clasificacionId = Convert.ToInt32(ddlClas.SelectedValue);
            ent.generoId = Convert.ToInt32(ddlGenero.SelectedValue);
            ent.video = txtVideo.Text.ToString();
            ent.fechaAlta = DateTime.Now;
            string ruta = Server.MapPath(@"content\img\");

            if (FuFotoPort.HasFile && FuFotoPort.FileName != hfFotoPort.Value)
            {
                ent.fotoPort = "content/img/" + FuFotoPort.FileName;
                FuFotoPort.SaveAs(ruta + FuFotoPort.FileName);
                File.Delete(ruta + hfFotoPort.Value);
            }
            else
                ent.fotoPort = hfFotoPort.Value;

            if (fuFotoMini.HasFile && fuFotoMini.FileName != hfFotoMini.Value)
            {
                ent.fotoMini = "content/img/" + fuFotoMini.FileName;
                fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
                File.Delete(ruta + hfFotoMini.Value);
            }
            else
                ent.fotoMini = hfFotoMini.Value;

            new BusCine().Actualizar(ent);
            Response.Redirect("Cinepol.aspx");

        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            if (fuFotoMini.HasFile && FuFotoPort.HasFile)
            {
                string ruta = MapPath(@"content\img\");
                int fileSize = FuFotoPort.PostedFile.ContentLength;
                string extension = System.IO.Path.GetExtension(FuFotoPort.FileName);
                MemoryStream str = new MemoryStream(FuFotoPort.FileBytes);
                System.Drawing.Image bmp = System.Drawing.Image.FromStream(str);
                int ancho = bmp.Width;
                int alto = bmp.Height;
                if ((extension == ".jpg" || extension == ".jpeg") && (ancho <= 1200 || alto <= 800))
                {
                    FuFotoPort.SaveAs(ruta + FuFotoPort.FileName);
                    fuFotoMini.SaveAs(ruta + fuFotoMini.FileName);
                    ent.fotoPort = "content\\img\\" + FuFotoPort.FileName;
                    ent.fotoMini = "content\\img\\" + fuFotoMini.FileName;
                    ent.nombre = txtNomb.Text;
                    ent.productor = txtProd.Text;
                    ent.sinopsis = txtSino.Text;
                    // ent.anio = Convert.ToInt32(ddlAnio.SelectedValue);
                    ent.clasificacionId = Convert.ToInt32(ddlClas.SelectedValue);
                    ent.generoId = Convert.ToInt32(ddlGenero.SelectedValue);
                    ent.estatus = chkEsta.Checked;
                    ent.video = txtVideo.Text;
                    ent.fechaAlta = DateTime.Now;

                    new BusCine().Insertar(ent);
                    Response.Redirect("Cinepol.aspx");
                }
                else
                {
                    throw new ApplicationException("No se pudo Insertar la pelicula");
                }
            }
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        try
        {
            EntCine ent = new EntCine();
            ent.id = Convert.ToInt32(Request.QueryString["id"]);
            new BusCine().Borrar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void txtVideo_TextChanged(object sender, EventArgs e)
    {
        IfVideo.Src = txtVideo.Text;
    }
}