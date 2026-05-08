# Fitness Calorie Tracker with Reminders

## Project Overview

This project is a C# console application made for our Application Development project.

The program lets a user create a simple fitness profile, log calories, log workouts, create reminders, mark reminders complete, and view a daily summary.

We originally had more features planned, but after feedback we decided to keep the project smaller and more realistic. The final version focuses on the main features that match our user stories and still shows object oriented programming.

## Team Members

Quentin Robinson

Jupiter Lebrun

George Moore

Jisoo Yoon

## Project Language

C#

## IDE Used

Visual Studio 2022

## Main Features

Create a user profile

View a user profile

Add calorie entries

View calorie history

Add workout entries

View workout history

Add reminders

View reminders

Mark reminders complete

View daily summary

Exit the program

## Class Responsibilities

### Program class

This is the startup file for the project. It creates the AppManager object and starts the program.

### AppManager class

Responsible person: George Moore

This class controls the main menu and connects the other classes together. It allows the user to move between profile, calorie tracking, workout tracking, reminders, daily summary, and exit.

### User class

Responsible person: Quentin Robinson

This class stores the user profile information. It includes the user name, age, weight, calorie goal, and whether a profile has been created.

### CalorieEntry class

Responsible person: Quentin Robinson

This class stores one calorie entry. It includes the food name and the number of calories.

### Workout class

Responsible person: Jupiter Lebrun

This class stores one workout entry. It includes the workout name, workout length in minutes, and calories burned.

### Reminder class

Responsible person: George Moore

This class stores one reminder. It includes the reminder text and whether the reminder is pending or complete.

### DailySummary class

Responsible person: Jupiter Lebrun

This class uses the calorie entries, workout entries, and user calorie goal to show the daily summary.

### Testing and quality support

Responsible person: Jisoo Yoon

This part includes the testing document, functional testing, integration testing, actual results, and demo support.

## OOP Concepts Used

### Classes and objects

The program is split into different classes instead of putting everything in one file. For example, User, CalorieEntry, Workout, Reminder, DailySummary, and AppManager are all separate classes.

### Encapsulation

Each class keeps its own data and methods together. For example, the User class stores profile information and also has the methods for creating and displaying the profile.

### Abstraction

The user does not need to know how the program calculates the daily summary. The user only chooses Daily Summary from the menu, and the DailySummary class handles the calculation.

### Class relationships

The AppManager class uses the other classes to run the program. The DailySummary class also depends on calorie entries, workout entries, and user profile information to calculate the summary.

### Separation of responsibilities

Each class has its own job. This makes the program easier to understand, test, and improve later.

## How to Run the Program

Open the project in Visual Studio 2022.

Open the solution file.

Build the solution.

Run the program using the Start button.

Use the menu numbers to choose different options.

## Basic Menu Flow

1. Profile

2. Calorie Tracking

3. Workout Tracking

4. Reminders

5. Daily Summary

6. Exit

## Testing

The testing document is located in the Testing folder.

The testing document includes functional testing and integration testing. The actual results should be filled in after manually running the program.

The goal of testing is not to say the app is perfect. The goal is to show what was tested and what actually happened.