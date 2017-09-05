using System;
using NPOI.SS.UserModel;
using System.Web.Security;
using MQUESTSYS.Util;
using System.Web.Profile;
using MQUESTSYS.BF.Master;

namespace MQUESTSYS
{
    public partial class ImportData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Import();
        }

        private void Import()
        {
            //this.CreateUser("administrator", "admin", (int)PermissionType.Administrator);
            //ImportCustomer();
            //importProductQty();
            //importProductBuyingPrice();
            //importProductSellingPrice();
            //importPurchasingList(); 
            //importStock();
            //updateProductMappingCode();
            //updateInventoryMappingCode();
            //importMarketing();
            //importVendor();
            //importStaff();
        }

        //private void CreateUser(string username, string password, int roleID)
        //{
        //    MembershipUser m = Membership.CreateUser(username, password);
        //    ProfileCommon.Create(username).Save();
        //    ProfileCommon p = ProfileCommon.GetProfile(username);
        //    p.RoleID = roleID;
        //    p.IsActive = true;
        //    p.Save();

        //    new UserProfileBFC().Create(username, "System");
        //}
        //private void ImportCustomer()
        //{
        //    var filename = "Customer List 2015";
        //    if (File.Exists(Server.MapPath("~/Import/Customer List 2015.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 2; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var customer = new CustomerModel();
        //            customer.Code = new CustomerBFC().GetCustomerCode();
        //            customer.ManualCode = getValueFromCell(sheet.GetRow(row).GetCell(0));
        //            customer.Name = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //            customer.Address = getValueFromCell(sheet.GetRow(row).GetCell(2));
        //            customer.Phone = getValueFromCell(sheet.GetRow(row).GetCell(3));
        //            customer.TaxFileNumber = getValueFromCell(sheet.GetRow(row).GetCell(4));
        //            customer.IsActive = true;
        //            customer.CreatedBy = customer.ModifiedBy = "SYSTEM";
        //            customer.CreatedDate = customer.ModifiedDate = customer.EffectiveStartDate = customer.EffectiveEndDate = DateTime.Now.Date;
        //            customer.MAP = false;
        //            customer.MaxDay = 2;
        //            //customer.EffectiveEndDate = DateTime.MaxValue.Date;
        //            customer.City = "";
        //            //customer.EffectiveStartDate = DateTime.MinValue;
        //            customer.Fax = "";
        //            if (!String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(5))))
        //                customer.SalesmanID = new SalesmanBFC().RetrieveSalesmanByName(getValueFromCell(sheet.GetRow(row).GetCell(5))).ID;

        //            new CustomerBFC().Create(customer);

        //        }
        //        File.Delete(Server.MapPath("~/Import/Customer List 2015.xls"));
        //    }
        //}

        //private void importProductSellingPrice()
        //{
        //    var filename = "FINAL PRODUCT LIST JULY15";
        //    if (File.Exists(Server.MapPath("~/Import/FINAL PRODUCT LIST JULY15.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 2; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;
        //            var productExist = new ProductBFC().RetrieveByBarcode(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            if (productExist != null)
        //            {
        //                productExist.SellingPrice = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(8)));
        //                productExist.SellingPriceB = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(9)));
        //                productExist.SellingPriceC = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(10)));
        //                new ProductBFC().Update(productExist);
        //                //var quantity = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(6)));

        //                //new ItemLocationBFC().Create(productExist.ID,
        //                //0, quantity, quantity);
        //                //new ProductBFC().Create(productExist);
        //            }
        //        }
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importProductBuyingPrice()
        //{
        //    var filename = "UPDATED_Latest Blum buying price Aug2015";
        //    if (File.Exists(Server.MapPath("~/Import/"+ filename +".xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 1; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;
        //            var productExist = new ProductBFC().RetrieveProductByIndentCode(getValueFromCell(sheet.GetRow(row).GetCell(0)));
        //            if (productExist != null)
        //            {
        //                productExist.AssetPrice = productExist.AssetPriceInDollar = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(2)));
        //                new ProductBFC().Update(productExist);
        //                //var quantity = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(6)));

        //                //new ItemLocationBFC().Create(productExist.ID,
        //                //0, quantity, quantity);
        //                //new ProductBFC().Create(productExist);
        //            }
        //            else
        //            {
        //                var product = new ProductModel();
        //                product.IndentCode = getValueFromCell(sheet.GetRow(row).GetCell(0));
        //                product.Code = product.Barcode = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //                product.ConversionID = 7;
        //                product.ProductGroupID = 3;
        //                product.IsActive = false;
        //                product.BuyingCurrency = product.BuyingUnit = 0;
        //                product.AssetPrice = product.AssetPriceInDollar = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(2)));
        //                product.SellingPrice = product.SellingPriceB = product.SellingPriceC = 0;
        //                product.CreatedBy = product.ModifiedBy = "MIGRATION";
        //                product.CreatedDate = product.ModifiedDate = DateTime.Now;
        //                new ProductBFC().Create(product);

        //                float quantity = 0;
        //                new ItemLocationBFC().Create(product.ID,
        //                1, quantity, quantity);
        //            }
        //        }
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importProductQty()
        //{
        //    var filename = "FINAL PRODUCT LIST JULY15";
        //    if (File.Exists(Server.MapPath("~/Import/FINAL PRODUCT LIST JULY15.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 2; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;
        //            var productExist = new ProductBFC().RetrieveByBarcode(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            if (productExist != null)
        //            {
        //                //productExist.ConversionID = new ProductBFC().RetrieveConversionByCode(getValueFromCell(sheet.GetRow(row).GetCell(7))).ID;
        //                //new ProductBFC().Update(productExist);
        //                var quantity = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(6)));
        //                if (quantity != null)
        //                {
        //                    var itemLoc = new ItemLocationBFC().RetrieveByProductIDWarehouseID(productExist.ID, 1);
        //                    itemLoc.QtyAvailable = quantity;
        //                    itemLoc.QtyOnHand = quantity;

        //                    new ItemLocationBFC().Update(itemLoc);
        //                }
        //              //  new ItemLocationBFC().Update(productExist.ID,
        //              //0, quantity, quantity);
                        
        //            }
        //        }
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importProduct()
        //{
        //    var filename = "FINAL PRODUCT LIST JULY15";
        //    if (File.Exists(Server.MapPath("~/Import/FINAL PRODUCT LIST JULY15.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);
                
        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 2; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;
        //            var productExist = new ProductBFC().RetrieveByCode(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            if (productExist == null)
        //            {
        //                var product = new ProductModel();

        //                product.Code = new ProductBFC().GetProductCode();
        //                product.ProductGroupID = new ProductGroupBFC().RetrieveByCode(getValueFromCell(sheet.GetRow(row).GetCell(1))).ID;
        //                product.Barcode = getValueFromCell(sheet.GetRow(row).GetCell(4));
        //                product.ProductName = getValueFromCell(sheet.GetRow(row).GetCell(5));
        //                product.IndentCode = getValueFromCell(sheet.GetRow(row).GetCell(2));
        //                product.MappingCode = getValueFromCell(sheet.GetRow(row).GetCell(3));
        //                //prodDetail.Quantity = prodDetail.QtyStart = prodDetail.QtySo =
        //                product.StockQty = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(6)));
        //                product.SellingPrice = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(8)));
        //                product.SellingPriceB = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(9)));
        //                product.SellingPriceC = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(10)));
        //                product.AssetPrice = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(11)));
        //                product.AssetPriceB = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(12)));

        //                var rateStr = getValueFromCell(sheet.GetRow(row).GetCell(13));
        //                if (rateStr != null)
        //                {
        //                    RateModel rate = new MQUESTSYSDAC().RetrieveRates(rateStr.Substring(0, 3));
        //                    product.BuyingCurrency = rate.ID;
        //                }
                        
        //                var buyingUnit = getValueFromCell(sheet.GetRow(row).GetCell(14));
        //                if (buyingUnit != null )
        //                    if (buyingUnit != "")
        //                        product.BuyingUnit = Convert.ToInt32(buyingUnit);
        //                    else
        //                        product.BuyingUnit = 1;
        //                else
        //                    product.BuyingUnit = 1;
        //                //product.BaseDoosPrice = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(3)));
        //                //product.StockQty = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(3)));
        //                //product.StockSo  = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(5)));
        //                // product.QtyInDoos = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(7)));

        //                //product.StockQty = 0;//Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //                product.ConversionID = new ProductBFC().RetrieveConversionByCode(getValueFromCell(sheet.GetRow(row).GetCell(7))).ID;

        //                //product.StockPo = product.StockSo = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(2)));

        //                product.IsActive = true;
        //                product.CreatedBy = product.ModifiedBy = "MIGRATION";
        //                product.CreatedDate = product.ModifiedDate = DateTime.Now.Date;
        //                //product.MAP = false;

        //                //customer.EffectiveEndDate = DateTime.MaxValue.Date;
        //                //product.City = "";

        //                //customer.EffectiveStartDate = DateTime.MinValue;
        //                //product.Fax = "";

        //                new ProductBFC().Create(product);
        //            }
        //        }
        //        //File.Delete(Server.MapPath("~/Import/Stock List Jan 2015.xls"));
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importPurchasingList()
        //{
        //    var filename = "Purchasing List Jan 2015update2";
        //    if (File.Exists(Server.MapPath("~/Import/Purchasing List Jan 2015update2.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        for (int row = 3; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var inv = new InventoryModel();

        //            inv.Code = new InventoryBFC().GetInventoryCode();
        //            inv.ProductGroupID = new ProductGroupBFC().RetrieveByCode(getValueFromCell(sheet.GetRow(row).GetCell(0))).ID;
        //            inv.Barcode = getValueFromCell(sheet.GetRow(row).GetCell(2));
        //            inv.InventoryName = getValueFromCell(sheet.GetRow(row).GetCell(3));
        //            inv.IndentCode = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //            //inv.MappingCode = getValueFromCell(sheet.GetRow(row).GetCell(3));
        //            inv.StockQty = 0; // Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(6)));
        //            inv.AssetPrice = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            inv.AssetPriceB = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(5)));
        //            //inv.SellingPriceC = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(10)));
        //            //product.StockQty = 0;//Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            inv.ConversionID = 1;//new ProductBFC().RetrieveConversionByCode(getValueFromCell(sheet.GetRow(row).GetCell(7))).ID;

        //            inv.IsActive = true;
        //            inv.CreatedBy = inv.ModifiedBy = "SYSTEM";
        //            inv.CreatedDate = inv.ModifiedDate = DateTime.Now.Date;

        //            new InventoryBFC().Create(inv);
        //        }
        //        //File.Delete(Server.MapPath("~/Import/Stock List Jan 2015.xls"));
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importStock()
        //{
        //    var filename = "Stock List Jan 2015 UPDATE2.xls";
        //    if (File.Exists(Server.MapPath("~/Import/Stock List Jan 2015 UPDATE2.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        var purchaseOrder = new PurchaseOrderModel();
        //        var poDetails = new List<PurchaseOrderDetailModel>();

        //        purchaseOrder.Code = "1";
        //        purchaseOrder.QuotationID = 0;
        //        purchaseOrder.Date = DateTime.Now;
        //        purchaseOrder.Title = "Import " + DateTime.Now.ToShortDateString();
        //        purchaseOrder.Status = (int)PurchaseOrderStatus.PD;
        //        purchaseOrder.CreatedBy = purchaseOrder.ModifiedBy = purchaseOrder.ApprovedBy = "SYSTEM";
        //        purchaseOrder.CreatedDate = purchaseOrder.ModifiedDate = purchaseOrder.ApprovedDate = DateTime.Now;
                
        //        //Create

        //        for (int row = 3; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var poDetail = new PurchaseOrderDetailModel();
        //            var product = new ProductBFC().RetrieveByCode(getValueFromCell(sheet.GetRow(row).GetCell(2)));
        //            poDetail.ProductID = product.ID;
        //            poDetail.Price = poDetail.AssetPrice = poDetail.AssetPriceInDollar = poDetail.Discount = 0;
        //            poDetail.Quantity = Convert.ToDouble(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            poDetails.Add(poDetail);
        //        }

        //        new PurchaseOrderBFC().Create(purchaseOrder, poDetails);

        //        foreach (var poDetail in poDetails)
        //        {
        //            var product = new ProductBFC().RetrieveByID(poDetail.ProductID);
        //            var productDetails = new ProductBFC().RetrieveDetails(poDetail.ProductID);

        //            var prodDetail = new ProductDetailModel();
        //            prodDetail.PurchaseOrderID = purchaseOrder.ID;
        //            prodDetail.PurchaseOrderItemNo = poDetail.ItemNo;
        //            prodDetail.ItemNo = productDetails.Count() + 1;
        //            prodDetail.Date = purchaseOrder.Date;
        //            prodDetail.Price = prodDetail.AssetPrice = 0;
        //            prodDetail.Quantity = prodDetail.QtyStart = prodDetail.QtySo = Convert.ToDouble(poDetail.Quantity);
        //            prodDetail.IsSaved = true;
        //            //productDetails.Add(prodDetail);

        //            product.StockQty += Convert.ToDouble(poDetail.Quantity);

        //            new ProductBFC().Update(product, productDetails);
        //        }
        //        //File.Delete(Server.MapPath("~/Import/Stock List Jan 2015.xls"));
        //    }
        //}


        //private void updateInventoryMappingCode()
        //{
        //    var filename = "Mapping list";
        //    if (File.Exists(Server.MapPath("~/Import/Mapping list.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        for (int row = 2; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var inv = new InventoryBFC().RetrieveByIndentCode(sheet.GetRow(row).GetCell(1).ToString());
        //            if (inv != null)
        //            {
        //                inv.MappingCode = sheet.GetRow(row).GetCell(3).ToString();

        //                inv.ModifiedBy = "SYSTEM";
        //                inv.ModifiedDate = DateTime.Now.Date;

        //                new InventoryBFC().Update(inv);
        //            }
        //        }
        //        //File.Delete(Server.MapPath("~/Import/Stock List Jan 2015.xls"));
        //    }
        //    LblStatus.Text = "Success!!!";

        //}

        //private void importVendor()
        //{
        //    var filename = "vendor";
        //    if (File.Exists(Server.MapPath("~/Import/vendor.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 5; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var vendor = new VendorModel();

        //            vendor.Code = new VendorBFC().GetVendorCode();
        //            vendor.Name = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //            vendor.Address = getValueFromCell(sheet.GetRow(row).GetCell(2));
        //            vendor.Phone = getValueFromCell(sheet.GetRow(row).GetCell(3));
        //            //vendor.StockSo = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            //vendor.Specification = "";

        //            vendor.IsActive = true;
        //            vendor.CreatedBy = vendor.ModifiedBy = "SYSTEM";
        //            vendor.CreatedDate = vendor.ModifiedDate = vendor.EffectiveStartDate = vendor.EffectiveEndDate = DateTime.Now.Date;
        //            //product.MAP = false;

        //            //customer.EffectiveEndDate = DateTime.MaxValue.Date;
        //            //product.City = "";

        //            //customer.EffectiveStartDate = DateTime.MinValue;
        //            //product.Fax = "";

        //            new VendorBFC().Create(vendor);
        //        }
        //    }

        //}
        //private void importMarketing()
        //{
        //    var filename = "marketing";
        //    if (File.Exists(Server.MapPath("~/Import/marketing.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 5; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var salesman = new SalesmanModel();

        //            salesman.Code = new SalesmanBFC().GetSalesmanCode();
        //            salesman.Name = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //            salesman.Address = getValueFromCell(sheet.GetRow(row).GetCell(2));
        //            salesman.Phone1 = getValueFromCell(sheet.GetRow(row).GetCell(4));
        //            // salesman.Specification = "";

        //            salesman.IsActive = true;
        //            salesman.CreatedBy = salesman.ModifiedBy = "SYSTEM";
        //            salesman.CreatedDate = salesman.ModifiedDate = salesman.EffectiveStartDate = salesman.EffectiveEndDate = DateTime.Now.Date;
        //            //product.MAP = false;

        //            //customer.EffectiveEndDate = DateTime.MaxValue.Date;
        //            //product.City = "";

        //            //customer.EffectiveStartDate = DateTime.MinValue;
        //            //product.Fax = "";

        //            new SalesmanBFC().Create(salesman);
        //        }
        //    }

        //}

        //private void importStaff()
        //{
        //    var filename = "staff";
        //    if (File.Exists(Server.MapPath("~/Import/staff.xls")))
        //    {
        //        var workbook = new HSSFWorkbook(File.OpenRead(Server.MapPath("~/Import/" + filename + ".xls")));
        //        ISheet sheet = workbook.GetSheetAt(0);

        //        //Create
        //        //for (int row = 5; row <= sheet.LastRowNum; row++)
        //        for (int row = 5; row <= sheet.LastRowNum; row++)
        //        {
        //            if (String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(0))) && String.IsNullOrEmpty(getValueFromCell(sheet.GetRow(row).GetCell(1))))
        //                break;

        //            var staff = new StaffModel();

        //            //staff.Code = new StaffBFC().Get();
        //            staff.Name = getValueFromCell(sheet.GetRow(row).GetCell(1));
        //            staff.BasicSalary = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(2)));
        //            // staff.StockSo = Convert.ToDecimal(getValueFromCell(sheet.GetRow(row).GetCell(4)));
        //            //staff.Specification = "";

        //            staff.IsActive = true;
        //            staff.CreatedBy = staff.ModifiedBy = "SYSTEM";
        //            staff.CreatedDate = staff.ModifiedDate = DateTime.Now.Date;
        //            //product.MAP = false;

        //            //customer.EffectiveEndDate = DateTime.MaxValue.Date;
        //            //product.City = "";

        //            //customer.EffectiveStartDate = DateTime.MinValue;
        //            //product.Fax = "";

        //            new StaffBFC().Create(staff);
        //        }
        //    }

        //}


        #region "Generic Function"
        
        private string getValueFromCell(NPOI.SS.UserModel.ICell Cell)
        {
            string Value = "";
            try
            {
                if (Cell.CellType == CellType.STRING)
                {
                    Value = Cell.StringCellValue;
                }
                else if (Cell.CellType == CellType.NUMERIC)
                {
                    Value = Convert.ToString(Cell.NumericCellValue);
                }
                else
                {
                    Value = Cell.StringCellValue;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return Value;
        }

        #endregion
    }
}