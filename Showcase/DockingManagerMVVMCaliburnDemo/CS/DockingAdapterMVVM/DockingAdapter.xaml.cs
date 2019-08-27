#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DockingAdapterMVVM
{
    /// <summary>
    /// Interaction logic for DockingAdapter.xaml
    /// </summary>
    public partial class DockingAdapter : UserControl
    {
        public DockingAdapter()
        {
            InitializeComponent();
        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IList), typeof(DockingAdapter), new PropertyMetadata(null,new PropertyChangedCallback(OnItemSourcePropertyChanged)));

        public bool UseDocumentContainer
        {
            get { return (bool)GetValue(UseDocumentContainerProperty); }
            set { SetValue(UseDocumentContainerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UseDocumentContainer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseDocumentContainerProperty =
            DependencyProperty.Register("UseDocumentContainer", typeof(bool), typeof(DockingAdapter), new PropertyMetadata(false, new PropertyChangedCallback(OnUseDocumentContainerChanged)));

        private static void OnUseDocumentContainerChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            DockingAdapter adapter = sender as DockingAdapter;
            if (adapter != null)
            {
                adapter.PART_DockingManager.UseDocumentContainer = (bool)args.NewValue;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
                base.OnPropertyChanged(e);
        }

        private static void OnItemSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DockingAdapter instance = (DockingAdapter)d;
            if (instance != null)
            {
                if (e.OldValue != null)
                {
                    var oldcollection = e.OldValue as INotifyCollectionChanged;
                    oldcollection.CollectionChanged -= instance.CollectionChanged;
                }
                if (e.NewValue != null)
                {
                    var newcollection = e.NewValue as INotifyCollectionChanged;
                    foreach (var item in ((IList)e.NewValue))
                    {
                        if (item is IChildrenElement)
                        {
                            instance.CreateChildren(item as IChildrenElement, instance);
                        }
                    }
                    newcollection.CollectionChanged += instance.CollectionChanged;
                }
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    ContentControl control = (from ContentControl element in PART_DockingManager.Children
                                              where element.Content == item
                                              select element).FirstOrDefault();
                    PART_DockingManager.Children.Remove(control);
                }
            }

            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is IChildrenElement)
                    {
                        this.CreateChildren(item as IChildrenElement, this);
                    }
                }
            }
        }

        private void CreateChildren(IChildrenElement element, DockingAdapter adapter)
        {
            ContentControl control = new ContentControl() { Content = element };
            control.Name = element.Name;

            adapter.SetCanAutoHide(control as DependencyObject, element);
            adapter.SetCanClose(control as DependencyObject, element);
            adapter.SetCanDock(control as DependencyObject, element);
            adapter.SetCanDocument(control as DependencyObject, element);
            adapter.SetCanDrag(control as DependencyObject, element);
            adapter.SetCanFloat(control as DependencyObject, element);
            adapter.SetDesiredHeightInDockedMode(control as DependencyObject, element);
            adapter.SetDesiredWidthInDockedMode(control as DependencyObject, element);
            adapter.SetDockAbility(control as DependencyObject, element);
            adapter.SetDockToFill(control as DependencyObject, element);
            adapter.SetHeader(control as DependencyObject, element);
            adapter.SetNoDock(control as DependencyObject, element);
            adapter.SetNoHeader(control as DependencyObject, element);
            adapter.SetSideInDockedMode(control as DependencyObject, element);
            adapter.SetSideInFloatMode(control as DependencyObject, element);
            adapter.SetState(control as DependencyObject, element);
            adapter.SetTargetNameInDockedMode(control as DependencyObject, element);
            adapter.SetTargetNameInFloatMode(control as DependencyObject, element);
            
            adapter.PART_DockingManager.Children.Add(control);
        }

        private void SetCanAutoHide(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanAutoHide(obj, element.CanAutoHide);
        }

        private void SetCanClose(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanClose(obj, element.CanClose);
        }

        private void SetCanDock(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanDock(obj, element.CanDock);
        }

        private void SetCanDocument(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanDocument(obj, element.CanDocument);
        }

        private void SetCanDrag(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanDrag(obj, element.CanDrag);
        }

        private void SetCanFloat(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetCanFloat(obj, element.CanFloat);
        }

        private void SetDesiredHeightInDockedMode(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetDesiredHeightInDockedMode(obj, element.DesiredHeightInDockedMode);
        }

        private void SetDesiredWidthInDockedMode(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetDesiredWidthInDockedMode(obj, element.DesiredWidthInDockedMode);
        }

        private void SetDockAbility(DependencyObject obj, IChildrenElement element)
        {
            if (element.DockAbility == DockAbility.All)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.All);
            }
            else if (element.DockAbility == DockAbility.Bottom)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Bottom);
            }
            else if (element.DockAbility == DockAbility.Horizontal)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Horizontal);
            }
            else if (element.DockAbility == DockAbility.Left)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Left);
            }
            else if (element.DockAbility == DockAbility.None)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.None);
            }
            else if (element.DockAbility == DockAbility.Right)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Right);
            }
            else if (element.DockAbility == DockAbility.Tabbed)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Tabbed);
            }
            else if (element.DockAbility == DockAbility.Top)
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Top);
            }
            else
            {
                DockingManager.SetDockAbility(obj, Syncfusion.Windows.Tools.Controls.DockAbility.Vertical);
            }
            
        }

        private void SetDockToFill(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetDockToFill(obj, element.DockToFill);
        }

        private void SetHeader(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetHeader(obj, element.Header);
        }

        private void SetNoDock(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetNoDock(obj, element.NoDock);
        }

        private void SetNoHeader(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetNoHeader(obj, element.NoHeader);
        }

        private void SetSideInDockedMode(DependencyObject obj, IChildrenElement element)
        {
            if (element.SideInDockMode == DockSide.Bottom)
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Bottom);
            }
            else if (element.SideInDockMode == DockSide.Right)
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Right);
            }
            else if (element.SideInDockMode == DockSide.Tabbed)
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Tabbed);
            }
            else if (element.SideInDockMode == DockSide.Top)
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Top);
            }
            else if (element.SideInDockMode == DockSide.None)
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.None);
            }
            else
            {
                DockingManager.SetSideInDockedMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Left);
            }
        }

        private void SetSideInFloatMode(DependencyObject obj, IChildrenElement element)
        {
            if (element.SideInFloatMode == DockSide.Bottom)
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Bottom);
            }
            else if (element.SideInFloatMode == DockSide.Right)
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Right);
            }
            else if (element.SideInFloatMode == DockSide.Tabbed)
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Tabbed);
            }
            else if (element.SideInFloatMode == DockSide.Top)
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Top);
            }
            else if (element.SideInFloatMode == DockSide.None)
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.None);
            }
            else
            {
                DockingManager.SetSideInFloatMode(obj, Syncfusion.Windows.Tools.Controls.DockSide.Left);
            }
        }

        private void SetState(DependencyObject obj, IChildrenElement element)
        {
            if (element.State == DockState.Document)
            {
                DockingManager.SetState(obj, Syncfusion.Windows.Tools.Controls.DockState.Document);
            }
            else if (element.State == DockState.Hidden)
            {
                DockingManager.SetState(obj, Syncfusion.Windows.Tools.Controls.DockState.Hidden);
            }
            else if (element.State == DockState.Float)
            {
                DockingManager.SetState(obj, Syncfusion.Windows.Tools.Controls.DockState.Float);
            }
            else if (element.State == DockState.AutoHidden)
            {
                DockingManager.SetState(obj, Syncfusion.Windows.Tools.Controls.DockState.AutoHidden);
            }
            else
            {
                DockingManager.SetState(obj, Syncfusion.Windows.Tools.Controls.DockState.Dock);
            }
        }

        private void SetTargetNameInDockedMode(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetTargetNameInDockedMode(obj, element.TargetNameInDockedMode);
        }

        private void SetTargetNameInFloatMode(DependencyObject obj, IChildrenElement element)
        {
            DockingManager.SetTargetNameInFloatingMode(obj, element.TargetNameInFloatMode);
        }

        
    }
}
