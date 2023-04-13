using Source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.Interfaces.Services
{
    public interface IInventoryServices
    {
        public Task<List<Inventory>> getAllServices();
        public Task<Inventory> getByIdServices(int id);
        public Task postCreateServices(Inventory inventory);
        public Task<Inventory> putUpdateServices(Inventory inventory);
        public Task deleteServices(int id);
    }
}
