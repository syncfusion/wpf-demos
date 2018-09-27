#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
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
            models = new ObservableCollection<Model>();
            Model model1 = new Model() { Caption = "WPF" };
            Model model2 = new Model() { Caption = "Silverlight" }; ;
            Model model3 = new Model() { Caption = "ASP.Net" }; ;
            Model model4 = new Model() { Caption = "ASP.Net MVC" }; ;

            Model mainmodel1 = new Model(){Caption = "User Interface"};
            mainmodel1.Models.Add(model1);
            mainmodel1.Models.Add(model2);
            mainmodel1.Models.Add(model3);
            mainmodel1.Models.Add(model4);

            Model model5 = new Model() { Caption = "WPF" };
            Model model6 = new Model() { Caption = "Silverlight" };
            Model model7 = new Model() { Caption = "ASP.Net" };
            Model model8 = new Model() { Caption = "ASP.Net MVC" };

            Model mainmodel2 = new Model() { Caption = "Business Intelligence" };
            mainmodel2.Models.Add(model5);
            mainmodel2.Models.Add(model6);
            mainmodel2.Models.Add(model7);
            mainmodel2.Models.Add(model8);

            Model model9 = new Model() { Caption = "WPF" };
            Model mode20 = new Model() { Caption = "Silverlight" };
            Model mode21 = new Model() { Caption = "ASP.Net" };

            Model mainmodel3 = new Model() { Caption = "Reporting" };
            mainmodel3.Models.Add(model9);
            mainmodel3.Models.Add(mode20);
            mainmodel3.Models.Add(mode21);

            Model mod = new Model() { Caption = "Syncfusion Essential Studio" };
            mod.Models.Add(mainmodel1);
            mod.Models.Add(mainmodel2);
            mod.Models.Add(mainmodel3);

          
            models.Add(mod);
        }


        public ObservableCollection<Model> models;
        public ObservableCollection<Model> Models
        {
            get 
            {
                return models;
            }
            set
            {
                models = value;
            }
        }             
    }
}
