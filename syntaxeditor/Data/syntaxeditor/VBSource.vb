#Region "Copyright Syncfusion Inc. 2001 - 2013"
'
'  Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
'
'  Use of this code is subject to the terms of our license.
'  A copy of the current license can be obtained at any time by e-mailing
'  licensing@syncfusion.com. Any infringement will be prosecuted under
'  applicable laws. 
'
#End Region

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Runtime.InteropServices '
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports Syncfusion.Windows.Forms.Edit
Imports Syncfusion.Windows.Forms.Edit.Dialogs
Imports Syncfusion.Windows.Forms.Edit.Implementation.Config
Imports Syncfusion.Windows.Forms.Edit.Interfaces
Imports Syncfusion.Windows.Forms.Edit.Implementation.IO
Imports Syncfusion.Windows.Forms.Edit.Implementation.Formatting
Imports Syncfusion.Windows.Forms.Edit.Implementation.Parser
Imports Syncfusion.IO


Public Class Form1
    Inherits System.Windows.Forms.Form '

    Private mainMenu1 As System.Windows.Forms.MainMenu
    Private menuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem3 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem5 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem4 As System.Windows.Forms.MenuItem

    Private BasePath As String = Path.GetDirectoryName(Application.ExecutablePath) + "..\..\Test Files\Test.lsp"
    Private ConfigPath As String = Path.GetDirectoryName(Application.ExecutablePath) + "..\..\..\VB\config.xml"

    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing

    Private menuItem6 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem7 As System.Windows.Forms.MenuItem
    Private editControl1 As Syncfusion.Windows.Forms.Edit.EditControl
    Private WithEvents menuItem9 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem8 As System.Windows.Forms.MenuItem



    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        Me.editControl1.CurrentColumn = 0
        Me.editControl1.CurrentLine = 0

        Me.editControl1.Configurator.Open(ConfigPath)
        Me.editControl1.ShowCollapse = True
        Me.editControl1.ShowLineNumbers = True
    End Sub 'New


    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose

#Region "Windows Form Designer generated code"

    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.mainMenu1 = New System.Windows.Forms.MainMenu()
        Me.menuItem1 = New System.Windows.Forms.MenuItem()
        Me.menuItem2 = New System.Windows.Forms.MenuItem()
        Me.menuItem3 = New System.Windows.Forms.MenuItem()
        Me.menuItem5 = New System.Windows.Forms.MenuItem()
        Me.menuItem4 = New System.Windows.Forms.MenuItem()
        Me.menuItem6 = New System.Windows.Forms.MenuItem()
        Me.menuItem7 = New System.Windows.Forms.MenuItem()
        Me.menuItem8 = New System.Windows.Forms.MenuItem()
        Me.menuItem9 = New System.Windows.Forms.MenuItem()
        Me.editControl1 = New Syncfusion.Windows.Forms.Edit.EditControl()
        CType(Me.editControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1, Me.menuItem8, Me.menuItem9})
        '
        'menuItem1
        '
        Me.menuItem1.Index = 0
        Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem2, Me.menuItem3, Me.menuItem5, Me.menuItem4, Me.menuItem6, Me.menuItem7})
        Me.menuItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.menuItem1.Text = "&File"
        '
        'menuItem2
        '
        Me.menuItem2.Index = 0
        Me.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.menuItem2.ShowShortcut = False
        Me.menuItem2.Text = "&New"
        '
        'menuItem3
        '
        Me.menuItem3.Index = 1
        Me.menuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.menuItem3.ShowShortcut = False
        Me.menuItem3.Text = "&Open"
        '
        'menuItem5
        '
        Me.menuItem5.Index = 2
        Me.menuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.menuItem5.ShowShortcut = False
        Me.menuItem5.Text = "&Save"
        '
        'menuItem4
        '
        Me.menuItem4.Index = 3
        Me.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS
        Me.menuItem4.ShowShortcut = False
        Me.menuItem4.Text = "Save&As"
        '
        'menuItem6
        '
        Me.menuItem6.Index = 4
        Me.menuItem6.Text = "-"
        '
        'menuItem7
        '
        Me.menuItem7.Index = 5
        Me.menuItem7.Text = "Exit"
        '
        'menuItem8
        '
        Me.menuItem8.Index = 1
        Me.menuItem8.Text = "Load TestFile"
        '
        'menuItem9
        '
        Me.menuItem9.Index = 2
        Me.menuItem9.Text = "Display ConfigFile"
        '
        'editControl1
        '
        Me.editControl1.AutoIndent = True
        Me.editControl1.AutoScrollPosition = New System.Drawing.Point(0, 0)
        Me.editControl1.BackColor = System.Drawing.SystemColors.Window
        Me.editControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.editControl1.CurrentColumn = 1
        Me.editControl1.CurrentPosition = New System.Drawing.Point(1, 1)
        Me.editControl1.CurrentLine = 1
        Me.editControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editControl1.FileOpened = Nothing
        Me.editControl1.GraphicsCompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default
        Me.editControl1.GraphicsInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default
        Me.editControl1.GraphicsSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default
        Me.editControl1.GraphicsTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        'Me.editControl1.KeyBindingProcessor = CType(resources.GetObject("editControl1.KeyBindingProcessor"), Syncfusion.Shared.Utils.KeyBinding.Implementation.KeyProcessor)
        Me.editControl1.Name = "editControl1"
        Me.editControl1.ScrollOffsetBottom = 0
        Me.editControl1.ScrollOffsetLeft = 14
        Me.editControl1.ScrollOffsetRight = 0
        Me.editControl1.ScrollOffsetTop = 0
        Me.editControl1.ShowCollapse = True
        Me.editControl1.ShowLineNumbers = False
        Me.editControl1.ShowMarkers = False
        Me.editControl1.ShowWhitespaces = False
        Me.editControl1.Size = New System.Drawing.Size(492, 395)
        Me.editControl1.TabIndex = 0
        Me.editControl1.TabSize = 2
        Me.editControl1.Text = ""
        Me.editControl1.VirtualSize = New System.Drawing.Size(16, 17)
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(492, 395)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.editControl1})
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Custom Configuration File Demo"
        CType(Me.editControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 
#End Region


    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main


    ' Open an existing File
    Private Sub menuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem3.Click
        Me.editControl1.LoadFile()
    End Sub 'menuItem3_Click


    ' Create a new File
    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem2.Click
        Me.editControl1.[New]()
    End Sub 'menuItem2_Click


    Private Sub menuItem5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem5.Click
        Me.editControl1.Save()
    End Sub 'menuItem5_Click


    Private Sub menuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem4.Click
        Me.editControl1.SaveAs()
    End Sub 'menuItem4_Click


    Private Sub menuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem7.Click
        Me.Close()
    End Sub 'menuItem7_Click


    Private Sub menuItem8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem8.Click
        Me.editControl1.LoadFile(BasePath)
    End Sub 'menuItem8_Click


    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = Not Me.editControl1.SaveModified()
    End Sub 'Form1_Closing


    Private Sub menuItem9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem9.Click
        Me.editControl1.LoadFile(ConfigPath)
    End Sub 'menuItem9_Click
End Class 'Form1 
