using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesPlatform_Application.Dtos;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.IServices;
using SalesPlatform_Application.Services;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Infrastructure.Repositories;
using SalesPlatform_Web.Controllers;

namespace SalesPlatform_Test
{
    public class ItemControllerTest
    {
        private readonly Item—ontroller _itemController;
        private readonly Mock<IItemService> _itemService;
        private readonly Mock<IRepository<Item>> _itemRepository;

        public ItemControllerTest()
        {
            _itemService = new Mock<IItemService>(); 
        }

        [Fact]
        public async Task GetAllItems_ReturnsOk()
        {
            // Arrange
            var paginationDto = new PaginationDto();
            var controller = new Item—ontroller(_itemService.Object);

            // Act
            var result = await controller.GetAllItems(paginationDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetItemById_ReturnsOk()
        {
            // Arrange
            int itemId = 7; 
            var controller = new Item—ontroller(_itemService.Object);

            // Act
            var result = await controller.GetItemById(itemId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task CreateItem_ReturnsOk()
        {
            // Arrange
            var itemDto = new ItemDto();
            var categoryId = 2; // «‡ÏÂÌËÚÂ Ì‡ ÌÂÓ·ıÓ‰ËÏÛ˛ Í‡ÚÂ„ÓË˛

            var controller = new Item—ontroller(_itemService.Object);

            // Act
            var result = await controller.CreateItem(itemDto, categoryId);

            // Assert
            result.Should().NotBeNull();
        }

    }
}