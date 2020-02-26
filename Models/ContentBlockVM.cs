using BHR.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHR.Models
{
  public class ContentBlockVM
  {
    public int Id { get; set; }
    public int PageId { get; set; }
    public int ViewIndex { get; set; }
    public string Header { get; set; }
    public string Content { get; set; }
    public DateTime? DateAdded { get; set; }
    public DateTime? DateUpdated { get; set; }

    public ContentBlockVM(){ }
    public ContentBlockVM(ContentBlock cb){
      Id = cb.Id;
      PageId = cb.PageId;
      Header = cb.Header;
      ViewIndex = cb.ViewIndex;
      Content = cb.Content;
      DateAdded = cb.CreatedDate;
      DateUpdated = cb.UpdatedDate;
    }
    
  }
}
