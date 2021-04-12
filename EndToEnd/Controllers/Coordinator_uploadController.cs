using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace EndToEnd.Controllers
{
    public class Coordinator_uploadController : Controller
    {
        // GET: Coordinator_upload
        public ActionResult Index()
        {
            var items = GetFiles();
            return View(items);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/CoordinatorPost"),
                                               Path.GetFileName(file.FileName));


                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            var items = GetFiles();
            return View(items);
        }

        public FileResult Download4(string FileName)
        {
            var FileVirtualPath = "~/CoordinatorPost/" + FileName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/CoordinatorPost"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");

            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return items;
        }
    }
}