using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQUESTSYS.EDM;
using MQUESTSYS.Models.Master;
using MPL.Business;
using MQUESTSYS.DA;
using System.Transactions;

namespace MQUESTSYS.BF.Master
{
    public class RoleBFC : GenericBFC<Role, Role, RoleModel>
    {
        public override string GenerateID()
        {
            throw new NotImplementedException();
        }

        protected override GenericDAC<Role, RoleModel> GetDAC()
        {
            return new GenericDAC<Role, RoleModel>("ID", false, "Name");
        }

        protected override GenericDAC<Role, RoleModel> GetViewDAC()
        {
            return new GenericDAC<Role, RoleModel>("ID", false, "Name");
        }
        public void Create(RoleModel role, List<RoleDetailModel> roleDetails, string userName)
        {
            var dac = new MQUESTSYSDAC();

            role.CreatedBy = role.ModifiedBy = userName;
            role.CreatedDate = role.ModifiedDate = DateTime.Now;

            using (TransactionScope trans = new TransactionScope())
            {
                dac.CreateRole(role);
                dac.CreateRoleDetails(role.ID, role.Details);

                trans.Complete();
            }
        }

        public void Update(RoleModel role, List<RoleDetailModel> roleDetails, string userName)
        {
            var dac = new MQUESTSYSDAC();

            var extObj = RetrieveByID(role.ID);

            extObj.Name = role.Name;
            extObj.IsActive = role.IsActive;
            extObj.ModifiedBy = userName;
            extObj.ModifiedDate = DateTime.Now;

            using (TransactionScope trans = new TransactionScope())
            {
                GetDAC().Update(extObj);
                dac.DeleteRoleDetails(role.ID);
                dac.CreateRoleDetails(role.ID, role.Details);

                trans.Complete();
            }
        }

        public override void DeleteByID(object id)
        {
            var dac = new MQUESTSYSDAC();

            using (TransactionScope trans = new TransactionScope())
            {
                base.DeleteByID(id);
                dac.DeleteRoleDetails(Convert.ToInt32(id));

                trans.Complete();
            }
        }

        public List<RoleModel> Retrieve(bool isActive)
        {
            return new MQUESTSYSDAC().RetrieveRole(isActive);
        }

        public List<RoleDetailModel> RetrieveDetails(int roleID)
        {
            return new MQUESTSYSDAC().RetrieveRoleDetails(roleID);
        }

        public List<RoleDetailModel> RetrieveActions(string moduleID)
        {
            return new MQUESTSYSDAC().RetrieveRoleActions(moduleID);
        }

        public List<string> RetrieveActions(int roleID, string moduleID)
        {
            return new MQUESTSYSDAC().RetrieveRoleActions(roleID, moduleID);
        }
        public bool CheckIsAllowed(int roleID, string moduleID, string action)
        {
            List<RoleDetailModel> listDetail = this.RetrieveDetails(roleID).Where(p => p.ModuleID == moduleID && p.Action == action).ToList();
            return listDetail.Count > 0;
        }
    }
}
