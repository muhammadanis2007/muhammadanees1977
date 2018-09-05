using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using CrossExchange.Controller;
using Moq;
using CrossExchange.Repository;
using CrossExchange.Model;
using System.Threading.Tasks;

namespace CrossExchange.Tests
{
    public class BuySellControllersTest
    {

        public readonly Mock<IShareRepository> _shareRepositoryMock = new Mock<IShareRepository>();
        private readonly Mock<IPortfolioRepository> _portRepositoryMock = new Mock<IPortfolioRepository>();
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new Mock<ITradeRepository>();

        private readonly BuyController _buyController;
        private readonly SellController _sellController;

        public  BuySellControllersTest()
        {
            _buyController = new BuyController(_shareRepositoryMock.Object, _tradeRepositoryMock.Object, _portRepositoryMock.Object);
            _sellController = new SellController(_shareRepositoryMock.Object, _tradeRepositoryMock.Object, _portRepositoryMock.Object);
        }


        [Test]
        public async Task GetAllSellBuying_BuyInfo()
        {
           
            var result = await _buyController.GetAllBuying(1, "cbi");
            var okresult = result as OkObjectResult;
           
            Assert.NotNull(okresult);
            Assert.AreEqual(200, okresult.StatusCode);

        }


        [Test]
        public async Task GetAllSellSelling_BuyInfo()
        {

            var result = await _sellController.GetAllSelling(1, "cbi");
            var okresult = result as OkObjectResult;

            Assert.NotNull(okresult);
            Assert.AreEqual(200, okresult.StatusCode);

        }



    }

   
}
