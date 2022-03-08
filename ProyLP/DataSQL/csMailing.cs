using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallCenterDB.Linq;
using System.Configuration;
using CallCenterDB.Entidades;

public class csMailing
{
    private DatosServidor _mailing;

    public csMailing()
    {
    }
    public DatosServidor Datos(int programa_id)
    {
        _mailing = new DatosServidor();

        using (EntitiesModel.EntitiesModel entities = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            EntitiesModel.programa prog = entities.programas.FirstOrDefault(_pr => _pr.id == programa_id) as EntitiesModel.programa;

            _mailing.ProgramaID = prog.id;
            _mailing.Programa = prog.descripcion;
            _mailing.FromMail = prog.correo_electronico;
            _mailing.FromName = prog.remitente;
            _mailing.ServidorSMTP = prog.servidor_smtp;
            _mailing.ServidorPOP = prog.servidor_pop;
            _mailing.UsuarioMail = prog.usuario_correo;
            _mailing.PasswordMail = prog.password_correo;
        }
        return _mailing;
    }
    public DatosServidor Datos(string clave)
    {
        _mailing = new DatosServidor();

        using (EntitiesModel.EntitiesModel entities = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            EntitiesModel.programa prog = entities.programas.FirstOrDefault(_pr => _pr.clave == clave) as EntitiesModel.programa;

            _mailing.ProgramaID = prog.id;
            _mailing.Programa = prog.descripcion;
            _mailing.FromMail = prog.correo_electronico;
            _mailing.FromName = prog.remitente;
            _mailing.ServidorSMTP = prog.servidor_smtp;
            _mailing.ServidorPOP = prog.servidor_pop;
            _mailing.UsuarioMail = prog.usuario_correo;
            _mailing.PasswordMail = prog.password_correo;
        }
        return _mailing;
    }
}
