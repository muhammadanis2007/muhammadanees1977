﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrossExchange.Model;
using CrossExchange.Repository;
using Microsoft.EntityFrameworkCore.Internal;

namespace CrossExchange.Controller
{
    [Produces("application/json")]
    [Route("api/Buy")]
    public class BuyController : ControllerBase
    {

        private IShareRepository _shareRepository { get; set; } 
        private ITradeRepository _tradeRepository { get; set; }
        private IPortfolioRepository _portfolioRepository { get; set; }

        public BuyController(IShareRepository shareRepository, ITradeRepository tradeRepository, IPortfolioRepository portfolioRepository)
        {
            _shareRepository = shareRepository;
            _tradeRepository = tradeRepository;
            _portfolioRepository = portfolioRepository;
        }


        [HttpGet("{portfolioid}/{symbol}")]
        public async Task<IActionResult> GetAllBuying([FromRoute]int portFolioid,[FromRoute]string symbol)
        {




            var buy = (from p in _portfolioRepository.GetAll()
                       join pt in _tradeRepository.Query() on p.Id equals pt.PortfolioId
                       join ts in _shareRepository.Query() on pt.Symbol equals ts.Symbol
                       where p.Id == portFolioid && pt.PortfolioId == portFolioid && pt.Action.Equals("BUY") && ts.Symbol.Equals(symbol)
                       orderby ts.Id descending
                       select new
                       {

                           p.Name,
                           pt.Action,
                           pt.Symbol,  
                           pt.NoOfShares,
                           ts.Rate,
                           pt.Price,
                           ts.TimeStamp,


                       }).ToList().FirstOrDefault();

                return Ok(buy);
            
           
        }

    }
}