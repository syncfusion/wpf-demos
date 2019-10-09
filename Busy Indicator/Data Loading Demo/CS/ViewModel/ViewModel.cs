#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace DataLoadingDemo
{
    public class ViewModel
    {
        private ObservableCollection<Model> models1;

        public ObservableCollection<Model> Models1
        {
            get { return models1; }
            set { models1 = value; }
        }

        public ViewModel()
        {
            Models1 = Populate();
        }

        private ObservableCollection<Model> Populate()
        {
            ObservableCollection<Model> models = new ObservableCollection<Model>();
            int count = 60;
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                count = 5;
            }
            for (int i = 0; i < count; i++)
            {
                models.Add(new Model(i + 4));
            }
            return models;
        }

        private void Randomize()
        {
            int  i = 0;
            foreach (Model model in Models1)
            {
                model.Randomize(i + 4);
                i++;
            }
        }

        private DelegateCommand<object> randomizeCommand;

        public DelegateCommand<object> RandomizeCommand
        {
            get
            {
                if (randomizeCommand == null)
                {
                    randomizeCommand = new DelegateCommand<object>(param => Randomize());
                }
                return randomizeCommand;
            }
        }

    }

    
}
