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
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttblproduct(tblproduct instance);
    partial void Updatetblproduct(tblproduct instance);
    partial void Deletetblproduct(tblproduct instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::ShopMnagementSystem.Properties.Settings.Default.ShopManageConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblproduct> tblproducts
		{
			get
			{
				return this.GetTable<tblproduct>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblproducts")]
	public partial class tblproduct : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Products;
		
		private string _Price;
		
		private string _Quantity;
		
		private string _Catagary;
		
		private string _Barcode;
		
		private string _Buy_Price;
		
		private string _Company_Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnProductsChanging(string value);
    partial void OnProductsChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(string value);
    partial void OnQuantityChanged();
    partial void OnCatagaryChanging(string value);
    partial void OnCatagaryChanged();
    partial void OnBarcodeChanging(string value);
    partial void OnBarcodeChanged();
    partial void OnBuy_PriceChanging(string value);
    partial void OnBuy_PriceChanged();
    partial void OnCompany_NameChanging(string value);
    partial void OnCompany_NameChanged();
    #endregion
		
		public tblproduct()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Products", DbType="NVarChar(150)")]
		public string Products
		{
			get
			{
				return this._Products;
			}
			set
			{
				if ((this._Products != value))
				{
					this.OnProductsChanging(value);
					this.SendPropertyChanging();
					this._Products = value;
					this.SendPropertyChanged("Products");
					this.OnProductsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Catagary", DbType="VarChar(150)")]
		public string Catagary
		{
			get
			{
				return this._Catagary;
			}
			set
			{
				if ((this._Catagary != value))
				{
					this.OnCatagaryChanging(value);
					this.SendPropertyChanging();
					this._Catagary = value;
					this.SendPropertyChanged("Catagary");
					this.OnCatagaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Barcode", DbType="VarChar(100)")]
		public string Barcode
		{
			get
			{
				return this._Barcode;
			}
			set
			{
				if ((this._Barcode != value))
				{
					this.OnBarcodeChanging(value);
					this.SendPropertyChanging();
					this._Barcode = value;
					this.SendPropertyChanged("Barcode");
					this.OnBarcodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Buy Price]", Storage="_Buy_Price", DbType="VarChar(100)")]
		public string Buy_Price
		{
			get
			{
				return this._Buy_Price;
			}
			set
			{
				if ((this._Buy_Price != value))
				{
					this.OnBuy_PriceChanging(value);
					this.SendPropertyChanging();
					this._Buy_Price = value;
					this.SendPropertyChanged("Buy_Price");
					this.OnBuy_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Company Name]", Storage="_Company_Name", DbType="VarChar(500)")]
		public string Company_Name
		{
			get
			{
				return this._Company_Name;
			}
			set
			{
				if ((this._Company_Name != value))
				{
					this.OnCompany_NameChanging(value);
					this.SendPropertyChanging();
					this._Company_Name = value;
					this.SendPropertyChanged("Company_Name");
					this.OnCompany_NameChanged();
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
