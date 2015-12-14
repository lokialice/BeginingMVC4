using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveYouSeenMe.Models;
using System.IO;
using HaveYouSeenMe.Models.Business;
namespace HaveYouSeenMe.Controllers
{
    public class PetController : Controller
    {
        //public ActionResult Display()
        //{
        //    var name = (string)RouteData.Values["id"];
        //    var model = PetManagement.GetByName(name);
        //    if (model == null)
        //    {
        //        return RedirectToAction("NotFound");
        //    }
        //    return View(model);
        //}
        public ActionResult NotFound()
        {
            return View();
        }
        public FileResult DownloadPetPicture() 
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg";
            var contentTyped = "image/jpg";
            var fileName = name + ".jpg";
            return File(picture,contentTyped,fileName);
        }
        // Using HttpStatusCodeResult
        public HttpStatusCodeResult UnauthorizedError()
        {
            return new HttpUnauthorizedResult("Custom Unauthorized Error");
        }
        // Using HttpNotFoundResult

        public ActionResult NotFoundError()
        {
            return HttpNotFound("Nothing here....");
        }
        public ActionResult PictureUpload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model)
        {
            if (model.PictureFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                PetManagement.CreateThumbnails(fileName, filePath, 100, 100, true);
            }
            return View(model);
        }

        public ActionResult GetPhoto()
        {
            var name = (string)RouteData.Values["id"];
            ViewBag.Photo = string.Format("/Content/Uploads/{0}.jpg", name);
            return PartialView();
        }
       

    }
}
