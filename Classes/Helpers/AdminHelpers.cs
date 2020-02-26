using BHR.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHR.Classes.Helpers
{
  public class AdminHelpers
  {
    public static List<SelectListItem> RetrievePages()
    {
      List<SelectListItem> Pages = new List<SelectListItem>() { 
         new SelectListItem { Value = "0", Text = "Please select a page..." }
      };

      using(var db = new DBHRDBContext())
      {
        var values = db.Page.ToList();

        if (values.Any())
        {
          foreach(var val in values)
          {
            Pages.Add(new SelectListItem { Value = val.Id.ToString(), Text = val.Name });
          }
        }
      }

      return Pages;
    }

    public static List<SelectListItem> RetrievePageContentBlocks(int PageId)
    {
      List<SelectListItem> ContentBlocks = new List<SelectListItem>() {
         new SelectListItem { Value = "0", Text = "Please select a content block..." }
      };

      using (var db = new DBHRDBContext())
      {
        var values = db.ContentBlock.Where(x => x.PageId == PageId).ToList();

        if (values.Any())
        {
          foreach (var val in values)
          {
            ContentBlocks.Add(new SelectListItem { Value = val.Id.ToString(), Text = val.Header });
          }
        }
      }

      return ContentBlocks;
    }
  }
}
