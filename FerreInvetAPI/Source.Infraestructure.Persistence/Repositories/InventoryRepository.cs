using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.Entities;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class InventoryRepository : GeneryRepository<Inventory>, IInventoryRepository
    {
        private readonly AplicationContext _aplicationContext;

        public InventoryRepository(AplicationContext context) : base(context)
        {
            _aplicationContext = context;
        }
    }
}
