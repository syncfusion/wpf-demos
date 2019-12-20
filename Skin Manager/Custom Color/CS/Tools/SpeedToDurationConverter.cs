#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;


namespace CustomizedTaskbarTheme
{
	/// <summary>
    /// This class implements conversion from <see cref="Int32"/> type to <see cref="Duration"/>
	/// type.
	/// </summary>
	/// <remarks>
    /// Calculate optimal <see cref="Duration"/> for current control height.
    /// </remarks>
	public class SpeedToDurationConverter : IMultiValueConverter
	{
		#region Constants
		/// <summary>
		/// This constant is used for calculating speed for expanded
		/// event.
		/// </summary>
		private const string AnimationTypeExpanding = "Expanded";
		/// <summary>
		/// This constant is used for calculating speed for collapsed
		/// event.
		/// </summary>
		private const string AnimationTypeCollapsing = "Collapsed";
		#endregion

		#region IMultiValueConverter Members
		/// <summary>
		/// This method converts speed value to duration value.
		/// </summary>
		/// <param name="values">Contains speed and the value of the
		/// height.</param>
		/// <param name="targetType">The type in which the value should
		/// be converted.</param>
		/// <param name="parameter">Contains name control part for
		/// painting out.</param>
		/// <param name="culture">The culture for given converting.</param>
		/// <returns>
		/// Duration of expanded/collapsed item.
		/// </returns>
		public object Convert( object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
		double speed=0;
           if(values[0] is double)
                 speed= (double)values[0];
            
			if( 0 != speed )
			{
				string param = parameter.ToString();
				double height = 0;

				if( AnimationTypeExpanding == param )
				{
					//height = (double)values[ 1 ] - (double)values[ 2 ];
					height = (double)values[ 1 ] - (double)values[ 2 ];
				}
				else if( AnimationTypeCollapsing == param )
				{
					height = (double)values[ 1 ];
					//height = (double)values[ 1 ] - (double)values[ 2 ] + (double)values[ 3 ];
				}
				else
					throw new InvalidOperationException(
						string.Format( "Invalid animation type s specified, only {0} and {1} values are allowed as the parameter for the {2} converter.",
						AnimationTypeCollapsing, AnimationTypeExpanding, typeof( SpeedToDurationConverter ).Name ) );

				double correct = 500;

				if( 400 > height )
				{
					if( !( 10 > height ) )
					{
						correct = ( height - 10 ) / 390 * 400 + 100;
					}
					else
					{
						correct = 0;
					}
				}
				return new Duration( new TimeSpan( 0, 0, 0, 0, (int)Math.Ceiling( correct / speed ) ) );
			}
			return new Duration( new TimeSpan( 0, 0, 0, 0, 0 ) );
		}
		/// <summary>
		/// Does nothing.
		/// </summary>
		/// <param name="value">Never transfer.</param>
		/// <param name="targetTypes">Never transfer.</param>
		/// <param name="parameter">Never transfer.</param>
		/// <param name="culture">Never transfer.</param>
		/// <returns>
		/// Always returns null.
		/// </returns>
		public object[] ConvertBack( object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture )
		{
			return null;
		}
		#endregion
	}
}
