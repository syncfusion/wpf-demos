#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RSIIndicatorDemo
{
    #region interface IPriceInfo

    /// <summary>
    /// Encapsulates a price object.
    /// </summary>
    public interface IPriceInfo 
    {
        /// <summary>
        /// Gets or sets the time of the price.
        /// </summary>
        DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the high price during the time slice.
        /// </summary>
        double High { get; set; }
        /// <summary>
        /// Gets or sets the low price during the time slice.
        /// </summary>
        double Low { get; set; }
        /// <summary>
        /// Gets or sets the last price during the time slice.
        /// </summary>
        double Last { get; set; }
        /// <summary>
        /// Gets or sets the open price during the time slice.
        /// </summary>
        double Open { get; set; }
        /// <summary>
        /// Gets or sets the volume during the time slice.
        /// </summary>
        double Volume { get; set; }
       // public double OpenInterest { get; set; }
    }
    #endregion


    #region class ExtendedPriceInfo
    internal class ExtendedPriceInfo : PriceInfo
    {

    }
    #endregion

    #region class PriceInfo

    /// <summary>
    /// Encapsulates a price object through an IPriceInfo implementation.
    /// </summary>
    public class PriceInfo : IPriceInfo
    {
        /// <summary>
        /// Gets or sets the time of the price.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the high price during the time slice.
        /// </summary>
        public double High { get; set; }
        /// <summary>
        /// Gets or sets the low price during the time slice.
        /// </summary>
        public double Low { get; set; }
        /// <summary>
        /// Gets or sets the last price during the time slice.
        /// </summary>
        public double Last { get; set; }
        /// <summary>
        /// Gets or sets the open price during the time slice.
        /// </summary>
        public double Open { get; set; }
        /// <summary>
        /// Gets or sets the volume during the time slice.
        /// </summary>
        public double Volume { get; set; }
        // public double OpenInterest { get; set; }

        /// <summary>
        /// override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TimeStamp.ToString() + ',' +
                Open.ToString() + ',' +
                High.ToString() + ',' +
                Low.ToString() + ',' +
                Last.ToString() + ',' +
                Volume.ToString();
        }



    }
    #endregion

    #region PartialList class

    public class PartialList<T> : IList<T>
    {
        IList<T> baseList;
        int startIndex;

        public int StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; }
        }
        int count;
        public PartialList(IList<T> baseList, int startIndex, int count)
        {
            this.baseList = baseList;
            this.startIndex = startIndex;
            this.count = count;
            if (baseList.Count <= startIndex + count - 1)
            {
                throw new ArgumentOutOfRangeException("startIndex + count must not be greater that the number of items in baseList.");
            }
        }



        #region IList<T> Members

        public int IndexOf(T item)
        {
            return baseList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            baseList.Insert(index + startIndex, item);
        }

        public void RemoveAt(int index)
        {
            baseList.RemoveAt(index + startIndex);
        }

        public T this[int index]
        {
            get
            {
                return baseList[index + startIndex];
            }
            set
            {
                baseList[index + startIndex] = value;
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            baseList.Add(item);
        }

        public void Clear()
        {
            baseList.Clear();
        }

        public bool Contains(T item)
        {
            return baseList.IndexOf(item) >= startIndex;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            baseList.CopyTo(array, startIndex + arrayIndex);
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(T item)
        {
            return baseList.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return baseList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return baseList.GetEnumerator();
        }

        #endregion
    }

    #endregion

    #region class DataPoint

    /// <summary>
    /// Encapulates the X-Y values of an indicator calculation time series.
    /// </summary>
    public class DataPoint
    {
        /// <summary>
        /// Gets or sets the Y ordinate of the time series value.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets of sets the X coordinate (time) of the time series value. 
        /// </summary>
        public DateTime X { get; set; }

        /// <summary>
        /// Gets or sets whether this time series point is a valid member of the time series.
        /// </summary>
        /// <remarks>For example, you cannot chart a 10-day simple average of a time series
        /// until day number 10. So, the first 9 values in the resulting time series do not
        /// represent chartable data points. If this case, the IsPadedValue would be set to 
        /// true for these first 9 values.
        /// </remarks>
        public bool? IsPaddedValue { get; set; }
    }
    #endregion
}
