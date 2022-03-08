using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Calendario_Canje
{
    public decimal ID
    {
        get;
        set;
    }
    public DateTime Fecha_Inicial
    {
        get;
        set;
    }

    public DateTime Fecha_Final
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
    public Calendario_Canje()
    { 
    }
    public Calendario_Canje(DateTime fecha_inicial, DateTime fecha_final, string descripcion, string descripcion_larga)
    {
        this.Fecha_Inicial = fecha_inicial;
        this.Fecha_Final = fecha_final;
        this.Descripcion = descripcion;
        this.DescripcionLarga = descripcion_larga;
    }
    public Calendario_Canje(decimal id, DateTime fecha_inicial, DateTime fecha_final, string descripcion, string descripcion_larga)
    {
        this.ID = id;
        this.Fecha_Inicial = fecha_inicial;
        this.Fecha_Final = fecha_final;
        this.Descripcion = descripcion;
        this.DescripcionLarga = descripcion_larga;
    }
}
