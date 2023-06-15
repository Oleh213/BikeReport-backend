using System;
using System.Text.Json.Serialization;

namespace task_backend.Context
{
	public class BikeType
	{
		public Guid BikeTypeId { get; set; }

		public string Name { get;set;}

        [JsonIgnore]
        public ICollection<Report> Report { get; set; }
    }
}

