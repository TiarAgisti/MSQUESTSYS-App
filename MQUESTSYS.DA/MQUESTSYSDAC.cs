using MPL;
using MPL.Business;
using MQUESTSYS.EDM;
using MQUESTSYS.Models.Master;
using MQUESTSYS.Models;
using MQUESTSYS.Util;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Linq.Dynamic;

namespace MQUESTSYS.DA
{
    public class MQUESTSYSDAC
    {
        private void ApplySorting<T>(ref IQueryable<T> query, string defaultSortField, string sortParameter)
        {
            if (string.IsNullOrEmpty(sortParameter.Trim()))
                sortParameter = defaultSortField;

            if (sortParameter.Trim().EndsWith(" DESC"))
            {
                sortParameter = sortParameter.Replace(" DESC", "");
                query = query.OrderByDescending(sortParameter);
            }
            else
            {
                query = query.OrderBy(sortParameter);
            }
        }

        private void ApplyFilter<T>(ref IQueryable<T> query, List<SelectFilter> filters)
        {
            if (filters != null)
            {
                object[] param = null;
                string statements = SelectFilter.Build(filters, out param);

                if (!string.IsNullOrEmpty(statements))
                    query = query.Where(statements, param);
            }
        }

      

        #region Company Setting
        public void UpdateCompanySetting(CompanySettingModel companySetting)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.CompanySetting
                        select i;

            var obj = query.FirstOrDefault();
            ObjectHelper.CopyProperties(companySetting, obj);
            ent.SaveChanges();
        }

        public CompanySettingModel RetrieveCompanySetting()
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.CompanySetting
                        select i;

            CompanySettingModel obj = new CompanySettingModel();

            if (query.FirstOrDefault() != null)
                ObjectHelper.CopyProperties(query.FirstOrDefault(), obj);
            else
                return null;

            return obj;
        }
        #endregion

        #region Customer
        public List<CustomerModel> RetrieveCustomerAutoComplete(string key)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.Customer
                        where (i.Name.ToLower().Contains(key.ToLower()) ||
                               i.Code.ToLower().Contains(key.ToLower())) &&
                               i.IsActive == true
                        select i;

            ApplySorting<Customer>(ref query, "Code", "");
            return ObjectHelper.CopyList<Customer, CustomerModel>(query.Take(SystemConstants.AutoCompleteItemCount).ToList());
        }

        public CustomerModel RetrieveCustomerByCodeOrName(string key)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.v_Customer
                        where i.Code == key || i.Name == key
                        select i;

            var obj = new CustomerModel();

            if (query.FirstOrDefault() != null)
                ObjectHelper.CopyProperties(query.FirstOrDefault(), obj);
            else
                return null;

            return obj;
        }
        #endregion

        #region Prefix Setting
        public PrefixSettingModel RetrievePrefixSetting()
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.PrefixSetting
                        select i;

            PrefixSettingModel obj = new PrefixSettingModel();

            if (query.FirstOrDefault() != null)
                ObjectHelper.CopyProperties(query.FirstOrDefault(), obj);
            else
                return null;

            return obj;
        }
        #endregion

        #region Role
        public void CreateRole(RoleModel role)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();
            Role obj = new Role();
            ObjectHelper.CopyProperties(role, obj);
            ent.AddToRole(obj);
            ent.SaveChanges();

            role.ID = obj.ID;
        }

        public void CreateRoleDetails(int roleID, List<RoleDetailModel> roleDetailList)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            foreach (var roleDetail in roleDetailList)
            {
                roleDetail.RoleID = roleID;

                RoleDetail obj = new RoleDetail();
                ObjectHelper.CopyProperties(roleDetail, obj);
                ent.AddToRoleDetail(obj);
            }

            ent.SaveChanges();
        }

        public void DeleteRoleDetails(long roleID)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.RoleDetail
                        where i.RoleID == roleID
                        select i;

            foreach (var obj in query.AsEnumerable())
                ent.DeleteObject(obj);

            ent.SaveChanges();
        }

        public List<RoleModel> RetrieveRole(bool isActive)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.Role
                        where i.IsActive == isActive
                        select i;

            return ObjectHelper.CopyList<Role, RoleModel>(query.ToList());
        }

        public List<RoleDetailModel> RetrieveRoleDetails(int roleID)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.RoleDetail
                        where i.RoleID == roleID
                        select i;

            return ObjectHelper.CopyList<RoleDetail, RoleDetailModel>(query.ToList());
        }

        public List<RoleDetailModel> RetrieveRoleActions(string moduleID)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.RoleDetail
                        where i.ModuleID == moduleID
                        select i;

            return ObjectHelper.CopyList<RoleDetail, RoleDetailModel>(query.ToList());
        }

        public List<string> RetrieveRoleActions(int roleID, string moduleID)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();

            var query = from i in ent.RoleDetail
                        where i.RoleID == roleID && i.ModuleID == moduleID
                        select i.Action;

            return query.ToList();
        }
        #endregion

        #region User Profile
        public List<UserProfileModel> RetrieveUserProfileByFilter(string sortParameter, List<SelectFilter> selectFilters)
        {
            MQUESTSYSEntities ent = new MQUESTSYSEntities();
            var query = from i in ent.v_UserProfile
                        select i;
            ApplyFilter<v_UserProfile>(ref query, selectFilters);
            ApplySorting<v_UserProfile>(ref query, "Code DESC", sortParameter);
            return ObjectHelper.CopyList<v_UserProfile, UserProfileModel>(query.ToList());
        }
        #endregion

       
    }
}
