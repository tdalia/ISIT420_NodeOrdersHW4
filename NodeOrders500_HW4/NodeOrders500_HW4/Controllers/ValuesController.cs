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

        // GET api/values
        public IEnumerable<string> Get()
        {
            /*
            List<CDTable> cds = entities.CDTables.Where(c => c.ListPrice > 13).ToList<CDTable>();

            var list = from c in entities.CDTables
            select new CityCDCount(c.CDname, c.YearReleased, 12);

            List<CityCDCount> list1 = list.ToList();
            */
            return new string[] { "value1", "value2" };
        }

        /*
        // GET api/values/5
        public string GetStore(int id)
        {
            return "value";
        }
        */

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

    }
}
