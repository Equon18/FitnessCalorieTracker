using Xunit;
using FitnessCalorieTracker;
using System;
using System.IO;
using System.Collections.Generic;

// FunctionalTest.cs
// Responsible: All Team Members

namespace FitnessCalorieTrackerTests
{
    public class FunctionalTest
    {
        // ---------------------------------------------------------
        // FUNCTIONAL TEST 1
        // Full user flow: Create Profile → Add Food → Add Workout → Summary
        // ---------------------------------------------------------
        [Fact]
        public void Test_FullUserFlow()
        {
            // 1) Create Profile
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            User user = new User();
            user.CreateProfile();

            Assert.True(user.HasProfile());

            // 2) Add Calorie Entry
            TestHelper.SetConsoleInput("Banana\n105\n");
            CalorieEntry entry = new CalorieEntry();
            entry.CreateEntry();

            Assert.Equal("Banana", entry.GetFoodName());
            Assert.Equal(105, entry.GetCalories());

            // 3) Add Workout
            TestHelper.SetConsoleInput("2\n30\n250\n"); // Running
            Workout workout = new Workout();
            workout.CreateWorkout();

            Assert.Equal("Running", workout.GetWorkoutName());
            Assert.Equal(30, workout.GetMinutes());
            Assert.Equal(250, workout.GetCaloriesBurned());

            // 4) Daily Summary
            var calories = new List<CalorieEntry>() { entry };
            var workouts = new List<Workout>() { workout };

            var output = TestHelper.CaptureConsoleOutput();

            DailySummary summary = new DailySummary();
            summary.DisplaySummary(calories, workouts, user);

            string result = output.ToString();

            // Functional-level assertions
            Assert.Contains("Calories Consumed", result);
            Assert.Contains("105", result);
            Assert.Contains("250", result);
            Assert.Contains("Net Calories", result);
            Assert.Contains("Goal Status", result);
        }

        // ---------------------------------------------------------
        // FUNCTIONAL TEST 2
        // User tries to add workout BEFORE creating a profile
        // ---------------------------------------------------------
        [Fact]
        public void Test_WorkoutBlockedWithoutProfile()
        {
            AppManager app = new AppManager();

            // Simulate choosing "Add Workout"
            TestHelper.SetConsoleInput("1\n");

            var output = TestHelper.CaptureConsoleOutput();

            // Call workout menu
            var method = typeof(AppManager)
                .GetMethod("handleWorkoutMenu",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            Assert.NotNull(method);

            method!.Invoke(app, null);

            string result = output.ToString();

            Assert.Contains("Please create a user profile", result);
        }

        // ---------------------------------------------------------
        // FUNCTIONAL TEST 3
        // User adds multiple foods and workouts, then checks summary
        // ---------------------------------------------------------
        [Fact]
        public void Test_MultipleEntriesSummary()
        {
            // Create profile
            TestHelper.SetConsoleInput("Jisoo\n22\n55\n1800\n");
            User user = new User();
            user.CreateProfile();

            // Add food 1
            TestHelper.SetConsoleInput("Apple\n80\n");
            CalorieEntry e1 = new CalorieEntry();
            e1.CreateEntry();

            // Add food 2
            TestHelper.SetConsoleInput("Rice\n200\n");
            CalorieEntry e2 = new CalorieEntry();
            e2.CreateEntry();

            // Add workout 1
            TestHelper.SetConsoleInput("1\n20\n100\n"); // Walking
            Workout w1 = new Workout();
            w1.CreateWorkout();

            // Add workout 2
            TestHelper.SetConsoleInput("4\n45\n300\n"); // Cycling
            Workout w2 = new Workout();
            w2.CreateWorkout();

            var calories = new List<CalorieEntry>() { e1, e2 };
            var workouts = new List<Workout>() { w1, w2 };

            var output = TestHelper.CaptureConsoleOutput();

            DailySummary summary = new DailySummary();
            summary.DisplaySummary(calories, workouts, user);

            string result = output.ToString();

            // Functional-level checks
            Assert.Contains("Calories Consumed", result);
            Assert.Contains("280", result); // 80 + 200
            Assert.Contains("400", result); // 100 + 300
            Assert.Contains("Net Calories", result);
        }
    }
}
