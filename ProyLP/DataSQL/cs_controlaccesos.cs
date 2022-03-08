using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CallCenterDB.Linq;
using System.Configuration;
using CallCenterDB.Linq;

public class cs_controlaccesos
{
    public void InsertaAccesoWeb(string loginId, string OpcionPortal)
    {
        using (Control_Acceso_PortalDataContext context = new Control_Acceso_PortalDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            try
            {
                bitacora_accesos obj_control = new bitacora_accesos();
                if (loginId != null)
                {
                    obj_control.usuario_id = new Guid(loginId);
                }

                if (OpcionPortal != null)
                {
                    obj_control.opcion = OpcionPortal;
                }
                obj_control.fecha = DateTime.Now;
                context.bitacora_accesos.InsertOnSubmit(obj_control);
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}
