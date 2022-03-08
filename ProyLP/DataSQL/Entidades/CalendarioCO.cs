using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CalendarioCO
{
    public decimal ID
    {
        get;
        set;
    }
    public DateTime Fecha
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
    public CalendarioCO()
    { 
    }
    public CalendarioCO(DateTime fecha, string descripcion, string descripcion_larga)
    {
        this.Fecha = fecha;
        this.Descripcion = descripcion;
        this.DescripcionLarga = descripcion_larga;
    }
    public CalendarioCO(decimal id, DateTime fecha, string descripcion, string descripcion_larga)
    {
        this.ID = id;
        this.Fecha = fecha;
        this.Descripcion = descripcion;
        this.DescripcionLarga = descripcion_larga;
    }
}
