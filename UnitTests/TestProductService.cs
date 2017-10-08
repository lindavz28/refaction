using Data;
using Data.ProductData;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class TestProductService
    {
        Mock<IProductRepository> _repo;

        public TestProductService()
        {
            _repo = SetupRepo();
        }


        public Mock<IProductRepository> SetupRepo()
        {
            return new Mock<IProductRepository>();
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct()
        {
            // Arrange
            var id = Guid.NewGuid();
            var product = new Product()
            {
                Id = id.ToString(),
                Name = "Test Name",
                Description = "Test Description",
                Price = 12.20m,
                DeliveryPrice = 2.33m
            };

            _repo.Setup((repo) => repo.GetProduct(It.IsAny<Guid>()))
                .Returns(product);

            ProductService sut = new ProductService(_repo.Object);
            
            // Act
            var productDto = sut.GetProduct(id);

            // Assert
            Assert.Equal(product.Id, productDto.Id.ToString());
            Assert.Equal(product.Name, productDto.Name);
            Assert.Equal(product.Description, productDto.Description);
            Assert.Equal(product.Price, productDto.Price);
            Assert.Equal(product.DeliveryPrice, productDto.DeliveryPrice);
        }

        [Fact]
        public void GetProductById_NullValueShouldReturnNull()
        {
            // Arrange
            Product product = null;

            _repo.Setup((repo) => repo.GetProduct(It.IsAny<Guid>()))
                .Returns(product);

            ProductService sut = new ProductService(_repo.Object);
            // Act
            var productDto = sut.GetProduct(Guid.NewGuid());

            // Assert
            Assert.Null(productDto);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnProductsDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var product1 = new Product()
            {
                Id = id.ToString(),
                Name = "Test Name",
                Description = "Test Description",
                Price = 12.20m,
                DeliveryPrice = 2.33m
            };

            var product2 = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Name 2",
                Description = "Test Description 2",
                Price = 22.20m,
                DeliveryPrice = 5.33m
            };

            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);

            _repo.Setup((repo) => repo.GetAllProducts())
               .Returns(products);

            ProductService sut = new ProductService(_repo.Object);
            
            // Act
            var productDto = sut.GetAllProducts();

            // Assert
            Assert.NotNull(productDto);
            Assert.NotNull(productDto.Items);
        }

        [Fact]
        public void GetAllProducts_EmptyList()
        {
            // Arrange

            List<Product> products = new List<Product>();

            _repo.Setup((repo) => repo.GetAllProducts())
               .Returns(products);

            ProductService sut = new ProductService(_repo.Object);
            
            // Act
            var productDto = sut.GetAllProducts();

            // Assert
            Assert.NotNull(productDto);
            Assert.NotNull(productDto.Items);
        }
    }
      
}
