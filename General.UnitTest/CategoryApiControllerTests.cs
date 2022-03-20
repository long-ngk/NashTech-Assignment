using CustomerSite.Controllers;
using General.DataAccess.Business.Interfaces;
using General.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace General.UnitTest
{
    public class CategoryApiControllerTests
    {
        private readonly Mock<IProductCategoryService> _mockCategoryService;
        public CategoryApiControllerTests()
        {
            _mockCategoryService = new Mock<IProductCategoryService>();
        }

        [Fact]
        public async void GetCategory_ListOfCategory_CategoryExistsInService()
        {
            //arrange
            var categories = GetSampleCategory();
            _mockCategoryService.Setup(x => x.GetAllAsync())
                .ReturnsAsync(categories);
            var controller = new CategoryApiController(_mockCategoryService.Object);

            //act
            var actionResult = controller.GetCategory();
            var result = await actionResult as OkObjectResult;
            var actual = result.Value as List<ProductCategoryDto>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(actual);
            Assert.Equal(categories.Count(), actual.Count());
            for (int i = 0; i < categories.Count(); i++)
            {
                Assert.Equal(categories[i], actual[i]);
            }
        }

        [Fact]
        public async void GetCategoryById_CategoryObject_CategorywithSpecificeIdExists()
        {
            //arrange
            var categories = GetSampleCategory();
            var firstCategory = categories[0];
            _mockCategoryService.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(firstCategory);
            var controller = new CategoryApiController(_mockCategoryService.Object);

            //act
            var result = await controller.GetCategoryById(1) as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(firstCategory, result.Value);
        }

        [Fact]
        public async void GetCategoryById_shouldReturnBadRequest_CategoryWithIDNotExists()
        {
            //arrange
            var categories = GetSampleCategory();
            var firstCategory = categories[0];
            _mockCategoryService.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(firstCategory);
            var controller = new CategoryApiController(_mockCategoryService.Object);

            //act
            var result = await controller.GetCategoryById(10);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void CreateCategory_CreatedStatus_PassingCategoryObjectToCreate()
        {
            //arrange
            ProductCategoryDto newCategory = new ProductCategoryDto()
            {
                CategoryName = "Keyboard",
                Description = "Keyboard",
                CreatedDate = new DateTime(2022, 02, 24),
                UpdatedDate = new DateTime(2022, 02, 24),
                IsActive = true,
            };
            var controller = new CategoryApiController(_mockCategoryService.Object);

            //act
            var result = await controller.CreateAsync(newCategory);

            //assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async void UpdateCategory_NoContentStatus_PassingCategoryObjectToUpdate()
        {
            //arrange
            var categories = GetSampleCategory();
            var firstCategory = categories[0];
            firstCategory.CategoryName = "Iphone Smartphone";
            var controller = new CategoryApiController(_mockCategoryService.Object);

            //act
            var result = await controller.UpdateAsync(firstCategory);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void DeleteCategory_NoContentStatus_CategoryWithIdExists()
        {
            // Arrange
            var id = 1;
            _mockCategoryService.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(new ProductCategoryDto() { });
            _mockCategoryService.Setup(repo => repo.RemoveAsync(It.IsAny<int>()));
            var controller = new CategoryApiController(_mockCategoryService.Object);

            // Act
            var result = await controller.DeleteAsync(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockCategoryService.Verify(repo => repo.RemoveAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async void DeleteCategory_NotFoundStatus_CategoryWithIdNotExists()
        {
            // Arrange
            var id = 10;
            var controller = new CategoryApiController(_mockCategoryService.Object);

            // Act
            var result = await controller.DeleteAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<ProductCategoryDto> GetSampleCategory()
        {
            List<ProductCategoryDto> productCategoryDtos = new List<ProductCategoryDto>()
            {
                new ProductCategoryDto
                {
                    CategoryID = 1,
                    CategoryName = "Smartphone",
                    Description ="Smartphone",
                    CreatedDate = new DateTime(2022,02,24),
                    UpdatedDate = new DateTime(2022,02,24),
                    IsActive = true,
                },
                new ProductCategoryDto
                {
                    CategoryID = 2,
                    CategoryName = "Tablet",
                    Description ="Tablet",
                    CreatedDate = new DateTime(2022,02,24),
                    UpdatedDate = new DateTime(2022,02,24),
                    IsActive = true,
                },
                new ProductCategoryDto
                {
                    CategoryID = 3,
                    CategoryName = "Headphone",
                    Description ="Headphone",
                    CreatedDate = new DateTime(2022,02,24),
                    UpdatedDate = new DateTime(2022,02,24),
                    IsActive = true,
                },
                new ProductCategoryDto
                {
                    CategoryID = 4,
                    CategoryName = "Video game",
                    Description ="Video game",
                    CreatedDate = new DateTime(2022,02,24),
                    UpdatedDate = new DateTime(2022,02,24),
                    IsActive = true,
                },
                new ProductCategoryDto
                {
                    CategoryID = 5,
                    CategoryName = "PC",
                    Description ="PC",
                    CreatedDate = new DateTime(2022,02,24),
                    UpdatedDate = new DateTime(2022,02,24),
                    IsActive = true,
                }
            };
            return productCategoryDtos;
        }
    }
}