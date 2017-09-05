using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQUESTSYS.Util
{
    public class SystemConstants
    {
        public static int AutoCompleteItemCount = 50;
        public static int ItemPerPage = 20;

        public static string ReportXMLFolder;
        public static string TempReportFolder;

        #region Account
        public static long SalesNonRetailAccount = 63;
        public static long TaxExpenseAccount = 65;
        public static long IncomeAccount = 28;
        public static long SalesDiscountAccount = 79;
        public static long PurchaseDiscountAccount = 80;
        public static long PurchaseAccount = 27;
        public static long OutcomeAccount = 24;
        public static long SelisihKursAccount = 81;
        public static long CostDeliveryAccount = 16;
        public static long CashAccount = 3;

        public static string SalesNonRetailAccountUserCode = "41200";
        public static string SalesRetailAccountUserCode = "41100";

        public static string PurchaseAccountUserCode = "51100";

        public static string SalaryAccountUserCode = "61100";
        public static string OfficeOvertimeAccountUserCode = "61410";
        public static string GeneralOvertimeAccountUserCode = "61420";
        public static string TransportationAccountUserCode = "61600";
        public static string CommunicationAccountUserCode = "61800";
        public static string PhoneAccountUserCode = "62040";
        public static string InternetAccountUserCode = "62050";
        public static string InstallationAccountUserCode = "62060";
        public static string OfficeSuppliesExpenseAccountUserCode = "62070";
        public static string ElectricAccountUserCode = "62080";
        public static string MealAllowanceAccountUserCode = "61500";
        public static string OperationalAccountUserCode = "62130";
        public static string DeliveryAccountUserCode = "62180";
        public static string MedicalAccountUserCode = "62090";
        public static string VehicleMaintenanceAccountUserCode = "62110";
        public static string OfficeMaintenanceAccountUserCode = "62140";
        public static string SalesCommissionAccountUserCode = "62150";
        public static string OfficeSuppliesMaintenanceAccountUserCode = "62170";
        public static string SecurityAccountUserCode = "62190";
        public static string OfficeSuppliesDepreciationAccountUserCode = "63100";
        public static string MachineDepreciationAccountUserCode = "63200";
        public static string VehicleDepreciationAccountUserCode = "63300";
        public static string BuildingDepreciationAccountUserCode = "63400";

        public static string BankAdministrationAccountUserCode = "81000";
        public static string OtherExAccountUserCode = "61101";
        public static string GasolineAccountUserCode = "61601";
        public static string TollRoadAccountUserCode = "61602";
        public static string interestAccountUserCode = "81001";
        public static string PPh21AccountUserCode = "83100";
        public static string PPh25AccountUserCode = "83200";


        public static string CashAccountUserCode = "11200";
        public static string BankAccountUserCode = "11300";
        public static string TravellingDPAccountUserCode = "11600";
        public static string IncomeAccountUserCode = "11700";
        public static string OtherIncomeAccountUserCode = "11900";
        public static string TaxIncomeAccountUserCode = "11920";

        public static string OfficeSuppliesAccountUserCode = "12100";
        public static string OfficeSuppliesAccumulationAccountUserCode = "12110";
        public static string MachineAccountUserCode = "12200";
        public static string MachineAccumulationAccountUserCode = "12210";
        public static string VehicleAccountUserCode = "12300";
        public static string VehicleAccumulationAccountUserCode = "63300";
        public static string BuildingAccountUserCode = "12400";
        public static string BuildingAccumulationAccountUserCode = "12410";

        public static string ExpenseAccountUserCode = "21100";
        public static string ExpensePPh21AccountUserCode = "21500";
        public static string TaxExpenseAccountUserCode = "21600";

        public static string AssetAccountUserCode = "31100";
        public static string HoldProfitAccountUserCode = "31300";
        public static string ContinuousProfitAccountUserCode = "";
        public static string OtherEquityAccountUserCode = "31500";

        public static string SalesDiscountUserCode = "41101";
        public static string PurchaseDiscountUserCode = "51101";
        #endregion

        #region Attendance
        public static decimal MealAllowanceCourier = 12000;
        public static decimal MealAllowanceOperator = 12000;
        public static decimal OvertimeCourier = 7000;
        public static decimal OvertimeOperator = 7000;
        public static decimal LatePenaltyCourier = 20000;
        public static decimal LatePenaltyOperator = 7000;
        public static decimal AlphaPenaltyCourier = 50000;
        public static decimal AlphaPenaltyCourierOnSaturday = 100000;
        public static decimal AlphaPenaltyOperator = 50000;
        public static string OffDutyCourier = "17:00";
        public static string OffDutyOperator = "17:00";
        public static string OffDutyCourierOnSaturday = "15:00";
        public static string OffDutyOperatorOnSaturday = "15:00";
        #endregion

        public static DateTime UnsetDateTime = new DateTime(1900, 1, 1);

        public const string autoGenerated = "Auto-Generated";
        public const string str_notif_success = "Document Saved";
        /*Permission Type*/
        public const string str_permission_Create = "Create";
        public const string str_permission_Edit = "Edit";
        public const string str_permission_View = "View";
        public const string str_permission_Void = "Void";
        public const string str_permission_Approve = "Approve";
        public const string str_invoiceID = "InvoiceID";

        public static string str_InvoiceID = "InvoiceID";
        public static string str_VocherID = "VocherID";
    }

    public enum AccountType { Debit = 1, Credit = 2 }
    public enum AccountingResultDocumentType { Accounting = 1, Invoice = 2, Allowance = 3, Attendance = 4, PPh21 = 5, PurchaseOrder = 6, PurchasePayment = 7, Payment = 8 }
    public enum AccountingResultType { Debit = 1, Credit = 2 }
    public enum EditMode { Create = 1, Update = 2 }
    public enum ActionType { Create = 1, Edit = 2, Approve = 3, Void = 4 }
    public enum PermissionType { Administrator = 1, HeadProduction = 2, HeadPurchasing = 3, Director = 4, Manager = 5 }
    public enum TaxType { NonTax = 1, PPN = 2 }

    public enum ProjectStatus { New = 1, Approved = 3, Invoice = 4, Payment = 5 , Void = 0}
    public enum InvoiceStatus { New = 1, Approved = 3, Payment = 4, Void = 0 }
    public enum VocherStatus { New = 1, Approved = 3, VocherExpense = 4, Void = 0 }
}

