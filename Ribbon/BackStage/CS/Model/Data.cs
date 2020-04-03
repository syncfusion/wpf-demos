#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace BackStageSample
{
    /// <summary>
    /// Represents a model class.
    /// </summary>
   internal class Data : ObservableCollection<Info>
    {
        /// <summary>
        /// Maintains the info command.
        /// </summary>
        private DelegateCommand infoCommand;

        /// <summary>
        /// Gets and sets the info.
        /// </summary>
        public Info info { get; set; }
       
        #region constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="Data" /> class.
        /// </summary>
        public Data()
       {
           this.Add(new Info() { Heading = " Permissions ", Description = " Any one can open, copy and change any part of this document." , ButtonContent = "Protect Document" , ButtonIcon="protuctdoc.png"});
           this.Add(new Info() { Heading = " Prepare For Sharing", Description = "Document properties, printer path, author name and related dates.", ButtonContent = "Check For Issues", ButtonIcon = "checkforissues.png" });
       }
        #endregion

        #region Command
        /// <summary>
        /// Gets the info command.
        /// </summary>
        public ICommand InfoCommand
       {
           get
           {
               if (infoCommand == null)
                   infoCommand = new DelegateCommand(new Action(InfoExecuted), new Func<bool>(InfoCanExecute));              
               return infoCommand;
           }
       }

        /// <summary>
        /// Method which is used to execute the method.
        /// </summary>
       public void InfoExecuted()
       {
       }

        /// <summary>
        /// Indicates whether the method can execute.
        /// </summary>
        /// <returns></returns>
       public bool InfoCanExecute()
       {
           return true;
       }
        #endregion
    }
    internal class Info
    {
        #region Fields
        /// <summary>
        /// Maintains the heading.
        /// </summary>
        private string heading;

        /// <summary>
        /// Maintains the description.
        /// </summary>
        private string description;

        /// <summary>
        /// Maintains the button content.
        /// </summary>
        private string buttonContent;

        /// <summary>
        /// Maintains the button icon.
        /// </summary>
        private string buttonIcon;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the heading.
        /// </summary>
        public string Heading
        {
            get
            {
                return heading;
            }
            set
            {
                heading = value;
            }
        }

       /// <summary>
       /// Gets and sets the description.
       /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
       
        /// <summary>
        /// Gets and sets the button content.
        /// </summary>
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                buttonContent = value;
            }
        }
      
        /// <summary>
        /// Gets and sets the button icon.
        /// </summary>
        public string ButtonIcon
        {
            get
            {
                return buttonIcon;
            }

            set
            {
                buttonIcon = value;
            }
        }
        #endregion
    }

}
