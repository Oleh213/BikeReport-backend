using System;
using task_backend.Context;
using task_backend.Models;

namespace task_backend.Interfaces
{
	public interface IReportActionsBL
	{
		Task<List<BikeType>> GetBikeTypes();

        Task<List<BikeBrand>> GetBikeBrand();

        Task<List<ServiceComponent>> GetServiceComponents();

        Task<List<ServicePackage>> GetServicePackages();

        Task<bool> AddData();

        Task<bool> SentReport(SentReportmodel reportmodel);

        Task<bool> CheckInformation(SentReportmodel reportmodel);
    }
}

