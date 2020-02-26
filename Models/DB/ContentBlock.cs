using System;
using System.Collections.Generic;

namespace BHR.Models.DB
{
    public partial class ContentBlock
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public int ViewIndex { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int PageId { get; set; }

        public virtual Page Page { get; set; }
    }
}
