using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MQUESTSYS.Models.Master;
using MQUESTSYS.BF.Master;
using MQUESTSYS.Util;
using System.Web.Security;
using MQUESTSYS.Helpers;
using MQUESTSYS;

namespace MQUESTSYS.Controllers.Master
{
    public class RoleController : PSIGenericController<RoleModel>
    {
        public RoleController()
        {
            base.ModuleID = "Role";
        }
        public override MPL.Business.IGenericBFC<RoleModel> GetBFC()
        {
            return new RoleBFC();
        }

        public override void PreDetailDisplay(RoleModel obj)
        {
            obj.Details = new RoleBFC().RetrieveDetails(obj.ID);
            base.PreDetailDisplay(obj, ModuleID);
        }

        public override void PreUpdateDisplay(RoleModel obj)
        {
            obj.Details = new RoleBFC().RetrieveDetails(obj.ID);
            base.PreUpdateDisplay(obj, ModuleID);
        }

        [HttpPost]
        public ActionResult CreateRole(RoleModel role, FormCollection col)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PopulateDetails(role, col);
                    new RoleBFC().Create(role, role.Details, MembershipHelper.GetUserName());

                    TempData["SuccessNotification"] = SystemConstants.str_notif_success;

                    return RedirectToAction("Detail", new { key = role.ID });
                }
                catch (Exception ex)
                {
                    ViewBag.Mode = EditMode.Create;
                    ViewBag.ErrorNotification = ex.Message;

                    return View(role);
                }
            }
            else
                ViewBag.ErrorMessage = "Object is invalid";

            ViewBag.Mode = EditMode.Create;

            return View(role);
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleModel role, FormCollection col)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PopulateDetails(role, col);
                    new RoleBFC().Update(role, role.Details, MembershipHelper.GetUserName());

                    foreach (MembershipUser user in Membership.GetAllUsers())
                        MenuHelper.ResetMenu(user.UserName);

                    TempData["SuccessNotification"] = SystemConstants.str_notif_success;
                    return RedirectToAction("Detail", new { key = role.ID });
                }
                catch (Exception ex)
                {
                    ViewBag.Mode = EditMode.Update;
                    ViewBag.ErrorNotification = ex.Message;

                    return View(role);
                }
            }
            else
                ViewBag.ErrorMessage = "Object is invalid";

            ViewBag.Mode = EditMode.Update;

            return View(role);
        }

        private void PopulateDetails(RoleModel role, FormCollection col)
        {
            var roleDetails = new List<RoleDetailModel>();

            foreach (var obj in ModuleHelper.ModuleList())
            {
                if (col["chkView" + obj.Key] != null)
                {
                    var roleDetail = new RoleDetailModel();
                    roleDetail.ModuleID = obj.Key;
                    roleDetail.Action = SystemConstants.str_permission_View;

                    roleDetails.Add(roleDetail);
                }

                if (col["chkCreate" + obj.Key] != null)
                {
                    var roleDetail = new RoleDetailModel();
                    roleDetail.ModuleID = obj.Key;
                    roleDetail.Action = SystemConstants.str_permission_Create;

                    roleDetails.Add(roleDetail);
                }

                if (col["chkEdit" + obj.Key] != null)
                {
                    var roleDetail = new RoleDetailModel();
                    roleDetail.ModuleID = obj.Key;
                    roleDetail.Action = SystemConstants.str_permission_Edit;

                    roleDetails.Add(roleDetail);
                }

                if (col["chkApprove" + obj.Key] != null)
                {
                    var roleDetail = new RoleDetailModel();
                    roleDetail.ModuleID = obj.Key;
                    roleDetail.Action = SystemConstants.str_permission_Approve;

                    roleDetails.Add(roleDetail);
                }
            }
            role.Details = roleDetails;
        }
    }
}
