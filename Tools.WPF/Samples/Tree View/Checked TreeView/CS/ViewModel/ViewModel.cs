#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace CheckedTreeView
{
    public class ViewModel : NotificationObject
    {

        public ViewModel()
        {
            Models = new ObservableCollection<Model>();
            var model1 = new Model { Caption = "WPF" };
            var model2 = new Model { Caption = "Silverlight" };
            var model3 = new Model { Caption = "ASP.Net" };
            var model4 = new Model { Caption = "ASP.Net MVC" };

            var mainmodel1 = new Model { Caption = "User Interface" };
            mainmodel1.Models.Add(model1);
            mainmodel1.Models.Add(model2);
            mainmodel1.Models.Add(model3);
            mainmodel1.Models.Add(model4);

            mainmodel1.UnCheckedItems.Add(model1);
            mainmodel1.UnCheckedItems.Add(model2);
            mainmodel1.UnCheckedItems.Add(model3);
            mainmodel1.UnCheckedItems.Add(model4);

            var model5 = new Model { Caption = "WPF" };
            var model6 = new Model { Caption = "Silverlight" };
            var model7 = new Model { Caption = "ASP.Net" };
            var model8 = new Model { Caption = "ASP.Net MVC" };

            var mainmodel2 = new Model { Caption = "Business Intelligence" };
            mainmodel2.Models.Add(model5);
            mainmodel2.Models.Add(model6);
            mainmodel2.Models.Add(model7);
            mainmodel2.Models.Add(model8);

            mainmodel2.UnCheckedItems.Add(model5);
            mainmodel2.UnCheckedItems.Add(model6);
            mainmodel2.UnCheckedItems.Add(model7);
            mainmodel2.UnCheckedItems.Add(model8);

            var model9 = new Model { Caption = "WPF" };
            var mode20 = new Model { Caption = "Silverlight" };
            var mode21 = new Model { Caption = "ASP.Net" };

            var mainmodel3 = new Model { Caption = "Reporting" };
            mainmodel3.Models.Add(model9);
            mainmodel3.Models.Add(mode20);
            mainmodel3.Models.Add(mode21);

            mainmodel3.UnCheckedItems.Add(model9);
            mainmodel3.UnCheckedItems.Add(mode20);
            mainmodel3.UnCheckedItems.Add(mode21);

            var mod = new Model { Caption = "Syncfusion Essential Studio" };
            mod.Models.Add(mainmodel1);
            mod.Models.Add(mainmodel2);
            mod.Models.Add(mainmodel3);

            mod.UnCheckedItems.Add(mainmodel1);
            mod.UnCheckedItems.Add(mainmodel2);
            mod.UnCheckedItems.Add(mainmodel3);

            Models.Add(mod);
        }

        public ObservableCollection<Model> Models { get; set; }
    }
}
