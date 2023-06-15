using System;
using System.Text.Json.Serialization;

namespace task_backend.Context
{
	public class ServicePackage
    {
		public Guid ServicePackageId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int? Price { get; set; }

        public string? Currency { get; set; }

        public bool? ElectroBike { get; set; }

        [JsonIgnore]
        public ICollection<Report> Reports { get; set; }
    }
}

