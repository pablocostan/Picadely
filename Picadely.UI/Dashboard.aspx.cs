﻿using Picadely.Entities;
using Picadely.Services;
using System;

namespace Picadely.UI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = Session["UsuarioLogueado"] as Usuario;
            if (usuario.Tipo != UsuarioTipo.Admin.ToString())
                Response.Redirect("Login.aspx");
            var picadasServices = new ComprasServices();
            var pedidos = picadasServices.GetPedidos();

            GridView.DataSource = pedidos;
            GridView.DataBind();
        }
    }
}