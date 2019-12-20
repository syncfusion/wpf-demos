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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Xml;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
#if !NETCORE
using System.Runtime.Serialization.Formatters.Soap;
#endif
using System.Windows.Forms.Integration;
using WinForms = System.Windows.Forms;
using System.Reflection;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools;

namespace DockingStudio
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
	{       
        
		#region Class Fields

        /// <summary>
        /// Class Fields
        /// </summary>

		private StorageFormat m_storageFormat;
		private bool m_bIsSoapFormatter;
        private string m_strStoragePath = string.Format(@"{0}\DockingStudio.", Environment.CurrentDirectory);
		#endregion

		#region Constructor
        /// <summary>
        /// Constructor for window1.
        /// </summary>
		public Window1()
        {
			InitializeComponent();
            DockingManager.ActiveWindow = Integration;
			InitWindowsFormsHost();
			SubscribeForEvents();           
#if NETCORE
            soapMenu.Visibility = Visibility.Collapsed;
#endif

        }
        #endregion
		
		#region Implementation

        /// <summary>
        /// Menu item click 
        /// </summary>
        /// <param name="item"></param>

		private void OnMenuItemClick( MenuItem item )
		{
			MenuItem parent = item.Parent as MenuItem;
			foreach( MenuItem menuItem in parent.Items )
			{
				menuItem.IsChecked = false;
			}
			item.IsChecked = true;
		}
        /// <summary>
        /// Changing the theme
        /// </summary>
        /// <param name="item"></param>
		private void OnThemeChanged( object sender, RoutedEventArgs e )
		{
            //Changing Theme
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );
			string theme = item.Tag as string;
            SfSkinManager.SetVisualStyle(this, (VisualStyles)Enum.Parse(typeof(VisualStyles), theme));

        }
        /// <summary>
        /// Set the active window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnActivateWindow( object sender, RoutedEventArgs e )
		{
			string name = ( sender as MenuItem ).Tag as string;
			DockingManager.ActivateWindow( name );
		}
        /// <summary>
        /// Set the tab placement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnTabPlacementChanged( object sender, RoutedEventArgs e )
		{
            //Dock Tab Alignment
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );
			
			Dock dock = ( Dock )Enum.Parse( typeof( Dock ), ( string )item.Header );
			DockingManager.DockTabAlignment = dock;
		}
        /// <summary>
        /// Set the dragging type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnDragModeChanged( object sender, RoutedEventArgs e )
		{
            //Dock Dragging Type
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );
			DraggingType type = ( DraggingType )Enum.Parse( typeof( DraggingType ), 
                ( string )item.Header );
			DockingManager.DraggingType = type;
		}
        /// <summary>
        /// Set the animation mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnAnimationChanged( object sender, RoutedEventArgs e )
		{
            //Auto Hide Animation Mode
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );			
			AutoHideAnimationMode mode = ( AutoHideAnimationMode )Enum.Parse
                ( typeof( AutoHideAnimationMode ),( string )item.Header );
			DockingManager.AutoHideAnimationMode = mode;
		}
        /// <summary>
        /// Set the auto hide tab mode
        /// </summary>
        /// <param name="sender"></param>
        /// /// <param name="e"></param>
		private void OnAutoHideTabsModeChanged( object sender, RoutedEventArgs e )
		{
            //Auto Hide Tabs Mode
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );
			
			AutoHideTabsMode mode = ( AutoHideTabsMode )Enum.Parse( typeof( AutoHideTabsMode ), 
                ( string )item.Header );
			DockingManager.AutoHideTabsMode = mode;
		}
        /// <summary>
        /// Set the close tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnCloseTabsModeChanged( object sender, RoutedEventArgs e )
		{
            //Close Tabs Mode
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );

			CloseTabsMode mode = ( CloseTabsMode )Enum.Parse( typeof( CloseTabsMode ), 
                ( string )item.Header );
			DockingManager.CloseTabs = mode;
		}
        /// <summary>
        /// Set the animation delay time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnAnimationSpeedChanged( object sender, RoutedEventArgs e )
		{
            //Docking Animation Delay
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );
			
			int value = int.Parse( item.Tag.ToString() );
			DockingManager.SetAnimationDelay( DockingManager, 
                        new Duration( TimeSpan.FromMilliseconds( value ) ) );
		}
        /// <summary>
        /// Enable/Disable the hot tracking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnHotTrackingChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			bool bChecked = item.IsChecked;

			DockingManager.IsEnableHotTracking = !bChecked;
			item.IsChecked = !bChecked;
		}
        /// <summary>
        /// Enable/Disable the dock fill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnDockFillChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			bool bChecked = item.IsChecked;

			DockingManager.DockFill = !bChecked;
			item.IsChecked = !bChecked;
		}

        /// <summary>
        /// Called when [dock fill document mode changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnDockFillDocumentModeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            DockFillDocumentMode mode = (DockFillDocumentMode)Enum.Parse(typeof(DockFillDocumentMode), (string)item.Header);
            DockingManager.DockFillDocumentMode = mode;            
        }

        /// <summary>
        /// Called when [document close button type changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnDocumentCloseButtonTypeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            CloseButtonType closetype = (CloseButtonType)Enum.Parse(typeof(CloseButtonType), (string)item.Header);
            DockingManager.DocumentCloseButtonType = closetype;
        }

        /// <summary>
        /// Called when [container splitter resize changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnContainerSplitterResizeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            SplitterResizeMode mode = (SplitterResizeMode)Enum.Parse(typeof(SplitterResizeMode), (string)item.Header);
            DockingManager.ContainerSplitterResize = mode;
        }

        /// <summary>
        /// Set the auto hide visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnAutoHideVisibilityChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			bool bChecked = item.IsChecked;

			DockingManager.AutoHideVisibility = !bChecked;
			item.IsChecked = !bChecked;
		}
        /// <summary>
        /// Set the state of the dock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnStateChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;

			DockState state = ( DockState )Enum.Parse( typeof( DockState ), 
                              ( string )item.Header );
			DockingManager.SetState( DockingManager.ActiveWindow, state );
		}
        /// <summary>
        /// Set the dock option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnDockOptionChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			SetDockOption( ( string )item.Header, DockingManager.ActiveWindow, !item.IsChecked );
		}
        /// <summary>
        /// Set the switch mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnSwitchModeChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );

			SwitchMode mode = ( SwitchMode )Enum.Parse( typeof( SwitchMode ), 
                              ( string )item.Header );
			DockingManager.SwitchMode = mode;
		}
        /// <summary>
        /// Set the container mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnContainerModeChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );

			DocumentContainerMode mode = ( DocumentContainerMode )Enum.Parse
                ( typeof( DocumentContainerMode ),( string )item.Header );
			DockingManager.ContainerMode = mode;
		}
        /// <summary>
        /// Set the dock ability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnDockAbilityChanged( object sender, RoutedEventArgs e )
		{
            //Setting Dock Ability
			MenuItem item = sender as MenuItem;
			FrameworkElement element = DockingManager.ActiveWindow;
			DockAbility ability = DockingManager.GetDockAbility( element );
			DockAbility dockAbility = ( DockAbility )Enum.Parse( typeof( DockAbility ), 
                                      ( string )item.Header );

			if( item.IsChecked )
			{
				item.IsChecked = false;
				ability &= ~dockAbility;
				DockingManager.SetDockAbility( element, ability );
			}
			else
			{
				item.IsChecked = true;
				ability |= dockAbility;
				DockingManager.SetDockAbility( element, ability );
			}
		}

        /// <summary>
        /// Called when [can resize changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnCanResizeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            FrameworkElement element = DockingManager.ActiveWindow;

            if (element != null)
            {
                switch ((string)item.Header)
                {
                    case "CanResizeInDockedState":
                        DockingManager.SetCanResizeInDockedState(element, !item.IsChecked);
                        break;
                    case "CanResizeInFloatState":
                        DockingManager.SetCanResizeInFloatState(element, !item.IsChecked);
                        break;
                    case "CanResizeHeightInDockedState":
                        DockingManager.SetCanResizeHeightInDockedState(element, !item.IsChecked);
                        break;
                    case "CanResizeWidthInDockedState":
                        DockingManager.SetCanResizeWidthInDockedState(element, !item.IsChecked);
                        break;
                    case "CanResizeHeightInFloatState":
                        DockingManager.SetCanResizeHeightInFloatState(element, !item.IsChecked);
                        break;
                    case "CanResizeWidthInFloatState":
                        DockingManager.SetCanResizeWidthInFloatState(element, !item.IsChecked);
                        break;
                }
            }
        }

        /// <summary>
        /// Called when [is fixed size changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnIsFixedSizeChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            FrameworkElement element = DockingManager.ActiveWindow;

            if (element != null)
            {
                switch ((string)item.Header)
                {
                    case "IsFixedSize":
                        DockingManager.SetIsFixedSize(element, !item.IsChecked);
                        break;
                    case "IsFixedHeight":
                        DockingManager.SetIsFixedHeight(element, !item.IsChecked);
                        break;
                    case "IsFixedWidth":
                        DockingManager.SetIsFixedWidth(element, !item.IsChecked);
                        break;
                }
            }
        }

        /// <summary>
        /// Set the active window as dock ability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnGetActiveWindowDockAbility( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			FrameworkElement element = DockingManager.ActiveWindow;
			DockAbility ability = DockingManager.GetDockAbility( element );

			foreach( MenuItem subitem in item.Items )
			{
				DockAbility dockAbility = ( DockAbility )Enum.Parse( typeof( DockAbility ), 
                    ( string )subitem.Header );
				subitem.IsChecked = ( dockAbility & ability ) == dockAbility;
			}
		}

        /// <summary>
        /// Called when [get can resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnGetCanResize(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            FrameworkElement element = DockingManager.ActiveWindow;

            if (element != null)
            {
                foreach (MenuItem subitem in item.Items)
                {
                    switch ((string)subitem.Header)
                    {
                        case "CanResizeInDockedState":
                            subitem.IsChecked = DockingManager.GetCanResizeInDockedState(element);
                            break;
                        case "CanResizeInFloatState":
                            subitem.IsChecked = DockingManager.GetCanResizeInFloatState(element);
                            break;
                        case "CanResizeHeightInDockedState":
                            subitem.IsChecked = DockingManager.GetCanResizeHeightInDockedState(element);
                            break;
                        case "CanResizeWidthInDockedState":
                            subitem.IsChecked = DockingManager.GetCanResizeWidthInDockedState(element);
                            break;
                        case "CanResizeHeightInFloatState":
                            subitem.IsChecked = DockingManager.GetCanResizeHeightInFloatState(element);
                            break;
                        case "CanResizeWidthInFloatState":
                            subitem.IsChecked = DockingManager.GetCanResizeWidthInFloatState(element);
                            break;
                    }
                }
            }
        }

        private void OnGetFixedSize(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            FrameworkElement element = DockingManager.ActiveWindow;

            if (element != null)
            {
                foreach (MenuItem subitem in item.Items)
                {
                    switch ((string)subitem.Header)
                    {
                        case "IsFixedSize":
                            subitem.IsChecked = DockingManager.GetIsFixedSize(element);
                            break;
                        case "IsFixedHeight":
                            subitem.IsChecked = DockingManager.GetIsFixedHeight(element);
                            break;
                        case "IsFixedWidth":
                            subitem.IsChecked = DockingManager.GetIsFixedWidth(element);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Set the MDI layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnSetMDILayout( object sender, RoutedEventArgs e )
		{
            //Setting MDI Layout
			MenuItem item = sender as MenuItem;
			
			MDILayout layout = ( MDILayout )Enum.Parse( typeof( MDILayout ), ( string )item.Header );
			DockingManager.SetMDILayout( layout );
		}
        /// <summary>
        /// Set the storage format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnStorageFormatChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );

			StorageFormat type = ( StorageFormat )Enum.Parse( typeof( StorageFormat ), 
                ( string )item.Header );
			m_storageFormat = type;
		}
        /// <summary>
        /// Set the serialization format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnSerializationFormatChanged( object sender, RoutedEventArgs e )
		{
			MenuItem item = sender as MenuItem;
			OnMenuItemClick( item );

			m_bIsSoapFormatter = string.Equals( ( string )item.Header, "SOAP" );
		}
        /// <summary>
        /// save the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnSaveState( object sender, RoutedEventArgs e )
		{
			switch( m_storageFormat )
			{
				case StorageFormat.Xml:
				case StorageFormat.Binary:
                    IFormatter formatter = null;
#if !NETCORE
                    formatter = m_bIsSoapFormatter
						? ( IFormatter )new SoapFormatter() : ( IFormatter )new BinaryFormatter();
#else
                    formatter=( IFormatter )new BinaryFormatter();
#endif
					DockingManager.SaveDockState( formatter, m_storageFormat,
						m_strStoragePath + m_storageFormat.ToString().Substring( 0, 3 ) );

					break;

				case StorageFormat.Registry:
					DockingManager.SaveDockState( new BinaryFormatter() );
					break;
			}
		}
        /// <summary>
        /// Load the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnLoadState( object sender, RoutedEventArgs e )
		{
			switch( m_storageFormat )
			{
				case StorageFormat.Xml:
				case StorageFormat.Binary:
                    IFormatter formatter = null;
#if !NETCORE
                    formatter = m_bIsSoapFormatter
						? ( IFormatter )new SoapFormatter() : ( IFormatter )new BinaryFormatter();
#else
                    formatter = (IFormatter)new BinaryFormatter();
#endif

                    //try
                    //{
						DockingManager.LoadDockState( formatter, m_storageFormat,
							m_strStoragePath + m_storageFormat.ToString().Substring( 0, 3 ) );
                    //}
                    //catch
                    //{
                    //};

					break;

				case StorageFormat.Registry:

					try
					{
						DockingManager.LoadDockState( new BinaryFormatter() );
					}
					catch
					{
					};
					break;
			}
		}
        /// <summary>
        /// Reset the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnResetState( object sender, RoutedEventArgs e )
		{
			DockingManager.ResetState();
		}
        /// <summary>
        /// Delete the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnDeleteState( object sender, RoutedEventArgs e )
		{
			switch( m_storageFormat )
			{
				case StorageFormat.Xml:
				case StorageFormat.Binary:

					DockingManager.DeleteDockState
						( m_strStoragePath + m_storageFormat.ToString().Substring( 0, 3 ) );

					break;

				case StorageFormat.Registry:
					DockingManager.DeleteDockState();
					break;
			}
		}
        /// <summary>
        /// Get the active window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnGetActiveWindowProperties( object sender, RoutedEventArgs e )
		{
            if (DockingManager.ActiveWindow != null)
            {

                MenuItem item = sender as MenuItem;
                FrameworkElement element = DockingManager.ActiveWindow;
                DockState state = DockingManager.GetState(element);

                foreach (Control control in item.Items)
                {
                    if (control is MenuItem)
                    {
                        MenuItem subitem = control as MenuItem;
                        string header = (string)subitem.Header;

                        if (!subitem.HasItems)
                        {
                            subitem.IsChecked = GetDockOption(header, element);
                            subitem.IsEnabled = GetStateLock(header, element);
                        }
                    }
                }
            }            
		}
        /// <summary>
        /// Get the state lock
        /// </summary>
        /// <param name="optionName"></param>
        /// <param name="element"></param>
		private bool GetStateLock( string optionName, FrameworkElement element )
		{
			bool result = true;
			DockState state = DockingManager.GetState( element );

			switch( optionName )
			{
                // Get the Dock state
				case "CanDock":
					result = state != DockState.Dock;
					break;
                // Get the Float state 
				case "CanFloat":
					result = state != DockState.Float;
					break;
                // Get the Hidden state 
				case "CanClose":
					result = state != DockState.Hidden;
					break;
                // Get the AutoHidden state 
				case "CanAutoHide":
					result = state != DockState.AutoHidden;
					break;
                // Get the Document state 
				case "CanDocument":
					result = state != DockState.Document;
					break;
                // Get the hidden state
				case "CanDrag":
					result = state != DockState.Hidden;
					break;
                //Get the dockstate state
                case "CanDragAutoHidden":
                    result = state != DockState.Document? state != DockState.Float:false;
                    break;
                // Get the Dock state
				case "Dock":
					result = DockingManager.GetCanDock( element );
					break;
                // Get the state lock as Dock
				case "Float":
					result = DockingManager.GetCanFloat( element );
					break;
                // Get the Document state
				case "Document":
					result = DockingManager.GetCanDocument( element );
					break;
                // Get the Autohidden state
				case "Autohidden":
					result = DockingManager.GetCanAutoHide( element );
					break;
                // Get the Hidden state
				case "Hidden":
					result = DockingManager.GetCanClose( element );
					break;
			}

			return result;
		}

        /// <summary>
        /// Get the dock option
        /// </summary>
        /// <param name="optionName"></param>
        /// <param name="element"></param>
		private bool GetDockOption( string optionName, FrameworkElement element )
		{
			bool result = true;
			DockState state = DockingManager.GetState( element );

			switch( optionName )
			{
                // Get the dock option as CanDock
				case "CanDock":
					result = DockingManager.GetCanDock( element );
					break;
                // Get the dock option as CanFloat
				case "CanFloat":
					result = DockingManager.GetCanFloat( element );
					break;
                // Get the dock option as CanClose
				case "CanClose":
					result = DockingManager.GetCanClose( element );
					break;
                // Get the dock option as CanAutoHide
				case "CanAutoHide":
					result = DockingManager.GetCanAutoHide( element );
					break;
                //Get the dock option as CanDragAutoHidden
                case "CanDragAutoHidden":
                    result = DockingManager.GetCanDragAutoHidden(element);
                    break;
                // Get the dock option as CanDocument
				case "CanDocument":
					result = DockingManager.GetCanDocument( element );
					break;
                // Get the dock option as CanDrag
				case "CanDrag":
					result = DockingManager.GetCanDrag( element );
					break;
                // Get the dock option as NoHeader
				case "NoHeader":
					result = DockingManager.GetNoHeader( element );
					break;
                //Get the dock option as AllowSnap
                case "AllowSnap":
                    result = DockingManager.GetAllowSnap(element);
                    break;
                // Get the dock option as Dock
				case "Dock":
					result = state == DockState.Dock;
					break;
                // Get the dock option as Float
				case "Float":
					result = state == DockState.Float;
					break;
                // Get the dock option as Document
				case "Document":
					result = state == DockState.Document;
					break;
                // Get the dock option as AutoHidden
				case "AutoHidden":
					result = state == DockState.AutoHidden;
					break;
                // Get the dock option as Hidden
				case "Hidden":
					result = state == DockState.Hidden;
					break;
                case "AllowPin":
                    result = DocumentContainer.GetAllowPin(element);
                    break;                    
                case "ShowPin":
                    result = DocumentContainer.GetShowPin(element);
                    break;
            }

			return result;
		}
        /// <summary>
        /// Set the dock option
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
		private void SetDockOption( string optionName, FrameworkElement element, bool value )
		{
			switch( optionName )
			{
                // Set dock option as CanDock
				case "CanDock":
					DockingManager.SetCanDock( element, value );
					break;
                // Set dock option as CanFloat
				case "CanFloat":
					DockingManager.SetCanFloat( element, value );
					break;
                // Set dock option as CanClose
				case "CanClose":
					DockingManager.SetCanClose( element, value );
					break;
                // Set dock option as CanAutoHide
				case "CanAutoHide":
					DockingManager.SetCanAutoHide( element, value );
					break;
                // Set dock option as CanDragAutoHidden
                case "CanDragAutoHidden":
                    DockingManager.SetCanDragAutoHidden(element, value);
                    break;
                // Set dock option as CanDocument
				case "CanDocument":
					DockingManager.SetCanDocument( element, value );
					break;
                // Set dock option as CanDrag
				case "CanDrag":
					DockingManager.SetCanDrag( element, value );
					break;
                // Set dock option as NoHeader
				case "NoHeader":
					DockingManager.SetNoHeader( element, value );
					break;
                case "AllowSnap":
                    DockingManager.SetAllowSnap(element, value);
                    break;

                case "AllowPin":
                    if (DockingManager.GetState(element) == DockState.Document)
                        DocumentContainer.SetAllowPin(element, value);
                    break;
                case "ShowPin":
                    if (DockingManager.GetState(element) == DockState.Document)
                        DocumentContainer.SetShowPin(element, value);
                    break;
			}
		}

        /// <summary>
        /// Initialize the windows forms host
        /// </summary>
        
		private void InitWindowsFormsHost()
		{
			if( DockingManager.UseInteropCompatibilityMode )
			{
				WindowsFormsHost host = new WindowsFormsHost();
				WinForms.Button btn = new WinForms.Button();
				btn.Text = "Winows Forms Button";
				host.Child = btn;
				FindResults.Content = host;
				WindowsFormsHost.EnableWindowsFormsInterop();
			}
		}

        /// <summary>
        /// Ckear the events
        /// </summary>
        private void OnClear(object sender, EventArgs args)
        {
            Log.Text = "";
        }
       
        /// <summary>
        /// Events
        /// </summary>
		private void SubscribeForEvents()
		{
            //Subscribe the AutoHideAnimationStart property changed event
			DockingManager.AutoHideAnimationStart += new RoutedEventHandler( OnEventRaising );
            //Subscribe the AutoHideAnimationStop property changed event
			DockingManager.AutoHideAnimationStop += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowActivated property changed event
			DockingManager.WindowActivated += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDeactivated property changed event
			DockingManager.WindowDeactivated += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDragStart property changed event
			DockingManager.WindowDragStart += new RoutedEventHandler( OnEventRaising );
            //Subscribe the WindowDragEnd property changed event
			DockingManager.WindowDragEnd += new RoutedEventHandler( OnEventRaising );
            //Subscribe the ActiveWindow property changed event
			DockingManager.ActiveWindowChanged += new PropertyChangedCallback( OnPropertyChanged );
        }       

        #endregion

        #region Events
        /// <summary>
        /// Routed event raising
        /// </summary>
		private void OnEventRaising( object sender, RoutedEventArgs e )
		{
			FrameworkElement element = e.OriginalSource as FrameworkElement;
			string name = element != null ? element.Name : string.Empty;
            Log.TextWrapping = TextWrapping.Wrap;
            Log.Text =Log.Text + e.RoutedEvent.Name + " : " + name + "\n";
            Scroll.ScrollToBottom();
			
		}
        /// <summary>
        /// Property changed event raising
        /// </summary>
		private void OnPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			string name = e.NewValue != null ? ( e.NewValue as FrameworkElement ).Name : string.Empty;
            Log.TextWrapping = TextWrapping.Wrap;
			Log.Text= Log.Text + e.Property.Name + " : " + name + "\n" ;
            Scroll.ScrollToBottom();
		}
        
    	#endregion

        bool m_layoutflag = true;
        private void DockingManager_LayoutUpdated(object sender, EventArgs e)
        {
            if (m_layoutflag)
            {
                
               // SfSkinManager.SetVisualStyle(this, VisualStyles.Metro);
                m_layoutflag = false;
            }
        }

        /// <summary>
        /// Handles the CloseAllTabs event of the DockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.CloseTabEventArgs"/> instance containing the event data.</param>
        private void DockingManager_CloseAllTabs(object sender, CloseTabEventArgs e)
        {
            string closingtabs = "";
            MessageBoxResult result = MessageBox.Show("Do you want to close the tabs? ", "Closing Tabs", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < e.ClosingTabItems.Count; i++)
                {
                    TabItemExt tabitem = e.ClosingTabItems[i] as TabItemExt;
                    if (tabitem.Content != null && (tabitem.Content as ContentPresenter) != null)
                    {
                        ContentPresenter presenter = tabitem.Content as ContentPresenter;
                        if (presenter != null && presenter.Content != null)
                        {
                            closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(presenter.Content as DependencyObject) ;
                        }
                    }
                }
                Log.TextWrapping = TextWrapping.Wrap;
                Log.Text = Log.Text + "Closed Tabs" + " : " + closingtabs + "\n";
                Scroll.ScrollToBottom();
            }
            else if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the CloseOtherTabs event of the DockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.CloseTabEventArgs"/> instance containing the event data.</param>
        private void DockingManager_CloseOtherTabs(object sender, CloseTabEventArgs e)
        {
            string closingtabs = "";
            MessageBoxResult result = MessageBox.Show("Do you want to close the tabs? ", "Closing Tabs", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < e.ClosingTabItems.Count; i++)
                {
                    TabItemExt tabitem = e.ClosingTabItems[i] as TabItemExt;
                    if (tabitem.Content != null && (tabitem.Content as ContentPresenter) != null)
                    {
                        ContentPresenter presenter = tabitem.Content as ContentPresenter;
                        if (presenter != null && presenter.Content != null)
                        {
                            closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(presenter.Content as DependencyObject) ;
                        }
                    }
                }
                Log.TextWrapping = TextWrapping.Wrap;
                Log.Text = Log.Text + "Closed Tabs" + " : " + closingtabs + "\n";
                Scroll.ScrollToBottom();
            }
            else if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the DocumentClosing event of the DockingManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Tools.Controls.CancelingRoutedEventArgs"/> instance containing the event data.</param>
        private void DockingManager_DocumentClosing(object sender, CancelingRoutedEventArgs e)
        {

        }

        private void DockingManager_WindowMoving(object sender, WindowMovingEventArgs e)
        {
            //Log.TextWrapping = TextWrapping.Wrap;
            //Log.Text = Log.Text + "The Window " + DockingManager.GetHeader(sender as DependencyObject) + " X position : " + e.X + "\n";
            //Log.Text = Log.Text + "The Window " + DockingManager.GetHeader(sender as DependencyObject) + " Y position : " + e.Y + "\n";
            //Scroll.ScrollToBottom();
        }

        private void SavetoanXml_Click(object sender, RoutedEventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("DockStates.xml");
            DockingManager.SaveDockState(writer);
            writer.Close();
        }

        private void LoadFromXmlNode_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlReader reader = XmlReader.Create("DockStates.xml");
            reader.MoveToContent();
            XmlNode node3 = xmldoc.ReadNode(reader);
            DockingManager.LoadDockState(node3);
            reader.Close();
        }

        private void LoadFromXmlReader_Click(object sender, RoutedEventArgs e)
        {
            XmlReader reader = XmlReader.Create("DockStates.xml");
            DockingManager.LoadDockState(reader);
            reader.Close();
        }

        private void DisabledCloseButtonsBehavior_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            OnMenuItemClick(item);

            DisabledButtonsBehavior mode = (DisabledButtonsBehavior)Enum.Parse(typeof(DisabledButtonsBehavior),
                (string)item.Header);
            DockingManager.DisabledCloseButtonsBehavior = mode;
        }
        private void DockingManager_IsSelectedDocument(FrameworkElement sender, IsSelectedChangedEventArgs e)
        {
            if (DockingManager.DocContainer != null && SfSkinManager.GetVisualStyle(this) != SfSkinManager.GetVisualStyle(DockingManager.DocContainer as DependencyObject))
            {
                SfSkinManager.SetVisualStyle(DockingManager.DocContainer as DependencyObject, SfSkinManager.GetVisualStyle(this));
            }
        }
       
        /// <summary>
        /// Update FlatLayout to the DockingManager
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event args</param>
        private void enableFlatLayoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).IsChecked)
                DockingManager.EnableFlatLayout = true;
            else
                DockingManager.EnableFlatLayout = false;

        }

        private void OnDockBehaviorChanged(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            OnMenuItemClick(item);
            DockBehavior type = (DockBehavior)Enum.Parse(typeof(DockBehavior),
                (string)item.Header);
            DockingManager.DockBehavior = type;
        }

        private void OnDockBehaviorMenuOpened(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            foreach (MenuItem subitem in item.Items)
            {
                if (subitem.Header.ToString() == DockingManager.DockBehavior.ToString())
                {
                    subitem.IsChecked = true;
                }
                else
                {
                    subitem.IsChecked = false;
                }
            }
        }
    }
}

