using MPL.MVC;
using MQUESTSYS.BF.Master;
using MQUESTSYS.Helpers;
using MQUESTSYS.Models.Master;
using MQUESTSYS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;

namespace MQUESTSYS.Controllers.Master
{
    public class UserController : Controller
    {
        private string ModuleID
        {
            get
            {
                return "User";
            }
        }

        private void SetViewBagPermission()
        {
            var roleDetails = new RoleBFC().RetrieveActions(MembershipHelper.GetRoleID(), ModuleID);

            ViewBag.AllowView = roleDetails.Contains("View");
            ViewBag.AllowEdit = roleDetails.Contains("Edit");
            ViewBag.AllowCreate = roleDetails.Contains("Create");
        }

        public ActionResult Index(int? pageIndex, int? amount, string sortParameter, string filterBy, string filterKey)
        {
            if (pageIndex == null)
                pageIndex = 1;

            int startIndex = Convert.ToInt32(pageIndex * amount);

            var userList = new List<UserModel>();
            var membershipList = Membership.GetAllUsers();

            var roleList = new RoleBFC().RetrieveAll();

            foreach (MembershipUser membershipUser in membershipList)
            {
                var user = new UserModel();
                user.UserID = membershipUser.UserName;

                var profile = ProfileCommon.GetProfile(membershipUser.UserName);

                var query = from i in roleList
                            where i.ID == profile.RoleID
                            select i;

                if (query.FirstOrDefault() != null)
                {
                    user.RoleID = query.FirstOrDefault().ID;
                    user.RoleName = query.FirstOrDefault().Name;
                }

                userList.Add(user);
            }

            ViewBag.ControllerName = "User";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = Math.Floor(Convert.ToDecimal(membershipList.Count / SystemConstants.ItemPerPage)) + 1;
            ViewBag.SortParameter = sortParameter;
            ViewBag.FilterKey = filterKey;

            SetViewBagPermission();

            return View(userList);
        }

        public ActionResult Create()
        {
            var obj = new UserModel();

            ViewBag.Mode = UIMode.Create;
            SetPreEditViewBag();

            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Validate(user);

                    using (TransactionScope trans = new TransactionScope())
                    {
                        Membership.CreateUser(user.UserID, user.Password);

                        var profile = ProfileCommon.GetProfile(user.UserID);
                        profile.RoleID = user.RoleID;
                        profile.IsActive = user.IsActive;
                     

                        trans.Complete();
                    }
                    /*Create User Profile*/
                    new UserProfileBFC().Create(user.UserID, MembershipHelper.GetUserName());

                    TempData["SuccessNotification"] = "Document has been saved";

                    return RedirectToAction("Detail", new { key = user.UserID });
                }
                catch (Exception ex)
                {
                    ViewBag.Mode = UIMode.Create;
                    ViewBag.ErrorNotification = ex.Message;
                    SetPreEditViewBag();

                    return View(user);
                }
            }
            else
                ViewBag.ErrorNotification = "Object is invalid";

            ViewBag.Mode = UIMode.Create;
            SetPreEditViewBag();
            return View(user);
        }

        public ActionResult Detail(string key)
        {
            var obj = new UserModel();
            var membership = Membership.GetUser(key);
            var profile = ProfileCommon.GetProfile(key);

            obj.UserID = membership.UserName;

            if (profile != null)
            {
                obj.RoleID = profile.RoleID;
                obj.IsActive = profile.IsActive;
            }

            if (obj.RoleID != 0)
            {
                var role = new RoleBFC().RetrieveByID(obj.RoleID);
                obj.RoleName = role.Name;
            }

            ViewBag.Mode = UIMode.Detail;

            SetViewBagNotification();
            SetViewBagPermission();

            return View(obj);
        }

        public ActionResult Update(string key)
        {
            var obj = new UserModel();
            var membership = Membership.GetUser(key);
            var profile = ProfileCommon.GetProfile(key);

            obj.UserID = membership.UserName;
            obj.RoleID = profile.RoleID;
            obj.IsActive = profile.IsActive;

            if (obj.RoleID != 0)
            {
                var role = new RoleBFC().RetrieveByID(obj.RoleID);
                obj.RoleName = role.Name;
            }

            ViewBag.Mode = UIMode.Update;
            SetPreEditViewBag();

            return View(obj);
        }

        [HttpPost]
        public ActionResult Update(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        Validate(user);

                        var membershipUser = Membership.GetUser(user.UserID);

                        membershipUser.ChangePassword(membershipUser.ResetPassword(), user.Password);
                    }

                    var profile = ProfileCommon.GetProfile(user.UserID);
                    profile.RoleID = user.RoleID;
                    profile.IsActive = user.IsActive;

                    MenuHelper.ResetMenu(user.UserID);

                    TempData["SuccessNotification"] = "Document has been updated";

                    return RedirectToAction("Detail", new { key = user.UserID });

                }
                catch (Exception ex)
                {
                    ViewBag.Mode = UIMode.Update;
                    ViewBag.ErrorNotification = ex.Message;
                    SetPreEditViewBag();

                    return View(user);
                }
            }
            else
                ViewBag.ErrorNotification = "Object is invalid";

            ViewBag.Mode = UIMode.Update;
            SetPreEditViewBag();

            return View(user);
        }

        public ActionResult Delete(string userID)
        {
            try
            {
                Membership.DeleteUser(userID);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mode = UIMode.Update;
                ViewBag.ErrorMessage = ex.Message;

                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOn()
        {
            this.CheckOrGenerateAdministrator();
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(UserModel model, string returnUrl)
        {
            this.CheckOrGenerateAdministrator();
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserID, model.Password))
                {
                    var profile = ProfileCommon.GetProfile(model.UserID);

                    if (profile.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserID, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user is not active.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private void SetPreEditViewBag()
        {
            ViewBag.RoleList = new RoleBFC().Retrieve(true).OrderBy(p => p.Name);
            SetViewBagPermission();
        }

        private void SetViewBagNotification()
        {
            if (TempData["SuccessNotification"] != null)
                ViewBag.SuccessNotification = Convert.ToString(TempData["SuccessNotification"]);

            if (!string.IsNullOrEmpty(Request.QueryString["errorMessage"]))
                ViewBag.ErrorNotification = Convert.ToString(Request.QueryString["errorMessage"]);
        }

        private void Validate(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Password))
                throw new Exception("Password should not be empty");

            if (string.IsNullOrEmpty(user.ConfirmPassword))
                throw new Exception("Confirm Password should not be empty");

            if (user.Password != user.ConfirmPassword)
                throw new Exception("Password should be equal with Confirm Password");

        }
        public void CheckOrGenerateAdministrator()
        {
            string username = "administrator";
            string password = "admin";
            MembershipUserCollection listOfUserNameByName = Membership.FindUsersByName(username);
            if (listOfUserNameByName.Count == 0)
            {
                MembershipUser m = Membership.CreateUser(username, password);
                ProfileCommon.Create(username).Save();
                ProfileCommon p = ProfileCommon.GetProfile(username);
                p.RoleID = (int)PermissionType.Administrator;
                p.IsActive = true;
                p.Save();

                new UserProfileBFC().Create(username, "System");
            }
        }
    }
}
