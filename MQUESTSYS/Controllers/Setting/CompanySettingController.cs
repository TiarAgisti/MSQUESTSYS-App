using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MQUESTSYS.BF.Master;
using MQUESTSYS.Models.Master;
using MQUESTSYS.Util;
using System.IO;
using MPL.MVC;

namespace MQUESTSYS.Controllers.Setting
{
    public class CompanySettingController : GenericController<CompanySettingModel>
    {

        public override MPL.Business.IGenericBFC<CompanySettingModel> GetBFC()
        {
            return new CompanySettingBFC();
        }

        public override ActionResult Update(string key)
        {
            key = "1";
            
            return base.Update(key);
        }

        public override ActionResult Detail(string key, string errorMessage)
        {
            key = "1";
            
            return base.Detail(key, errorMessage);
        }

        [HttpPost]
        public ActionResult UpdateSetting(CompanySettingModel setting, FormCollection col, HttpPostedFileBase file)//, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = file.FileName;
                    var fileExtension = "";

                    if (fileName.Contains("."))
                        fileExtension = fileName.Substring(fileName.LastIndexOf("."));

                    var directory = "~/Content/Site/Image/";

                    if (!Directory.Exists(Server.MapPath(directory)))
                        Directory.CreateDirectory(Server.MapPath(directory));

                    var path = Path.Combine(directory, "logo") + fileExtension;
                    file.SaveAs(Server.MapPath(path));

                    setting.ImageName = "logo" + fileExtension;

                    col.Add("ImageName", setting.ImageName);
                }
                //if (file2 != null && file2.ContentLength > 0)
                //{
                //    var fileName = file2.FileName;
                //    var fileExtension = "";

                //    if (fileName.Contains("."))
                //        fileExtension = fileName.Substring(fileName.LastIndexOf("."));

                //    var directory = "~/Uploads/CompanySetting/";

                //    if (!Directory.Exists(Server.MapPath(directory)))
                //        Directory.CreateDirectory(Server.MapPath(directory));

                //    var path = Path.Combine(directory, "logo2") + fileExtension;
                //    file2.SaveAs(Server.MapPath(path));

                //    setting.ImageName2 = "logo2" + fileExtension;

                //    col.Add("ImageName2", setting.ImageName2);
                //}
                //if (file3 != null && file3.ContentLength > 0)
                //{
                //    var fileName = file3.FileName;
                //    var fileExtension = "";

                //    if (fileName.Contains("."))
                //        fileExtension = fileName.Substring(fileName.LastIndexOf("."));

                //    var directory = "~/Uploads/CompanySetting/";

                //    if (!Directory.Exists(Server.MapPath(directory)))
                //        Directory.CreateDirectory(Server.MapPath(directory));

                //    var path = Path.Combine(directory, "logo3") + fileExtension;
                //    file3.SaveAs(Server.MapPath(path));

                //    setting.ImageName3 = "logo3" + fileExtension;

                //    col.Add("ImageName3", setting.ImageName3);
                //}
                base.Update(setting, col);

                return RedirectToAction("Detail");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.Mode = UIMode.Update;

                return View(setting);
            }
        }

    }
}
