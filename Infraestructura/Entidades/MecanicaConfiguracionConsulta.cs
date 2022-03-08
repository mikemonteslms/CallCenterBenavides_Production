using ORMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{

    public class MecanicaConfiguracionConsulta
    {
        public int Id_MecanicaConfiguracion { get; set; }
        public string id_grupoMecanica { get; set; }
        public int idGrupoMecanicaJoin { get; set; }
        public int Id_Club { get; set; }
        public string DescClub { get; set; }
        public int Id_mecanicaNivel { get; set; }
        public int Id_Nivel { get; set; }
        public List<Nivel> Niveles { get; set; }

        public int CompraIni { get; set; }
        public int CompraFin { get; set; }

        public int EdadIni { get; set; }
        public int EdadFin { get; set; }
        public int BeneficioIni { get; set; }
        public int BeneficioFin { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public int Id_Periodo { get; set; }
        public string Perido { get; set; }
        public int Limite { get; set; }
        public int id_status { get; set; }
        public string Status { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int LimiteMecanica { get; set; }

        public int id_TipoOperacion { get; set; }
        public string TipoOperacion { get; set; }

        public int id_categoriaMecanica { get; set; }
        public string CategoriaMecanica { get; set; }
        public string DescNivel { get; set; }

        public List<ProductoSeleccionado> PiezasLM { get; set; }
        public List<ProductoSeleccionadoLista> PiezasLista { get; set; }
        public List<ProductoSeleccionadoLista> BeneficioLista { get; set; }

        public string PiezasProductostr_SKU { get; set; }
        public string PiezasProductostr_SKU_Benavides { get; set; }
        public string PiezasCantidad { get; set; }

        public string BeneficioProductostr_SKU { get; set; }
        public string BeneficioProductostr_SKU_Benavides { get; set; }
        public string BeneficioCantidad { get; set; }

        public string NivelesStr { get; set; }

        public string UserId { get; set; }

        public int IdTipoPrecio { get; set; }
        public string DescTipoPrecio { get; set; }

    }

}