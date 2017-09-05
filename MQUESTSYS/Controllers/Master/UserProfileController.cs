using MQUESTSYS.BF.Master;
using MQUESTSYS.Helpers;
using MQUESTSYS.Models.Master;
using MQUESTSYS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.Security;

namespace MQUESTSYS.Controllers.Master
{
    public class UserProfileController : PSIGenericController<UserProfileModel>
    {
        public UserProfileController()
        {
            base.ModuleID = "UserProfile";
        }
        public override MPL.Business.IGenericBFC<UserProfileModel> GetBFC()
        {
            return new UserProfileBFC();
        }
        public override void PreDetailDisplay(UserProfileModel obj)
        {
            if (MembershipHelper.GetUserName() == obj.UserName || MembershipHelper.GetRoleID() == (int)PermissionType.Administrator)
                base.PreDetailDisplay(obj, base.ModuleID);
            else
                base.RedirectToHome();
        }
        public override void PreUpdateDisplay(UserProfileModel obj)
        {
            if (MembershipHelper.GetUserName() == obj.UserName || MembershipHelper.GetRoleID() == (int)PermissionType.Administrator)
                base.PreUpdateDisplay(obj, base.ModuleID);
            else
                base.RedirectToHome();
        }
        public override void PreCreateDisplay(UserProfileModel obj)
        {
            if (MembershipHelper.GetUserName() == obj.UserName || MembershipHelper.GetRoleID() == (int)PermissionType.Administrator)
                base.PreCreateDisplay(obj, base.ModuleID);
            else
                base.RedirectToHome();
        }
        public override System.Web.Mvc.ActionResult Index(int? startIndex, int? amount, string sortParameter, MPL.MVC.GenericFilter filter)
        {
            base.SetViewBag(base.ModuleID);
            amount = (amount == null) ? 20 : amount;
            startIndex = (startIndex == null) ? 0 : startIndex;
            sortParameter = (string.IsNullOrEmpty(sortParameter)) ? "" : sortParameter;
            List<UserProfileModel> listModel = new UserProfileBFC().RetrieveUserProfileByFilter(sortParameter, filter.GetSelectFilters());
            listModel = new UserProfileBFC().RetrieveCustomFilter(listModel, MembershipHelper.GetUserName(), MembershipHelper.GetRoleID(), ViewBag);
            ViewBag.DataCount = listModel.Count;
            ViewBag.PageSize = amount;
            ViewBag.StartIndex = startIndex;
            ViewBag.FilterFields = filter.FilterFields;
            ViewBag.PageSeriesSize = GetPageSeriesSize();
            base.ResetBackToListUrl(filter);
            return View(listModel.GetRange((int)startIndex, ((int)startIndex + (int)amount > listModel.Count) ? listModel.Count - (int)startIndex : (int)amount));
        }
        public override void UpdateData(UserProfileModel obj, System.Web.Mvc.FormCollection formCollection)
        {
            if (!string.IsNullOrEmpty(obj.Password))
            {
                if (obj.Password == obj.ConfirmPassword)
                {
                    var membershipUser = Membership.GetUser(obj.UserName);
                    membershipUser.ChangePassword(membershipUser.ResetPassword(), obj.Password);
                    MenuHelper.ResetMenu(MembershipHelper.GetUserName());
                }
                else
                {
                    throw new Exception("Password and Confirm Password do not match");
                }
            }
            base.UpdateData(obj, formCollection, base.ModuleID);
        }
    }
}