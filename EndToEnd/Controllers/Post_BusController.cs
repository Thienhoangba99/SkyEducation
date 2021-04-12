﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndToEnd.Controllers
{
    public class Post_BusController : Controller
    {
        // GET: Post_IT
        public ActionResult Index()
        {
            var items = GetFilesBus();
            return View(items);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Upload1"),
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

            var items = GetFilesBus();
            return View(items);
        }

        public FileResult Download7(string FileName)
        {
            var FileVirtualPath = "~/CoordinatorPostBus/" + FileName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFilesBus()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/CoordinatorPostBus"));
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