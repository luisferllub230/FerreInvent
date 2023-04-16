using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.ErrorMessage;

namespace Source.Core.Application.Interfaces.Services
{
    public interface ICustumerServices
    {
        public Task<(List<CustumerDTO>, ErrorMessageDTO)> getAllServices();
        public Task<(CustumerDTO, ErrorMessageDTO)> getByIdServices(int id);
        public Task postCreateServices(SaveCustumerDTO saveInventoryDTO);
        public Task putUpdateServices(SaveCustumerDTO saveInventoryDTO);
        public Task deleteServices(int id);
    }
}
