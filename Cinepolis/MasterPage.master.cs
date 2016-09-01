using Cinepolis.Cine.Business;
using Cinepolis.Cine.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            EntUsuario user = new BusCine().Validar(txtMail.Text, txtPassword.Text);
            if (user != null)
            {
                Session["USUARIO"] = user;
                lblUsuario.Text = "Bienvenido " + user.nombre;
                lblModal.InnerText = "";
            }
            else
            {
                lblModal.InnerText = "Login";
            }
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void MostrarMensaje(string mensaje)
    {
        string alerta = mensaje.Replace("\n","").Replace("\r","").Replace("'","");
        alerta = "alert('" + alerta + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
    protected void lnkSalir_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Response.Redirect("Cinepol.aspx");
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
}
