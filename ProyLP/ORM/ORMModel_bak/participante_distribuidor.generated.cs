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
	public partial class participante_distribuidor
	{
		private int _id;
		public virtual int id
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
		
		private long _participante_id;
		public virtual long participante_id
		{
			get
			{
				return this._participante_id;
			}
			set
			{
				this._participante_id = value;
			}
		}
		
		private long _distribuidor_id;
		public virtual long distribuidor_id
		{
			get
			{
				return this._distribuidor_id;
			}
			set
			{
				this._distribuidor_id = value;
			}
		}
		
		private distribuidor _distribuidor;
		public virtual distribuidor distribuidor
		{
			get
			{
				return this._distribuidor;
			}
			set
			{
				this._distribuidor = value;
			}
		}
		
		private participante _participante;
		public virtual participante participante
		{
			get
			{
				return this._participante;
			}
			set
			{
				this._participante = value;
			}
		}
		
	}
}
#pragma warning restore 1591
