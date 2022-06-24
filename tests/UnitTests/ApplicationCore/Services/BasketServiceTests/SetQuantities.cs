using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class SetQuantities
    {
        private readonly string sampleBuyerId = Guid.NewGuid().ToString();

        private readonly Mock<IRepository<Basket>> _mockBasketRepo = new Mock<IRepository<Basket>>();

        [Fact]
        public async Task ThrowsGivenNonpositiveQuantities()
        {
            var basket = new BasketService(_mockBasketRepo.Object);

            var quantities = new Dictionary<int, int>()
            {
                { 3, 4 },
                { 2, 0 },
                { 5, -8 }
            };

            await Assert.ThrowsAsync<NonpositiveQuantityException>(async () =>
            {
                await basket.SetQuantities(sampleBuyerId, quantities);
            });
        }
    }
}
