Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.IntegrationTests
{
    public class CalorieIntegrationTests
    {
        [Fact]
        public void Create_CalorieEntry_Should_Save_To_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();
            context.Users.Add(new User { Id = 1, Name = "TestUser" });
            context.SaveChanges();

            var controller = new CalorieController(context);

            var entry = new CalorieEntry
            {
                FoodName = "Chicken",
                Calories = 350,
                Date = DateTime.Today,
                UserId = 1                   
            };


            // Act
            var result = controller.Create(entry) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, context.CalorieEntries.Count());
            Assert.Equal("Index", result!.ActionName);
        }
    }
}
