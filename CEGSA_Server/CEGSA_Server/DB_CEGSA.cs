﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.4927
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



public partial class DB_CEGSA : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertSession(Session instance);
  partial void UpdateSession(Session instance);
  partial void DeleteSession(Session instance);
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  #endregion
	
	public DB_CEGSA(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DB_CEGSA(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DB_CEGSA(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DB_CEGSA(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Session> Session
	{
		get
		{
			return this.GetTable<Session>();
		}
	}
	
	public System.Data.Linq.Table<User> User
	{
		get
		{
			return this.GetTable<User>();
		}
	}
}

[Table(Name="dbo.Session")]
public partial class Session : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _S;
	
	private string _E;
	
	private string _G;
	
	private string _P;
	
	private string _Y;
	
	private string _Q;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnSChanging(string value);
    partial void OnSChanged();
    partial void OnEChanging(string value);
    partial void OnEChanged();
    partial void OnGChanging(string value);
    partial void OnGChanged();
    partial void OnPChanging(string value);
    partial void OnPChanged();
    partial void OnYChanging(string value);
    partial void OnYChanged();
    partial void OnQChanging(string value);
    partial void OnQChanged();
    #endregion
	
	public Session()
	{
		OnCreated();
	}
	
	[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_S", DbType="VarChar(256)")]
	public string S
	{
		get
		{
			return this._S;
		}
		set
		{
			if ((this._S != value))
			{
				this.OnSChanging(value);
				this.SendPropertyChanging();
				this._S = value;
				this.SendPropertyChanged("S");
				this.OnSChanged();
			}
		}
	}
	
	[Column(Storage="_E", DbType="VarChar(256)")]
	public string E
	{
		get
		{
			return this._E;
		}
		set
		{
			if ((this._E != value))
			{
				this.OnEChanging(value);
				this.SendPropertyChanging();
				this._E = value;
				this.SendPropertyChanged("E");
				this.OnEChanged();
			}
		}
	}
	
	[Column(Name="g", Storage="_G", DbType="VarChar(1024)")]
	public string G
	{
		get
		{
			return this._G;
		}
		set
		{
			if ((this._G != value))
			{
				this.OnGChanging(value);
				this.SendPropertyChanging();
				this._G = value;
				this.SendPropertyChanged("G");
				this.OnGChanged();
			}
		}
	}
	
	[Column(Name="p", Storage="_P", DbType="VarChar(1024)")]
	public string P
	{
		get
		{
			return this._P;
		}
		set
		{
			if ((this._P != value))
			{
				this.OnPChanging(value);
				this.SendPropertyChanging();
				this._P = value;
				this.SendPropertyChanged("P");
				this.OnPChanged();
			}
		}
	}
	
	[Column(Name="y", Storage="_Y", DbType="VarChar(1024)")]
	public string Y
	{
		get
		{
			return this._Y;
		}
		set
		{
			if ((this._Y != value))
			{
				this.OnYChanging(value);
				this.SendPropertyChanging();
				this._Y = value;
				this.SendPropertyChanged("Y");
				this.OnYChanged();
			}
		}
	}
	
	[Column(Name="q", Storage="_Q", DbType="VarChar(256)")]
	public string Q
	{
		get
		{
			return this._Q;
		}
		set
		{
			if ((this._Q != value))
			{
				this.OnQChanging(value);
				this.SendPropertyChanging();
				this._Q = value;
				this.SendPropertyChanged("Q");
				this.OnQChanged();
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

[Table(Name="dbo.User")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID_user;
	
	private string _Login;
	
	private string _Password;
	
	private string _Fio;
	
	private System.Nullable<bool> _Admin;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_userChanging(int value);
    partial void OnID_userChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnFioChanging(string value);
    partial void OnFioChanged();
    partial void OnAdminChanging(System.Nullable<bool> value);
    partial void OnAdminChanged();
    #endregion
	
	public User()
	{
		OnCreated();
	}
	
	[Column(Storage="_ID_user", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID_user
	{
		get
		{
			return this._ID_user;
		}
		set
		{
			if ((this._ID_user != value))
			{
				this.OnID_userChanging(value);
				this.SendPropertyChanging();
				this._ID_user = value;
				this.SendPropertyChanged("ID_user");
				this.OnID_userChanged();
			}
		}
	}
	
	[Column(Storage="_Login", DbType="VarChar(20)")]
	public string Login
	{
		get
		{
			return this._Login;
		}
		set
		{
			if ((this._Login != value))
			{
				this.OnLoginChanging(value);
				this.SendPropertyChanging();
				this._Login = value;
				this.SendPropertyChanged("Login");
				this.OnLoginChanged();
			}
		}
	}
	
	[Column(Storage="_Password", DbType="VarChar(64)")]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[Column(Storage="_Fio", DbType="VarChar(60)")]
	public string Fio
	{
		get
		{
			return this._Fio;
		}
		set
		{
			if ((this._Fio != value))
			{
				this.OnFioChanging(value);
				this.SendPropertyChanging();
				this._Fio = value;
				this.SendPropertyChanged("Fio");
				this.OnFioChanged();
			}
		}
	}
	
	[Column(Storage="_Admin", DbType="Bit")]
	public System.Nullable<bool> Admin
	{
		get
		{
			return this._Admin;
		}
		set
		{
			if ((this._Admin != value))
			{
				this.OnAdminChanging(value);
				this.SendPropertyChanging();
				this._Admin = value;
				this.SendPropertyChanged("Admin");
				this.OnAdminChanged();
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
#pragma warning restore 1591
