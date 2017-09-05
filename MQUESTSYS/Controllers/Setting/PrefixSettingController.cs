using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MQUESTSYS.BF.Master;
using MQUESTSYS.Models.Master;
using MPL.MVC;

namespace MQUESTSYS.Controllers.Setting
{
    public class PrefixSettingController : GenericController<PrefixSettingModel>
    {

        public override MPL.Business.IGenericBFC<PrefixSettingModel> GetBFC()
        {
            return new PrefixSettingBFC();
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
    }
}
