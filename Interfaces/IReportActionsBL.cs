using System;
using task_backend.Context;

namespace task_backend.Interfaces
{
	public interface IReportActionsBL
	{
		Task<List<BikeType>> GetBikeTypes();

        Task<List<BikeBrand>> GetBikeBrand();

        Task<List<ServiceComponent>> GetServiceComponents();

        Task<List<ServicePackage>> GetServicePackages();

        Task<bool> AddData();
    }
}

