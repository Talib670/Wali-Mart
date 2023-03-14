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
	public partial class DataClasses19DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertcompanybarrow(companybarrow instance);
    partial void Updatecompanybarrow(companybarrow instance);
    partial void Deletecompanybarrow(companybarrow instance);
    #endregion
		
		public DataClasses19DataContext() : 
				base(global::ShopMnagementSystem.Properties.Settings.Default.ShopManageConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses19DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses19DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses19DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses19DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<companybarrow> companybarrows
		{
			get
			{
				return this.GetTable<companybarrow>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.companybarrow")]
	public partial class companybarrow : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _Company_Name;
		
		private string _Products_Details;
		
		private string _Name_Amount;
		
		private string _Jumma_Amount;
		
		private string _Bqaya_Amount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnCompany_NameChanging(string value);
    partial void OnCompany_NameChanged();
    partial void OnProducts_DetailsChanging(string value);
    partial void OnProducts_DetailsChanged();
    partial void OnName_AmountChanging(string value);
    partial void OnName_AmountChanged();
    partial void OnJumma_AmountChanging(string value);
    partial void OnJumma_AmountChanged();
    partial void OnBqaya_AmountChanging(string value);
    partial void OnBqaya_AmountChanged();
    #endregion
		
		public companybarrow()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Company Name]", Storage="_Company_Name", DbType="NVarChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Products Details]", Storage="_Products_Details", DbType="NVarChar(300)")]
		public string Products_Details
		{
			get
			{
				return this._Products_Details;
			}
			set
			{
				if ((this._Products_Details != value))
				{
					this.OnProducts_DetailsChanging(value);
					this.SendPropertyChanging();
					this._Products_Details = value;
					this.SendPropertyChanged("Products_Details");
					this.OnProducts_DetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Name Amount]", Storage="_Name_Amount", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Bqaya Amount]", Storage="_Bqaya_Amount", DbType="NVarChar(100)")]
		public string Bqaya_Amount
		{
			get
			{
				return this._Bqaya_Amount;
			}
			set
			{
				if ((this._Bqaya_Amount != value))
				{
					this.OnBqaya_AmountChanging(value);
					this.SendPropertyChanging();
					this._Bqaya_Amount = value;
					this.SendPropertyChanged("Bqaya_Amount");
					this.OnBqaya_AmountChanged();
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
