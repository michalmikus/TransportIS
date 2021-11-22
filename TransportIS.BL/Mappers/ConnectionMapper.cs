using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.BL.Factories;
using TransportIS.BL.Factories.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.DAL.Entities;

namespace TransportIS.BL.Mappers
{
    public class ConnectionMapper
    {
        public static ConnectionDetailModel? MapToDetailModel(ConnectionEntity entity) =>
            entity == null ? null : new ConnectionDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ReservedSeats = entity.ReservedSeats,
                EmptySeats = entity?.Vehicle?.NumberOfSeats - entity.ReservedSeats,
                VehicleType = Enum.GetName(entity.Vehicle.Type),
                VehicleId = entity.Vehicle.Id,
                CarrierName = entity?.Carrier?.CarrierName,
                CarrierId = entity?.CarrierId,
                PersonelNames = GetPersonelNames(entity),
                PersonelIds = GetPersonelIds(entity),
                NamesOfStops = GetStopNames(entity),
                TimeOfStops = GetStopTimes(entity)
            };

        public static ConnectionEntity MapToEntity(ConnectionDetailModel detailModel, IEntityFactory entityFactory) 
        {
            ConnectionEntity entity = (entityFactory ??= new DefaultEntityFactory()).Create<ConnectionEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.Name = detailModel.Name;
            entity.Description = detailModel.Description;
            entity.ReservedSeats = detailModel.ReservedSeats;
            entity.VehicleId = detailModel.VehicleId;
            entity.CarrierId = detailModel?.CarrierId;
            return entity;
        }

        static ICollection<string?> GetPersonelNames(ConnectionEntity entity)
        {
            ICollection<string?> names = new List<string?>();

            foreach(var personelEntity in entity.Personel)
            {
                names.Add(personelEntity?.Address?.Name);
            }    

            return names;
        }

        static ICollection<Guid?> GetPersonelIds(ConnectionEntity entity)
        {
            ICollection<Guid?> ids = new List<Guid?>();

            foreach (var personelEntity in entity.Personel)
            {
                ids.Add(personelEntity?.Id);
            }

            return ids;
        }

        static ICollection<Guid?> GetStoplIds(ConnectionEntity entity)
        {
            ICollection<Guid?> ids = new List<Guid?>();

            foreach (var personelEntity in entity.Stops)
            {
                ids.Add(personelEntity?.Id);
            }

            return ids;
        }

        static ICollection<Guid?> GetTicketlIds(ConnectionEntity entity)
        {
            ICollection<Guid?> ids = new List<Guid?>();

            if (entity == null) return null;

            foreach (var personelEntity in entity.Tickets)
            {
                ids.Add(personelEntity?.Id);
            }

            return ids;
        }

        static ICollection<string?> GetStopNames(ConnectionEntity entity)
        {
            ICollection<string?> names = new List<string?>();

            foreach (var stopEntity in entity.Stops)
            {
                names.Add(stopEntity?.Stop?.Name);
            }

            return names;
        }

        static List<DateTime> GetStopTimes(ConnectionEntity entity)
        {
            List<DateTime> times = new();

            foreach (var time in entity.Stops)
            {
                times.Add(time.TimeOfDeparture);
            }

            return times;
        }
    }
}

