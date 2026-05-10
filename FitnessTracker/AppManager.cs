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
                    Console.WriteLine("Exiting program.");
                }
                else
                {
                    this.printError("Invalid choice. Try again.");
                }
            }
        }

        private void showMainMenu()
        { 
            this.printHeader("Main Menu: Fitness & Calorie Tracker");
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fitness and Calorie Tracking System");
            Console.WriteLine();
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select an option below: ");
            Console.ResetColor();
            this.printMenuOption(1, "Profile");
            this.printMenuOption(2, "Calorie Tracking");
            this.printMenuOption(3, "Workout Tracking");
            this.printMenuOption(4, "Reminders");
            this.printMenuOption(5, "Daily Summary");
            this.printMenuOption(6, "Exit");

            this.printFooter();
        }

        private void handleProfileMenu()
        {
            this.printHeader("Profile Menu");

            this.printMenuOption(1, "Create Profile");
            this.printMenuOption(2, "View Profile");

            this.printFooter();

            int choice = this.readNumber();

            if (choice == 1)
            {
                this.user.CreateProfile();
            }
            else if (choice == 2)
            {
                this.user.DisplayProfile();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // UPDATED CALORIE MENU (Week 4)
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void handleCalorieMenu()
        {
            this.printHeader("Calorie Menu");

            this.printMenuOption(1, "Add Calorie Entry");
            this.printMenuOption(2, "View Calorie History");
            this.printMenuOption(3, "Edit Calorie Entry");
            this.printMenuOption(4, "Delete Calorie Entry");

            this.printFooter();

            int choice = this.readNumber();

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
                Console.WriteLine("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // UPDATED WORKOUT MENU (Week 4)
        // RESPONSIBLE: Jisoo Yoon
        // ---------------------------------------------------------
        private void handleWorkoutMenu()
        {
            this.printHeader("Workout Menu");

            this.printMenuOption(1, "Add Workout");
            this.printMenuOption(2, "View Workout History");
            this.printMenuOption(3, "Edit Workout");
            this.printMenuOption(4, "Delete Workout");

            this.printFooter();

            int choice = this.readNumber();

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
                Console.WriteLine("Invalid choice.");
            }
        }

        private void handleReminderMenu()
        {
            this.printHeader("Reminder Menu");

            this.printMenuOption(1, "Add Reminder");
            this.printMenuOption(2, "View Reminders");
            this.printMenuOption(3, "Mark Reminder Complete");

            this.printFooter();

            int choice = this.readNumber();

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
                this.printError("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // DISPLAY METHODS
        // ---------------------------------------------------------
        private void displayCalorieHistory()
        {
            if (this.calorieEntries.Count == 0)
            {
                this.printError("No calorie entries yet.");
                return;
            }

            this.printSectionTitle("Calorie History");

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
                this.printError("No workouts yet.");
                return;
            }

            this.printSectionTitle("Workout History");

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
                this.printError("No reminders yet.");
                return;
            }

            this.printSectionTitle("Reminders");

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
                this.printError("No calorie entries to edit.");
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
                this.printError("Invalid entry number.");
            }
        }

        private void deleteCalorieEntry()
        {
            if (this.calorieEntries.Count == 0)
            {
                this.printError("No calorie entries to delete.");
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
                this.printSuccess("Calorie entry deleted.");
            }
            else
            {
                this.printError("Invalid entry number.");
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
                this.printError("No workouts to edit.");
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
                this.printError("Invalid workout number.");
            }
        }

        private void deleteWorkoutEntry()
        {
            if (this.workouts.Count == 0)
            {
                this.printError("No workouts to delete.");
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
                this.printSuccess("Workout deleted.");
            }
            else
            {
                this.printError("Invalid workout number.");
            }
        }

        private void markReminderComplete()
        {
            if (this.reminders.Count == 0)
            {
                this.printError("No reminders to complete.");
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
                this.printError("Invalid reminder number.");
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

        // ---------------------------------------------------------
        // STYLE HELPER METHODS
        // ---------------------------------------------------------
        private void printHeader(string title)
        {
           // Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("        " + title.ToUpper());
            Console.WriteLine("");
            Console.ResetColor();

            Console.WriteLine();
        }

        private void printFooter()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Choose an option: ");
            Console.ResetColor();
        }

        private void printMenuOption(int number, string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  [" + number + "] ");
            Console.ResetColor();

            Console.WriteLine(text);
        }

        private void printSectionTitle(string title)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----- " + title + " -----");
            Console.ResetColor();

            Console.WriteLine();
        }

        private void printSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void printError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void pauseScreen()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press Enter to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }

    }
}
