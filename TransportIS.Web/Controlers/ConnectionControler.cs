using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionControler : ControllerBase
    {
        private readonly ConnectionRepository repository;

        public ConnectionControler(ConnectionRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public string Get()
        {
            ConnectionDetailModel model = new ConnectionDetailModel {
                Id = Guid.NewGuid(),
                Description = "Toto je popis detailModelu",
                CarrierName = "BlaBlaCar",
                EmptySeats = 5,                
            };

            ConnectionDetailModel Tmodel = new ConnectionDetailModel
            {
                Id = Guid.NewGuid(),
                Description = "Toto je popis detailModelu",
                CarrierName = "BlaBlaCar",
                EmptySeats = 5,
            };

            repository.Update(model);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConnectionControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
