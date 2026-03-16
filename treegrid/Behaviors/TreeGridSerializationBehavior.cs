#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
{
    public class TreeGridSerializationBehavior : Behavior<SfTreeGrid>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.SerializationController = new SerializationControllerExt(this.AssociatedObject);
            this.AssociatedObject.Loaded += OnSfTreeGridLoaded;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnSfTreeGridLoaded;
        }

        void OnSfTreeGridLoaded(object sender, RoutedEventArgs e)
        {
            var treeGrid = this.AssociatedObject as SfTreeGrid;
            if (treeGrid == null) return;
            try
            {
                using (var file = File.Create("Reset.xml"))
                {
                    treeGrid.Serialize(file);
                }
            }
            catch (Exception)
            {

            }
        }
    }

    public class SerializationControllerExt : TreeGridSerializationController
    {
        public SerializationControllerExt(SfTreeGrid sftreegrid) : base(sftreegrid)
        {

        }

        protected override void RestoreColumnProperties(SerializableTreeGridColumn serializableColumn, TreeGridColumn column)
        {
            base.RestoreColumnProperties(serializableColumn, column);
            if (column is TreeGridTemplateColumn)
                column.CellTemplate = GetDataTemplate(column as TreeGridTemplateColumn);
        }

        private static DataTemplate GetDataTemplate(TreeGridTemplateColumn col)
        {
            FrameworkElementFactory txt = new FrameworkElementFactory(typeof(TextBlock));
            var bind = new Binding
            {
                Path = new PropertyPath(col.MappingName),
                Mode = BindingMode.TwoWay
            };
            txt.SetBinding(TextBlock.TextProperty, bind);
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = txt;
            return dataTemplate;
        }
    }
}
