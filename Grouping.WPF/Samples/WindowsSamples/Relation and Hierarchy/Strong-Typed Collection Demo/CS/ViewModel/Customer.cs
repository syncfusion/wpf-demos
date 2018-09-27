#region Copyright Syncfusion Inc. 2001 - 2006
//
//  Copyright Syncfusion Inc. 2001 - 2006. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;

using Syncfusion.ComponentModel;
using Syncfusion.Drawing;
using Syncfusion.Styles;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace StrongTypedCollectionSample
{
	public class PopulateCustomers
	{
		public static CustomerCollection CreateCustomers() 
		{
			CustomerCollection customers = new CustomerCollection();
			Customer cust1 = ReadCustomer1();
			cust1.Children.Add(ReadCustomer3());
			cust1.Children.Add(ReadCustomer4());
			customers.Add(cust1);
			Customer cust2 = ReadCustomer2();
			cust2.Children.Add(ReadCustomer5());
			
			customers.Add(cust2);
			return customers;
		}

		// Worker functions to populate the list with data.
		private static Customer ReadCustomer1() 
		{
			Customer cust = new Customer("536-45-1245");
			cust.FirstName = "Jo";
			cust.LastName = "Brown";
			return cust;
		}
        
		private static Customer ReadCustomer2() 
		{
			Customer cust = new Customer("246-12-5645");
			cust.FirstName = "Robert";
			cust.LastName = "Brown";
			return cust;
		}

		private static Customer ReadCustomer3() 
		{
			Customer cust = new Customer("537-45-1245");
			cust.FirstName = "Keith";
			cust.LastName = "Brown";
			return cust;
		}
        
		private static Customer ReadCustomer4() 
		{
			Customer cust = new Customer("247-12-5645");
			cust.FirstName = "Sven";
			cust.LastName = "Brown";
			return cust;
		}
	
		private static Customer ReadCustomer5() 
		{
			Customer cust = new Customer("538-45-1245");
			cust.FirstName = "Katie";
			cust.LastName = "Brown";
			return cust;
		}
        
		private static Customer ReadCustomer6() 
		{
			Customer cust = new Customer("248-12-5645");
			cust.FirstName = "Steve";
			cust.LastName = "Brown";
			return cust;
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Customer : IEditableObject 
	{
		struct CustomerData 
		{
			internal string id;
			internal string firstName ;
			internal string lastName ;
		}
        
		#region Fields

		private CustomerCollection _parentCollection;
		private CustomerCollection _children = new CustomerCollection();
		private CustomerData custData; 
		private CustomerData backupData; 
		private bool beginEditCalled = false;
		private bool modified = false;
		private IEditableObject _forwardEditableObject;

		#endregion

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}
		
		/// <summary>
		/// Raises PropertyChanged event
		/// </summary>
		/// <param name="propertyName"></param>
		void RaisePropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

			if (!this.beginEditCalled)
			{
				if (_parentCollection != null)
					_parentCollection.NotifyItemPropertyChanged(this, propertyName);
			}
			else
				modified = true;
		}
		
		#endregion 

		#region ctor

		/// <summary>
		/// Default ctor needed for Xml and CodeDom serialization of strong-typed collections and
		/// for Essential Grid to be able to detect properties of items in strong-typed collections.
		/// </summary>
		public Customer()
		{
			this.custData = new CustomerData();
			this.custData.id = "";
			this.custData.firstName = "";
			this.custData.lastName = "";
		}

		/// <summary>
		/// Specialized ctor
		/// </summary>
		/// <param name="ID"></param>
		public Customer(string ID)
		{
			this.custData = new CustomerData();
			this.custData.id = ID;
			this.custData.firstName = "";
			this.custData.lastName = "";
		}

		#endregion 

		#region IEditableObject implementation

		// lets ParentCollection collection be aware of status (used when AddNew was called).
		[Browsable(false)]
		public IEditableObject ForwardEditableObject
		{
			get
			{
				return this._forwardEditableObject;
			}
			set
			{
				this._forwardEditableObject = value;
			}
		}

		public void BeginEdit() 
		{
			if (!beginEditCalled) 
			{
				this.backupData = custData;
				beginEditCalled = true;
				Console.WriteLine("BeginEdit - " + this.backupData.lastName);
				if (ForwardEditableObject != null)
					ForwardEditableObject.BeginEdit();
				modified = false;
			}
		}

		public void CancelEdit() 
		{
			if (beginEditCalled) 
			{
				this.custData = backupData;
				beginEditCalled = false;
				Console.WriteLine("CancelEdit - " + this.custData.lastName);
				if (ForwardEditableObject != null)
					ForwardEditableObject.CancelEdit();
				modified = false;
			}
		}

		public void EndEdit() 
		{
			if (beginEditCalled) 
			{
				backupData = new CustomerData();
				beginEditCalled = false;
				Console.WriteLine("Done EndEdit - " + this.custData.id + this.custData.lastName);
				if (ForwardEditableObject != null)
					ForwardEditableObject.EndEdit();

				if (ParentCollection != null && modified)
					this.ParentCollection.RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, ParentCollection.IndexOf(this), -1));
				modified = false;
			}
		}

	
		[Browsable(false)]
		public bool IsBeginEditCalled
		{
			get
			{
				return this.beginEditCalled;
			}
		}

		#endregion

		#region Properties

		[Browsable(true)]
		public string ID 
		{
			get 
			{
				return this.custData.id;
			}
			set
			{
				if (ID != value)
				{
					this.custData.id = value;
					RaisePropertyChanged("ID");
				}
			}
		}
        
		[Browsable(true)]
		public string FirstName 
		{
			get 
			{
				return this.custData.firstName;
			}
			set 
			{
				if (FirstName != value)
				{
					this.custData.firstName = value;
					RaisePropertyChanged("FirstName");
				}
			}
		}
             
		[Browsable(true)]
		public string LastName 
		{
			get 
			{
				return this.custData.lastName;
			}
			set 
			{
				if (LastName != value)
				{
					this.custData.lastName = value;
					RaisePropertyChanged("LastName");
				}
			}
		}
       
		[Browsable(true)]
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
		public CustomerCollection Children 
		{
			get 
			{
				return _children;
			}
			set 
			{
				if (!Object.ReferenceEquals(Children, value))
				{
					_children = value;
					RaisePropertyChanged("Children");
				}
			}
		}

		public bool ShouldSerializeChildren()
		{
			return _children != null && _children.Count > 0;
		}

		[Browsable(false)] // do not show as field in grid
		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
		public CustomerCollection ParentCollection 
		{
			get 
			{
				return _parentCollection;
			}
			set 
			{
				_parentCollection = value;
			}
		}

		public bool ShouldSerializeParentCollection()
		{
			return false;
		}

		#endregion
	}

	public class CustomerCollection : IList, IBindingList
	{
		ArrayList inner = new ArrayList();

		public CustomerCollection()
		{
		}

		public override string ToString()
		{
			return GetType().Name.ToString() + "{ " + String.Format("Count {0}", Count) + " }";
		}

		public Customer this[int index]
		{
			get
			{
				return (Customer) inner[index];
			}
			set
			{
				if (!Object.ReferenceEquals(inner[index], value))
				{
					inner[index] = value;
					value.ParentCollection = this;
					RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index, index));
				}
			}
		}

		public bool Contains(Customer value)
		{
			if (value == null)
				return false;

			return inner.Contains(value);
		}

		public int IndexOf(Customer value)
		{
			return inner.IndexOf(value);
		}

		public void CopyTo(Customer[] array, int index)
		{
			int count = Count;
			for (int n = 0; n < count; n++)
				array[index+n] = this[n];
		}

		public CustomerCollection SyncRoot
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public CustomerCollectionEnumerator GetEnumerator()
		{
			return new CustomerCollectionEnumerator(this);
		}
		
		public void Insert(int index, Customer value)
		{
			inner.Insert(index, value);
			value.ParentCollection = this;
			RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index, -1));
		}
	
		public void Remove(Customer value)
		{
			int index = IndexOf(value);
			RemoveAt(index);
		}
		
		public int Add(Customer value)
		{
			int index = inner.Add(value);
			value.ParentCollection = this;
			RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index, -1));
			return index;
		}

		public void RemoveAt(int index)
		{
			inner.RemoveAt(index);
			RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index, -1));
		}

		public void Clear()
		{
			if (inner.Count > 0)
			{
				inner.Clear();
				RaiseListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1, -1));
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public int Count
		{
			get
			{
				return inner.Count;
			}
		}


		public void NotifyItemPropertyChanged(Customer item, string propertyName)
		{
			this.RaiseListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf(item), -1));
		}

		#region IList Private Members

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (Customer) value;
			}
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (Customer) value);
		}

		void IList.Remove(object value)
		{
			Remove((Customer) value);
		}

		bool IList.Contains(object value)
		{
			return Contains((Customer) value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((Customer) value);
		}

		int IList.Add(object value)
		{
			return Add((Customer) value);
		}

		#endregion

		#region ICollection Private Members

		void ICollection.CopyTo(Array array, int index)
		{
			CopyTo((Customer[]) array, index);
		}

		object ICollection.SyncRoot
		{
			get
			{
				return null;
			}
		}

		#endregion

		#region IEnumerable Private Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region IBindingList Members

		// Implements IBindingList.
		public bool AllowEdit 
		{ 
			get { return true ; }
		}

		public bool AllowNew 
		{ 
			get { return true ; }
		}

		public bool AllowRemove 
		{ 
			get { return true ; }
		}

		public bool SupportsChangeNotification 
		{ 
			get { return true ; }
		}
        
		public bool SupportsSearching 
		{ 
			get { return false ; }
		}

		public bool SupportsSorting 
		{ 
			get { return false ; }
		}


		// Events.
		
		public event ListChangedEventHandler ListChanged;
		
		protected virtual void OnListChanged(ListChangedEventArgs e)
		{
			if (ListChanged != null)
				ListChanged(this, e);
		}
		
		public void RaiseListChanged(ListChangedEventArgs e)
		{
			OnListChanged(e);
		}
		
		// Methods.

		public Customer AddNew()
		{
			Customer c = new Customer(this.Count.ToString());
			new AddNewObjectListener(this, c, Add(c));
			return c;
		}

		object IBindingList.AddNew() 
		{
			return AddNew();
		}

		public class AddNewObjectListener : IEditableObject	
		{
			CustomerCollection customers;
			Customer item;
			int index;

			public AddNewObjectListener(CustomerCollection customers, Customer item, int index)
			{
				this.customers = customers;
				this.item = item;
				this.index = index;
				item.ForwardEditableObject = this;
			}

			public void Detach()
			{
				item.ForwardEditableObject = null;
				customers = null;
				item = null;
			}

			#region IEditableObject Members

			public void EndEdit()
			{
				

				Detach();
			}

			public void CancelEdit()
			{
				// When a AddNew operation is canceld by the user the object needs to be removed again from
				// the list.
				customers.RemoveAt(index);

				Detach();
			}

			public void BeginEdit()
			{
			}

			#endregion
		}

		// Unsupported properties.
		bool IBindingList.IsSorted 
		{ 
			get { throw new NotSupportedException(); }
		}

		ListSortDirection IBindingList.SortDirection 
		{ 
			get { throw new NotSupportedException(); }
		}


		PropertyDescriptor IBindingList.SortProperty 
		{ 
			get { throw new NotSupportedException(); }
		}

		// Unsupported Methods.
		void IBindingList.AddIndex(PropertyDescriptor property) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) 
		{
			throw new NotSupportedException(); 
		}

		int IBindingList.Find(PropertyDescriptor property, object key) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveSort() 
		{
			throw new NotSupportedException(); 
		}

		#endregion

	}

	public class CustomerCollectionEnumerator : IEnumerator 
	{
		int _cursor = -1, _next = -1;
		CustomerCollection _coll;

		public CustomerCollectionEnumerator(CustomerCollection ParentCollectionCollection)
		{
			_coll = ParentCollectionCollection;
			_next = _coll.Count > 0 ? 0 : -1;
		}

		#region IEnumerator Members

		public virtual void Reset()
		{
			_cursor = -1;
			_next = _coll.Count > 0 ? 0 : -1;
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public Customer Current
		{
			get
			{
				return _coll[_cursor];
			}
		}

		public bool MoveNext()
		{
			if (_next == -1)
				return false;

			_cursor = _next;

			_next++;
			if (_next >= _coll.Count)
				_next = -1;

			return _cursor != -1;
		}
		#endregion

	}


}
