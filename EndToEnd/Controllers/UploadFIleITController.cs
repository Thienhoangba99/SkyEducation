﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndToEnd.Controllers
{
    public class UploadFIleITController : Controller
    {
        // GET: UploadFIleIT
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
                    string path = Path.Combine(Server.MapPath("~/Upload"),
                                               Path.GetFileName(file.FileName));
                    string path1 = Path.Combine(Server.MapPath("~/UploadIT"),
                                              Path.GetFileName(file.FileName));
                    file.SaveAs(path1);
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

        public FileResult Download(string FileName)
        {
            var FileVirtualPath = "~/Upload/" + FileName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Upload"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");

            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return items;
        }
        public ActionResult IndexBus()
        {
            var items = GetFilesBus();
            return View(items);
        }

        [HttpPost]
        public ActionResult IndexBus(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Upload1"),
                                               Path.GetFileName(file.FileName));
                    string path1 = Path.Combine(Server.MapPath("~/UploadBus"),
                                              Path.GetFileName(file.FileName));
                    file.SaveAs(path1);
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

        public FileResult Download1(string FileName)
        {
            var FileVirtualPath = "~/Upload1/" + FileName;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFilesBus()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Upload1"));
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