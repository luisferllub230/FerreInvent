using Source.Core.Application.DTO.ErrorMessage;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Application.DTO.Sales;
using Source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.Interfaces.Services
{
    public interface ISalesServices
    {
        public Task<(List<SalesDTO>, ErrorMessageDTO)> getAllServices();
        public Task<(SalesDTO, ErrorMessageDTO)> getByIdServices(int id);
        public Task postCreateServices(SaveSalesDTO saveSalesDTO);
        public Task putUpdateServices(SaveSalesDTO saveSalesDTO);
        public Task deleteServices(int id);
    }
}
