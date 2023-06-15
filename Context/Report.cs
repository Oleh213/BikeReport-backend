using System;
namespace task_backend.Context
{
	public class Report
	{
		public Guid ReportId { get; set; }

		public Guid BikeTypeId { get; set; }

        public Guid BikeBrandId { get; set; }

		public Guid  ServiceComponentId { get; set; }

        public string Message { get; set; }

        public int MaxMoney { get; set; }

        public string Name { get; set; }

        public string SureName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Street2 { get; set; }

        public string Zip { get; set; }

        public BikeType BikeType { get; set; }

        public BikeBrand BikeBrand { get; set; }

        public ICollection<ServicePackage> ServicePackeges { get; set; }

        public ServiceComponent ServiceComponent { get; set; }


    }
}

