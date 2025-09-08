#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts a collection size into an other object.
    /// Can be used to convert to bind a visibility, a color or an image to the size of the collection.
    /// </summary>
    public class EmptyCollectionToObjectConverter : EmptyObjectToObjectConverter
    {
        /// <summary>
        /// Checks collection for emptiness.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if value is an empty collection or does not implement IEnumerable, false otherwise.</returns>
        protected override bool CheckValueIsEmpty(object value)
        {
            bool isEmpty = true;
            var collection = value as IEnumerable;
            if (collection != null)
            {
                var enumerator = collection.GetEnumerator();
                isEmpty = !enumerator.MoveNext();
            }

            return isEmpty;
        }
    }

}
