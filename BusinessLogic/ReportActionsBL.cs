using System;
using Microsoft.EntityFrameworkCore;
using task_backend.Context;
using task_backend.Interfaces;

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

        public async  Task<List<BikeBrand>> GetBikeBrand()
            => await _context.BikeBrands.ToListAsync();


        public async  Task<List<ServiceComponent>> GetServiceComponents()
            => await _context.ServiceComponents.ToListAsync();


        public async  Task<List<ServicePackage>> GetServicePackages()
            => await _context.ServicePackages.ToListAsync();

        public async Task<bool> AddData()
        {
            var serviceComponents = new List<ServiceComponent> {
                new ServiceComponent { Name = "Check-Up", Currency = "CHF", Price = 50, Description = ""},
                new ServiceComponent { Name = "Service klei", Currency = "CHF", Price = 120, Description = ""},
                new ServiceComponent { Name = "Service gross", Currency = "CHF", Price = 170, Description = ""},
            };

            var listBikeBrands = new List<ServicePackage> {
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

            await _context.ServiceComponents.AddRangeAsync(serviceComponents);
            await _context.ServicePackages.AddRangeAsync(listBikeBrands);

            await _context.SaveChangesAsync();
            return true;

        }
    }

}

