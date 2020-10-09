Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Syncfusion.Windows.Edit

Namespace SyntaxHighlighting1

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>

    Partial Public Class Window11
        Inherits ChromelessWindow

        Public Sub New()
            AddHandler mnulg1.Click, AddressOf mnulg1_Click
            AddHandler mnulg2.Click, AddressOf mnulg1_Click
            AddHandler mnulg3.Click, AddressOf mnulg1_Click
            AddHandler mnulg4.Click, AddressOf mnulg1_Click
        End Sub

        Private Sub mnulg1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim menuitem As MenuItem = CType(sender, MenuItem)
            Select Case menuitem.Header.ToString()
                Case "CSharp"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.CSharp
                Case "Visual Basic"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.VisualBasic
                Case "Text"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.Text
                Case "XAML"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.XAML
                Case "XML"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.XML
                Case "Custom"
                    editControl.DocumentLanguage = Syncfusion.Windows.Edit.Languages.Custom
                    editControl.CustomLanguage = TryCast(Me.Resources("symbolslang"), EditLanguage)
            End Select
            UnCheckAll()
            menuitem.IsChecked = True
        End Sub

        Private Sub UnCheckAll()
            mnulg1.IsChecked = False
            mnulg2.IsChecked = False
            mnulg3.IsChecked = False
            mnulg4.IsChecked = False
        End Sub
    End Class

End Namespace
