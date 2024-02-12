using Xunit;
using ShoppingCartTDDAssignmentLib;

namespace ShoppingCartTest.Lib
{
    public class CheckoutFixture : IDisposable
    {
        public Checkout Checkout { get; private set; }

        public CheckoutFixture()
        {
            
            PriceRules priceRules = new PriceRules();
            
            priceRules.Add('A', 50, new SpecialOffer { quantity = 3, offerPrice = 130 });
            priceRules.Add('B', 30, new SpecialOffer { quantity = 2, offerPrice = 45 });
            priceRules.Add('C', 20);
            priceRules.Add('D', 15);
            Checkout = new Checkout(priceRules);
        }

        public void Dispose()
        {
            // Clean up resources if needed
        }
    }

    public class ShoppingCartTest : IClassFixture<CheckoutFixture>
    {
        private readonly Checkout _checkout;

        public ShoppingCartTest(CheckoutFixture fixture)
        {
            _checkout = fixture.Checkout;
        }

        [Fact]
        public void GivenEmptyCart_ReturnsZero()
        {
            // Arrange
            string input = "";
            int expectedOutput = 0;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenSingleItemA_ReturnsPrice50()
        {
            // Arrange
            string input = "A";
            int expectedOutput = 50;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenItemsABC_ReturnsTotalPrice115()
        {
            // Arrange
            string input = "ABC";
            int expectedOutput = 100;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenThreeItemsA_ReturnsTotalPrice130()
        {
            // Arrange
            string input = "AAA";
            int expectedOutput = 130;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenTwoItemsB_ReturnsTotalPrice45()
        {
            // Arrange
            string input = "BB";
            int expectedOutput = 45;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenItemsAAAABB_ReturnsTotalPrice225()
        {
            // Arrange
            string input = "AAAABB";
            int expectedOutput = 225;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenItemsDABABA_ReturnsTotalPrice190()
        {
            // Arrange
            string input = "DABABA";
            int expectedOutput = 190;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenItemsAAABB_ReturnsTotalPrice175()
        {
            // Arrange
            string input = "AAABB";
            int expectedOutput = 175;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenSixItemsA_ReturnsTotalPrice260()
        {
            // Arrange
            string input = "AAAAAA";
            int expectedOutput = 260;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenItemsABCD_ReturnsTotalPrice130()
        {
            // Arrange
            string input = "ABCD";
            int expectedOutput = 115;

            // Act
            int actualOutput = _checkout.GetTotal(input);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GivenInvalidItemE_ThrowsInvalidItemError()
        {
            // Arrange
            string input = "E";

            // Act & Assert
            Assert.Throws<InvalidItemException>(() => _checkout.GetTotal(input));
        }

        [Fact]
        public void GivenItemsABCDX_ThrowsInvalidItemError()
        {
            // Arrange
            string input = "ABCDX";

            // Act & Assert
            Assert.Throws<InvalidItemException>(() => _checkout.GetTotal(input));
        }
    }
}
