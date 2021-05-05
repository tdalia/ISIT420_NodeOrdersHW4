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
            List<CDTable> cds = entities.CDTables.Where(c => c.ListPrice > 13).ToList<CDTable>();

            var list = from c in entities.CDTables
            select new CityCDCount(c.CDname, c.YearReleased, 12);

            List<CityCDCount> list1 = list.ToList();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
