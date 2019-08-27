#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace SerializationDemo
{
    public class SfDataGridBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        ///   Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.SerializationController = new SerializationControllerExt(this.AssociatedObject);
            this.AssociatedObject.Loaded += OnSfDataGridLoaded;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnSfDataGridLoaded;
        }

        /// <summary>
        /// Event handler when the SfDataGrid is Loaded.
        /// </summary>  
        void OnSfDataGridLoaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = this.AssociatedObject as SfDataGrid;

            if (dataGrid == null) return;
            try
            {
                using (var file = File.Create("Reset.xml"))
                {
                    dataGrid.Serialize(file);
                }
            }
            catch (Exception)
            {

            }
        }
    }


    public class SerializationControllerExt : SerializationController
    {
        public SerializationControllerExt(SfDataGrid sfdatagrid): base(sfdatagrid)
        {

        }
        /// <summary>
        /// Restores the grid column properties from the specified SerializableGridColumn to the GridColumn during deserialization.
        /// </summary>  
        protected override void RestoreColumnProperties(SerializableGridColumn serializableColumn, GridColumn column)
        {
            base.RestoreColumnProperties(serializableColumn, column);
            if (!(column is GridUnBoundColumn) && column is GridTemplateColumn)
                column.CellTemplate = GetDataTemplate(column as GridTemplateColumn);
        }

        #region GetDataTemplate
        private static DataTemplate GetDataTemplate(GridTemplateColumn col)
        {
            FrameworkElementFactory btn = new FrameworkElementFactory(typeof(TextBlock));
            var bind = new Binding
            {
                Path = new PropertyPath(col.MappingName),
                Mode = BindingMode.TwoWay
            };
            btn.SetBinding(TextBlock.TextProperty, bind);
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = btn;
            return dataTemplate;
        }

        #endregion
    }
}
