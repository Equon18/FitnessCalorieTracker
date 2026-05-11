Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.IntegrationTests
{
    public class ReminderIntegrationTests
    {
        [Fact]
        public void Create_Reminder_Should_Save_To_Database()
        {
            // Arrange
            var context = TestHelper.GetInMemoryDbContext();
            context.Users.Add(new User { Id = 1, Name = "TestUser" });
            context.SaveChanges();

            var controller = new ReminderController(context);

            var reminder = new Reminder
            {
                Title = "Drink Water",
                Description = "500ml after lunch",
                ReminderTime = DateTime.Now.AddHours(1)
            };

            // Act
            var result = controller.Create(reminder) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, context.Reminders.Count());
            Assert.Equal("Index", result!.ActionName);
        }
    }
}
