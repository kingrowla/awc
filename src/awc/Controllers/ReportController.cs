using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using awc.Entities;
using awc.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace awc.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {

        private AWContext db = new AWContext();
        // GET: /<controller>/
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            //var customers = db.Customer.OrderByDescending(u => u.FirstName).Take(5);
            //return View(customers.ToList());
            //ElmahError = grp.OrderBy(s => s.ElmahError.TimeUtc).FirstOrDefault();
            List<ReportAttributes> model = new List<ReportAttributes>();
                                  var innerJoinQuery = (from c in db.Customer
                                  join s in db.SalesOrderHeader on c.CustomerId equals s.CustomerId
                                  join sd in db.SalesOrderDetail on s.SalesOrderId equals sd.SalesOrderId 
                                  orderby s.CustomerId descending
                                  select new
                                  {
                                      sd.SalesOrderDetailId,
                                      sd.OrderQty,
                                      sd.ProductId,
                                      sd.UnitPrice,
                                      sd.UnitPriceDiscount,
                                      sd.LineTotal,
                                      s.SalesOrderId,
                                      s.RevisionNumber,
                                      s.OrderDate,
                                      s.DueDate,
                                      s.ShipDate,
                                      s.Status,
                                      s.OnlineOrderFlag,
                                      s.SalesOrderNumber,
                                      s.PurchaseOrderNumber,
                                      s.AccountNumber,
                                      s.CustomerId,
                                      s.ShipToAddressId,
                                      s.BillToAddressId,
                                      s.ShipMethod,
                                      s.CreditCardApprovalCode,
                                      s.SubTotal,
                                      s.TaxAmt,
                                      s.Freight,
                                      s.TotalDue,
                                      c.Title,
                                      c.FirstName,
                                      c.MiddleName,
                                      c.LastName,
                                      c.CompanyName,
                                      c.SalesPerson,
                                      c.EmailAddress,
                                      c.Phone,
                                 
                                  }).ToList();
            var newItems = innerJoinQuery.Where(x => !model.Any(y => x.CustomerId == y.CustomerId));
            foreach (var item in newItems)
            {
               
                model.Add(new ReportAttributes()
                    {
                        SalesOrderId = item.SalesOrderDetailId,
                        OrderQty = item.OrderQty,
                        ProductId = item.ProductId,
                        UnitPrice = item.UnitPrice,
                        UnitPriceDiscount = item.UnitPriceDiscount,
                        LineTotal = item.LineTotal,
                        RevisionNumber = item.RevisionNumber,
                        OrderDate = item.OrderDate,
                        DueDate = item.DueDate,
                        ShipDate = item.ShipDate,
                        Status = item.Status,
                        OnlineOrderFlag = item.OnlineOrderFlag,
                        SalesOrderNumber = item.SalesOrderNumber,
                        PurchaseOrderNumber = item.PurchaseOrderNumber,
                        AccountNumber = item.AccountNumber,
                        CustomerId = item.CustomerId,
                        ShipToAddressId = item.ShipToAddressId,
                        BillToAddressId = item.BillToAddressId,
                        ShipMethod = item.ShipMethod,
                        CreditCardApprovalCode = item.CreditCardApprovalCode,
                        SubTotal = item.SubTotal,
                        TaxAmt = item.TaxAmt,
                        TotalDue = item.TotalDue,
                        Title = item.Title,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName,
                        CompanyName = item.CompanyName,
                        SalesPerson = item.SalesPerson,
                        EmailAddress = item.EmailAddress,
                        Phone = item.Phone,
                        CustomerName = item.LastName + ", " + item.FirstName
                    });
                }
            return View(model);

        }
    }
}
