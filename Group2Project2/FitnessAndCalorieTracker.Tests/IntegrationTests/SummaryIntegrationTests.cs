Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.IntegrationTests
{
    public class SummaryIntegrationTests
    {
        [Fact]
        public void Summary_Should_Calculate_Correct_Values()
        {
            // Arrange
            var context = TestHelper.GetInMemoryDbContext();

            var user = new User
            {
                Id = 1,
                Name = "TestUser",
                DailyCalorieGoal = 2000
            };
            context.Users.Add(user);

            context.CalorieEntries.Add(new CalorieEntry
            {
                UserId = 1,
                FoodName = "Chicken",
                Calories = 500,
                Date = DateTime.Today
            });

            context.Workouts.Add(new Workout
            {
                UserId = 1,
                WorkoutType = "Running",
                CaloriesBurned = 200,
                Date = DateTime.Today
            });

            context.SaveChanges();

            var controller = new SummaryController(context);

            // Act
            var result = controller.Index(DateTime.Today) as ViewResult;
            Assert.NotNull(result);

            var vm = result!.Model as DailySummaryViewModel;
            Assert.NotNull(vm);

            // Assert
            Assert.Equal(500, vm!.TotalCaloriesConsumed);
            Assert.Equal(200, vm.TotalCaloriesBurned);
            Assert.Equal(300, vm.NetCalories);
            Assert.Equal(2000, vm.DailyGoal);
            Assert.Equal("On Track", vm.GoalStatus);
        }
    }
}
