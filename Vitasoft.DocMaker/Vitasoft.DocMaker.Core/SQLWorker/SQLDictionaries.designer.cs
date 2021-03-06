﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vitasoft.DocMaker.Core.SQLWorker
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ORVD_TEST")]
	public partial class SQLDictionariesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public SQLDictionariesDataContext() : 
				base(global::Vitasoft.DocMaker.Core.Properties.Settings.Default.ORVD_TESTConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDictionariesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDictionariesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDictionariesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDictionariesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SqlObjectParameter> SqlObjectParameters
		{
			get
			{
				return this.GetTable<SqlObjectParameter>();
			}
		}
		
		public System.Data.Linq.Table<SqlObject> SqlObjects
		{
			get
			{
				return this.GetTable<SqlObject>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="[INFORMATION_SCHEMA].[PARAMETERS]")]
	public partial class SqlObjectParameter
	{
		
		private string _SPECIFIC_CATALOG;
		
		private string _SPECIFIC_SCHEMA;
		
		private string _SPECIFIC_NAME;
		
		private int _ORDINAL_POSITION;
		
		private string _PARAMETER_MODE;
		
		private string _IS_RESULT;
		
		private string _AS_LOCATOR;
		
		private string _PARAMETER_NAME;
		
		private string _DATA_TYPE;
		
		private System.Nullable<int> _CHARACTER_MAXIMUM_LENGTH;
		
		private System.Nullable<int> _CHARACTER_OCTET_LENGTH;
		
		private string _COLLATION_CATALOG;
		
		private string _COLLATION_SCHEMA;
		
		private string _COLLATION_NAME;
		
		private string _CHARACTER_SET_CATALOG;
		
		private string _CHARACTER_SET_SCHEMA;
		
		private string _CHARACTER_SET_NAME;
		
		private System.Nullable<byte> _NUMERIC_PRECISION;
		
		private System.Nullable<short> _NUMERIC_PRECISION_RADIX;
		
		private System.Nullable<int> _NUMERIC_SCALE;
		
		private System.Nullable<short> _DATETIME_PRECISION;
		
		private string _INTERVAL_TYPE;
		
		private System.Nullable<short> _INTERVAL_PRECISION;
		
		private string _USER_DEFINED_TYPE_CATALOG;
		
		private string _USER_DEFINED_TYPE_SCHEMA;
		
		private string _USER_DEFINED_TYPE_NAME;
		
		private string _SCOPE_CATALOG;
		
		private string _SCOPE_SCHEMA;
		
		private string _SCOPE_NAME;
		
		public SqlObjectParameter()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SPECIFIC_CATALOG", DbType="NVarChar(128)")]
		public string SPECIFIC_CATALOG
		{
			get
			{
				return this._SPECIFIC_CATALOG;
			}
			set
			{
				if ((this._SPECIFIC_CATALOG != value))
				{
					this._SPECIFIC_CATALOG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SPECIFIC_SCHEMA", DbType="NVarChar(128)")]
		public string SPECIFIC_SCHEMA
		{
			get
			{
				return this._SPECIFIC_SCHEMA;
			}
			set
			{
				if ((this._SPECIFIC_SCHEMA != value))
				{
					this._SPECIFIC_SCHEMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SPECIFIC_NAME", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string SPECIFIC_NAME
		{
			get
			{
				return this._SPECIFIC_NAME;
			}
			set
			{
				if ((this._SPECIFIC_NAME != value))
				{
					this._SPECIFIC_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ORDINAL_POSITION", DbType="Int NOT NULL")]
		public int ORDINAL_POSITION
		{
			get
			{
				return this._ORDINAL_POSITION;
			}
			set
			{
				if ((this._ORDINAL_POSITION != value))
				{
					this._ORDINAL_POSITION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PARAMETER_MODE", DbType="NVarChar(10)")]
		public string PARAMETER_MODE
		{
			get
			{
				return this._PARAMETER_MODE;
			}
			set
			{
				if ((this._PARAMETER_MODE != value))
				{
					this._PARAMETER_MODE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IS_RESULT", DbType="NVarChar(10)")]
		public string IS_RESULT
		{
			get
			{
				return this._IS_RESULT;
			}
			set
			{
				if ((this._IS_RESULT != value))
				{
					this._IS_RESULT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AS_LOCATOR", DbType="NVarChar(10)")]
		public string AS_LOCATOR
		{
			get
			{
				return this._AS_LOCATOR;
			}
			set
			{
				if ((this._AS_LOCATOR != value))
				{
					this._AS_LOCATOR = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PARAMETER_NAME", DbType="NVarChar(128)")]
		public string PARAMETER_NAME
		{
			get
			{
				return this._PARAMETER_NAME;
			}
			set
			{
				if ((this._PARAMETER_NAME != value))
				{
					this._PARAMETER_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DATA_TYPE", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string DATA_TYPE
		{
			get
			{
				return this._DATA_TYPE;
			}
			set
			{
				if ((this._DATA_TYPE != value))
				{
					this._DATA_TYPE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHARACTER_MAXIMUM_LENGTH", DbType="Int")]
		public System.Nullable<int> CHARACTER_MAXIMUM_LENGTH
		{
			get
			{
				return this._CHARACTER_MAXIMUM_LENGTH;
			}
			set
			{
				if ((this._CHARACTER_MAXIMUM_LENGTH != value))
				{
					this._CHARACTER_MAXIMUM_LENGTH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHARACTER_OCTET_LENGTH", DbType="Int")]
		public System.Nullable<int> CHARACTER_OCTET_LENGTH
		{
			get
			{
				return this._CHARACTER_OCTET_LENGTH;
			}
			set
			{
				if ((this._CHARACTER_OCTET_LENGTH != value))
				{
					this._CHARACTER_OCTET_LENGTH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COLLATION_CATALOG", DbType="NVarChar(128)")]
		public string COLLATION_CATALOG
		{
			get
			{
				return this._COLLATION_CATALOG;
			}
			set
			{
				if ((this._COLLATION_CATALOG != value))
				{
					this._COLLATION_CATALOG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COLLATION_SCHEMA", DbType="NVarChar(128)")]
		public string COLLATION_SCHEMA
		{
			get
			{
				return this._COLLATION_SCHEMA;
			}
			set
			{
				if ((this._COLLATION_SCHEMA != value))
				{
					this._COLLATION_SCHEMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COLLATION_NAME", DbType="NVarChar(128)")]
		public string COLLATION_NAME
		{
			get
			{
				return this._COLLATION_NAME;
			}
			set
			{
				if ((this._COLLATION_NAME != value))
				{
					this._COLLATION_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHARACTER_SET_CATALOG", DbType="NVarChar(128)")]
		public string CHARACTER_SET_CATALOG
		{
			get
			{
				return this._CHARACTER_SET_CATALOG;
			}
			set
			{
				if ((this._CHARACTER_SET_CATALOG != value))
				{
					this._CHARACTER_SET_CATALOG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHARACTER_SET_SCHEMA", DbType="NVarChar(128)")]
		public string CHARACTER_SET_SCHEMA
		{
			get
			{
				return this._CHARACTER_SET_SCHEMA;
			}
			set
			{
				if ((this._CHARACTER_SET_SCHEMA != value))
				{
					this._CHARACTER_SET_SCHEMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHARACTER_SET_NAME", DbType="NVarChar(128)")]
		public string CHARACTER_SET_NAME
		{
			get
			{
				return this._CHARACTER_SET_NAME;
			}
			set
			{
				if ((this._CHARACTER_SET_NAME != value))
				{
					this._CHARACTER_SET_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NUMERIC_PRECISION", DbType="TinyInt")]
		public System.Nullable<byte> NUMERIC_PRECISION
		{
			get
			{
				return this._NUMERIC_PRECISION;
			}
			set
			{
				if ((this._NUMERIC_PRECISION != value))
				{
					this._NUMERIC_PRECISION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NUMERIC_PRECISION_RADIX", DbType="SmallInt")]
		public System.Nullable<short> NUMERIC_PRECISION_RADIX
		{
			get
			{
				return this._NUMERIC_PRECISION_RADIX;
			}
			set
			{
				if ((this._NUMERIC_PRECISION_RADIX != value))
				{
					this._NUMERIC_PRECISION_RADIX = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NUMERIC_SCALE", DbType="Int")]
		public System.Nullable<int> NUMERIC_SCALE
		{
			get
			{
				return this._NUMERIC_SCALE;
			}
			set
			{
				if ((this._NUMERIC_SCALE != value))
				{
					this._NUMERIC_SCALE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DATETIME_PRECISION", DbType="SmallInt")]
		public System.Nullable<short> DATETIME_PRECISION
		{
			get
			{
				return this._DATETIME_PRECISION;
			}
			set
			{
				if ((this._DATETIME_PRECISION != value))
				{
					this._DATETIME_PRECISION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INTERVAL_TYPE", DbType="NVarChar(30)")]
		public string INTERVAL_TYPE
		{
			get
			{
				return this._INTERVAL_TYPE;
			}
			set
			{
				if ((this._INTERVAL_TYPE != value))
				{
					this._INTERVAL_TYPE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INTERVAL_PRECISION", DbType="SmallInt")]
		public System.Nullable<short> INTERVAL_PRECISION
		{
			get
			{
				return this._INTERVAL_PRECISION;
			}
			set
			{
				if ((this._INTERVAL_PRECISION != value))
				{
					this._INTERVAL_PRECISION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_DEFINED_TYPE_CATALOG", DbType="NVarChar(128)")]
		public string USER_DEFINED_TYPE_CATALOG
		{
			get
			{
				return this._USER_DEFINED_TYPE_CATALOG;
			}
			set
			{
				if ((this._USER_DEFINED_TYPE_CATALOG != value))
				{
					this._USER_DEFINED_TYPE_CATALOG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_DEFINED_TYPE_SCHEMA", DbType="NVarChar(128)")]
		public string USER_DEFINED_TYPE_SCHEMA
		{
			get
			{
				return this._USER_DEFINED_TYPE_SCHEMA;
			}
			set
			{
				if ((this._USER_DEFINED_TYPE_SCHEMA != value))
				{
					this._USER_DEFINED_TYPE_SCHEMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_DEFINED_TYPE_NAME", DbType="NVarChar(128)")]
		public string USER_DEFINED_TYPE_NAME
		{
			get
			{
				return this._USER_DEFINED_TYPE_NAME;
			}
			set
			{
				if ((this._USER_DEFINED_TYPE_NAME != value))
				{
					this._USER_DEFINED_TYPE_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SCOPE_CATALOG", DbType="NVarChar(128)")]
		public string SCOPE_CATALOG
		{
			get
			{
				return this._SCOPE_CATALOG;
			}
			set
			{
				if ((this._SCOPE_CATALOG != value))
				{
					this._SCOPE_CATALOG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SCOPE_SCHEMA", DbType="NVarChar(128)")]
		public string SCOPE_SCHEMA
		{
			get
			{
				return this._SCOPE_SCHEMA;
			}
			set
			{
				if ((this._SCOPE_SCHEMA != value))
				{
					this._SCOPE_SCHEMA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SCOPE_NAME", DbType="NVarChar(128)")]
		public string SCOPE_NAME
		{
			get
			{
				return this._SCOPE_NAME;
			}
			set
			{
				if ((this._SCOPE_NAME != value))
				{
					this._SCOPE_NAME = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="[sys].[objects]")]
	public partial class SqlObject
	{
		
		private string _name;
		
		private int _object_id;
		
		private System.Nullable<int> _principal_id;
		
		private int _schema_id;
		
		private int _parent_object_id;
		
		private string _type;
		
		private string _type_desc;
		
		private System.DateTime _create_date;
		
		private System.DateTime _modify_date;
		
		private bool _is_ms_shipped;
		
		private bool _is_published;
		
		private bool _is_schema_published;
		
		public SqlObject()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_object_id", DbType="Int NOT NULL")]
		public int object_id
		{
			get
			{
				return this._object_id;
			}
			set
			{
				if ((this._object_id != value))
				{
					this._object_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_principal_id", DbType="Int")]
		public System.Nullable<int> principal_id
		{
			get
			{
				return this._principal_id;
			}
			set
			{
				if ((this._principal_id != value))
				{
					this._principal_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_schema_id", DbType="Int NOT NULL")]
		public int schema_id
		{
			get
			{
				return this._schema_id;
			}
			set
			{
				if ((this._schema_id != value))
				{
					this._schema_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parent_object_id", DbType="Int NOT NULL")]
		public int parent_object_id
		{
			get
			{
				return this._parent_object_id;
			}
			set
			{
				if ((this._parent_object_id != value))
				{
					this._parent_object_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="Char(2) NOT NULL", CanBeNull=false)]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this._type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type_desc", DbType="NVarChar(60)")]
		public string type_desc
		{
			get
			{
				return this._type_desc;
			}
			set
			{
				if ((this._type_desc != value))
				{
					this._type_desc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_create_date", DbType="DateTime NOT NULL")]
		public System.DateTime create_date
		{
			get
			{
				return this._create_date;
			}
			set
			{
				if ((this._create_date != value))
				{
					this._create_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_modify_date", DbType="DateTime NOT NULL")]
		public System.DateTime modify_date
		{
			get
			{
				return this._modify_date;
			}
			set
			{
				if ((this._modify_date != value))
				{
					this._modify_date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_ms_shipped", DbType="Bit NOT NULL")]
		public bool is_ms_shipped
		{
			get
			{
				return this._is_ms_shipped;
			}
			set
			{
				if ((this._is_ms_shipped != value))
				{
					this._is_ms_shipped = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_published", DbType="Bit NOT NULL")]
		public bool is_published
		{
			get
			{
				return this._is_published;
			}
			set
			{
				if ((this._is_published != value))
				{
					this._is_published = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_schema_published", DbType="Bit NOT NULL")]
		public bool is_schema_published
		{
			get
			{
				return this._is_schema_published;
			}
			set
			{
				if ((this._is_schema_published != value))
				{
					this._is_schema_published = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
