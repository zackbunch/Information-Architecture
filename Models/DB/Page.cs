using System;
using System.Collections.Generic;

namespace BHR.Models.DB
{
    public partial class Page
    {
        public Page()
        {
            ContentBlock = new HashSet<ContentBlock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ContentBlock> ContentBlock { get; set; }
    }
}
