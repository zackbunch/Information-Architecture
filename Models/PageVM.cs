using BHR.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHR.Models
{
  public class PageVM
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ContentBlockVM> PageContents { get; set; }

    public PageVM(){ }
    public PageVM(Page instance){
      Id = instance.Id;
      Name = instance.Name;
      PageContents = new List<ContentBlockVM>();

      foreach(var cb in instance.ContentBlock){
        PageContents.Add(new ContentBlockVM(cb));
      }
    }

  }
}
