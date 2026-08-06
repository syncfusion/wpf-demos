using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Represents a custom control that serves as a container for a demo sample. It provides a structured layout with a main content area for the demo itself.
    /// </summary>
    [ContentProperty("Content")]
    [DefaultProperty("Content")]
    public class DemoControl : UserControl, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoControl"/> class.
        /// </summary>
        public DemoControl()
        {
            this.DefaultStyleKey = typeof(DemoControl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoControl"/> class with a specified theme.
        /// </summary>
        /// <param name="themename">The name of the theme to apply to the control.</param>
        public DemoControl(string themename) : this()
        {
            SfSkinManager.SetTheme(this, Theme.GetTheme(themename));
        }

        Grid ROOT;
        ContentPresenter SAMPLEVIEW;
        Grid OPTIONSVIEW;
        Border OPTIONSBORDER;

        /// <summary>
        /// When overridden in a derive class, it is invoked whenever application code or internal processes class <see cref="OnApplyTemplate"/>
        /// </summary>
        public override void OnApplyTemplate()
        {
            ROOT = GetTemplateChild("ROOT") as Grid;
            SAMPLEVIEW = GetTemplateChild("SAMPLEVIEW") as ContentPresenter;
            OPTIONSVIEW = GetTemplateChild("OPTIONSVIEW") as Grid;
            OPTIONSBORDER = GetTemplateChild("OPTIONSBORDER") as Border;

            base.OnApplyTemplate();

            if (Options == null)
            {
                OPTIONSVIEW.Visibility = Visibility.Collapsed;
                ROOT.ColumnDefinitions[1].Width = new GridLength(0);
            }
            else
            {
                if (OptionsPosition == Dock.Right)
                {
                    ROOT.ColumnDefinitions[1].Width = OptionsSize;
                    OPTIONSVIEW.Margin = new Thickness(5, 0, 0, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(1, 0, 0, 0);
                }
                else if(OptionsPosition == Dock.Left)
                {
                    ROOT.ColumnDefinitions.RemoveAt(1);
                    ROOT.ColumnDefinitions.Insert(0, new ColumnDefinition() { Width = OptionsSize });
                    OPTIONSVIEW.Margin = new Thickness(0, 0, 5, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 0, 1, 0);
                    Grid.SetColumn(SAMPLEVIEW, 1);
                    Grid.SetColumn(OPTIONSVIEW, 0);
                }
                else if (OptionsPosition == Dock.Top)
                {
                    ROOT.ColumnDefinitions.Clear();
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = OptionsSize });
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    OPTIONSVIEW.Margin = new Thickness(0, 0, 0, 5);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 0, 0, 1);
                    Grid.SetRow(SAMPLEVIEW, 1);
                    Grid.SetRow(OPTIONSVIEW, 0);
                }
                else if (OptionsPosition == Dock.Bottom)
                {
                    ROOT.ColumnDefinitions.Clear();
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    ROOT.RowDefinitions.Add(new RowDefinition() { Height = OptionsSize });
                    OPTIONSVIEW.Margin = new Thickness(0, 5, 0, 0);
                    OPTIONSBORDER.BorderThickness = new Thickness(0, 1, 0, 0);
                    Grid.SetRow(SAMPLEVIEW, 0);
                    Grid.SetRow(OPTIONSVIEW, 1);
                }
            }
        }

        /// <summary>
        /// Releases all resource by the <see cref="DemoControl"/>
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all Unmanaged resources used by the <see cref="DemoControl"/> and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {

        }

        /// <summary>
        ///  Gets or sets the options view.
        /// </summary>
        public object Options
        {
            get { return (object)GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Options"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsProperty =
            DependencyProperty.Register("Options", typeof(object), typeof(DemoControl), new PropertyMetadata(null));


        /// <summary>
        ///  Gets or sets position of <see cref="DemoControl.Options"/> view. You can position left, right, top or button and contorl the width or height using <see cref="DemoControl.OptionsSize"/>
        /// </summary>
        public Dock OptionsPosition
        {
            get { return (Dock)GetValue(OptionsPositionProperty); }
            set { SetValue(OptionsPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionsPosition"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsPositionProperty =
            DependencyProperty.Register("OptionsPosition", typeof(Dock), typeof(DemoControl), new PropertyMetadata(Dock.Right));

        /// <summary>
        /// Gets or sets the width of <see cref="DemoControl.Options"/> view when <see cref="DemoControl.OptionsPosition"/> is <see cref="Dock.Left"/> and <see cref="Dock.Right"/>.
        /// Gets or sets the height of <see cref="DemoControl.Options"/> view when <see cref="DemoControl.OptionsPosition"/> is <see cref="Dock.Top"/> and <see cref="Dock.Bottom"/>.
        /// </summary>
        public GridLength OptionsSize
        {
            get { return (GridLength)GetValue(OptionsSizeProperty); }
            set { SetValue(OptionsSizeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionsSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsSizeProperty =
            DependencyProperty.Register("OptionsSize", typeof(GridLength), typeof(DemoControl), new PropertyMetadata(new GridLength(200)));

        /// <summary>
        /// Gets or sets the text displayed as options heading. you can hide the same by setting empty string.
        /// </summary>
        public string OptionsTitle
        {
            get { return (string)GetValue(OptionsTitleProperty); }
            set { SetValue(OptionsTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionsTitle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsTitleProperty =
            DependencyProperty.Register("OptionsTitle", typeof(string), typeof(DemoControl), new PropertyMetadata("OPTIONS"));

        /// <summary>
        /// Gets or sets the title of the demo, typically used for the display in the main application window. This property is not browsable in the designer.
        /// </summary>
        [Browsable(false)]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DemoControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the primary control being demonstrated. This property is not browsable in the designer.
        /// </summary>
        [Browsable(false)]
        public string ControlName
        {
            get { return (string)GetValue(ControlNameProperty); }
            set { SetValue(ControlNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ControlName"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ControlNameProperty =
            DependencyProperty.Register("ControlName", typeof(string), typeof(DemoControl), new PropertyMetadata(string.Empty)); 

        /// <summary>
        /// Gets or sets the description text for the demo. This property is not browsable in the designer.
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Description"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(DemoControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the item source for a collection of helplinks in the documentation
        /// </summary>
        public object DocumentsItemSource
        {
            get { return (object)GetValue(DocumentsItemSourceProperty); }
            set { SetValue(DocumentsItemSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DocumentsItemSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DocumentsItemSourceProperty =
            DependencyProperty.Register("DocumentsItemSource", typeof(object), typeof(DemoControl), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the HyperLinkStyle for the collection of helplinks in the documentation
        /// </summary>
        public Style HyperLinkStyle
        {
            get { return (Style)GetValue(HyperLinkStyleProperty); }
            set { SetValue(HyperLinkStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="HyperLinkStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HyperLinkStyleProperty =
            DependencyProperty.Register("HyperLinkStyle", typeof(Style), typeof(DemoControl), new PropertyMetadata(null));       
        
        /// <summary>
        /// Gets or sets the HorizontalScrollBarVisibility of the option panel
        /// </summary>
        public ScrollBarVisibility OptionsHorizontalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(OptionsHorizontalScrollBarVisibilityProperty); }
            set { SetValue(OptionsHorizontalScrollBarVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionsHorizontalScrollBarVisibility"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsHorizontalScrollBarVisibilityProperty =
            DependencyProperty.Register("OptionsHorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(DemoControl), new PropertyMetadata(ScrollBarVisibility.Disabled));


        /// <summary>
        /// Gets or Sets the VerticalScrollBarVisibility of the option panel
        /// </summary>
        public ScrollBarVisibility OptionsVerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(OptionsVerticalScrollBarVisibilityProperty); }
            set { SetValue(OptionsVerticalScrollBarVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionsVerticalScrollBarVisibility"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsVerticalScrollBarVisibilityProperty =
            DependencyProperty.Register("OptionsVerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(DemoControl), new PropertyMetadata(ScrollBarVisibility.Disabled));

        /// <summary>
        /// Gets or sets the SubCategoryDemos property that provides access to a list of DemoInfo objects.
        /// </summary>
        public List<DemoInfo> SubCategoryDemos
        {
            get { return ( List<DemoInfo>)GetValue(SubCategoryDemosProperty); }
            set { SetValue(SubCategoryDemosProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubCategoryDemos"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubCategoryDemosProperty =
            DependencyProperty.Register("SubCategoryDemos", typeof( List<DemoInfo>), typeof(DemoControl), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the value of SubCategorySelectedItem property in the Demo window.
        /// </summary>
        public DemoInfo SubCategorySelectedItem
        {
            get { return (DemoInfo)GetValue(SubCategorySelectedItemProperty); }
            set { SetValue(SubCategorySelectedItemProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubCategorySelectedItem"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubCategorySelectedItemProperty =
            DependencyProperty.Register("SubCategorySelectedItem", typeof(DemoInfo), typeof(DemoControl), new PropertyMetadata(null));
    }
}
