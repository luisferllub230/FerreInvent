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
    public class CustumerServices : ICustumerServices
    {
        private readonly ICustumerRepository _custumerRepository;

        public CustumerServices(ICustumerRepository custumer) 
        {
            _custumerRepository = custumer;
        }

        public async Task<(List<CustumerDTO>, ErrorMessageDTO)> getAllServices()
        {
            var error = new ErrorMessageDTO();
            var custumers = await _custumerRepository.GetAllWhitIncluedeRepository(new List<string> {"sales"});

            if (custumers == null || custumers.Count() == 0) 
            {
                error.IsError = true;
                error.ErrorMessage = "There arent custumer";
                return (null, error);
            }

            var custumerDTO = custumers.Select(custumer => new CustumerDTO
            {
                id = custumer.id,
                custumerName = custumer.custumerName,
                custumerAddress = custumer.custumerAddress,
                custumerEmail = custumer.custumerEmail,
                salesDTO = custumer.sales.Select(sale => new SalesDTO 
                {
                    id = sale.id,
                    dateSales = sale.dateSales,
                    totalCosto = sale.totalCosto,
                    quantity = sale.quantity,
                }).ToList()
            }).ToList();

            return (custumerDTO, error);
        }

        public async Task<(CustumerDTO, ErrorMessageDTO)> getByIdServices(int id)
        {
            var error = new ErrorMessageDTO();
            var custumer = await _custumerRepository.GetByIdWhitIncludeRepository<Custumers>(id, new List<string> {"sales"});

            if (custumer == null)
            {
                error.IsError = true;
                error.ErrorMessage = "There arent custumer";
                return (null, error);
            }

            var custumerDTO = new CustumerDTO 
            {
                id = custumer.id,
                custumerName = custumer.custumerName,
                custumerAddress = custumer.custumerAddress,
                custumerEmail = custumer.custumerEmail,
                salesDTO = custumer.sales.Select(sale => new SalesDTO
                {
                    id = sale.id,
                    dateSales = sale.dateSales,
                    totalCosto = sale.totalCosto,
                    quantity = sale.quantity,
                }).ToList()
            };


            return (custumerDTO, error);
        }

        public async Task postCreateServices(SaveCustumerDTO saveInventoryDTO)
        {
            var custumer = new Custumers 
            {
                custumerName = saveInventoryDTO.custumerName,
                custumerAddress = saveInventoryDTO.custumerAddress,
                custumerEmail = saveInventoryDTO.custumerEmail,
            };

            await _custumerRepository.AddRepository(custumer);
        }

        public async Task putUpdateServices(SaveCustumerDTO saveInventoryDTO)
        {
            var custumer = await _custumerRepository.GetByIdRepository(saveInventoryDTO.id);
            custumer.custumerEmail = saveInventoryDTO.custumerEmail;
            custumer.custumerName = saveInventoryDTO.custumerName;
            custumer.custumerAddress = saveInventoryDTO.custumerAddress;
            
            await _custumerRepository.UpdateRepository(custumer);
        }

        public async Task deleteServices(int id)
        {
            var custumer = await _custumerRepository.GetByIdRepository(id);
            await _custumerRepository.DeleteRepository(custumer);
        }
    }
}
