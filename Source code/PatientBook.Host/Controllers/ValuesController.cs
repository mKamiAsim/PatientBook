using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using PatientBook.Core;
using System.Text;

namespace PatientBook.Host.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        IDistributedCache _cache;
        Business.IRepository.IPatientRepository _patient;
        public ValuesController(IDistributedCache cache, Business.IRepository.IPatientRepository patient)
        { 
            _cache = cache;
            _patient = patient;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            var patient = _patient.Insert(new Model.Info.Patient { Address="Addres", PatientName="Asim", MaritalStatus="Signle", Age=20, Sex="Male" });

            
            return new string[] { $"Name:\t{patient.PatientName}\t\tAddress:\t{patient.Address}" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public async Task<string> Get(string name)
        {
           await _cache.SetStringAsync("test",name);

            string val = await _cache.GetStringAsync("test");
            return val;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
