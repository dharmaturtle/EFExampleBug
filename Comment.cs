using System;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
