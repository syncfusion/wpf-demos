#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="Enum.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace Appearance.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Generic enumeration class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Enum<T>
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetNames()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return
              (from field in
                   type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
               where field.IsLiteral
               select field.Name).ToList();
        }
    }
}