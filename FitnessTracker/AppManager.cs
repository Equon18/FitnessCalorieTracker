namespace FitnessCalorieTracker
{
    // AppManager class
    // Responsible: George Moore
    public class AppManager
    {
        private User user;
        private List<CalorieEntry> calorieEntries;
        private List<Workout> workouts;
        private List<Reminder> reminders;

        public AppManager()
        {
            this.user = new User();
            this.calorieEntries = new List<CalorieEntry>();
            this.workouts = new List<Workout>();
            this.reminders = new List<Reminder>();
        }

        public void Run()
        {
            int choice = 0;

            while (choice != 6)
            {
                this.showMainMenu();
                choice = this.readNumber();

                if (choice == 1)
                {
                    this.handleProfileMenu();
                }
                else if (choice == 2)
                {
                    this.handleCalorieMenu();
                }
                else if (choice == 3)
                {
                    this.handleWorkoutMenu();
                }
                else if (choice == 4)
                {
                    this.handleReminderMenu();
                }
                else if (choice == 5)
                {
                    DailySummary summary = new DailySummary();
                    summary.DisplaySummary(this.calorieEntries, this.workouts, this.user);
                }
                else if (choice == 6)
                {
                    CssStyleConsoleHelper.printSuccess("Exiting program.");
                }
                else
                {
                    CssStyleConsoleHelper.printError("Invalid choice. Try again.");
                }
            }
        }

        

        private void showMainMenu()
        { 
            CssStyleConsoleHelper.printHeader("Main Menu: Fitness & Calorie Tracker");
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fitness and Calorie Tracking System");
            Console.WriteLine();
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select an option below: ");
            Console.ResetColor();
            CssStyleConsoleHelper.printMenuOption(1, "Profile");
            CssStyleConsoleHelper.printMenuOption(2, "Calorie Tracking");
            CssStyleConsoleHelper.printMenuOption(3, "Workout Tracking");
            CssStyleConsoleHelper.printMenuOption(4, "Reminders");
            CssStyleConsoleHelper.printMenuOption(5, "Daily Summary");
            CssStyleConsoleHelper.printMenuOption(6, "Exit");

            CssStyleConsoleHelper.printFooter();
        }

        private void printNavigationOptions(int optionCount)
        {
            CssStyleConsoleHelper.printMenuOption(optionCount + 1, "Main Menu");
            CssStyleConsoleHelper.printMenuOption(optionCount + 2, "Exit");
        }

        private bool handleNavigationChoice(int choice, int optionCount)
        {
            if (choice == optionCount + 1)
            {
                return true;
            }
            else if (choice == optionCount + 2)
            {
                CssStyleConsoleHelper.printSuccess("Exiting program.");
                Environment.Exit(0);
            }

            return false;
        }

        private void handleProfileMenu()
        {
            CssStyleConsoleHelper.printHeader("Profile Menu");

            CssStyleConsoleHelper.printMenuOption(1, "Create Profile");
            CssStyleConsoleHelper.printMenuOption(2, "View Profile");
            this.printNavigationOptions(2);
            

            CssStyleConsoleHelper.printFooter();

            int choice = this.readNumber();
            if (this.handleNavigationChoice(choice, 2))
            {
                return;
            }

            if (choice == 1)
            {
                this.user.CreateProfile();
            }
            else if (choice == 2)
            {
                this.user.DisplayProfile();
            }
            else if (choice == 3)
            {
                return;
            }
            else if (choice == 4)
            {
                CssStyleConsoleHelper.printSuccess("Exiting program.");
                Environment.Exit(0);
            }
            else
            {
               CssStyleConsoleHelper.printError("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // UPDATED CALORIE MENU (Week 4)
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void handleCalorieMenu()
        {
            CssStyleConsoleHelper.printHeader("Calorie Menu");

            CssStyleConsoleHelper.printMenuOption(1, "Add Calorie Entry");
            CssStyleConsoleHelper.printMenuOption(2, "View Calorie History");
            CssStyleConsoleHelper.printMenuOption(3, "Edit Calorie Entry");
            CssStyleConsoleHelper.printMenuOption(4, "Delete Calorie Entry");
            this.printNavigationOptions(4);

            CssStyleConsoleHelper.printFooter();

            int choice = this.readNumber();
            
            if (this.handleNavigationChoice(choice, 4))
            {
                return;
            }
            if (choice == 1)
            {
                CalorieEntry entry = new CalorieEntry();
                entry.CreateEntry();
                this.calorieEntries.Add(entry);
            }
            else if (choice == 2)
            {
                this.displayCalorieHistory();
            }
            else if (choice == 3)
            {
                this.editCalorieEntry();
            }
            else if (choice == 4)
            {
                this.deleteCalorieEntry();
            }   
            else
            {
                CssStyleConsoleHelper.printError("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // UPDATED WORKOUT MENU (Week 4)
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void handleWorkoutMenu()
        {
            CssStyleConsoleHelper.printHeader("Workout Menu");

            CssStyleConsoleHelper.printMenuOption(1, "Add Workout");
            CssStyleConsoleHelper.printMenuOption(2, "View Workout History");
            CssStyleConsoleHelper.printMenuOption(3, "Edit Workout");
            CssStyleConsoleHelper.printMenuOption(4, "Delete Workout");
            this.printNavigationOptions(4);

            CssStyleConsoleHelper.printFooter();

            int choice = this.readNumber();
                if (this.handleNavigationChoice(choice, 4))
                {
                    return;
            }

            if (choice == 1)
            {
                Workout workout = new Workout();
                workout.CreateWorkout();
                this.workouts.Add(workout);
            }
            else if (choice == 2)
            {
                this.displayWorkoutHistory();
            }
            else if (choice == 3)
            {
                this.editWorkoutEntry();
            }
            else if (choice == 4)
            {
                this.deleteWorkoutEntry();
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid choice.");
            }
        }

        private void handleReminderMenu()
        {
            CssStyleConsoleHelper.printHeader("Reminder Menu");

            CssStyleConsoleHelper.printMenuOption(1, "Add Reminder");
            CssStyleConsoleHelper.printMenuOption(2, "View Reminders");
            CssStyleConsoleHelper.printMenuOption(3, "Mark Reminder Complete");
            this.printNavigationOptions(3);
            CssStyleConsoleHelper.printFooter();

            int choice = this.readNumber();

            if (this.handleNavigationChoice(choice, 3))
            {
                return;
            }

            if (choice == 1)
            {
                Reminder reminder = new Reminder();
                reminder.CreateReminder();
                this.reminders.Add(reminder);
            }
            else if (choice == 2)
            {
                this.displayReminders();
            }
            else if (choice == 3)
            {
                this.markReminderComplete();
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // DISPLAY METHODS
        // ---------------------------------------------------------
        private void displayCalorieHistory()
        {
            if (this.calorieEntries.Count == 0)
            {
                CssStyleConsoleHelper.printError("No calorie entries yet.");
                return;
            }

            CssStyleConsoleHelper.printSectionTitle("Calorie History");
            for (int index = 0; index < this.calorieEntries.Count; index++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((index + 1) + ". ");
                Console.ResetColor();
                this.calorieEntries[index].DisplayEntry();
            }
        }

        private void displayWorkoutHistory()
        {
            if (this.workouts.Count == 0)
            {
                CssStyleConsoleHelper.printError("No workouts yet.");
                return;
            }

            CssStyleConsoleHelper.printSectionTitle("Workout History");
            for (int index = 0; index < this.workouts.Count; index++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((index + 1) + ". ");
                Console.ResetColor();
                this.workouts[index].DisplayWorkout();
            }

        }

        private void displayReminders()
        {
            if (this.reminders.Count == 0)
            {
                CssStyleConsoleHelper.printError("No reminders yet.");
                return;
            }

            CssStyleConsoleHelper.printSectionTitle("Reminders");
            for (int index = 0; index < this.reminders.Count; index++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((index + 1) + ". ");
                Console.ResetColor();
                this.reminders[index].DisplayReminder();
            }
        }

        // ---------------------------------------------------------
        // NEW: EDIT + DELETE CALORIE ENTRY
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void editCalorieEntry()
        {
            if (this.calorieEntries.Count == 0)
            {
                CssStyleConsoleHelper.printError("No calorie entries to edit.");
                return;
            }

            this.displayCalorieHistory();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter entry number to edit: ");
                Console.ResetColor();
            int index = this.readNumber();

            if (index >= 1 && index <= this.calorieEntries.Count)
            {
                this.calorieEntries[index - 1].EditEntry();
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid entry number.");
            }
        }

        private void deleteCalorieEntry()
        {
            if (this.calorieEntries.Count == 0)
            {
                CssStyleConsoleHelper.printError("No calorie entries to delete.");
                return;
            }

            this.displayCalorieHistory();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter entry number to delete: ");
            Console.ResetColor();
            int index = this.readNumber();

            if (index >= 1 && index <= this.calorieEntries.Count)
            {
                this.calorieEntries.RemoveAt(index - 1);
                CssStyleConsoleHelper.printSuccess("Calorie entry deleted.");
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid entry number.");
            }
        }

        // ---------------------------------------------------------
        // NEW: EDIT + DELETE WORKOUT ENTRY
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void editWorkoutEntry()
        {
            if (this.workouts.Count == 0)
            {
                CssStyleConsoleHelper.printError("No workouts to edit.");
                return;
            }

            this.displayWorkoutHistory();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter workout number to edit: ");
            Console.ResetColor();
            int index = this.readNumber();

            if (index >= 1 && index <= this.workouts.Count)
            {
                this.workouts[index - 1].EditWorkout();
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid workout number.");
            }
        }

        private void deleteWorkoutEntry()
        {
            if (this.workouts.Count == 0)
            {
                CssStyleConsoleHelper.printError("No workouts to delete.");
                return;
            }

            this.displayWorkoutHistory();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter workout number to delete: ");
            Console.ResetColor();
            int index = this.readNumber();

            if (index >= 1 && index <= this.workouts.Count)
            {
                this.workouts.RemoveAt(index - 1);
                CssStyleConsoleHelper.printSuccess("Workout deleted.");
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid workout number.");
            }
        }

        private void markReminderComplete()
        {
            if (this.reminders.Count == 0)
            {
                CssStyleConsoleHelper.printError("No reminders to complete.");
                return;
            }

            this.displayReminders();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter reminder number: ");
            Console.ResetColor();
            int reminderNumber = this.readNumber();

            if (reminderNumber >= 1 && reminderNumber <= this.reminders.Count)
            {
                this.reminders[reminderNumber - 1].MarkComplete();
            }
            else
            {
                CssStyleConsoleHelper.printError("Invalid reminder number.");
            }
        }

        // ---------------------------------------------------------
        // INPUT VALIDATION
        // ---------------------------------------------------------
        private int readNumber()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Enter a valid number: ");
                Console.ResetColor();
            }

            return number;
        }

    }
}
