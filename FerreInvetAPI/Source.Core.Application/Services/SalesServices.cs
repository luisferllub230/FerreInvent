using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.DTO.Sales;
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
    public class SalesServices : ISalesServices
    {

        private readonly ISalesRepository _salesRepository;

        public SalesServices(ISalesRepository salesRepository) 
        {
            _salesRepository = salesRepository;
        }

        public async Task<(List<SalesDTO>, ErrorMessageDTO)> getAllServices()
        {
            var error = new ErrorMessageDTO();
            var sales = await _salesRepository.GetAllWhitIncluedeRepository(new List<string> {"custumer", "inventory"});

            if (sales == null || sales.Count() == 0) 
            {
                error.IsError = true;
                error.ErrorMessage = "Sorry there arent any sales";
                return (null, error);
            }

            var salesDTO = sales.Select(
               sale => new SalesDTO
               {
                   id = sale.id,
                   dateSales = sale.dateSales,
                   totalCosto = sale.totalCosto,
                   quantity = sale.quantity,
                   custumerDTO = new CustumerDTO
                   {
                       id = sale.custumer.id,
                       custumerName = sale.custumer.custumerName,
                       custumerAddress = sale.custumer.custumerAddress,
                       custumerEmail = sale.custumer.custumerEmail
                   },
                   inventoryDTO = new InventoryDTO
                   {
                       id = sale.inventory.id,
                       inventoryName = sale.inventory.inventoryName,
                       discount = sale.inventory.discount,
                       bran = sale.inventory.bran,
                       price = sale.inventory.price,
                       quantity = sale.inventory.quantity,
                   }
               }).ToList();

            return (salesDTO, error);
        }

        public async Task<(SalesDTO, ErrorMessageDTO)> getByIdServices(int id)
        {
            var error = new ErrorMessageDTO();
            var sale = await _salesRepository.GetByIdWhitIncludeRepository<Sales>(id, new List<string> { "custumer", "inventory" });

            if (sale == null)
            {
                error.IsError = true;
                error.ErrorMessage = "Sorry, we didn't find any sales";
                return (null, error);
            }

            var salesDTO = new SalesDTO
            {
                id = sale.id,
                dateSales = sale.dateSales,
                totalCosto = sale.totalCosto,
                quantity = sale.quantity,
                custumerDTO = new CustumerDTO
                {
                    id = sale.custumer.id,
                    custumerName = sale.custumer.custumerName,
                    custumerAddress = sale.custumer.custumerAddress,
                    custumerEmail = sale.custumer.custumerEmail
                },
                inventoryDTO = new InventoryDTO
                {
                    id = sale.inventory.id,
                    inventoryName = sale.inventory.inventoryName,
                    discount = sale.inventory.discount,
                    bran = sale.inventory.bran,
                    price = sale.inventory.price,
                    quantity = sale.inventory.quantity,
                }
            };

            return (salesDTO, error);
        }

        public async Task postCreateServices(SaveSalesDTO saveSalesDTO)
        {
            var sale = new Sales
            {
                dateSales = saveSalesDTO.dateSales,
                quantity = saveSalesDTO.quantity,
                totalCosto = saveSalesDTO.totalCosto,
                custumerID = saveSalesDTO.custumerID,
                inventoryID = saveSalesDTO.inventoryID,
            };

            await _salesRepository.AddRepository(sale);
        }

        public async Task putUpdateServices(SaveSalesDTO saveSalesDTO)
        {
            var sale = await _salesRepository.GetByIdRepository(saveSalesDTO.id);
            sale.id = saveSalesDTO.id;
            sale.dateSales = saveSalesDTO.dateSales;
            sale.quantity = saveSalesDTO.quantity;
            sale.totalCosto = saveSalesDTO.totalCosto;
            sale.custumerID = saveSalesDTO.custumerID;
            sale.inventoryID = saveSalesDTO.inventoryID;

            await _salesRepository.UpdateRepository(sale);
        }

        public async Task deleteServices(int id)
        {
            var sale = await _salesRepository.GetByIdRepository(id);
            await _salesRepository.DeleteRepository(sale);
        }
    }
}
