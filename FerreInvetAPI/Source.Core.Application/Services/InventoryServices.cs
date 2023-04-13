using Source.Core.Application.Interfaces.Repository;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryServices(IInventoryRepository repository) 
        {
            _inventoryRepository = repository;
        }


        public async Task<List<Inventory>> getAllServices()
        {
           return await _inventoryRepository.GetAllRepository();
        }

        public async Task<Inventory> getByIdServices(int id)
        {
            return await _inventoryRepository.GetByIdRepository(id);
        }

        public async Task postCreateServices(Inventory inventory)
        {
            await _inventoryRepository.AddRepository(inventory);
        }

        public async Task<Inventory> putUpdateServices(Inventory inventory)
        {
            await _inventoryRepository.UpdateRepository(inventory);

            return await _inventoryRepository.GetByIdRepository(inventory.id);
        }

        public async Task deleteServices(int id)
        {
            var repository = await _inventoryRepository.GetByIdRepository(id);
            await _inventoryRepository.DeleteRepository(repository);
        }
    }
}
