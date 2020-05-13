#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syncfusion.Zugferd
{
    /// <summary>
    /// Invoice Type
    /// </summary>
    public enum InvoiceType
    {
        Unknown = 0,
        Invoice = 380,
        Correction = 1380,
        CreditNote = 381,
        DebitNote = 383,
        SelfBilledInvoice = 389
    }
}
