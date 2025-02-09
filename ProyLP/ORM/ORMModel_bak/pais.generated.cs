#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using EntitiesModel;

namespace EntitiesModel	
{
	public partial class pais
	{
		private long _id;
		public virtual long id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		
		private string _clave;
		public virtual string clave
		{
			get
			{
				return this._clave;
			}
			set
			{
				this._clave = value;
			}
		}
		
		private string _descripcion;
		public virtual string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				this._descripcion = value;
			}
		}
		
		private string _descripcion_larga;
		public virtual string descripcion_larga
		{
			get
			{
				return this._descripcion_larga;
			}
			set
			{
				this._descripcion_larga = value;
			}
		}
		
		private DateTime _fecha_alta;
		public virtual DateTime fecha_alta
		{
			get
			{
				return this._fecha_alta;
			}
			set
			{
				this._fecha_alta = value;
			}
		}
		
		private DateTime? _fecha_cambio;
		public virtual DateTime? fecha_cambio
		{
			get
			{
				return this._fecha_cambio;
			}
			set
			{
				this._fecha_cambio = value;
			}
		}
		
		private DateTime? _fecha_baja;
		public virtual DateTime? fecha_baja
		{
			get
			{
				return this._fecha_baja;
			}
			set
			{
				this._fecha_baja = value;
			}
		}
		
		private Guid _usuario_alta_id;
		public virtual Guid usuario_alta_id
		{
			get
			{
				return this._usuario_alta_id;
			}
			set
			{
				this._usuario_alta_id = value;
			}
		}
		
		private Guid? _usuario_cambio_id;
		public virtual Guid? usuario_cambio_id
		{
			get
			{
				return this._usuario_cambio_id;
			}
			set
			{
				this._usuario_cambio_id = value;
			}
		}
		
		private Guid? _usuario_baja_id;
		public virtual Guid? usuario_baja_id
		{
			get
			{
				return this._usuario_baja_id;
			}
			set
			{
				this._usuario_baja_id = value;
			}
		}
		
		private IList<tipo_respuesta> _tipo_respuesta = new List<tipo_respuesta>();
		public virtual IList<tipo_respuesta> tipo_respuesta
		{
			get
			{
				return this._tipo_respuesta;
			}
		}
		
		private IList<tipo_encuesta> _tipo_encuesta = new List<tipo_encuesta>();
		public virtual IList<tipo_encuesta> tipo_encuesta
		{
			get
			{
				return this._tipo_encuesta;
			}
		}
		
		private IList<status_transaccion> _status_transaccion = new List<status_transaccion>();
		public virtual IList<status_transaccion> status_transaccion
		{
			get
			{
				return this._status_transaccion;
			}
		}
		
		private IList<status_llamada> _status_llamada = new List<status_llamada>();
		public virtual IList<status_llamada> status_llamada
		{
			get
			{
				return this._status_llamada;
			}
		}
		
		private IList<status_carga> _status_carga = new List<status_carga>();
		public virtual IList<status_carga> status_carga
		{
			get
			{
				return this._status_carga;
			}
		}
		
		private IList<sexo> _sexo = new List<sexo>();
		public virtual IList<sexo> sexo
		{
			get
			{
				return this._sexo;
			}
		}
		
		private IList<respuesta> _respuesta = new List<respuesta>();
		public virtual IList<respuesta> respuesta
		{
			get
			{
				return this._respuesta;
			}
		}
		
		private IList<proveedor_premios> _proveedor_premios = new List<proveedor_premios>();
		public virtual IList<proveedor_premios> proveedor_premios
		{
			get
			{
				return this._proveedor_premios;
			}
		}
		
		private IList<operadora> _operadora = new List<operadora>();
		public virtual IList<operadora> operadora
		{
			get
			{
				return this._operadora;
			}
		}
		
		private IList<ocupacion> _ocupacion = new List<ocupacion>();
		public virtual IList<ocupacion> ocupacion
		{
			get
			{
				return this._ocupacion;
			}
		}
		
		private IList<marca> _marca = new List<marca>();
		public virtual IList<marca> marca
		{
			get
			{
				return this._marca;
			}
		}
		
		private IList<escolaridad> _escolaridad = new List<escolaridad>();
		public virtual IList<escolaridad> escolaridad
		{
			get
			{
				return this._escolaridad;
			}
		}
		
		private IList<distribuidor> _distribuidor = new List<distribuidor>();
		public virtual IList<distribuidor> distribuidor
		{
			get
			{
				return this._distribuidor;
			}
		}
		
		private IList<categoria_transaccion> _categoria_transaccion = new List<categoria_transaccion>();
		public virtual IList<categoria_transaccion> categoria_transaccion
		{
			get
			{
				return this._categoria_transaccion;
			}
		}
		
		private IList<categoria_tipo_llamada> _categoria_tipo_llamada = new List<categoria_tipo_llamada>();
		public virtual IList<categoria_tipo_llamada> categoria_tipo_llamada
		{
			get
			{
				return this._categoria_tipo_llamada;
			}
		}
		
		private IList<categoria_producto> _categoria_producto = new List<categoria_producto>();
		public virtual IList<categoria_producto> categoria_producto
		{
			get
			{
				return this._categoria_producto;
			}
		}
		
		private IList<categoria_pasatiempos> _categoria_pasatiempos = new List<categoria_pasatiempos>();
		public virtual IList<categoria_pasatiempos> categoria_pasatiempos
		{
			get
			{
				return this._categoria_pasatiempos;
			}
		}
		
		private IList<estado_civil> _estado_civil = new List<estado_civil>();
		public virtual IList<estado_civil> estado_civil
		{
			get
			{
				return this._estado_civil;
			}
		}
		
		private IList<marca_premio> _marca_premio = new List<marca_premio>();
		public virtual IList<marca_premio> marca_premio
		{
			get
			{
				return this._marca_premio;
			}
		}
		
	}
}
#pragma warning restore 1591
