using Source.Core.Application.Interfaces.Repository;
using Source.Core.Domain.Entities;
using Source.Infraestructure.Persistence.Context;

namespace Source.Infraestructure.Persistence.Repositories
{
    public class CategoriesRepository : GeneryRepository<Categories>, ICategoryRepository
    {
        private readonly AplicationContext _aplicationContext;

        public CategoriesRepository(AplicationContext context) : base(context)
        {
            _aplicationContext = context;
        }
    }
}
