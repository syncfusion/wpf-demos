#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace CustomDD_2008
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media.Imaging;

    public class ListBoxContent
    {
        private List<ImageTextListBoxListBoxItem> allDatas = new List<ImageTextListBoxListBoxItem>();

        public List<ImageTextListBoxListBoxItem> GenerateListBoxContent()
        {
            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Sunset.jpg", UriKind.Relative)),
                Text = "Sunset"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Rose.jpg", UriKind.Relative)),

                Text = "Rose"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Water lilies.jpg", UriKind.Relative)),

                Text = "Water lilies"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Winter.jpg", UriKind.Relative)),

                Text = "Winter"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Mixed Flowers and a Bear.jpg", UriKind.Relative)),

                Text = "Mixed Flowers"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\08 Chrysanthemum flowers.jpg", UriKind.Relative)),

                Text = "Chrysanthemum flowers"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Bidens_discoidea_flowers3.jpg", UriKind.Relative)),

                Text = "Bidens_discoidea_flowers"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\crimson-red-flowers.jpg", UriKind.Relative)),

                Text = "crimson-red-flowers"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\Dichelostemma_capitatum,_flowers,I_JP523.jpg", UriKind.Relative)),

                Text = "Dichelostemma_capitatum,_flowers"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\GD7329343Dahlia-flowers-are-pi-8711.jpg", UriKind.Relative)),

                Text = "Dahlia"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\flowers_65.gif", UriKind.Relative)),
                Text = "Violet flower"
            });

            this.allDatas.Add(new ImageTextListBoxListBoxItem()
            {
                Image = new BitmapImage(
                    new Uri(@"\Resources\flowers4.jpg", UriKind.Relative)),
                Text = "Violet"
            });

            return this.allDatas;
        }
    }
}
