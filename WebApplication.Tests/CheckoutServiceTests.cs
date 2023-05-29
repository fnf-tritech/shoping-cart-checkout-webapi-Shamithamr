using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Controllers;

namespace WebApplication.Tests
{
    public class CheckoutServiceTests
    {
        [Fact]
        public void CalculateTotalPrice_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            string skus = "AAABBBCCDD";

            // Act
            decimal totalPrice = checkoutService.CalculateTotalPrice(skus);

            // Assert
            decimal expectedTotalPrice = 260;  // Total price for the given skus
            Assert.Equal(expectedTotalPrice, totalPrice);
        }
    }
}
