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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace CustomColor_Demo_2008
{
    class GameCollect
    {
        #region Members

        /// <summary>
        /// Collection
        /// </summary>
        public static ObservableCollection<GameData> _GameCollection =
         new ObservableCollection<GameData>();

        /// <summary>
        /// Games the collection.
        /// </summary>
        public static void gameCollection()
        {
            _GameCollection.Add(new GameData
            {
                PID = "101",
                PName = "Mouse",
                price = "$50",

            });
            _GameCollection.Add(new GameData
            {
                PID = "102",
                PName = "Keyboard",
                price = "$250",
            });
            _GameCollection.Add(new GameData
            {
                PID = "103",
                PName = "Radio",
                price = "$550",
            });
            _GameCollection.Add(new GameData
            {
                PID = "104",
                PName = "Speaker",
                price = "$390",
            });
            _GameCollection.Add(new GameData
            {
                PID = "105",
                PName = "Television",
                price = "$5050",

            });
            _GameCollection.Add(new GameData
            {
                PID = "106",
                PName = "CPU",
                price = "$6000",
            });
            _GameCollection.Add(new GameData
            {
                PID = "107",
                PName = "USB falsh drive disk",
                price = "$950",
            });
            _GameCollection.Add(new GameData
            {
                PID = "108",
                PName = "Scanner",
                price = "$10000",
            });
            _GameCollection.Add(new GameData
            {
                PID = "109",
                PName = "Projector",
                price = "$5000",
            });
            _GameCollection.Add(new GameData
            {
                PID = "110",
                PName = "Webcams",
                price = "$5000",

            });
            _GameCollection.Add(new GameData
            {
                PID = "111",
                PName = "Mouse pad",
                price = "$20",
            });
            _GameCollection.Add(new GameData
            {
                PID = "109",
                PName = "Projector",
                price = "$5000",
            });
            _GameCollection.Add(new GameData
            {
                PID = "110",
                PName = "Webcams",
                price = "$5000",

            });
            _GameCollection.Add(new GameData
            {
                PID = "111",
                PName = "Mouse pad",
                price = "$20",
            });
        }

        #endregion      
    }

    #region GameData

    /// <summary>
    /// GameData Class used for collections
    /// </summary>
    public class GameData
    {
        public string PID { get; set; }
        public string PName { get; set; }
        public string price { get; set; }
    }
    #endregion
}
