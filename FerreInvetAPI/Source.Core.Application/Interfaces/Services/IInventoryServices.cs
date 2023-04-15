using Source.Core.Application.DTO;
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
        public Task<(List<InventoryDTO>, ErrorMessageDTO)> getAllServices();
        public Task<(InventoryDTO, ErrorMessageDTO)> getByIdServices(int id);
        public Task postCreateServices(SaveInventoryDTO saveInventoryDTO);
        public Task putUpdateServices(SaveInventoryDTO saveInventoryDTO);
        public Task deleteServices(int id);
    }
}
