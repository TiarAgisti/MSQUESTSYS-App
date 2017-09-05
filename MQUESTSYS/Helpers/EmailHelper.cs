﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MQUESTSYS.BF;

namespace MQUESTSYS.Helpers
{
    public class EmailHelper
    {

        //public void SendVoidQuotationEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var quotation = new QuotationBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + quotation.Code;

        //    var emailMessage = "[VOID] " + quotation.Code + ":" + quotation.ModifiedBy + " " + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidPurchaseOrderEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var purchaseOrder = new PurchaseOrderBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + purchaseOrder.Code;

        //    var emailMessage = "[VOID] " + purchaseOrder.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidPurchaseDeliveryEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var pd = new PurchaseDeliveryBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + pd.Code;

        //    var emailMessage = "[VOID] " + pd.Code + ":" + pd.ModifiedBy + " " + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidSalesOrderEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var salesOrder = new SalesOrderBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + salesOrder.Code;

        //    var emailMessage = "[VOID] " + salesOrder.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidSalesReturnEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var salesReturn = new SalesReturnBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + salesReturn.Code;

        //    var emailMessage = "[VOID] " + salesReturn.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidDOEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var deliveryOrder = new DeliveryOrderBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + deliveryOrder.Code;

        //    var emailMessage = "[VOID] " + deliveryOrder.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidInvoiceEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var invoice = new InvoiceBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + invoice.Code;

        //    var emailMessage = "[VOID] " + invoice.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidPaymentEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var payment = new PaymentBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + payment.Code;

        //    var emailMessage = "[VOID] " + payment.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidPurchasePaymentEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var purchasePayment = new PurchasePaymentBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + purchasePayment.Code;

        //    var emailMessage = "[VOID] " + purchasePayment.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidIncomeExpenseEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var incomeExpense = new IncomeExpenseBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + incomeExpense.Code;

        //    var emailMessage = "[VOID] " + incomeExpense.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        //public void SendVoidAccountingEmail(long id, string voidRemarks, string userName)
        //{
        //    var companySetting = new CompanySettingBFC().Retrieve();
        //    var accounting = new AccountingBFC().RetrieveByID(id);

        //    var subject = "[VOID] " + accounting.Code;

        //    var emailMessage = "[VOID] " + accounting.Code + ":" + voidRemarks;

        //    SendEmail(companySetting.OwnerEmail, subject, emailMessage);
        //}

        public void SendEmail(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage("noreply@psinformatika.com", email);
            SmtpClient client = new SmtpClient();
            //client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "113.20.31.137";
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}