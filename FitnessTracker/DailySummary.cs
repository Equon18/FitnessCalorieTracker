using System.Diagnostics;

namespace FitnessCalorieTracker
{
    // DailySummary class
    // Responsible: Jupiter Lebrun
    public class DailySummary
    {
        public void DisplaySummary(List<CalorieEntry> calorieEntries, List<Workout> workouts, User user)
        {
            int totalCalories = 0;
            int totalBurned = 0;

            foreach (CalorieEntry entry in calorieEntries)
            {
                totalCalories += entry.GetCalories();
            }

            foreach (Workout workout in workouts)
            {
                totalBurned += workout.GetCaloriesBurned();
            }

            int netCalories = totalCalories - totalBurned;


            CssStyleConsoleHelper.printHeader("Daily Summary");
            CssStyleConsoleHelper.printInfoLine("Calories Consumed: ", totalCalories.ToString());
            CssStyleConsoleHelper.printInfoLine("Calories Burned: ", totalBurned.ToString());
            CssStyleConsoleHelper.printInfoLine("Net Calories: ", netCalories.ToString());

            if (user.HasProfile())
            {
                CssStyleConsoleHelper.printInfoLine("Daily Goal: ", user.GetCalorieGoal().ToString());
                if (netCalories <= user.GetCalorieGoal())
                {
                    CssStyleConsoleHelper.printSuccess("Goal Status: On track");
                }
                else
                {
                    CssStyleConsoleHelper.printError("Goal Status: Over goal");
                }
            }
            else
            {
                CssStyleConsoleHelper.printError("Please create a user profile to view your daily summary.");
            }
            this.returnToMainMenu();
        }

        private void returnToMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select an option below: ");
            Console.ResetColor();
            CssStyleConsoleHelper.printMenuOption(1, "Main Menu");
            CssStyleConsoleHelper.printFooter();

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice != 1)
            {
                CssStyleConsoleHelper.printError("Invalid choice. Enter 1 to return to the Main Menu.");

            }
        }
    }
}