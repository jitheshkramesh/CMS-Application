using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CMSApp.Models;
using System.IO;

namespace CMSApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserIndex()
        {

            ViewBag.Message = "User Index page.";
            CMSAPPEntities _context = new CMSAPPEntities();
            var model = _context.COMPANies
                .FirstOrDefault();
            return View(model);
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        [HttpPost]
        public ActionResult Post_Login(USERLOGIN login)
        {
            using (CMSAPPEntities _context = new CMSAPPEntities())
            {
                var userId = _context.
                USERLOGINs.
                Where(x => x.USERNAME.Equals(login.USERNAME) && x.PASSWRD.Equals(login.PASSWRD))
                .SingleOrDefault();

                if (userId != null)
                {
                    return Redirect("MenuList");
                }
                else
                {
                    ViewBag.Message = "Invalid Login Details.";
                    return RedirectToAction("Login", "Home");
                }

            }

        }

        public ActionResult Menupartial() {
            return View();
        }

        public ActionResult ImageListing() {
            return View();
        }

        public ActionResult MenuList()
        {
            ViewBag.Message = "Menu List.";
            CMSAPPEntities _context = new CMSAPPEntities();
            var model = _context.MENUs
                .ToList();
            return View(model);
        }

        public ActionResult MenuAdd(int? id)
        {
            ViewBag.Message = "Menu Add.";
            CMSAPPEntities _context = new CMSAPPEntities();
              var  model = _context.MENUs
                       .Where(x => x.ID == id)
                       .FirstOrDefault();
                return View(model);
                        
        }

        [HttpPost]
        public ActionResult PostMenu(MENU menu)
        {
            CMSAPPEntities db = new CMSAPPEntities();
            var model = db.MENUs.Where(x => x.ID.Equals(menu.ID)).FirstOrDefault();
            if (model != null)
            {
                model.MENU_NAME = menu.MENU_NAME;
                model.MENU_ADDRESS = menu.MENU_ADDRESS;
                model.SEQ = menu.SEQ;
            }
            else
            {
                db.MENUs.Add(menu);
            }
            db.SaveChanges();
            return RedirectToAction("MenuList");
        }

        public ActionResult MenuDelete(int id)
        {
            try
            {
                using (CMSAPPEntities db = new CMSAPPEntities())
                {
                    MENU item = db.MENUs.Where(x => x.ID == id).FirstOrDefault();
                    db.MENUs.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction("MenuList");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("MenuList");
            }
        }

        public ActionResult FeatureList()
        {
            ViewBag.Message = "Feature List.";
            CMSAPPEntities _context = new CMSAPPEntities();
            var model = _context.FEATURES
                .ToList();
            return View(model);
        }

        public ActionResult FeatureAdd(int? id)
        {
            ViewBag.Message = "Feature Add.";
            CMSAPPEntities _context = new CMSAPPEntities();
            var model = _context.FEATURES
                     .Where(x => x.ID == id)
                     .FirstOrDefault();
            return View(model);

        }

        [HttpPost]
        public ActionResult PostFeature(FEATURE fEATURE, HttpPostedFileBase file)
        {
            CMSAPPEntities db = new CMSAPPEntities();
            var model = db.FEATURES.Where(x => x.ID.Equals(fEATURE.ID)).FirstOrDefault();
            string dstring ="";
            dstring = DateTime.Now.ToLongDateString();

            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/images/"), dstring + fileName);
                file.SaveAs(imgpath);
                fEATURE.FEATURE_PATH = "~/images/" + dstring + file.FileName;
            }

            if (model != null)
            {
                model.FEATURE_NAME = fEATURE.FEATURE_NAME;
                                model.SEQ = fEATURE.SEQ;
            }
            else
            {
                db.FEATURES.Add(fEATURE);
            }
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult FeatureDelete(int id)
        {
            try
            {
                using (CMSAPPEntities db = new CMSAPPEntities())
                {
                    FEATURE item = db.FEATURES.Where(x => x.ID == id).FirstOrDefault();
                    db.FEATURES.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction("FeatureList");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("FeatureList");
            }
        }

    }
}