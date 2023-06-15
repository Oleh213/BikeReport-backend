using System;
using System.Text.Json.Serialization;

namespace task_backend.Context
{
	public class ServiceComponent
    {
        public Guid ServiceComponentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Currency { get; set; }

        [JsonIgnore]
        public ICollection<Report> Report { get; set; }
    }
}

