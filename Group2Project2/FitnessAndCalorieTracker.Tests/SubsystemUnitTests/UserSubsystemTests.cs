Contributor: Jisoo Yoon

using Xunit;
using FitnessAndCalorieTracker.Controllers;
using FitnessAndCalorieTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Tests.SubsystemUnitTests
{
    public class UserSubsystemTests
    {
        // -------------------------------------------------------
        // 1) Create User Test
        // -------------------------------------------------------
        [Fact]
        public void Create_User_Should_Save_To_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new UserController(context);

            var user = new User
            {
                Name = "TestUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            };

            var result = controller.Create(user) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal(1, context.Users.Count());
            Assert.Equal("Index", result!.ActionName);
        }

        // -------------------------------------------------------
        // 2) Create User Should Fail When ModelState Invalid
        // -------------------------------------------------------
        [Fact]
        public void Create_User_Should_Fail_When_ModelState_Invalid()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new UserController(context);

            var user = new User
            {
                Name = "",            // ❌ Required violation
                Age = 0,              // ❌ Range violation
                Height = 0,           // ❌ Range violation
                Weight = 0,           // ❌ Range violation
                DailyCalorieGoal = 0  // ❌ Range violation
            };

            controller.ModelState.AddModelError("Name", "Required");

            var result = controller.Create(user) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(0, context.Users.Count());
        }

        [Fact]
        public void Edit_User_Should_Update_Data()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new UserController(context);

            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "OldName",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            };
            context.Users.Add(user);
            context.SaveChanges();

            // Detach
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            // Act
            var updatedUser = new User
            {
                Id = 1,
                Name = "NewName",
                Age = 30,
                Height = 175,
                Weight = 70,
                DailyCalorieGoal = 2200
            };

            var result = controller.Edit(updatedUser) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);

            var saved = context.Users.Find(1);
            Assert.NotNull(saved);
            Assert.Equal("NewName", saved!.Name);
            Assert.Equal(30, saved.Age);
            Assert.Equal(175, saved.Height);
            Assert.Equal(70, saved.Weight);
            Assert.Equal(2200, saved.DailyCalorieGoal);
        }


        // -------------------------------------------------------
        // 4) Delete User Test
        // -------------------------------------------------------
        [Fact]
        public void Delete_User_Should_Remove_From_Database()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new UserController(context);

            context.Users.Add(new User
            {
                Id = 1,
                Name = "DeleteMe",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });
            context.SaveChanges();

            var result = controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
            Assert.Equal(0, context.Users.Count());
        }

        // -------------------------------------------------------
        // 5) Details Should Return Correct User
        // -------------------------------------------------------
        [Fact]
        public void Details_Should_Return_Correct_User()
        {
            var context = TestHelper.GetInMemoryDbContext();
            var controller = new UserController(context);

            context.Users.Add(new User
            {
                Id = 1,
                Name = "DetailUser",
                Age = 25,
                Height = 170,
                Weight = 65,
                DailyCalorieGoal = 2000
            });
            context.SaveChanges();

            var result = controller.Details(1) as ViewResult;

            Assert.NotNull(result);
            var model = result!.Model as User;

            Assert.NotNull(model);
            Assert.Equal("DetailUser", model!.Name);
        }
    }
}
