Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessAndCalorieTracker.Tests.SubsystemUnitTests
{
    public class ReminderSubsystemTests
    {
        // -------------------------------------------------------
        // 1) Create Reminder (Success)
        // -------------------------------------------------------
        [Fact]
        public void Create_Reminder_Should_Save_To_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();

            // User must exist
            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });
            context.SaveChanges();

            var controller = new ReminderController(context);

            var reminder = new Reminder
            {
                Title = "Drink Water",
                Description = "500ml after lunch",
                ReminderTime = DateTime.Now.AddHours(1)
            };

            var result = controller.Create(reminder) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(1, context.Reminders.Count());
        }

        // -------------------------------------------------------
        // 2) Create Reminder (Fail — No User Exists)
        // -------------------------------------------------------
        [Fact]
        public void Create_Reminder_Should_Fail_When_No_User_Exists()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new ReminderController(context);

            var reminder = new Reminder
            {
                Title = "Drink Water",
                Description = "500ml after lunch",
                ReminderTime = DateTime.Now.AddHours(1)
            };

            var result = controller.Create(reminder) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(0, context.Reminders.Count());
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        // -------------------------------------------------------
        // 3) Complete Reminder
        // -------------------------------------------------------
        [Fact]
        public void Complete_Reminder_Should_Set_IsComplete_True()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });

            context.Reminders.Add(new Reminder
            {
                Id = 1,
                UserId = 1,
                Title = "Workout",
                Description = "30 min run",
                ReminderTime = DateTime.Now.AddHours(1),
                IsComplete = false
            });
            context.SaveChanges();

            var controller = new ReminderController(context);

            var result = controller.Complete(1) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);

            var saved = context.Reminders.Find(1);
            Assert.True(saved!.IsComplete);
        }

        // -------------------------------------------------------
        // 4) Delete Reminder
        // -------------------------------------------------------
        [Fact]
        public void Delete_Reminder_Should_Remove_From_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Users.Add(new User
            {
                Id = 1,
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });

            context.Reminders.Add(new Reminder
            {
                Id = 1,
                UserId = 1,
                Title = "Study",
                Description = "1 hour",
                ReminderTime = DateTime.Now.AddHours(2)
            });
            context.SaveChanges();

            var controller = new ReminderController(context);

            var result = controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(0, context.Reminders.Count());
        }

        // -------------------------------------------------------
        // 5) Index Sorting Test
        // -------------------------------------------------------
        [Fact]
        public void Index_Should_Return_Sorted_Reminders()
        {
            var context = TestHelper.GetInMemoryDbContext();

            context.Reminders.AddRange(
                new Reminder
                {
                    Id = 1,
                    UserId = 1,
                    Title = "B",
                    ReminderTime = DateTime.Now.AddHours(2),
                    IsComplete = false
                },
                new Reminder
                {
                    Id = 2,
                    UserId = 1,
                    Title = "A",
                    ReminderTime = DateTime.Now.AddHours(1),
                    IsComplete = false
                },
                new Reminder
                {
                    Id = 3,
                    UserId = 1,
                    Title = "C",
                    ReminderTime = DateTime.Now.AddHours(3),
                    IsComplete = true
                }
            );
            context.SaveChanges();

            var controller = new ReminderController(context);

            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);

            var list = result!.Model as System.Collections.Generic.List<Reminder>;
            Assert.NotNull(list);

            // Expected order:
            // 1) Not complete → earliest ReminderTime first
            // 2) Completed items last
            Assert.Equal(2, list![0].Id); // A
            Assert.Equal(1, list![1].Id); // B
            Assert.Equal(3, list![2].Id); // C (completed)
        }
    }
}
