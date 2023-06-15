using System;
using Microsoft.EntityFrameworkCore;
using task_backend.Context;
using task_backend.DTO;
using task_backend.Interfaces;
using task_backend.Models;

namespace task_backend.BusinessLogic
{
	public class ReportActionsBL : IReportActionsBL
    {
        private readonly ReportContext _context;

        public ReportActionsBL(ReportContext context)
		{
            _context = context;
        }

        public async Task<List<BikeType>> GetBikeTypes()
            => await _context.BikeTypes.ToListAsync();

        public async Task<List<BikeBrand>> GetBikeBrand()
            => await _context.BikeBrands.ToListAsync();


        public async Task<List<ServiceComponent>> GetServiceComponents()
            => await _context.ServiceComponents.ToListAsync();


        public async Task<List<ServicePackage>> GetServicePackages()
            => await _context.ServicePackages.ToListAsync();

        public async Task<bool> SentReport(SentReportmodel reportmodel)
        {

            var report = new Report
            {
                AddPackages = reportmodel.AddPackages,
                BikeBrandId = reportmodel.BikeBrandId,
                BikeTypeId = reportmodel.BikeTypeId,
                City = reportmodel.City,
                Ebike = reportmodel.Ebike,
                Message = reportmodel.Message,
                Name = reportmodel.Name,
                MaxMoney = reportmodel.MaxMoney,
                Email = reportmodel.Email,
                Phone = reportmodel.Phone,
                Street = reportmodel.Street,
                Street2 = reportmodel.Street2,
                ServiceComponentId = reportmodel.ServiceComponentId,
                SureName = reportmodel.SureName,
                Zip = reportmodel.Zip,
            };

            if (reportmodel.ServicePackages != null)
            {
                report.ServicePackeges = TransferServicePackageFromDTO(reportmodel.ServicePackages);
            }

            await _context.AddAsync(report);

            await _context.SaveChangesAsync();
            return true;
        }

        public List<ServicePackage> TransferServicePackageFromDTO(List<ServicePackageDTO> servicePackagesDTO)
        {
            var list = new List<ServicePackage>();

            var servicePackages = _context.ServicePackages;
            foreach(var item in servicePackagesDTO)
            {
                list.Add(servicePackages.FirstOrDefault(x => x.ServicePackageId == item.ServicePackageId)!);
            }

            return list;
        }

        public async Task<bool> CheckInformation(SentReportmodel reportmodel)
        {
            if(string.IsNullOrEmpty(reportmodel.City)
                || string.IsNullOrEmpty(reportmodel.Zip)
                || string.IsNullOrEmpty(reportmodel.Street)
                || string.IsNullOrEmpty(reportmodel.Street2)
                || string.IsNullOrEmpty(reportmodel.SureName)
                || string.IsNullOrEmpty(reportmodel.Phone)
                || string.IsNullOrEmpty(reportmodel.Email)
                || string.IsNullOrEmpty(reportmodel.Name)
                )
            {
                return false;
            }

            if(await _context.BikeBrands.AnyAsync(x=> x.BikeBrandId == reportmodel.BikeBrandId)
                && await _context.BikeTypes.AnyAsync(x => x.BikeTypeId == reportmodel.BikeTypeId)
                && await _context.ServiceComponents.AnyAsync(x => x.ServiceComponentId == reportmodel.ServiceComponentId))
            {
                return!(reportmodel.AddPackages && reportmodel.ServicePackages == null);
                
            }
            return true;

        }

        public async Task<bool> AddData()
        {
            var serviceComponents = new List<ServiceComponent> {
                new ServiceComponent { Name = "Check-Up", Currency = "CHF", Price = 50, Description = ""},
                new ServiceComponent { Name = "Service klei", Currency = "CHF", Price = 120, Description = ""},
                new ServiceComponent { Name = "Service gross", Currency = "CHF", Price = 170, Description = ""},
            };

            var listServicePackages = new List<ServicePackage> {
                new ServicePackage { Name = "Schlauch- und/oder Reifenwechsel", ElectroBike = false},
                new ServicePackage { Name = "Räder zentrieren", ElectroBike = false},
                new ServicePackage { Name = "Schaltung einstellen", ElectroBike = false},
                new ServicePackage { Name = "Bremsen prüfen und einstellen", ElectroBike = false},
                new ServicePackage { Name = "Bremsbeläge wechseln", ElectroBike = false},
                new ServicePackage { Name = "Federgabel Service", ElectroBike = false},
                new ServicePackage { Name = "Dämpfer Service", ElectroBike = false},
                new ServicePackage { Name = "Fahrrad-Komplettreinigung", ElectroBike = false},
                new ServicePackage { Name = "Licht kontrollieren", ElectroBike = false},
                new ServicePackage { Name = "Funktionskontrolle Elektronik/Antrieb", ElectroBike = true},
                new ServicePackage { Name = "Batterie prüfen und laden", ElectroBike = true},
            };

            var listBikeBrands = new List<BikeBrand>{
                new BikeBrand{Name ="Trek"},
                new BikeBrand{Name ="BMC"},
                new BikeBrand{Name ="Scott"},
            };

            var listBikeTypes = new List<BikeType>{
                new BikeType{Name ="Rennvelo"},
                new BikeType{Name ="Reisevelo"},
                new BikeType{Name ="Elektro Velo"},
            };


            await _context.BikeBrands.AddRangeAsync(listBikeBrands);
            await _context.BikeTypes.AddRangeAsync(listBikeTypes);

            await _context.ServiceComponents.AddRangeAsync(serviceComponents);
            await _context.ServicePackages.AddRangeAsync(listServicePackages);

            await _context.SaveChangesAsync();
            return true;

        }
    }

}

