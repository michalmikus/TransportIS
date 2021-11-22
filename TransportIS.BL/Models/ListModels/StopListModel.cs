﻿namespace TransportIS.BL.Models.DetailModels
{
    public class StopListModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public AddressListModel Address{ get; set; } = new AddressListModel();
    }
}
