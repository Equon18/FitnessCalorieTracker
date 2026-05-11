Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.IntegrationTests
{
    public class WorkoutIntegrationTests
    {
        [Fact]
        public void Create_Workout_Should_Save_To_Database()
        {
            // Arrange
            var context = TestHelper.GetInMemoryDbContext();
            context.Users.Add(new User { Id = 1, Name = "TestUser" });
            context.SaveChanges();

            var controller = new WorkoutController(context);

            var workout = new Workout
            {
                WorkoutType = "Running",
                DurationMinutes = 30,
                CaloriesBurned = 200,
                Date = DateTime.Today
            };

            // Act
            var result = controller.Create(workout) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, context.Workouts.Count());
            Assert.Equal("Index", result!.ActionName);
        }
    }
}
