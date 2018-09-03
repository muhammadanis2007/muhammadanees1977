using System.Linq;
using CrossExchange.Model;
using CrossExchange.Repository;
using Microsoft.EntityFrameworkCore;

namespace CrossExchange.Repository
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(ExchangeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Portfolio> GetAll()
        {
            return _dbContext.Portfolios.Include(x => x.Trade).AsQueryable();
        }
    }
}