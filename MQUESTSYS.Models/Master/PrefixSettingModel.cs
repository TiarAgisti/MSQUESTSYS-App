using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQUESTSYS.Models.Master
{
    public class PrefixSettingModel
    {
        public int ID { get; set; }
        public string ProductPrefix { get; set; }
        public string CustomerPrefix { get; set; }
        public string SupplierPrefix { get; set; }
        public string VendorPrefix { get; set; }
        public string SalesmanPrefix { get; set; }
        public string WarehousePrefix { get; set; }
        public string AdjustmentPrefix { get; set; }
        public string QuotationPrefix { get; set; }
        public string DeliveryOrderPrefix { get; set; }
        public string SalesOrderPrefix { get; set; }
        public string SalesReturnPrefix { get; set; }
        public string PurchasePrefix { get; set; }
        public string InvoicePrefix { get; set; }
        public string VendorInvoicePrefix { get; set; }
        public string IncomePrefix { get; set; }
        public string ExpensePrefix { get; set; }
        public string AccountPrefix { get; set; }
        public string PaymentPrefix { get; set; }
        public string AccountingPrefix { get; set; }
        public string AllowancePrefix { get; set; }
        public string AttendancePrefix { get; set; }
        public string IncomeBankPrefix { get; set; }
        public string ExpenseBankPrefix { get; set; }
        public string CashInPrefix { get; set; }
        public string CashOutPrefix { get; set; }
        public string PurchasePaymentPrefix { get; set; }
        public string PurchaseDeliveryPrefix { get; set; }
        public string CRMPrefix { get; set; }
        public string ForwarderPrefix { get; set; }
        public string InventoryPrefix { get; set; }
        public string AssemblyPrefix { get; set; }
        public string CreditNotePrefix { get; set; }
        public string DepartmentPrefix { get; set; }
    }
}
