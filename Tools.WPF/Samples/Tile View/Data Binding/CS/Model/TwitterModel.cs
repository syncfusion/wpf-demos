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

namespace DataBindingDemo
{
    public class Tweet
    {
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public Author Author { get; set; }
        public string Image { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
