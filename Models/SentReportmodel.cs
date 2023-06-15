using System;
using task_backend.Context;
using task_backend.DTO;

namespace task_backend.Models
{
	public class SentReportmodel
	{
        public Guid BikeTypeId { get; set; }

        public Guid BikeBrandId { get; set; }

        public Guid ServiceComponentId { get; set; }

        public string Message { get; set; }

        public bool AddPackages { get; set; }

        public bool Ebike { get; set; }

        public int? MaxMoney { get; set; }

        public string Name { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Street2 { get; set; }

        public string Zip { get; set; }

        public List<ServicePackageDTO> ServicePackages { get; set; }
    }
}

