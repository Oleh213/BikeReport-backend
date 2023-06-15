using System;
using System.Text.Json.Serialization;

namespace task_backend.Context
{
	public class BikeBrand
	{
        public Guid BikeBrandId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Report> Report { get; set; }
    }
}

