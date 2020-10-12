#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.diagrambackstage.wpf
{
   public class DiagramCommonViewModel : INotifyPropertyChanged
    {
       private ICommand m_ExportFiles;

       public ICommand ExportFiles
       {
           get { return m_ExportFiles; }
           set
           {
               if (m_ExportFiles != value)
               {
                   m_ExportFiles = value;
                   OnPropertyChanged("ExportFiles");
               }
           }
       }

       private string _mFrontPageImge;

       public string FrontPageImge
       {
           get
           {
               return _mFrontPageImge;
           }
           set
           {
               if (_mFrontPageImge != value)
               {
                   _mFrontPageImge = value;
                   OnPropertyChanged("FrontPageImge");
               }
           }
       }
       private Visibility m_DiagramVisibility = Visibility.Collapsed;

       public Visibility DiagramVisibility
       {
           get { return m_DiagramVisibility; }
           set
           {
               if (m_DiagramVisibility != value)
               {
                   m_DiagramVisibility = value;
                   OnPropertyChanged("DiagramVisibility");
               }
           }
       }

       private ICommand m_ImportFiles;

       public ICommand ImportFiles
       {
           get { return m_ImportFiles; }
           set
           {
               if (m_ImportFiles != value)
               {
                   m_ImportFiles = value;
                   OnPropertyChanged("ImportFiles");
               }
           }
       }

       private ICommand m_DeleteFiles;

       public ICommand DeleteFiles
       {
           get { return m_DeleteFiles; }
           set
           {
               if (m_DeleteFiles != value)
               {
                   m_DeleteFiles = value;
                   OnPropertyChanged("DeleteFiles");
               }
           }
       }

       private ICommand m_SelectAll;

       public ICommand SelectAll
       {
           get { return m_SelectAll; }
           set
           {
               if (m_SelectAll != value)
               {
                   m_SelectAll = value;
                   OnPropertyChanged("SelectAll");
               }
           }
       }

       private ICommand m_ClearSelection;

       public ICommand ClearSelection
       {
           get { return m_ClearSelection; }
           set
           {
               if (m_ClearSelection != value)
               {
                   m_ClearSelection = value;
                   OnPropertyChanged("ClearSelection");
               }
           }
       }
       private int m_SelectedItemsCount;

       public int SelectedItemsCount
       {
           get { return m_SelectedItemsCount; }
           set
           {
               if (m_SelectedItemsCount != value)
               {
                   m_SelectedItemsCount = value;
                   OnPropertyChanged("SelectedItemsCount");
               }
           }
       }
       private ICommand m_RenameFile;

       public ICommand RenameFile
       {
           get { return m_RenameFile; }
           set
           {
               if (m_RenameFile != value)
               {
                   m_RenameFile = value;
                   OnPropertyChanged("RenameFile");
               }
           }
       }
       private Visibility m_CanExportImport = Visibility.Collapsed;

       public Visibility CanExportImport
       {
           get { return m_CanExportImport; }
           set
           {
               if (m_CanExportImport != value)
               {
                   m_CanExportImport = value;
                   OnPropertyChanged("CanExportImport");
               }
           }
       }
       protected virtual void OnPropertyChanged(string prop)
       {
           if (PropertyChanged != null)
           {
               PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
           }
       }

       private ICommand m_Create;

       public ICommand Create
       {
           get { return m_Create; }
           set
           {
               if (m_Create != value)
               {
                   m_Create = value;
                   OnPropertyChanged("Create");
               }
           }
       }


       private ICommand m_itemClick;
       public ICommand ItemClick
       {
           get { return m_itemClick; }
           set
           {
               if (m_itemClick != value)
               {
                   m_itemClick = value;
                   OnPropertyChanged("ItemClick");
               }
           }
       }

       public event PropertyChangedEventHandler PropertyChanged;

   
    }
}
