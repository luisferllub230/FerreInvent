using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.Interfaces.Repository;
using Source.Core.Application.Interfaces.Services;
using Source.Core.Domain.Entities;
using System.Diagnostics;

namespace Source.Core.Application.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryServices(IInventoryRepository repository) 
        {
            _inventoryRepository = repository;
        }


        public async Task<(List<InventoryDTO>, ErrorMessageDTO)> getAllServices()
        {
            var error = new ErrorMessageDTO();
            var inventories = await _inventoryRepository
                .GetAllWhitIncluedeRepository(new List<string> { "sales", "categories" });

            if (inventories.Count() == 0) 
            {
                error.IsError = true;
                error.ErrorMessage = "There arent inventory :(";

                return (null, error);
            }

            var invetoryDTO = inventories.Select(
                inventory => new InventoryDTO
                {
                    id = inventory.id,
                    inventoryName = inventory.inventoryName,
                    discount = inventory.discount,
                    bran = inventory.bran,
                    price = inventory.price,
                    salesCount = inventory.sales.Count(),
                    quantity = inventory.quantity,
                    categoryName = inventory.categories.categoryName
                }).ToList();

            return (invetoryDTO, error);
        }

        
        public async Task<(InventoryDTO, ErrorMessageDTO)> getByIdServices(int id)
        {
            var error = new ErrorMessageDTO();
            var inventory = await _inventoryRepository.GetByIdWhitIncludeRepository<Inventory>(id, new List<string> {"sales", "categories"});

            if (inventory == null) 
            {
                error.IsError = true;
                error.ErrorMessage = "Sorry, we didn't find any inventory";
                return (null, error);
            }

            var inventoryDTO = new InventoryDTO();
            inventoryDTO.id = inventory.id;
            inventoryDTO.inventoryName = inventory.inventoryName;
            inventoryDTO.discount = inventory.discount;
            inventoryDTO.bran = inventory.bran;
            inventoryDTO.price = inventory.price;
            inventoryDTO.salesCount = inventory.sales.Count();
            inventoryDTO.quantity = inventory.quantity;
            inventoryDTO.categoryName = inventory.categories.categoryName;

            return (inventoryDTO, error);
        }

        public async Task postCreateServices(SaveInventoryDTO saveInventoryDTO)
        {
            var inventory = new Inventory();
            inventory.inventoryName = saveInventoryDTO.inventoryName;
            inventory.quantity = saveInventoryDTO.quantity;
            inventory.price = saveInventoryDTO.price;
            inventory.discount = saveInventoryDTO.discount;
            inventory.categoryID = saveInventoryDTO.categoryId;
            inventory.bran = saveInventoryDTO.bran;

            await _inventoryRepository.AddRepository(inventory);
        }

        public async Task putUpdateServices(SaveInventoryDTO saveInventoryDTO)
        {
            var inventory = await _inventoryRepository.GetByIdRepository(saveInventoryDTO.id);
            inventory.id = saveInventoryDTO.id;
            inventory.inventoryName = saveInventoryDTO.inventoryName;
            inventory.quantity = saveInventoryDTO.quantity;
            inventory.price = saveInventoryDTO.price;
            inventory.discount = saveInventoryDTO.discount;
            inventory.categoryID = saveInventoryDTO.categoryId;
            inventory.bran = saveInventoryDTO.bran;

            await _inventoryRepository.UpdateRepository(inventory);
        }

        public async Task deleteServices(int id)
        {
            var repository = await _inventoryRepository.GetByIdRepository(id);
            await _inventoryRepository.DeleteRepository(repository);
        }
    }
}
