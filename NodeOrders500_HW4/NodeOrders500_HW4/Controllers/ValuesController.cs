using NodeOrders500_HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NodeOrders500_HW4.Controllers
{
    public class ValuesController : ApiController
    {
        NodeOrders500Entities entities = new NodeOrders500Entities();

        // Gets a list of city of stores
        [HttpGet]
        [ActionName("storeByCity")]
        public List<StoreDTO> GetStoreByCity()
        {
            List<StoreDTO> cities = (from s in entities.StoreTables
                                select new StoreDTO {
                                    StoreId = s.storeID,
                                    City = s.City
                                }).ToList();

            return cities;
        }

        // Get all employees 
        [HttpGet]
        [ActionName("empList")]
        public List<EmployeeDTO> GetEmployees()
        {
            List<EmployeeDTO> employees = (from s in entities.SalesPersonTables
                              select new EmployeeDTO {
                                  SalesPersonId = s.salesPersonID,
                                  EmployeeFullName = s.FirstName + " " + s.LastName
                              }).ToList();

            return employees;
        }

        [ActionName("salesOfEmployee")]
        public IHttpActionResult GetSalesOfEmployee(int id)  // salesPersonId
        {
            int sales = 0;

            try
            {
                sales = (from o in entities.Orders
                         where o.salesPersonID == id && o.dayPurch <= 365
                         select o.pricePaid).Sum();
            } catch
            {
                return BadRequest();
            }

            return Ok(sales);               
        }

        [ActionName("salesOfStore")]
        public IHttpActionResult GetSalesOfStore(int id)  // storeId
        {
            int sales = 0;

            try
            {
                sales = (from o in entities.Orders
                         where o.storeID == id && o.dayPurch <= 365
                         select o.pricePaid).Sum();
            }
            catch
            {
                return BadRequest();
            }

            return Ok(sales);
        }

        [ActionName("topCDCounts")]
        public IHttpActionResult GetTopCDCounts()
        {
            var counts = (from o in entities.Orders
                          where o.pricePaid > 13
                          group o by o.StoreTable.City into g
                          select new CityCDCount()
                          {
                              CityName = g.Key,
                              RowsCount = g.Count()
                          }).OrderBy(t => t.RowsCount);

            return Json(counts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (entities != null)
                {
                    entities.Database.Connection.Close();
                    entities.Dispose();
                }
            }
        }
    }
}
