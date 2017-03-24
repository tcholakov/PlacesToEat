namespace PlacesToEat.Web.Controller.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Moq;
    using NUnit.Framework;

    using Controllers;
    using Data.Models.Users;
    using Services.Data.Contracts;
    using Services.Data.Contracts.UserServices;
    using ViewModels.Restaurant;
    using Infrastructure.Mapping;
    using Data.Models;
    using ViewModels.Comment;
    using ViewModels.RegularUser;

    [TestFixture]
    public class RestaurantControllerTests
    {
        [Test]
        public void DetailsReturnsValidRestaurantDetailedViewModelId()
        {
            //Arrange
            var restaurantId = Guid.NewGuid().ToString();
            var resultDbRestaurant = new RestaurantUser
            {
                Id = restaurantId
            };

            var mockedRestaurantUserService = new Mock<IRestaurantUserService>();
            mockedRestaurantUserService.Setup(x => x.GetById(restaurantId)).Returns(resultDbRestaurant);

            var mockedCommentService = new Mock<ICommentService>();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RestaurantController).Assembly);

            var restaurantController = new RestaurantController(mockedRestaurantUserService.Object, mockedCommentService.Object);

            //Act
            var actionResult = restaurantController.Details(restaurantId) as ViewResult;
            var restaurantViewModel = (RestaurantDetailedViewModel)actionResult.ViewData.Model;

            var expectedRestaurantViewModel = new RestaurantDetailedViewModel
            {
                Id = resultDbRestaurant.Id
            };

            //Assert
            Assert.AreEqual(expectedRestaurantViewModel.Id, restaurantViewModel.Id, "Expected RestaurantDetailedViewModel Id doesn`t match actual Id.");
        }

        [Test]
        public void DetailsReturnsValidRestaurantDetailedViewModelFavourites()
        {
            //Arrange
            var restaurantId = Guid.NewGuid().ToString();

            var regularUsers = new List<RegularUser>
            {
                new RegularUser(),
                new RegularUser()
            };

            var resultDbRestaurant = new RestaurantUser
            {
                RegularUsers = regularUsers
            };

            var mockedRestaurantUserService = new Mock<IRestaurantUserService>();
            mockedRestaurantUserService.Setup(x => x.GetById(restaurantId)).Returns(resultDbRestaurant);

            var mockedCommentService = new Mock<ICommentService>();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RestaurantController).Assembly);

            var restaurantController = new RestaurantController(mockedRestaurantUserService.Object, mockedCommentService.Object);

            //Act
            var actionResult = restaurantController.Details(restaurantId) as ViewResult;
            var restaurantViewModel = (RestaurantDetailedViewModel)actionResult.ViewData.Model;

            var expectedRestaurantViewModel = new RestaurantDetailedViewModel
            {
                Favourites = resultDbRestaurant.RegularUsers.AsQueryable().To<RegularUserViewModel>().ToList(),
            };

            //Assert
            Assert.AreEqual(restaurantViewModel.Favourites.Count, expectedRestaurantViewModel.Favourites.Count, "Expected RestaurantDetailedViewModel Favourites count doesn`t match actual count.");
        }

        [Test]
        public void DetailsReturnsValidRestaurantDetailedViewModelComments()
        {
            //Arrange
            var restaurantId = Guid.NewGuid().ToString();

            var comments = new List<Comment>
            {
                new Comment
                {
                    Author = new RegularUser()
                    {
                        FirstName = "Test",
                        LastName = "User1"
                    }
                }
            };

            var resultDbRestaurant = new RestaurantUser
            {
                Comments = comments
            };

            var mockedRestaurantUserService = new Mock<IRestaurantUserService>();
            mockedRestaurantUserService.Setup(x => x.GetById(restaurantId)).Returns(resultDbRestaurant);

            var mockedCommentService = new Mock<ICommentService>();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(RestaurantController).Assembly);

            var restaurantController = new RestaurantController(mockedRestaurantUserService.Object, mockedCommentService.Object);

            //Act
            var actionResult = restaurantController.Details(restaurantId) as ViewResult;
            var restaurantViewModel = (RestaurantDetailedViewModel)actionResult.ViewData.Model;

            var expectedRestaurantViewModel = new RestaurantDetailedViewModel
            {
                Comments = resultDbRestaurant.Comments.AsQueryable().To<CommentViewModel>().ToList()
            };

            //Assert
            Assert.AreEqual(restaurantViewModel.Comments.Count, expectedRestaurantViewModel.Comments.Count, "Expected RestaurantDetailedViewModel Comments count doesn`t match actual count.");
            Assert.AreEqual(restaurantViewModel.Comments.FirstOrDefault().Author, expectedRestaurantViewModel.Comments.FirstOrDefault().Author, "Expected RestaurantDetailedViewModel comment Author doesn`t match the actual Author.");
        }
    }
}
