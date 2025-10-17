using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace syncfusion.organizationallayout.wpf.Views
{
    /// <summary>
    /// Interaction logic for Properties.xaml
    /// </summary>
    public partial class Properties : ChromelessWindow
    {
        public Properties()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            this.Loaded += Properties_Loaded;
        }

        private void Properties_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                NameTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.Name;
                RoleTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.Role;
                EMailTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.Email;
                PhoneTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.PhoneNumber;
                EMPIDTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.EmployeeID;
                TierTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.Tier;
                TeamTextBox.Text = (this.DataContext as organizationallayoutNode).CustomContent.Team;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (AnnotationEditorViewModel anno in (this.DataContext as organizationallayoutNode).Annotations as AnnotationCollection)
            {
                if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.Name)
                {
                    anno.Content = NameTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.Role)
                {
                    anno.Content = RoleTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.EmployeeID)
                {
                    anno.Content = EMPIDTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.Team)
                {
                    anno.Content = TeamTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.Email)
                {
                    anno.Content = EMailTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.PhoneNumber)
                {
                    anno.Content = PhoneTextBox.Text.ToString();
                }
                else if (anno.Content.ToString() == (this.DataContext as organizationallayoutNode).CustomContent.Tier)
                {
                    anno.Content = TierTextBox.Text.ToString();
                }
            }
            
            (this.DataContext as organizationallayoutNode).CustomContent.Name = NameTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.Role = RoleTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.EmployeeID = EMPIDTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.Team = TeamTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.Email = EMailTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.PhoneNumber = PhoneTextBox.Text.ToString();
            (this.DataContext as organizationallayoutNode).CustomContent.Tier = TierTextBox.Text.ToString();

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
