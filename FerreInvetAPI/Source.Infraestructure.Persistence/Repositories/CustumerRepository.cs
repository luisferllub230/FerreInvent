using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.Entities;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class CustumerRepository : GeneryRepository<Custumers>, ICustumerRepository
    {
        private readonly AplicationContext _aplicationContext;

        public CustumerRepository(AplicationContext context) : base(context)
        {
            _aplicationContext = context;
        }
    }
}
