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
	public partial class programa_carrusel
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
		
		private long _programa_id;
		public virtual long programa_id
		{
			get
			{
				return this._programa_id;
			}
			set
			{
				this._programa_id = value;
			}
		}
		
		private byte? _orden;
		public virtual byte? orden
		{
			get
			{
				return this._orden;
			}
			set
			{
				this._orden = value;
			}
		}
		
		private byte[] _imagen_carrusel;
		public virtual byte[] imagen_carrusel
		{
			get
			{
				return this._imagen_carrusel;
			}
			set
			{
				this._imagen_carrusel = value;
			}
		}
		
		private string _url_imagen;
		public virtual string url_imagen
		{
			get
			{
				return this._url_imagen;
			}
			set
			{
				this._url_imagen = value;
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
		
		private DateTime? _fecha_inicio_vigencia;
		public virtual DateTime? fecha_inicio_vigencia
		{
			get
			{
				return this._fecha_inicio_vigencia;
			}
			set
			{
				this._fecha_inicio_vigencia = value;
			}
		}
		
		private DateTime? _fecha_fin_vigencia;
		public virtual DateTime? fecha_fin_vigencia
		{
			get
			{
				return this._fecha_fin_vigencia;
			}
			set
			{
				this._fecha_fin_vigencia = value;
			}
		}
		
		private programa _programa;
		public virtual programa programa
		{
			get
			{
				return this._programa;
			}
			set
			{
				this._programa = value;
			}
		}
		
	}
}
#pragma warning restore 1591
