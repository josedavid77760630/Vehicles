using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypesAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();

        }

        private async Task CheckProceduresAsync()
        {
            if(!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineacion" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Lubricacion de suspencion" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Calibracion de valvulas" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineacion de carburador" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Aceite de motor" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Aceite de caja" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Filtro de aire" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Sistema electrico" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio llanta delantera" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio llanta trasera" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Reparacion de motor" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Kit de arrastre" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio de bateria" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio de bujia" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio rodamiento delantero" });
                _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio rodamiento trasero" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Libreta Servicio Militar" });

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "Ducati" });
                _context.Brands.Add(new Brand { Description = "Toyota" });
                _context.Brands.Add(new Brand { Description = "Nissan" });
                _context.Brands.Add(new Brand { Description = "KIA" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Kawasaki" });
                _context.Brands.Add(new Brand { Description = "BMW" });
                _context.Brands.Add(new Brand { Description = "KTM" });
                _context.Brands.Add(new Brand { Description = "Yamaha" });
                _context.Brands.Add(new Brand { Description = "Mazda" });
                _context.Brands.Add(new Brand { Description = "Foton" });
                _context.Brands.Add(new Brand { Description = "Renault" });
                _context.Brands.Add(new Brand { Description = "Crevrolet" });
                _context.Brands.Add(new Brand { Description = "suzuki" });

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckVehicleTypesAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Moto" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Camion" });

                await _context.SaveChangesAsync();
                
            }
        }
    }
}
