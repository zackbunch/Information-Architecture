using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHR.Models.DB;
using BHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BHR.Controllers
{
  public class AdminController : Controller {
    public IActionResult Index() {
      return View();
    }

    [HttpGet]
    public ActionResult RetrievePageContentBlocks(int PageId) {
      List<SelectListItem> ContentBlocks = new List<SelectListItem>() {
         new SelectListItem { Value = "0", Text = "Please select a content block..." }
      };

      using (var db = new DBHRDBContext()) {
        var values = db.ContentBlock.Where(x => x.PageId == PageId).ToList();

        if (values.Any()) {
          foreach (var val in values) {
            ContentBlocks.Add(new SelectListItem { Value = val.Id.ToString(), Text = val.Header });
          }
        }
      }

      return PartialView("PageContentBlocksSelectList", ContentBlocks);
    }

    [HttpGet]
    public ActionResult RetrieveContentBlock(int ContentId) {
      List<SelectListItem> ContentBlocks = new List<SelectListItem>() {
         new SelectListItem { Value = "0", Text = "Please select a content block..." }
      };

      using (var db = new DBHRDBContext()) {
        var value = db.ContentBlock.FirstOrDefault(x => x.Id == ContentId);

        ContentBlockVM content = new ContentBlockVM {
          Id = value.Id,
          Content = value.Content,
          ViewIndex = value.ViewIndex,
          Header = value.Header,
          DateAdded = value.CreatedDate,
          DateUpdated = value.UpdatedDate
        };

        return PartialView("ContentBlockEdit", content);
      }
    }

    [HttpPost]
    public ActionResult UpdateContentBlock(int Id, string Header, int ViewIndex, string Content) {

      using (var db = new DBHRDBContext()) {
        var value = db.ContentBlock.FirstOrDefault(x => x.Id == Id);

        if(value != null){
          value.Header = Header;
          value.ViewIndex = ViewIndex;
          value.Content = Content;
          value.UpdatedDate = DateTime.Now;

          db.SaveChanges();
        }

        return PartialView("ContentBlockEdit", new ContentBlockVM(value));
      }
    }
  }
}