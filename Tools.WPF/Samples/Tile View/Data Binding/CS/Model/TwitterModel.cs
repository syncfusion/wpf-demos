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
