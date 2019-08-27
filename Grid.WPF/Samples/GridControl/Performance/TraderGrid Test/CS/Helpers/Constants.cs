#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace TraderGridTest
{
    /// <summary>
    /// Specifies the blink state for a cell indicating whether the cells
    /// value was increased or decreased or if the record has been recently added. The
    /// BlinkState will be reset to BlinkState.None after the interval specified in 
    /// <see cref="FlatDataViewGridControl.BlinkTime"/> elapsed.
    /// </summary>
    public enum BlinkState
    {
        /// <summary>
        /// No change was detected recently.
        /// </summary>
        None,
        /// <summary>
        /// Value of cell was increased.
        /// </summary>
        Increased,
        /// <summary>
        /// Value of cell was reduced.
        /// </summary>
        Reduced,
        /// <summary>
        /// Cell belongs to a record that 
        /// has been recently added or cell was null before.
        /// </summary>
        NewRecord,
        /// <summary>
        /// A value has been applied to a cell that was null before.
        /// </summary>
        NewValue,
        /// <summary>
        /// Null has been applied to a cell that was a valid value before.
        /// </summary>
        NullValue
    }

}
