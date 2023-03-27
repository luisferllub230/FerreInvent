using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.Entities;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class SalesRepository : GeneryRepository<Sales>, ISalesRepository
    {
        private readonly AplicationContext _aplicationContext;

        public SalesRepository(AplicationContext context) : base(context)
        {
            _aplicationContext = context;
        }
    }
}
