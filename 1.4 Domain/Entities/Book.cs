using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Book
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public User LentTo { get; set; }
        public int? LentToId { get; set; }
    }
}
