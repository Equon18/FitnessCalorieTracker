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
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        private void showMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Fitness and Calorie Tracker");
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. Calorie Tracking");
            Console.WriteLine("3. Workout Tracking");
            Console.WriteLine("4. Reminders");
            Console.WriteLine("5. Daily Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
        }

        private void handleProfileMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Profile Menu");
            Console.WriteLine("1. Create Profile");
            Console.WriteLine("2. View Profile");
            Console.Write("Choose an option: ");

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
            Console.WriteLine();
            Console.WriteLine("Calorie Menu");
            Console.WriteLine("1. Add Calorie Entry");
            Console.WriteLine("2. View Calorie History");
            Console.WriteLine("3. Edit Calorie Entry");
            Console.WriteLine("4. Delete Calorie Entry");
            Console.Write("Choose an option: ");

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
            Console.WriteLine();
            Console.WriteLine("Workout Menu");
            Console.WriteLine("1. Add Workout");
            Console.WriteLine("2. View Workout History");
            Console.WriteLine("3. Edit Workout");
            Console.WriteLine("4. Delete Workout");
            Console.Write("Choose an option: ");

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
            Console.WriteLine();
            Console.WriteLine("Reminder Menu");
            Console.WriteLine("1. Add Reminder");
            Console.WriteLine("2. View Reminders");
            Console.WriteLine("3. Mark Reminder Complete");
            Console.Write("Choose an option: ");

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
                Console.WriteLine("Invalid choice.");
            }
        }

        // ---------------------------------------------------------
        // DISPLAY METHODS
        // ---------------------------------------------------------
        private void displayCalorieHistory()
        {
            if (this.calorieEntries.Count == 0)
            {
                Console.WriteLine("No calorie entries yet.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Calorie History");

            for (int index = 0; index < this.calorieEntries.Count; index++)
            {
                Console.Write((index + 1) + ". ");
                this.calorieEntries[index].DisplayEntry();
            }
        }

        private void displayWorkoutHistory()
        {
            if (this.workouts.Count == 0)
            {
                Console.WriteLine("No workouts yet.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Workout History");

            for (int index = 0; index < this.workouts.Count; index++)
            {
                Console.Write((index + 1) + ". ");
                this.workouts[index].DisplayWorkout();
            }
        }

        private void displayReminders()
        {
            if (this.reminders.Count == 0)
            {
                Console.WriteLine("No reminders yet.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Reminders");

            for (int index = 0; index < this.reminders.Count; index++)
            {
                Console.Write((index + 1) + ". ");
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
                Console.WriteLine("No calorie entries to edit.");
                return;
            }

            this.displayCalorieHistory();
            Console.Write("Enter entry number to edit: ");
            int index = this.readNumber();

            if (index >= 1 && index <= this.calorieEntries.Count)
            {
                this.calorieEntries[index - 1].EditEntry();
            }
            else
            {
                Console.WriteLine("Invalid entry number.");
            }
        }

        private void deleteCalorieEntry()
        {
            if (this.calorieEntries.Count == 0)
            {
                Console.WriteLine("No calorie entries to delete.");
                return;
            }

            this.displayCalorieHistory();
            Console.Write("Enter entry number to delete: ");
            int index = this.readNumber();

            if (index >= 1 && index <= this.calorieEntries.Count)
            {
                this.calorieEntries.RemoveAt(index - 1);
                Console.WriteLine("Calorie entry deleted.");
            }
            else
            {
                Console.WriteLine("Invalid entry number.");
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
                Console.WriteLine("No workouts to edit.");
                return;
            }

            this.displayWorkoutHistory();
            Console.Write("Enter workout number to edit: ");
            int index = this.readNumber();

            if (index >= 1 && index <= this.workouts.Count)
            {
                this.workouts[index - 1].EditWorkout();
            }
            else
            {
                Console.WriteLine("Invalid workout number.");
            }
        }

        private void deleteWorkoutEntry()
        {
            if (this.workouts.Count == 0)
            {
                Console.WriteLine("No workouts to delete.");
                return;
            }

            this.displayWorkoutHistory();
            Console.Write("Enter workout number to delete: ");
            int index = this.readNumber();

            if (index >= 1 && index <= this.workouts.Count)
            {
                this.workouts.RemoveAt(index - 1);
                Console.WriteLine("Workout deleted.");
            }
            else
            {
                Console.WriteLine("Invalid workout number.");
            }
        }

        private void markReminderComplete()
        {
            if (this.reminders.Count == 0)
            {
                Console.WriteLine("No reminders to complete.");
                return;
            }

            this.displayReminders();

            Console.Write("Enter reminder number: ");
            int reminderNumber = this.readNumber();

            if (reminderNumber >= 1 && reminderNumber <= this.reminders.Count)
            {
                this.reminders[reminderNumber - 1].MarkComplete();
            }
            else
            {
                Console.WriteLine("Invalid reminder number.");
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
                Console.Write("Enter a valid number: ");
            }

            return number;
        }
    }
}
