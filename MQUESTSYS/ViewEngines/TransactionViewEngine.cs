using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MQUESTSYS
{
    public class TransactionViewEngine : RazorViewEngine
    {
        public TransactionViewEngine()
            : base()
        {
            base.ViewLocationFormats = base.ViewLocationFormats.Concat(new[] {
            "~/Views/Transaction/{1}/{0}.cshtml",
            "~/Views/Transaction/{1}/{0}.vbhtml"
            }).ToArray();

            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Concat(new[] {
            "~/Views/Transaction/{1}/{0}.cshtml",
            "~/Views/Transaction/{1}/{0}.vbhtml"
            }).ToArray();
        }
    }
}