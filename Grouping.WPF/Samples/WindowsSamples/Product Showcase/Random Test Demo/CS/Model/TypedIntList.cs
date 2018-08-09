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
using System.ComponentModel;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel.Design.Serialization;

using Syncfusion.Diagnostics;
using Syncfusion.Collections;


namespace RandomTest
{
	public struct WrappedInt : IConvertible, IComparable
	{
		private Int32 val;
		
		public WrappedInt(Int32 val)
		{
			this.val = val;
			//listName = null;
			//this.itemProperties = null;
		}
		public Int32 Value
		{
			get{return this.val;}
			set{this.val = value;}
		}
		public static implicit operator Int32(WrappedInt m) 
		{
			return m.Value;
		}
		public static explicit operator WrappedInt(Int32 i)
		{
			return new WrappedInt(i);
		}

		public override string ToString()
		{
			return  this.val.ToString();
		}

		#region IConvertible Members

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return (ulong)this.val;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return (double)this.val;
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return (float)this.val;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return (int)this.val;
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return this.ToString();
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Object;
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			try
			{
				return Activator.CreateInstance(conversionType, new object[] { this });
			}
			catch (Exception ex)
			{
				throw new InvalidCastException("", ex);
			}
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		#endregion

	
		public int CompareTo(object o)
		{
			if(o == null)
				return -1;
			else
			{
				WrappedInt wInt = (WrappedInt)o;
				return this.val - wInt.Value;
				
			}
		}
	}

	[ListBindableAttribute(false)]
	public class IntegerCollection : IList, ICloneable, IBindingList, ITypedList
	{
		ArrayList inner = new ArrayList();
		public event ListPropertyChangedEventHandler Changed;
		public event ListPropertyChangedEventHandler Changing;
		internal int version;
		internal bool insideCollectionEditor = false;
//		bool inInitializeFrom = false;

		public static readonly IntegerCollection Empty = new IntegerCollection();

		public IntegerCollection()
		{
		}

		public IntegerCollection(params WrappedInt[] values)
		{
			this.AddRange(values);
		}

		public override string ToString()
		{
			return String.Format("Count = {0}", Count);
		}

		public void InitializeFrom(IntegerCollection other)
		{
			int i;
//			inInitializeFrom = true;
			int count = Math.Min(Count, other.Count);
			for (i = 0; i < count; i++)
				this[i] = other[i];

			for (; i < other.Count; i++)
				Add(other[i]);

			while (Count > other.Count)
				RemoveAt(Count-1);
//			inInitializeFrom = false;
		}

		public void AddRange(WrappedInt[] values)
		{
			this.inner.AddRange(values);
		}

		IntegerCollection(WrappedInt[] values, int version)
			: this(values)
		{
			this.version = version;
		}

		public IntegerCollection Clone()
		{
			IntegerCollection coll = new IntegerCollection();
			coll.inner = new ArrayList();
			int count = Count;
			WrappedInt[] values = new WrappedInt[count];
			for (int n = 0; n < count; n++)
				coll.inner.Add(this[n]);
			return coll;
		}

		public override bool Equals(object obj)
		{
			if (this == null && obj == null)
				return true;
			else if (this == null)
				return false;
			else if (!(obj is IntegerCollection))
				return false;

			return Equals((IntegerCollection) obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		public int Version
		{
			get
			{
				return version;
			}
		}

		bool Equals(IntegerCollection other)
		{
			int count = Count;
			if (other.Count != count)
				return false;
			for (int n = 0; n < count; n++)
			{
				if (!this[n].Equals(other[n]))
					return false;
			}
			return true;
		}

		public WrappedInt this[int index]
		{
			get
			{
				return (WrappedInt) inner[index];
			}
			set
			{
				if ((int) inner[index] != value)
				{
					OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.ItemChanged, index, value, null));
					inner[index] = value;
					OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.ItemChanged, index, value, null));
				}
			}
		}

		

		/// <summary>
		/// Checks if the group belongs to the details section and is visible
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(WrappedInt value)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Gets the visible position within the details section.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(WrappedInt value)
		{
			throw new NotSupportedException();
		}

		public void CopyTo(WrappedInt[] array, int index)
		{
			int count = Count;
			for (int n = 0; n < count; n++)
				array[index+n] = this[n];
		}

		public IntegerCollection SyncRoot
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public IntegerCollectionEnumerator GetEnumerator()
		{
			return new IntegerCollectionEnumerator(this);
		}
		
		public void Insert(int index, WrappedInt value)
		{
			OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.Insert, index, value, null));
			inner.Insert(index, value);
			OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.Insert, index, value, null));
		}
	
		public void Remove(WrappedInt value)
		{
			int index = IndexOf(value);
			OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.Remove, index, value, null));
			inner.Remove(value);
			OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.Remove, index, value, null));
		}
		
		public int Add(WrappedInt value)
		{
			OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.Add, -1, value, null));
			int index = inner.Add(value);
			OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.Add, index, value, null));
			return index;
		}

		public void RemoveAt(int index)
		{
			object value = inner[index];
			OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.Remove, index, value, null));
			inner.RemoveAt(index);
			OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.Remove, index, value, null));
		}

		public void Clear()
		{
			OnChanging(new ListPropertyChangedEventArgs(ListPropertyChangedType.Refresh, -1, null, null));
			inner.Clear();
			OnChanged(new ListPropertyChangedEventArgs(ListPropertyChangedType.Refresh, -1, null, null));
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

		/// <summary>
		/// Raises the <see cref="Changed"/> event.
		/// </summary>
		/// <param name="e">A <see cref="ListPropertyChangedEventArgs" /> that contains the event data.</param>
		protected virtual void OnChanged(ListPropertyChangedEventArgs e)
		{
			version++;
			if (!this.insideCollectionEditor)
			{
				if (Changed != null)
					Changed(this, e);
			}

			if (ListChanged != null)
			{
				switch (e.Action)
				{
					case ListPropertyChangedType.Add:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, e.Index, -1));
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, e.Index, -1));
						break;

					case ListPropertyChangedType.Insert:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, e.Index, -1));
							break;

					case ListPropertyChangedType.ItemChanged:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemChanged, e.Index, -1));
							break;

					case ListPropertyChangedType.ItemPropertyChanged:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemChanged, e.Index, -1));
							break;

					case ListPropertyChangedType.Refresh:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, -1, -1));
							break;

					case ListPropertyChangedType.Remove:
						ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, e.Index, -1));
							break;
				}
			}
		}

		/// <summary>
		/// Raises the <see cref="Changed"/> event.
		/// </summary>
		/// <param name="e">A <see cref="ListPropertyChangedEventArgs" /> that contains the event data.</param>
		protected virtual void OnChanging(ListPropertyChangedEventArgs e)
		{
			if (!this.insideCollectionEditor)
			{
				if (Changing != null)
					Changing(this, e);
			}
		}

		#region ICloneable Private Members
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion

		#region IList Private Members

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (WrappedInt) value;
			}
		}

		void IList.Insert(int index, object value)
		{
			Insert(index, (WrappedInt) value);
		}

		void IList.Remove(object value)
		{
			Remove((WrappedInt) value);
		}

		bool IList.Contains(object value)
		{
			return Contains((WrappedInt) value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((WrappedInt) value);
		}

		int IList.Add(object value)
		{
			return Add((WrappedInt) value);
		}

		#endregion

		#region ICollection Private Members

		void ICollection.CopyTo(Array array, int index)
		{
			CopyTo((WrappedInt[]) array, index);
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

		#region Implementation of IBindingList
		void IBindingList.AddIndex(System.ComponentModel.PropertyDescriptor property)
		{
		
		}

		void IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
		{
		
		}

		int IBindingList.Find(System.ComponentModel.PropertyDescriptor property, object key)
		{
			return 0;
		}

		void IBindingList.RemoveSort()
		{
		
		}

		object IBindingList.AddNew()
		{
			int n = Add((WrappedInt) 0);
			return this[n];
		}

		void IBindingList.RemoveIndex(System.ComponentModel.PropertyDescriptor property)
		{
		
		}

		public bool AllowNew
		{
			get
			{
				return true;
			}
		}

		public System.ComponentModel.PropertyDescriptor SortProperty
		{
			get
			{
				return null;
			}
		}

		bool IBindingList.SupportsSorting
		{
			get
			{
				return false;
			}
		}

		bool IBindingList.IsSorted
		{
			get
			{
				return false;
			}
		}

		public bool AllowRemove
		{
			get
			{
				return true;
			}
		}

		bool IBindingList.SupportsSearching
		{
			get
			{
				return false;
			}
		}

		System.ComponentModel.ListSortDirection IBindingList.SortDirection
		{
			get
			{
				return ListSortDirection.Ascending;
			}
		}

		public event System.ComponentModel.ListChangedEventHandler ListChanged;

		public bool SupportsChangeNotification
		{
			get
			{
				return true;
			}
		}

		public bool AllowEdit
		{
			get
			{
				return true;
			}
		}
		#endregion

		#region Implementation of ITypedList
		public System.ComponentModel.PropertyDescriptorCollection GetItemProperties(System.ComponentModel.PropertyDescriptor[] listAccessors)
		{
			return TypeDescriptor.GetProperties(typeof(WrappedInt));
		}

		public string GetListName(System.ComponentModel.PropertyDescriptor[] listAccessors)
		{
			return null;
		}
		#endregion
	}

	public class IntegerCollectionEnumerator : IEnumerator 
	{
		int _cursor = -1, _next = -1;
		IntegerCollection _coll;

		public IntegerCollectionEnumerator(IntegerCollection collection)
		{
			_coll = collection;
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

		public WrappedInt Current
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
