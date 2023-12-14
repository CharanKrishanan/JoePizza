using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Pizza_App_Phase_4_project.Controllers;
using Pizza_App_Phase_4_project.Models;

namespace Testing
{
    [TestFixture]
    public class Tests
    {
        private PizzaController _pizzaController;

        [SetUp]
        public void Setup()
        {
            _pizzaController = new PizzaController();
        }

        [Test]
        public void Index_ReturnsViewWithPizzas()
        {
            // Act
            var result = _pizzaController.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.Model.Should().BeAssignableTo<List<Pizza>>();
        }




        [Test]
        public void Checkout_ReturnsViewWithCorrectTotalAmount()
        {
            // Arrange
            PizzaController.orderdetails = new List<OrderInfo>
    {
        new OrderInfo { OrderId = 1, PizzaId = 105, Type = "Hawaiian", Price = 500, Quantity = 2, TotalPrice = 1000 }
    };

            // Act
            var result = _pizzaController.Checkout() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.Model.Should().BeAssignableTo<List<OrderInfo>>();
            var orderDetails = (List<OrderInfo>)result.Model;
            orderDetails.Should().NotBeNullOrEmpty();

            // Check if the total amount in the order details is correct
            orderDetails.Sum(o => o.TotalPrice).Should().Be(1000); // Adjust this based on the actual TotalPrice used in the test
        }

        [Test]
        public void Checkout_ReturnsViewWithOrderDetails()
        {
            // Act
            var result = _pizzaController.Checkout() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.Model.Should().BeAssignableTo<List<OrderInfo>>();
        }
        [Test]
        public void Checkout_ReturnsViewWithOrderDetailos()
        {
            // Act
            var result = _pizzaController.Checkout() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.Model.Should().BeAssignableTo<List<OrderInfo>>();
        }
    }
}