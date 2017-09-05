using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MQUESTSYS.Controllers
{
    public class ReportViewerController : Controller
    {
        private string GetReportTitle(ReportViewerType type, string queryString)
        {
            if (type == ReportViewerType.Project)
                return "Laporan Proyek";


            return "";
        }

        private string GetReportPath(ReportViewerType type)
        {
            if (type == ReportViewerType.Project)
                return "/Report/Transaction/Project/ProjectReport.aspx";

            return "";
        }

        private string GetPrintOutTitle(PrintOutType type)
        {
            if (type == PrintOutType.Invoice)
                return "Invoice";
           
            return "";
        }

        private string GetPrintOutPath(PrintOutType type)
        {

            if (type == PrintOutType.Invoice)
                return "/PrintOut/Transaction/Invoice/InvoicePrintOut.aspx";

            return "";
        }

        public ActionResult Index(ReportViewerType type, string queryString)
        {
            ViewBag.Title = GetReportTitle(type, queryString);

            var reportPath = GetReportPath(type);

            if (!string.IsNullOrEmpty(queryString))
            {
                reportPath += "?" + queryString;
            }

            ViewBag.ReportPath = reportPath;

            return View();
        }

        public ActionResult PopUp(PrintOutType type, string queryString)
        {
            ViewBag.Title = GetPrintOutTitle(type);

            var reportPath = GetPrintOutPath(type);

            if (!string.IsNullOrEmpty(queryString))
            {
                reportPath += "?" + queryString;
            }

            ViewBag.ReportPath = reportPath;

            return View();
        }

        public enum PrintOutType
        {
            Invoice

        }

        public enum ReportViewerType
        {
            Project
        }
    }
}
