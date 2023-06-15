using System;
namespace task_backend.DTO
{
	public class ServicePackageDTO
    {
        public Guid ServicePackageId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int? Price { get; set; }

        public string? Currency { get; set; }

        public bool? ElectroBike { get; set; }
    }
}

