using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            _ = await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypesAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUsersAsync("1010", "Jose", "Mamani", "jose@yopmail.com", "123456789", "Vinto calle 3", UserType.Admin);
            await CheckUsersAsync("2020", "David", "Zapata", "david@yopmail.com", "123456789", "Vinto calle 3", UserType.User);
            await CheckUsersAsync("3030", "Juan", "Zuluaga", "zulu@yopmail.com", "123456789", "Vinto calle 3", UserType.User);
            await CheckUsersAsync("4040", "Sandra", "Lopera", "sandra@yopmail.com", "123456789", "Vinto calle 3", UserType.Admin);

        }

        private async Task CheckUsersAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x=> x.Description == "Cedula de Identidad"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineacion" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Lubricacion de suspencion" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Frenos delanteros" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Frenos traseros" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido frenos traseros" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Liquido frenos delanteros" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Calibracion de valvulas" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Alineacion de carburador" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Aceite de motor" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Aceite de caja" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Filtro de aire" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Sistema electrico" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio llanta delantera" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio llanta trasera" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Reparacion de motor" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Kit de arrastre" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio de bateria" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio de bujia" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio rodamiento delantero" });
                _ = _context.Procedures.Add(new Procedure { Price = 1000, Description = "Cambio rodamiento trasero" });

                _ = await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _ = _context.DocumentTypes.Add(new DocumentType { Description = "Cedula de Identidad" });
                _ = _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                _ = _context.DocumentTypes.Add(new DocumentType { Description = "Libreta Servicio Militar" });

                _ = await _context.SaveChangesAsync();

            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _ = _context.Brands.Add(new Brand { Description = "Ducati" });
                _ = _context.Brands.Add(new Brand { Description = "Toyota" });
                _ = _context.Brands.Add(new Brand { Description = "Nissan" });
                _ = _context.Brands.Add(new Brand { Description = "KIA" });
                _ = _context.Brands.Add(new Brand { Description = "Honda" });
                _ = _context.Brands.Add(new Brand { Description = "Kawasaki" });
                _ = _context.Brands.Add(new Brand { Description = "BMW" });
                _ = _context.Brands.Add(new Brand { Description = "KTM" });
                _ = _context.Brands.Add(new Brand { Description = "Yamaha" });
                _ = _context.Brands.Add(new Brand { Description = "Mazda" });
                _ = _context.Brands.Add(new Brand { Description = "Foton" });
                _ = _context.Brands.Add(new Brand { Description = "Renault" });
                _ = _context.Brands.Add(new Brand { Description = "Crevrolet" });
                _ = _context.Brands.Add(new Brand { Description = "suzuki" });

                _ = await _context.SaveChangesAsync();

            }
        }

        private async Task CheckVehicleTypesAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _ = _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _ = _context.VehicleTypes.Add(new VehicleType { Description = "Moto" });
                _ = _context.VehicleTypes.Add(new VehicleType { Description = "Camion" });

                _ = await _context.SaveChangesAsync();

            }
        }
    }
}
