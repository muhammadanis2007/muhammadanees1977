using CrossExchange.Model;
using System.Linq;

namespace CrossExchange.Repository
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        IQueryable<Portfolio> GetAll();
    }
}