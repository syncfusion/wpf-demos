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
using Syncfusion.Windows.Shared;
using System.IO;
using Syncfusion.XlsIO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Documents;
using Syncfusion.Windows.ComponentModel;
using Microsoft.Win32;
using Syncfusion.Windows.Controls.Grid;

namespace ImportingDemo.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        #region Fields

        private IMainView mainView;
        private IWorkbook workbook;
        private ExcelEngine excelEngine;
        private int activeGridIndex;
        private FontFamily fontFamily = new FontFamily("Arial");
        private double fontSize = 12;
        private FontWeight fontWeight;
        private FontStyle fontStyle;
        private TextDecorationCollection textDecorations;
        private Brush foreground;
        private Brush background;
        private HorizontalAlignment horizontalAlignment;
        private VerticalAlignment verticalAlignment;
        private IEnumerable<FontFamily> fontFamilyList;
        private IEnumerable<double> fontSizeList;

        #endregion

        public MainViewModel(IMainView mainview)
        {
            this.mainView = mainview;
            Initialize();
        }

        #region properties

        public IMainView MainView
        {
            get
            {
                return mainView;
            }
        }

        public IWorkbook Workbook
        {
            get
            {
                return workbook;
            }
        }

        public int ActiveTabIndex
        {
            get
            {
                return activeGridIndex;
            }
            set
            {
                activeGridIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }

        }

        public FontFamily FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {
                fontFamily = value;
                RaisePropertyChanged("FontFamily");
                if (MainView != null)
                {
                    MainView.CurrentCellStyleChanged(ActiveTabIndex, "FontFamily", fontFamily);
                }
            }
        }

        public double FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                RaisePropertyChanged("FontSize");
                if (MainView != null)
                {
                    MainView.CurrentCellStyleChanged(ActiveTabIndex, "FontSize", fontSize);
                }
            }
        }

        public FontWeight FontWeight
        {
            get
            {
                return fontWeight;
            }
            set
            {
                fontWeight = value;
                RaisePropertyChanged("FontWeight");
                if (MainView != null)
                {
                    MainView.CurrentCellStyleChanged(ActiveTabIndex, "FontWeight", fontWeight);
                }
            }
        }

        public FontStyle FontStyle
        {
            get
            {
                return fontStyle;
            }
            set
            {
                fontStyle = value;
                RaisePropertyChanged("FontStyle");
                if (MainView != null)
                {
                    MainView.CurrentCellStyleChanged(ActiveTabIndex, "FontStyle", fontStyle);
                }
            }
        }

        public TextDecorationCollection TextDecorations
        {
            get
            {
                return textDecorations;
            }
            set
            {
                textDecorations = value;
                RaisePropertyChanged("TextDecorations");
                if (MainView != null)
                {
                    MainView.CurrentCellStyleChanged(ActiveTabIndex, "TextDecorations", textDecorations);
                }
            }
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return horizontalAlignment;
            }
            set
            {
                horizontalAlignment = value;
                RaisePropertyChanged("HorizontalAlignment");
            }
        }

        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return verticalAlignment;
            }
            set
            {
                verticalAlignment = value;
                RaisePropertyChanged("VerticalAlignment");
            }
        }

        public IEnumerable<FontFamily> FontFamilyList
        {
            get
            {
                if (this.fontFamilyList == null)
                {
                    this.fontFamilyList = new List<FontFamily>
                    {
                        new FontFamily("Arial"),
                        new FontFamily("Arial Black"),
                        new FontFamily("Calibri"),
                        new FontFamily("Comic Sans MS"),
                        new FontFamily("Courier New"),
                        new FontFamily("Georgia"),
                        new FontFamily("Lucida Sans Unicode"),
                        new FontFamily("Portable User Interface"),
                        new FontFamily("Times New Roman"),
                        new FontFamily("Trebuchet MS"),
                        new FontFamily("Verdana"),
                        new FontFamily("Webdings")
                    };
                }

                return this.fontFamilyList;
            }
            set
            {
                this.fontFamilyList = value;
                this.RaisePropertyChanged("FontFamilyList");
            }
        }

        public IEnumerable<double> FontSizeList
        {
            get
            {
                if (fontSizeList == null)
                {
                    fontSizeList = new List<double>
                    {
                        8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72
                    };
                }
                return fontSizeList;
            }
            set
            {
                this.fontSizeList = value;
                this.RaisePropertyChanged("FontSizeList");
            }
        }

        #endregion

        #region Helper Methods

        private void Initialize()
        {
            excelEngine = new ExcelEngine();

            FileStream fileStream = new FileStream(@"..\..\Data\Sample.xlsx", FileMode.Open);
            if (fileStream != null && MainView!=null)
            {
                workbook = excelEngine.Excel.Workbooks.Open(fileStream, ExcelOpenType.Automatic);
                MainView.LoadWorkbook(Workbook);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand<object> _OpenCommand;
        public DelegateCommand<object> OpenCommand
        {
            get
            {
                if (_OpenCommand == null)
                    _OpenCommand = new DelegateCommand<object>(OnOpenCommandExecute);
                return _OpenCommand;
            }
        }

        private void OnOpenCommandExecute(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files(*.xls)|*.xls|Files(*.xlsx)|*.xlsx";
            if ((bool)openFileDialog.ShowDialog())
            {
                FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open);
                if (stream != null)
                {
                    workbook.Close();
                    workbook = excelEngine.Excel.Workbooks.Open(stream, ExcelOpenType.Automatic);
                    MainView.LoadWorkbook(Workbook);
                }
            }
        }

        private DelegateCommand<object> _PrintCommand;
        public DelegateCommand<object> PrintCommand
        {
            get
            {
                if (_PrintCommand == null)
                    _PrintCommand = new DelegateCommand<object>(OnPrintCommandExecute);
                return _PrintCommand;
            }
        }

        private void OnPrintCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecutePrintCommand(ActiveTabIndex);
            }
        }

        private DelegateCommand<object> _UndoCommand;
        public DelegateCommand<object> UndoCommand
        {
            get
            {
                if (_UndoCommand == null)
                    _UndoCommand = new DelegateCommand<object>(OnUndoCommandExecute);
                return _UndoCommand;
            }
        }

        private void OnUndoCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecuteUndoCommand(ActiveTabIndex);
            }
        }


        private DelegateCommand<object> _RedoCommand;
        public DelegateCommand<object> RedoCommand
        {
            get
            {
                if (_RedoCommand == null)
                    _RedoCommand = new DelegateCommand<object>(OnRedoCommandExecute);
                return _RedoCommand;
            }
        }

        private void OnRedoCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecuteRedoCommand(ActiveTabIndex);
            }
        }


        private DelegateCommand<object> _SaveCommand;
        public DelegateCommand<object> SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute);
                return _SaveCommand;
            }
        }

        private void OnSaveCommandExecute(object param)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                DefaultExt = "xlsx",
                Filter = "Excel 97 to 2003 File(*.xls)|*.xls|Excel 2007 to 2010 File(*.xlsx)|*.xlsx",
                FilterIndex = 2,
            };
            if ((bool)sfd.ShowDialog())
            {
                using (Stream stream = sfd.OpenFile())
                {
                    if (sfd.FilterIndex == 1)
                    {
                        if (workbook.Version == ExcelVersion.Excel97to2003)
                            workbook.SaveAs(stream);
                        else
                        {
                            workbook.Version = ExcelVersion.Excel97to2003;
                            workbook.SaveAs(stream);
                        }
                    }
                    else if (sfd.FilterIndex == 2)
                    {
                        if (workbook.Version == ExcelVersion.Excel2007 || workbook.Version == ExcelVersion.Excel2010)
                            workbook.SaveAs(stream);
                        else
                        {
                            workbook.Version = ExcelVersion.Excel2010;
                            workbook.SaveAs(stream);
                        }
                    }
                }
            }
        }

        private DelegateCommand<object> _CopyCommand;
        public DelegateCommand<object> CopyCommand
        {
            get
            {
                if (_CopyCommand == null)
                    _CopyCommand = new DelegateCommand<object>(OnCopyCommandExecute);

                return _CopyCommand;
            }
        }

        private void OnCopyCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecuteCopyCommand(ActiveTabIndex);
            }
        }

        private DelegateCommand<object> _CutCommand;
        public DelegateCommand<object> CutCommand
        {
            get
            {
                if (_CutCommand == null)
                    _CutCommand = new DelegateCommand<object>(OnCutCommandExecute);

                return _CutCommand;
            }
        }

        private void OnCutCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecuteCutCommand(ActiveTabIndex);
            }
        }

        private DelegateCommand<object> _PasteCommand;
        public DelegateCommand<object> PasteCommand
        {
            get
            {
                if (_PasteCommand == null)
                    _PasteCommand = new DelegateCommand<object>(OnPasteCommandExecute);
                return _PasteCommand;
            }
        }

        private void OnPasteCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.ExecutePasteCommand(ActiveTabIndex);
            }
        }

        private DelegateCommand<object> _BackgroundCommand;
        public DelegateCommand<object> BackgroundCommand
        {
            get
            {
                if (_BackgroundCommand == null)
                    _BackgroundCommand = new DelegateCommand<object>(OnBackgroundCommandExecute);
                return _BackgroundCommand;
            }
        }

        private void OnBackgroundCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.CurrentCellStyleChanged(ActiveTabIndex, "Background", null);
            }
        }

        private DelegateCommand<object> _ForegroundCommand;
        public DelegateCommand<object> ForegroundCommand
        {
            get
            {
                if (_ForegroundCommand == null)
                    _ForegroundCommand = new DelegateCommand<object>(OnForegroundCommandExecute);
                return _ForegroundCommand;
            }
        }

        private void OnForegroundCommandExecute(object param)
        {
            if (MainView != null)
            {
                MainView.CurrentCellStyleChanged(ActiveTabIndex, "Foreground", null);
            }
        }

        private DelegateCommand<object> _HorizontalAlignmentCommand;
        public DelegateCommand<object> HorizontalAlignmentCommand
        {
            get
            {
                if (_HorizontalAlignmentCommand == null)
                    _HorizontalAlignmentCommand = new DelegateCommand<object>(OnHorizontalAlignmentCommandExecute);
                return _HorizontalAlignmentCommand;
            }
        }

        private void OnHorizontalAlignmentCommandExecute(object param)
        {
            if (param != null)
            {
                if (param.ToString() == "Left")
                    HorizontalAlignment = HorizontalAlignment.Left;
                else if (param.ToString() == "Right")
                    HorizontalAlignment = HorizontalAlignment.Right;
                else if (param.ToString() == "Center")
                    HorizontalAlignment = HorizontalAlignment.Center;
            }
            if (MainView != null)
            {
                MainView.CurrentCellStyleChanged(ActiveTabIndex, "HorizontalAlignment", HorizontalAlignment);
            }
        }

        private DelegateCommand<object> _VerticalAlignmentCommand;
        public DelegateCommand<object> VerticalAlignmentCommand
        {
            get
            {
                if (_VerticalAlignmentCommand == null)
                    _VerticalAlignmentCommand = new DelegateCommand<object>(OnVerticalAlignmentCommandExecute);
                return _VerticalAlignmentCommand;
            }
        }

        private void OnVerticalAlignmentCommandExecute(object param)
        {
            if (param != null)
            {
                if (param.ToString() == "Top")
                    VerticalAlignment = VerticalAlignment.Top;
                else if (param.ToString() == "Bottom")
                    VerticalAlignment = VerticalAlignment.Bottom;
                else if (param.ToString() == "Center")
                    VerticalAlignment = VerticalAlignment.Center;
            }
            if (MainView != null)
            {
                MainView.CurrentCellStyleChanged(ActiveTabIndex, "VerticalAlignment", VerticalAlignment);
            }
        }

        private DelegateCommand<object> _FontSizeCommand;
        public DelegateCommand<object> FontSizeCommand
        {
            get
            {
                if (_FontSizeCommand == null)
                    _FontSizeCommand = new DelegateCommand<object>(OnFontSizeCommandExecute);
                return _FontSizeCommand;
            }
        }

        private void OnFontSizeCommandExecute(object param)
        {
            if (param != null &&MainView != null)
            {
                MainView.ExecuteFontSizeCommand(ActiveTabIndex, bool.Parse(param.ToString()));
            }
        }

        #endregion
    }
}
