using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallCenterDB;
using System.Configuration;

public class CategoriaTipoLlamada
{
    public int ID
    {
        get;
        set;
    }
    public string Clave
    {
        get;
        set;
    }
    public string Descripcion
    {
        get;
        set;
    }
    public string DescripcionLarga
    {
        get;
        set;
    }
    public DateTime FechaAlta
    {
        get;
        set;
    }
    public DateTime FechaCambio
    {
        get;
        set;
    }
    public DateTime FechaBaja
    {
        get;
        set;
    }
    public int UsuarioAlta
    {
        get;
        set;
    }
    public int UsuarioCambio
    {
        get;
        set;
    }
    public int UsuarioBaja
    {
        get;
        set;
    }
    public string Status
    {
        get;
        set;
    }
}

public class TipoLlamada
{
    public int ID
    {
        get;
        set;
    }
    public string Clave
    {
        get;
        set;
    }
    public string Descripcion
    {
        get;
        set;
    }
    public string DescripcionLarga
    {
        get;
        set;
    }
    public int CategoriaTipoLlamadaID
    {
        get;
        set;
    }
    public DateTime FechaAlta
    {
        get;
        set;
    }
    public DateTime FechaCambio
    {
        get;
        set;
    }
    public DateTime FechaBaja
    {
        get;
        set;
    }
    public int UsuarioAlta
    {
        get;
        set;
    }
    public int UsuarioCambio
    {
        get;
        set;
    }
    public int UsuarioBaja
    {
        get;
        set;
    }
    public string Status
    {
        get;
        set;
    }
}

public class csCatalogoLlamada
{
    public csCatalogoLlamada()
    {
    }

    public List<CategoriaTipoLlamada> ConsultaCategoriasTipoLlamada()
    {
        List<CategoriaTipoLlamada> cats = new List<CategoriaTipoLlamada>();
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var categorias = from c in cat_llam.CategoriaTipoLlamada
                             where c.Clave.ToUpper().Trim() != "ESCALA"
                             select c;
            foreach (var _c in categorias)
            {
                if (_c.CountryCode == null)
                {
                    CategoriaTipoLlamada cat = new CategoriaTipoLlamada();
                    cat.ID = Convert.ToInt32(_c.ID);
                    cat.Clave = _c.Clave;
                    cat.Descripcion = _c.Descripcion;
                    cat.DescripcionLarga = _c.DescripcionLarga;
                    if (_c.UsuarioBajaID == null || _c.FechaBaja == null)
                    {
                        cat.Status = "Activo";
                    }
                    else
                    {
                        cat.Status = "Inactivo";
                    }
                    cats.Add(cat);
                }
            }
        }
        return cats;
    }

    //public List<CategoriaTipoLlamadaBR> ConsultaCategoriasTipoLlamadaBR()
    //{
    //    List<CategoriaTipoLlamadaBR> cats = new List<CategoriaTipoLlamadaBR>();
    //    using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
    //    {
    //        var categorias = from c in cat_llam.CategoriaTipoLlamada
    //                         select c;
    //        foreach (var _c in categorias)
    //        {
    //            CategoriaTipoLlamadaBR cat = new CategoriaTipoLlamadaBR();
    //            cat.ID = Convert.ToInt32(_c.ID);
    //            cat.Clave = _c.Clave;
    //            cat.Descripcion = _c.Descripcion;
    //            cat.DescripcionLarga = _c.DescripcionLarga;
    //            if (_c.UsuarioBajaID == null || _c.FechaBaja == null)
    //            {
    //                cat.Status = "Ativo";
    //            }
    //            else
    //            {
    //                cat.Status = "Inativo";
    //            }
    //            cats.Add(cat);
    //        }
    //    }
    //    return cats;
    //}

    public List<CategoriaTipoLlamada> ConsultaCategoriaTipoLlamada(int categoria_id)
    {
        List<CategoriaTipoLlamada> cats = new List<CategoriaTipoLlamada>();
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var categorias = from c in cat_llam.CategoriaTipoLlamada
                             where c.ID == categoria_id
                             select c;
            foreach (var _c in categorias)
            {
                CategoriaTipoLlamada cat = new CategoriaTipoLlamada();
                cat.ID = Convert.ToInt32(_c.ID);
                cat.Clave = _c.Clave;
                cat.Descripcion = _c.Descripcion;
                cat.DescripcionLarga = _c.DescripcionLarga;
                if (_c.UsuarioBajaID == null || _c.FechaBaja == null)
                {
                    cat.Status = "Activo";
                }
                else
                {
                    cat.Status = "Inactivo";
                }
                cats.Add(cat);
            }
        }
        return cats;
    }

    public List<TipoLlamada> ConsultaTipoLlamadas(CategoriaTipoLlamada c_id)
    {
        List<TipoLlamada> cats = new List<TipoLlamada>();
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var categorias = from c in cat_llam.TipoLlamada
                             where c.CategoriaTipoLlamadaID == c_id.ID
                             select c;
            foreach (var _c in categorias)
            {
                TipoLlamada cat = new TipoLlamada();
                cat.ID = Convert.ToInt32(_c.ID);
                cat.Clave = _c.Clave;
                cat.Descripcion = _c.Descripcion;
                cat.DescripcionLarga = _c.DescripcionLarga;
                if (_c.UsuarioBajaID == null || _c.FechaBaja == null)
                {
                    cat.Status = "Activo";
                }
                else
                {
                    cat.Status = "Inactivo";
                }
                cats.Add(cat);
            }
        }
        return cats;
    }
    public List<TipoLlamada> ConsultaTipoLlamada(int tipo_llamada_id)
    {
        List<TipoLlamada> cats = new List<TipoLlamada>();
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var categorias = from c in cat_llam.TipoLlamada
                             where c.ID == tipo_llamada_id
                             select c;
            foreach (var _c in categorias)
            {
                TipoLlamada cat = new TipoLlamada();
                cat.ID = Convert.ToInt32(_c.ID);
                cat.Clave = _c.Clave;
                cat.Descripcion = _c.Descripcion;
                cat.DescripcionLarga = _c.DescripcionLarga;
                if (_c.UsuarioBajaID == null || _c.FechaBaja == null)
                {
                    cat.Status = "Activo";
                }
                else
                {
                    cat.Status = "Inactivo";
                }
                cats.Add(cat);
            }
        }
        return cats;
    }
    public void InsertaCategoriaTipoLlamada(CategoriaTipoLlamada c)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var t = new CallCenterDB.CategoriaTipoLlamada()
            {
                Clave = c.Clave,
                Descripcion = c.Descripcion,
                DescripcionLarga = c.DescripcionLarga,
                FechaAlta = DateTime.Now,
                UsuarioAltaID = c.UsuarioAlta,
            };
            cat_llam.CategoriaTipoLlamada.InsertOnSubmit(t);
            cat_llam.SubmitChanges();

            if (c.UsuarioBaja == 1)
            {
                c.ID = Convert.ToInt32(t.ID);
                BajaCategoriaTipoLlamada(c);
            }
        }
    }
    public void InsertaTipoLlamada(TipoLlamada t)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var _t = new CallCenterDB.TipoLlamada()
            {
                Clave = t.Clave,
                Descripcion = t.Descripcion,
                DescripcionLarga = t.DescripcionLarga,
                CategoriaTipoLlamadaID = t.CategoriaTipoLlamadaID,
                FechaAlta = DateTime.Now,
                UsuarioAltaID = t.UsuarioAlta,
                UsuarioBajaID = t.UsuarioBaja,
            };
            cat_llam.TipoLlamada.InsertOnSubmit(_t);
            cat_llam.SubmitChanges();

            if (t.UsuarioBaja == 1)
            {
                t.ID = Convert.ToInt32(_t.ID);
                BajaTipoLlamada(t);
            }
        }
    }
    public void BajaCategoriaTipoLlamada(CategoriaTipoLlamada c)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            CallCenterDB.CategoriaTipoLlamada cat = cat_llam.CategoriaTipoLlamada.Single(_c => _c.ID == c.ID);
            cat.FechaBaja = DateTime.Now;
            cat.UsuarioBajaID = c.UsuarioBaja;
            cat_llam.SubmitChanges();
        }
    }
    public void BajaTipoLlamada(TipoLlamada c)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            CallCenterDB.TipoLlamada cat = cat_llam.TipoLlamada.Single(_c => _c.ID == c.ID);
            cat.FechaBaja = DateTime.Now;
            cat.UsuarioBajaID = c.UsuarioBaja;
            cat_llam.SubmitChanges();
        }
    }
    public void ActualizaCategoriaTipoLlamada(CategoriaTipoLlamada c)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            CallCenterDB.CategoriaTipoLlamada cat = cat_llam.CategoriaTipoLlamada.Single(_c => _c.ID == c.ID);
            cat.Clave = c.Clave;
            cat.Descripcion = c.Descripcion;
            cat.DescripcionLarga = c.DescripcionLarga;
            cat.FechaCambio = DateTime.Now;
            cat.UsuarioCambioID = c.UsuarioCambio;
            cat.UsuarioBajaID = null;
            cat.FechaBaja = null;            
            cat_llam.SubmitChanges();
            if (c.UsuarioBaja == 1)
            {
                BajaCategoriaTipoLlamada(c);
            }
        }
    }
    public void ActualizaTipoLlamada(TipoLlamada c)
    {
        using (CatalogoLlamadaDataContext cat_llam = new CatalogoLlamadaDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            CallCenterDB.TipoLlamada cat = cat_llam.TipoLlamada.Single(_c => _c.ID == c.ID);
            cat.Clave = c.Clave;
            cat.Descripcion = c.Descripcion;
            cat.DescripcionLarga = c.DescripcionLarga;
            cat.CategoriaTipoLlamadaID = c.CategoriaTipoLlamadaID;
            cat.FechaCambio = DateTime.Now;
            cat.UsuarioCambioID = c.UsuarioCambio;
            cat.UsuarioBajaID = null;
            cat.FechaBaja = null;

            cat_llam.SubmitChanges();

            if (c.UsuarioBaja == 1)
            {
                BajaTipoLlamada(c);
            }
        }
    }
}
