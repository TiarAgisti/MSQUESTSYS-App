using MPL.Business;
using MQUESTSYS.DA;
using MQUESTSYS.EDM;
using MQUESTSYS.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using MQUESTSYS.Util;

namespace MQUESTSYS.BF.Master
{
    public class UserProfileBFC : PSIGenericBFC<UserProfile, v_UserProfile, UserProfileModel>
    {
        public override void Create(UserProfileModel dr)
        {
            dr.Code = base.GenerateCode("UP", 5);
            base.Create(dr);
        }
        public override void Update(UserProfileModel dr)
        {
            base.Update(dr);
        }

        public List<UserProfileModel> RetrieveUserProfileByFilter(string sortParameter, List<SelectFilter> selectFilters)
        {
            return new MQUESTSYSDAC().RetrieveUserProfileByFilter(sortParameter, selectFilters);
        }

        public List<UserProfileModel> RetrieveCustomFilter(List<UserProfileModel> listModel, string username, int roleID, dynamic ViewBag)
        {
            if (roleID != (int)PermissionType.Administrator)
                listModel = listModel.Where(e => e.UserName == username).ToList();
            return listModel.OrderByDescending(e => e.Code).ToList();
        }

        public UserProfileModel RetrieveByUserName(string username)
        {
            return base.RetrieveAll().SingleOrDefault(e => e.UserName == username);
        }

        public void Create(string newUserName, string loginUserName)
        {
            UserProfileModel userProfile = new UserProfileModel();
            userProfile.UserName = newUserName;
            userProfile.DisplayName = newUserName;
            userProfile.CreatedBy = loginUserName;
            userProfile.ModifiedBy = loginUserName;
            userProfile.CreatedDate = DateTime.Now;
            userProfile.ModifiedDate = DateTime.Now;
            this.Create(userProfile);
        }
    }
}
