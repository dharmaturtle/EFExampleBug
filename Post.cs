using System;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
