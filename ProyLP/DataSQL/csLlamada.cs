using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de csLlamada
/// </summary>
public class csLlamada
{
    csDataBase database;
    List<SqlParameter> parametros;

    private string participante_id;
    private string nombre_participante;
    private string nombre_llama;
    private string telefono;
    private string correo_electronico;
    private string descripcion_llamada;
    private string fecha_llamada;
    private string country_code;
    private string usuario_id;
    private string nombre_usuario;
    private string llamada_id;
    private string llamada_seguimiento_id;
    private string observacion;
    private string status_llamada_id;
    private string status_seguimiento_id;
    private string categoria_llamada_id;
    private List<string> lista_tipo_llamada;
    private List<string> lista_tipo_llamada_salida;
    private string programa;
    public csLlamada()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string IDParticipante
    {
        get
        {
            return participante_id;
        }
        set
        {
            participante_id = value;
        }
    }

    public string NombreParticipante
    {
        get
        {
            return nombre_participante;
        }
    }

    public string NombreLlama
    {
        get
        {
            return nombre_llama;
        }
        set
        {
            nombre_llama = value;
        }
    }

    public string Telefono
    {
        get
        {
            return telefono;
        }
        set
        {
            telefono = value;
        }
    }

    public string Correo_Electronico
    {
        get
        {
            return correo_electronico;
        }
        set
        {
            correo_electronico = value;
        }
    }

    public string Descripcion
    {
        get
        {
            return descripcion_llamada;
        }
        set
        {
            descripcion_llamada = value;
        }
    }

    public string FechaLlamada
    {
        get
        {
            return fecha_llamada;
        }
    }

    public string CountryCode
    {
        get
        {
            return country_code;
        }
        set
        {
            country_code = value;
        }
    }

    public string IDUsuario
    {
        get
        {
            return usuario_id;
        }
        set
        {
            usuario_id = value;
        }
    }

    public string NombreUsuario
    {
        get
        {
            return nombre_usuario;
        }
    }

    public string IDlamada
    {
        get
        {
            return llamada_id;
        }
        set
        {
            llamada_id = value;
        }
    }

    public string IDlamada_seguimiento
    {
        get
        {
            return llamada_seguimiento_id;
        }
        set
        {
            llamada_seguimiento_id = value;
        }
    }

    public string Observacion
    {
        get
        {
            return observacion;
        }
        set
        {
            observacion = value;
        }
    }

    public string Status_llamada_id
    {
        get
        {
            return status_llamada_id;
        }
        set
        {
            status_llamada_id = value;
        }
    }

    public string Status_seguimiento_id
    {
        get
        {
            return status_seguimiento_id;
        }
        set
        {
            status_seguimiento_id = value;
        }
    }

    public string CategoriaLlamada
    {
        get
        {
            return categoria_llamada_id;
        }
        set
        {
            categoria_llamada_id = value;
        }
    }
    public string Programa
    { get { return programa; } set { programa = value; } }
    public void AgregaTipoLlamada(string tipo_llamada)
    {
        if (lista_tipo_llamada == null)
        {
            lista_tipo_llamada = new List<string>();
            lista_tipo_llamada.Add(tipo_llamada);
        }
        else
        {
            lista_tipo_llamada.Add(tipo_llamada);
        }
    }

    public int ConsultaCantidadTipoLlamada
    {
        get
        {
            if (
                lista_tipo_llamada == null)
            {
                return 0;
            }
            else
            {
                return lista_tipo_llamada.Count;
            }
        }
    }

    public void AgregaTipoLlamadaSalida(string tipo_llamada_salida)
    {
        if (lista_tipo_llamada_salida == null)
        {
            lista_tipo_llamada_salida = new List<string>();
            lista_tipo_llamada_salida.Add(tipo_llamada_salida);
        }
        else
        {
            lista_tipo_llamada_salida.Add(tipo_llamada_salida);
        }
    }

    public int ConsultaCantidadTipoLlamadaSalida
    {
        get
        {
            if (
                lista_tipo_llamada_salida == null)
            {
                return 0;
            }
            else
            {
                return lista_tipo_llamada_salida.Count;
            }
        }
    }

    public DataTable ConsultaCategoriaLlamada()
    {
        database = new csDataBase();
        string categoria = "sp_consulta_categoria_tipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
        return database.dtConsulta(categoria, parametros, true);
    }

    public DataTable ConsultaCategoriaLlamada(string country)
    {
        database = new csDataBase();
        string categoria = "sp_consulta_categoria_tipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country));
        return database.dtConsulta(categoria, parametros, true);
    }

    public DataTable ConsultaTipoLlamadaComentario()
    {
        database = new csDataBase();
        string categoria = "Obtiene_Tipo_Llamada_Comentario";
        return database.dtConsulta(categoria, true);
    }


    public DataTable Consulta_categoria_tipo_contacto(string programa)
    {
        database = new csDataBase();
        string categoria = "sp_consulta_categoria_tipo_contacto";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));

        return database.dtConsulta(categoria, parametros, true);
    }


    public DataTable ConsultaTipoLlamada()
    {
        database = new csDataBase();
        string tipollamada = "sp_consulta_tipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@categoria_id", categoria_llamada_id));
        return database.dtConsulta(tipollamada, parametros, true);
    }

    public void GuardaLlamada()
    {
        database = new csDataBase();
        string llamada = "sp_guarda_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@nombre_llama", nombre_llama));
        parametros.Add(new SqlParameter("@telefono", telefono));
        parametros.Add(new SqlParameter("@descripcion", descripcion_llamada));
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
        llamada_id = database.consultaDato(llamada, parametros, true).ToString();
        lista_tipo_llamada.ForEach(GuardaTipoLlamada);
    }

    public void GuardaLlamada(string country)
    {
        database = new csDataBase();
        string llamada = "sp_guarda_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@nombre_llama", nombre_llama));
        parametros.Add(new SqlParameter("@telefono", telefono));
        parametros.Add(new SqlParameter("@descripcion", descripcion_llamada));
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
        parametros.Add(new SqlParameter("@country", country));
        llamada_id = database.consultaDato(llamada, parametros, true).ToString();
        lista_tipo_llamada.ForEach(GuardaTipoLlamada);
    }

    public void GuardaLlamadaComentario()
    {
        database = new csDataBase();
        string llamada = "sp_guarda_llamada_comentario";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@nombre_llama", nombre_llama));
        parametros.Add(new SqlParameter("@correo_electronico", correo_electronico));
        parametros.Add(new SqlParameter("@descripcion", descripcion_llamada));
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
        parametros.Add(new SqlParameter("@telefono", telefono));
        llamada_id = database.consultaDato(llamada, parametros, true).ToString();
        lista_tipo_llamada.ForEach(GuardaTipoLlamada);
    }

    public void GuardaLlamadaSeguimiento(string tipollamada)
    {
        database = new csDataBase();
        string llamada_seguimiento = "sp_guarda_llamada_seguimiento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@llamada_id", llamada_id));
        parametros.Add(new SqlParameter("@observacion", descripcion_llamada));
        parametros.Add(new SqlParameter("@tipo_llamada_id", tipollamada));
        parametros.Add(new SqlParameter("@status_seguimiento_id", status_seguimiento_id));
        parametros.Add(new SqlParameter("@aspnet_UserId", usuario_id));
        llamada_seguimiento_id = database.consultaDato(llamada_seguimiento, parametros, true).ToString();
    }

    public void GuardaLlamadaSeguimiento()
    {
        database = new csDataBase();
        string llamada_seguimiento = "sp_guarda_llamada_seguimiento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@llamada_id", llamada_id));
        parametros.Add(new SqlParameter("@observacion", descripcion_llamada));
        parametros.Add(new SqlParameter("@tipo_llamada_id", null));
        parametros.Add(new SqlParameter("@status_seguimiento_id", status_seguimiento_id));
        parametros.Add(new SqlParameter("@aspnet_UserId", usuario_id));
        llamada_seguimiento_id = database.consultaDato(llamada_seguimiento, parametros, true).ToString();
    }

    private void GuardaTipoLlamada(string tipollamada)
    {
        database = new csDataBase();
        string tipo = "sp_inserta_llamada_tipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@llamada_id", llamada_id));
        parametros.Add(new SqlParameter("@tipo_llamada_id", tipollamada));
        database.acutualizaDatos(tipo, parametros, true);
        DataTable dtClave = ObtieneClaveTipoLlamada(tipollamada);
        if (dtClave.Rows.Count > 0)
        {
            DataRow drClave = dtClave.Rows[0];
            if (drClave["clave"].ToString().ToUpper() != "CANJE" && drClave["clave_categoria"].ToString().ToUpper() != "SAL")
            {
                DataTable dtIdllamada;
                string claveCategoria = drClave["clave_categoria"].ToString().ToUpper();
                string clave = drClave["clave"].ToString().ToUpper();
                if (clave == "ACLAPROG")
                {
                    dtIdllamada = ObtieneIdTipoLlamada(clave);
                    if (dtIdllamada.Rows.Count > 0)
                    {
                        DataRow drIdllamada = dtIdllamada.Rows[0];
                        GuardaLlamadaSeguimiento(drIdllamada["id"].ToString());
                    }
                }
                else
                {
                    if (claveCategoria != "COMENTARIO")
                        dtIdllamada = ObtieneIdTipoLlamada("OPCALLC");
                    else
                        dtIdllamada = ObtieneIdTipoLlamada(clave);
                    if (dtIdllamada.Rows.Count > 0)
                    {
                        DataRow drIdllamada = dtIdllamada.Rows[0];
                        GuardaLlamadaSeguimiento(drIdllamada["id"].ToString());
                    }
                }
            }
        }
    }

    public DataTable ObtieneClaveTipoLlamada(string tipo_llamada)
    {
        database = new csDataBase();
        string ObtieneClaveTipoLlamada = "Obtiene_Clave_Tipo_Llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_llamada", tipo_llamada));
        return database.dtConsulta(ObtieneClaveTipoLlamada, parametros, true);
    }

    public DataTable ObtieneIdTipoLlamada(string clave)
    {
        database = new csDataBase();
        string ObtieneClaveTipoLlamada = "ObtieneIdTipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave", clave));
        return database.dtConsulta(ObtieneClaveTipoLlamada, parametros, true);
    }

    public DataTable ObtieneIdTipoLlamada(string clave, string country)
    {
        database = new csDataBase();
        string ObtieneClaveTipoLlamada = "ObtieneIdTipo_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country));
        parametros.Add(new SqlParameter("@clave", clave));
        return database.dtConsulta(ObtieneClaveTipoLlamada, parametros, true);
    }

    public DataTable ObtieneClaveStatusSeguimiento(string id, string country)
    {
        database = new csDataBase();
        string ObtieneStatusSeguimiento = "Obtiene_clave_status_seguimiento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country));
        parametros.Add(new SqlParameter("@id", id));
        return database.dtConsulta(ObtieneStatusSeguimiento, parametros, true);
    }

    public DataTable HistorialLlamadas()
    {
        database = new csDataBase();
        string historial = "sp_historial_llamadas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        return database.dtConsulta(historial, parametros, true);
    }

    public DataTable DetalleHistorialLlamadas()
    {
        consulta_llamada();

        database = new csDataBase();
        string historial = "sp_historial_llamadas_detalle";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@llamada_id", llamada_id));
        return database.dtConsulta(historial, parametros, true);
    }

    public DataTable SeguimientoLlamadas()
    {
        database = new csDataBase();
        string seguimiento = "Obtiene_Seguimiento_Llamadas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        return database.dtConsulta(seguimiento, parametros, true);
    }

    public DataTable SeguimientoLlamadasDetalle()
    {
        database = new csDataBase();
        string detalle = "Obtiene_Seguimiento_Llamadas_Detalle";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@id", llamada_id));
        return database.dtConsulta(detalle, parametros, true);
    }

    public DataTable LlenarStatusSeguimientoLlamadas()
    {
        database = new csDataBase();
        string detalle = "Obtiene_Status_Seguimiento";
        return database.dtConsulta(detalle, true);
    }

    public DataTable LlenarStatusSeguimientoLlamadas(string country_code)
    {
        database = new csDataBase();
        string detalle = "Obtiene_Status_Seguimiento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country_code));
        return database.dtConsulta(detalle, parametros, true);
    }

    public DataTable LlenarEscalamientoSeguimientoLlamadas()
    {
        database = new csDataBase();
        string detalle = "Obtiene_Escalamiento_Seguimiento";
        return database.dtConsulta(detalle, true);
    }

    public DataTable LlenarEscalamientoSeguimientoLlamadas(string country_code)
    {
        database = new csDataBase();
        string detalle = "Obtiene_Escalamiento_Seguimiento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country_code));
        DataTable dtLlamada = database.dtConsulta(detalle, parametros, true);
        return database.dtConsulta(detalle, true);
    }

    private void consulta_llamada()
    {
        database = new csDataBase();
        string llamada = "sp_consulta_llamada";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@llamada_id", llamada_id));
        DataTable dtLlamada = database.dtConsulta(llamada, parametros, true);
        if (dtLlamada.Rows.Count > 0)
        {
            DataRow drLlamada = dtLlamada.Rows[0];
            nombre_participante = drLlamada["participante"].ToString();
            nombre_llama = drLlamada["nombre_llama"].ToString();
            telefono = drLlamada["telefono"].ToString();
            fecha_llamada = drLlamada["fecha"].ToString();
            descripcion_llamada = drLlamada["descripcion"].ToString();
            nombre_usuario = drLlamada["usuario"].ToString();
        }
    }
}