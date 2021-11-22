using Microsoft.EntityFrameworkCore;
using TransportIS.DAL;
using TransportIS.DAL.Entities;
using TransportIS.DAL.Entities.Interfaces;
using TransportIS.BL.Repository;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Mappers;
using TransportIS.DAL.Repository;

namespace TransportIS.BL.Repository
{
    public class ConnectionRepository : Repository<ConnectionEntity>
    {
        public TransportISDbContext context;
        public ConnectionRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
            context = contextProvider();
        }
        
        public ICollection<ConnectionDetailModel?> GetAll()
        {
            return context.Connections.Select(c => ConnectionMapper.MapToDetailModel(c)).ToList();
        }

        public ConnectionDetailModel? GetById(Guid Id)
        {
            var entity = context.Connections.FirstOrDefault(c => c.Id == Id);
            return ConnectionMapper.MapToDetailModel(entity);
        }

        public void Insert(ConnectionEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            context.Add(entity);
            context.SaveChanges();
        }

        public ConnectionDetailModel? Update(ConnectionDetailModel model)
        {
            var entity = ConnectionMapper.MapToEntity(model,null);

            Insert(entity);

            return ConnectionMapper.MapToDetailModel(entity);
        }
    }
}
