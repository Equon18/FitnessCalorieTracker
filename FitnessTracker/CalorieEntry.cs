namespace FitnessCalorieTracker
{
    // CalorieEntry class
    // Responsible: Quentin Robinson
    public class CalorieEntry
    {
        private string foodName;
        private int calories;

        public CalorieEntry()
        {
            this.foodName = "";
            this.calories = 0;
        }

        public void CreateEntry()
        {
            Console.Write("Enter food name: ");
            this.foodName = Console.ReadLine() ?? "";

            Console.Write("Enter calories: ");
            this.calories = this.readNumber();

            while (this.calories < 0)
            {
                Console.Write("Calories cannot be negative. Enter calories again: ");
                this.calories = this.readNumber();
            }

            Console.WriteLine("Calorie entry saved.");
        }

        // -----------------------------
        // NEW: Edit existing entry
        // RESPONSIBLE: Jisoo Yoon
        // -----------------------------
        public void EditEntry()
        {
            Console.Write("Enter new food name (leave blank to keep current): ");
            string newName = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(newName))
            {
                this.foodName = newName;
            }

            Console.Write("Enter new calories (-1 to keep current): ");
            int newCalories = this.readNumber();
            if (newCalories >= 0)
            {
                this.calories = newCalories;
            }

            Console.WriteLine("Calorie entry updated.");
        }

        // -----------------------------
        // Display entry
        // -----------------------------
        public void DisplayEntry()
        {
            Console.WriteLine(this.foodName + " - " + this.calories + " calories");
        }

        // -----------------------------
        // Getters for AppManager
        // -----------------------------
        public int GetCalories()
        {
            return this.calories;
        }

        // -----------------------------
        // Getters for Get Food Name
        // RESPONSIBLE: Jisoo Yoon
        // -----------------------------
        public string GetFoodName()
        {
            return this.foodName;
        }

        // -----------------------------
        // Helper: read number safely
        // -----------------------------
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
