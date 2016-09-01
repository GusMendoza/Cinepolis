using Cinepolis.Cine.Business;
using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cinepol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CargarCarruselUno();
            CargarCarruselDos();
            CargarPelicula();
            //txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            EntUsuario user = (EntUsuario)Session["USUARIO"];
            if (user != null)
            {
                Label lbl = (Label)Master.FindControl("lblUsuario");
                lbl.Text = "Bienvenido " + user.nombre;
            }     
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void CargarPelicula()
    {
        List<EntCine> lista = new BusCine().ObtenerPelicula();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        foreach (EntCine ent in lista)
        {
            literal.Text += "<div class=\"col-md-4\">";
            literal.Text += "<div class=\"panel panel-info\">";
            literal.Text += "<div class=\"panel-heading\" style = \"height:207px; overflow-y:hidden;\">";
            literal.Text += "<a href=\"Altas.aspx?id=" + ent.id + "\" title=\"Editar Pelicula\"><img src=\"" + ent.fotoPort + "\" class=\"img-responsive\" alt=\"\" /></a>";
            literal.Text += "<h3 class=\"panel-title\"></h3>";
            literal.Text += "</div>";
            literal.Text += "<div class=\"panel-body\" style =\"height: 300px;\">";
            literal.Text += "<div class=\"row\">";
            literal.Text += "<div class=\"col-xs-4\">";
            literal.Text += "<img src=\"" + ent.fotoMini + "\" alt=\"\" class=\"img-responsive\" />";
            literal.Text += "</div>";
            literal.Text += "<div class=\"col-xs-8\">";
            literal.Text += "Nombre : <span>" + ent.nombre + "</span><br />";
            literal.Text += "Genero : <span>" + ent.Genero.nombre + "</span><br />";
            literal.Text += "Clasificacion : <span>" + ent.Clas.nombre + "</span><br />";
            literal.Text += "Productor : <span>" + ent.productor + "</span><br />";
            literal.Text += "</div>";
            literal.Text += "</div>";
            literal.Text += "<hr />";
            literal.Text += "<p style=\"height:100px; overflow-y:scroll;\">" + ent.sinopsis + "</p>";
            literal.Text += "</div>";
            literal.Text += "<div class=\"panel-footer\">";
            literal.Text += "<iframe class=\"img-responsive\" style=\"margin: auto\" src=\"" + ent.video + "\" frameborder=\"0\" allowfullscreen=\"\"></iframe>";
            literal.Text +="</div>";
            literal.Text += "</div>";
            literal.Text += "</div>";

        }
        phpelis.Controls.Add(literal);
    }

    private void CargarCarruselDos()
    {
        List<EntCine> lista = new BusCine().ObtenerEstrenos();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0;
        foreach (EntCine ent in lista)
        {
            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += "<li data-target=\"#Estrenos\" data-slide-to=\"" + contador + "\" class=\"active\"></li>";
            else
                literal.Text += "<li data-target=\"#Estrenos\" data-slide-to=\"" + contador + "\"></li>";
            phtres.Controls.Add(literal);

            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += " <div class=\"item active\">";
            else
                literal.Text += " <div class=\"item\">";
            literal.Text += "<img src=\"" + ent.fotoPort + "\" alt=\"Chania\" />";
            literal.Text += "<div class=\"carousel-caption\">";
            literal.Text += "<h3>" + ent.nombre + "</h3>";
            literal.Text += "<p>" + ent.sinopsis.Substring(0, 20) + "</p>";
            literal.Text += "</div>";
            literal.Text += "</div>";
            phcuatro.Controls.Add(literal);

            contador++;
        }
    }

    private void CargarCarruselUno()
    {
        List<EntCine> lista = new BusCine().ObtenerPelicula();
        LiteralControl literal = new LiteralControl();
        literal.Text = "";
        int contador = 0; 
        foreach (EntCine ent in lista)
        {
            literal = new LiteralControl();
            if (contador == 0)          
            literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\" class=\"active\"></li>";					
            else
                literal.Text += "<li data-target=\"#myCarousel\" data-slide-to=\"" + contador + "\"></li>";
            phuno.Controls.Add(literal);

            literal = new LiteralControl();
            if (contador == 0)
                literal.Text += " <div class=\"item active\">";
            else
                literal.Text +=" <div class=\"item\">";						
            literal.Text +="<img src=\"" + ent.fotoPort + "\" alt=\"Chania\" />";						
            literal.Text +="<div class=\"carousel-caption\">";						
            literal.Text +="<h3>" + ent.nombre + "</h3>";						
            literal.Text +="<p>" + ent.sinopsis.Substring(0, 20) + "</p>";				
            literal.Text +="</div>";						
            literal.Text +="</div>";
            phdos.Controls.Add(literal);

            contador++;
        }

    }

    private void MostrarMensaje(string mensaje)
    {
        string alerta = mensaje.Replace("\r","").Replace("\n","").Replace("'","");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);        
    }
}