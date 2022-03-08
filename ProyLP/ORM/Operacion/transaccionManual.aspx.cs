using CallCenterDB;
using EntitiesModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class transaccionManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Participantes";
                Master.Submenu = "Transacción Galenia";
            }
            CompareValidator2.ValueToCompare = DateTime.Now.ToShortDateString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            DataSet tarjeta = buscaNumeroTarjeta(numTarjeta.Text);
            if (tarjeta.Tables[0].Rows.Count == 0)
            {
                Master.MuestraMensaje("No existe numero de tarjeta. Revisar datos");
            }
            else if (tarjeta.Tables[0].Rows.Count > 0)
            {
                int comparaFechaFactura = DateTime.Compare(fechaFactura.SelectedDate.Value, DateTime.Now.Date);
                int comparaFechaPago;
                if (fechaPago.SelectedDate != null)
                {
                    comparaFechaPago = DateTime.Compare(fechaPago.SelectedDate.Value, DateTime.Now.Date);
                }
                else
                {
                    comparaFechaPago = 0;
                }

                if (comparaFechaFactura > 0 || comparaFechaPago > 0)
                {
                    Master.MuestraMensaje("Fecha de Pago o Fecha de factura no pueden ser mayores al dia actual");
                }
                else
                {
                    DataSet historico = buscaHistoricoVentas(sucursal.Text, factRem.Text);
                    if (historico.Tables[0].Rows.Count > 0)
                    {
                        Master.MuestraMensaje("Venta ya registrada anteriormente");
                    }
                    else if (historico.Tables[0].Rows.Count == 0)
                    {
                        try
                        {
                            csHistoricoVentas venta = new csHistoricoVentas();
                            venta.Numero_tarjeta = numTarjeta.Text;
                            venta.Clave_sucursal = sucursal.SelectedItem.Text;
                            venta.Tipo_transaccion = tipoTransaccion.SelectedItem.Text == "Venta" ? "V" : "C";
                            venta.Area_departamento = area.SelectedValue;
                            venta.Factura = factRem.Text;
                            venta.Fecha_factura = fechaFactura.SelectedDate.Value;
                            venta.Producto_clave = claveProducto.Text;
                            venta.Producto_descripcion = descProducto.Text;
                            venta.Cantidad = cantidad.Value.Value;
                            venta.Precio_unitario = precioUnitario.Value.Value;
                            venta.Importe = importe.Value.Value;
                            venta.Impuesto = impuesto.Value.Value;
                            venta.Total = total.Value.Value;
                            //campos opcionales
                            venta.Tipo_pago = tipoPago.SelectedValue == null ? null : tipoPago.SelectedValue;
                            if (fechaPago.SelectedDate != null)
                            {
                                venta.Fecha_pago = fechaPago.SelectedDate.Value;
                            }
                            else
                            {
                                venta.Fecha_pago = null;
                            }
                            venta.Status = "C";
                            venta.Fecha_status = DateTime.Now;
                            venta.Clave_persona = !claveCliente.Text.Equals("") ? claveCliente.Text : null;
                            venta.Nombre_persona = !nombreCliente.Text.Equals("") ? nombreCliente.Text : null;
                            venta.Inserta();
                            venta.CalculaPuntosMecanicas();
                            Master.MuestraMensaje("Transaccion insertada con exito");
                        }
                        catch (Exception ex)
                        {
                            Master.MuestraMensaje("ocurrio un error al insertar la transaccion" + ex.Message);
                        }
                    }
                }
            }
        }
        protected DataSet buscaNumeroTarjeta(string numeroTarjeta)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM participante WHERE clave = @clave", con);
            command.Parameters.Add("@clave", numeroTarjeta);
            adapter.SelectCommand = command;

            DataSet participante = new DataSet();
            adapter.Fill(participante);
            return participante;
        }
        protected DataSet buscaHistoricoVentas(string sucursal, string factura)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM historico_ventas WHERE clave_sucursal = @sucursal and factura = @factura", con);
            command.Parameters.Add("@sucursal", sucursal);
            command.Parameters.Add("@factura", factura);
            adapter.SelectCommand = command;

            DataSet historico = new DataSet();
            adapter.Fill(historico, "historico_ventas");
            return historico;
        }

        protected void cantidad_TextChanged(object sender, EventArgs e)
        {
            if (!precioUnitario.Text.Equals(""))
            {
                importe.Value = cantidad.Value * precioUnitario.Value;

                if (!impuesto.Text.Equals(""))
                {
                    total.Value = importe.Value + impuesto.Value;
                }
            }
        }

        protected void precioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (!cantidad.Text.Equals(""))
            {
                importe.Value = cantidad.Value * precioUnitario.Value;

                if (!impuesto.Text.Equals(""))
                {
                    total.Value = importe.Value + impuesto.Value;
                }
            }
        }

        protected void importe_TextChanged(object sender, EventArgs e)
        {
            if (!impuesto.Text.Equals(""))
            {
                total.Value = importe.Value + impuesto.Value;
            }

        }

        protected void impuesto_TextChanged(object sender, EventArgs e)
        {
            if (!importe.Text.Equals(""))
            {
                total.Value = importe.Value + impuesto.Value;
            }
        }

        protected void claveProducto_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            Object returnValue;

            cmd.CommandText = "select descripcion from producto where id = " + e.Value;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlcon;

            sqlcon.Open();
            returnValue = cmd.ExecuteScalar();
            sqlcon.Close();
            descProducto.Text = returnValue.ToString();
        }
    }
}