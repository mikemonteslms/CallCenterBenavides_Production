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
	public partial class mecanica
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
		
		private long? _marca_id;
		public virtual long? marca_id
		{
			get
			{
				return this._marca_id;
			}
			set
			{
				this._marca_id = value;
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
		
		private string _nombre_contacto;
		public virtual string nombre_contacto
		{
			get
			{
				return this._nombre_contacto;
			}
			set
			{
				this._nombre_contacto = value;
			}
		}
		
		private string _correo_electronico;
		public virtual string correo_electronico
		{
			get
			{
				return this._correo_electronico;
			}
			set
			{
				this._correo_electronico = value;
			}
		}
		
		private string _telefono;
		public virtual string telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				this._telefono = value;
			}
		}
		
		private string _url_imagen_large;
		public virtual string url_imagen_large
		{
			get
			{
				return this._url_imagen_large;
			}
			set
			{
				this._url_imagen_large = value;
			}
		}
		
		private string _url_imagen_small;
		public virtual string url_imagen_small
		{
			get
			{
				return this._url_imagen_small;
			}
			set
			{
				this._url_imagen_small = value;
			}
		}
		
		private int? _orden;
		public virtual int? orden
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
		
		private string _legales;
		public virtual string legales
		{
			get
			{
				return this._legales;
			}
			set
			{
				this._legales = value;
			}
		}
		
		private marca _marca;
		public virtual marca marca
		{
			get
			{
				return this._marca;
			}
			set
			{
				this._marca = value;
			}
		}
		
	}
}
#pragma warning restore 1591
