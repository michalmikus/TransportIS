using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;
using AutoMapper;
using TransportIS.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connections")]
    [ApiController]
    public class ConnectionControler : ControllerBase
    {
        private readonly IRepository<CarrierEntity> repository;
        private readonly IMapper mapper;

        public ConnectionControler(IRepository<CarrierEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<ConnectionListModel> Get()
        {
           var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<ConnectionListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public ConnectionDetialModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<ConnectionDetialModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public ConnectionDetialModel Post([FromBody] ConnectionDetialModel model)
        {
           var result =  repository.Insert(mapper.Map<ConnectionEntity>(model));
            return mapper.Map<ConnectionDetialModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public CarrierDetailModel Put(Guid id, [FromBody] CarrierDetailModel model)
        {
            var entity = repository.GetEntityById(id);
            mapper.Map(model, entity );
            repository.Update(entity);
            
            return model;
        }

        // DELETE api/<ConnectionControler>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
