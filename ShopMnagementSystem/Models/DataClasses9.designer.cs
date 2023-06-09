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
	public partial class DataClasses9DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSaleAccount(SaleAccount instance);
    partial void UpdateSaleAccount(SaleAccount instance);
    partial void DeleteSaleAccount(SaleAccount instance);
    #endregion
		
		public DataClasses9DataContext() : 
				base(global::ShopMnagementSystem.Properties.Settings.Default.ShopManageConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses9DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses9DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses9DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses9DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SaleAccount> SaleAccounts
		{
			get
			{
				return this.GetTable<SaleAccount>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SaleAccount")]
	public partial class SaleAccount : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _Computer_Sale;
		
		private string _Load_Sale;
		
		private string _Biscuit_Tofee_Sale;
		
		private string _Name_Amount;
		
		private string _Jumma_Amount;
		
		private string _Baqaya_Amount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnComputer_SaleChanging(string value);
    partial void OnComputer_SaleChanged();
    partial void OnLoad_SaleChanging(string value);
    partial void OnLoad_SaleChanged();
    partial void OnBiscuit_Tofee_SaleChanging(string value);
    partial void OnBiscuit_Tofee_SaleChanged();
    partial void OnName_AmountChanging(string value);
    partial void OnName_AmountChanged();
    partial void OnJumma_AmountChanging(string value);
    partial void OnJumma_AmountChanged();
    partial void OnBaqaya_AmountChanging(string value);
    partial void OnBaqaya_AmountChanged();
    #endregion
		
		public SaleAccount()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Computer Sale]", Storage="_Computer_Sale", DbType="NVarChar(500)")]
		public string Computer_Sale
		{
			get
			{
				return this._Computer_Sale;
			}
			set
			{
				if ((this._Computer_Sale != value))
				{
					this.OnComputer_SaleChanging(value);
					this.SendPropertyChanging();
					this._Computer_Sale = value;
					this.SendPropertyChanged("Computer_Sale");
					this.OnComputer_SaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Load Sale]", Storage="_Load_Sale", DbType="NVarChar(200)")]
		public string Load_Sale
		{
			get
			{
				return this._Load_Sale;
			}
			set
			{
				if ((this._Load_Sale != value))
				{
					this.OnLoad_SaleChanging(value);
					this.SendPropertyChanging();
					this._Load_Sale = value;
					this.SendPropertyChanged("Load_Sale");
					this.OnLoad_SaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Biscuit Tofee Sale]", Storage="_Biscuit_Tofee_Sale", DbType="NVarChar(60)")]
		public string Biscuit_Tofee_Sale
		{
			get
			{
				return this._Biscuit_Tofee_Sale;
			}
			set
			{
				if ((this._Biscuit_Tofee_Sale != value))
				{
					this.OnBiscuit_Tofee_SaleChanging(value);
					this.SendPropertyChanging();
					this._Biscuit_Tofee_Sale = value;
					this.SendPropertyChanged("Biscuit_Tofee_Sale");
					this.OnBiscuit_Tofee_SaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Name Amount]", Storage="_Name_Amount", DbType="NVarChar(100)")]
		public string Name_Amount
		{
			get
			{
				return this._Name_Amount;
			}
			set
			{
				if ((this._Name_Amount != value))
				{
					this.OnName_AmountChanging(value);
					this.SendPropertyChanging();
					this._Name_Amount = value;
					this.SendPropertyChanged("Name_Amount");
					this.OnName_AmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Jumma Amount]", Storage="_Jumma_Amount", DbType="NVarChar(100)")]
		public string Jumma_Amount
		{
			get
			{
				return this._Jumma_Amount;
			}
			set
			{
				if ((this._Jumma_Amount != value))
				{
					this.OnJumma_AmountChanging(value);
					this.SendPropertyChanging();
					this._Jumma_Amount = value;
					this.SendPropertyChanged("Jumma_Amount");
					this.OnJumma_AmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Baqaya Amount]", Storage="_Baqaya_Amount", DbType="NVarChar(100)")]
		public string Baqaya_Amount
		{
			get
			{
				return this._Baqaya_Amount;
			}
			set
			{
				if ((this._Baqaya_Amount != value))
				{
					this.OnBaqaya_AmountChanging(value);
					this.SendPropertyChanging();
					this._Baqaya_Amount = value;
					this.SendPropertyChanged("Baqaya_Amount");
					this.OnBaqaya_AmountChanged();
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
