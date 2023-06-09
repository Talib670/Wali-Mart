﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopMnagementSystem.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ShopManage")]
	public partial class DataClasses3DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblSoldProduct(tblSoldProduct instance);
    partial void UpdatetblSoldProduct(tblSoldProduct instance);
    partial void DeletetblSoldProduct(tblSoldProduct instance);
    #endregion
		
		public DataClasses3DataContext() : 
				base(global::ShopMnagementSystem.Properties.Settings.Default.ShopManageConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses3DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses3DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses3DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses3DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblSoldProduct> tblSoldProducts
		{
			get
			{
				return this.GetTable<tblSoldProduct>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblSoldProduct")]
	public partial class tblSoldProduct : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Product_Name;
		
		private string _Price;
		
		private string _Quantity;
		
		private string _Grand_Price;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _Sale_Man;
		
		private string _Invoice_Num;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnProduct_NameChanging(string value);
    partial void OnProduct_NameChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(string value);
    partial void OnQuantityChanged();
    partial void OnGrand_PriceChanging(string value);
    partial void OnGrand_PriceChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnSale_ManChanging(string value);
    partial void OnSale_ManChanged();
    partial void OnInvoice_NumChanging(string value);
    partial void OnInvoice_NumChanged();
    #endregion
		
		public tblSoldProduct()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Product Name]", Storage="_Product_Name", DbType="VarChar(150)")]
		public string Product_Name
		{
			get
			{
				return this._Product_Name;
			}
			set
			{
				if ((this._Product_Name != value))
				{
					this.OnProduct_NameChanging(value);
					this.SendPropertyChanging();
					this._Product_Name = value;
					this.SendPropertyChanged("Product_Name");
					this.OnProduct_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="VarChar(50)")]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="VarChar(50)")]
		public string Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Grand Price]", Storage="_Grand_Price", DbType="NVarChar(150)")]
		public string Grand_Price
		{
			get
			{
				return this._Grand_Price;
			}
			set
			{
				if ((this._Grand_Price != value))
				{
					this.OnGrand_PriceChanging(value);
					this.SendPropertyChanging();
					this._Grand_Price = value;
					this.SendPropertyChanged("Grand_Price");
					this.OnGrand_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Sale Man]", Storage="_Sale_Man", DbType="VarChar(150)")]
		public string Sale_Man
		{
			get
			{
				return this._Sale_Man;
			}
			set
			{
				if ((this._Sale_Man != value))
				{
					this.OnSale_ManChanging(value);
					this.SendPropertyChanging();
					this._Sale_Man = value;
					this.SendPropertyChanged("Sale_Man");
					this.OnSale_ManChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Invoice Num]", Storage="_Invoice_Num", DbType="VarChar(50)")]
		public string Invoice_Num
		{
			get
			{
				return this._Invoice_Num;
			}
			set
			{
				if ((this._Invoice_Num != value))
				{
					this.OnInvoice_NumChanging(value);
					this.SendPropertyChanging();
					this._Invoice_Num = value;
					this.SendPropertyChanged("Invoice_Num");
					this.OnInvoice_NumChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
