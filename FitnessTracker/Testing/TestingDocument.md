# Fitness Calorie Tracker Testing Document

## Tester

Jisoo Yoon

## Project

Fitness Calorie Tracker with Reminders

## Purpose

This document is for testing our Fitness Calorie Tracker program.

The tests are based on the user stories we decided to keep for the final version of the project. I tested the main parts of the program to see if they worked correctly.

For the test data, use sample information only. The names, ages, weights, foods, workouts, and reminders in this document are not real user information. They are just examples for testing.

If something does not work, I will write what happened and mark the test as Fail. The goal is not to say the program is perfect. The goal is to show what was tested and what the result was.



# Functional Testing

Functional testing checks if each main feature works by itself.



# Profile Testing

These tests check if the user profile part works correctly.



## Profile Test 1

Test Case ID: Profile Test 1

Test Case Description: Create a user profile

Test Steps: Start the program. Choose Profile. Choose Create Profile. Enter sample user information.

Test Data: Name: Sample User, Age: 25, Weight: 170, Daily Goal: 2200

Expected Result: The program saves the profile and shows Profile saved.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Profile Test 2

Test Case ID: Profile Test 2

Test Case Description: View a saved profile

Test Steps: Choose Profile. Choose View Profile.

Test Data: Use the sample profile created in Profile Test 1

Expected Result: The program shows the saved name, age, weight, and daily calorie goal.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Profile Test 3

Test Case ID: Profile Test 3

Test Case Description: View profile before creating one

Test Steps: Start the program without creating a profile. Choose Profile. Choose View Profile.

Test Data: No profile created

Expected Result: The program shows No profile has been created yet.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Calorie Tracking Testing

These tests check if calorie entries can be added and viewed correctly.



## Calorie Test 1

Test Case ID: Calorie Test 1

Test Case Description: Add a calorie entry

Test Steps: Choose Calorie Tracking. Choose Add Calorie Entry. Enter a sample food name and calories.

Test Data: Food: Sample Meal, Calories: 650

Expected Result: The program saves the entry and shows Calorie entry saved.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Calorie Test 2

Test Case ID: Calorie Test 2

Test Case Description: View calorie history

Test Steps: Add a sample calorie entry. Choose Calorie Tracking. Choose View Calorie History.

Test Data: Food: Sample Meal, Calories: 650

Expected Result: The program shows the saved calorie entry in the calorie history.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Calorie Test 3

Test Case ID: Calorie Test 3

Test Case Description: Reject a negative calorie value

Test Steps: Choose Add Calorie Entry. Enter a sample food name. Enter a negative calorie amount.

Test Data: Food: Sample Snack, Calories: -200

Expected Result: The program does not accept the negative number and asks the user to enter calories again.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Workout Tracking Testing

These tests check if workout entries can be added and viewed correctly.



## Workout Test 1

Test Case ID: Workout Test 1

Test Case Description: Add a workout entry

Test Steps: Choose Workout Tracking. Choose Add Workout. Enter sample workout information.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The program saves the workout and shows Workout saved.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Workout Test 2

Test Case ID: Workout Test 2

Test Case Description: View workout history

Test Steps: Add a sample workout. Choose Workout Tracking. Choose View Workout History.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The program shows the saved workout in the workout history.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Workout Test 3

Test Case ID: Workout Test 3

Test Case Description: Reject a negative workout duration

Test Steps: Choose Add Workout. Enter a sample workout name. Enter a negative number for minutes.

Test Data: Workout: Sample Walk, Minutes: -10

Expected Result: The program does not accept the negative minutes and asks the user to enter minutes again.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Reminder Testing

These tests check if reminders can be added, viewed, and marked complete.



## Reminder Test 1

Test Case ID: Reminder Test 1

Test Case Description: Add a reminder

Test Steps: Choose Reminders. Choose Add Reminder. Enter sample reminder text.

Test Data: Reminder: Sample reminder for testing

Expected Result: The program saves the reminder and shows Reminder saved.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Reminder Test 2

Test Case ID: Reminder Test 2

Test Case Description: View reminders

Test Steps: Add a sample reminder. Choose Reminders. Choose View Reminders.

Test Data: Reminder: Sample reminder for testing

Expected Result: The program shows the reminder with Pending status.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Reminder Test 3

Test Case ID: Reminder Test 3

Test Case Description: Mark a reminder complete

Test Steps: Add a sample reminder. Choose Reminders. Choose Mark Reminder Complete. Enter reminder number 1.

Test Data: Reminder number: 1

Expected Result: The program changes the reminder from Pending to Complete.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Daily Summary and Exit Testing

These tests check the daily summary and the exit option.



## Summary Test 1

Test Case ID: Summary Test 1

Test Case Description: View the daily summary

Test Steps: Create a sample profile. Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Daily Goal: 2200, Calories Consumed: 650, Calories Burned: 300

Expected Result: The program shows calories consumed, calories burned, net calories, daily goal, and goal status.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Exit Test 1

Test Case ID: Exit Test 1

Test Case Description: Exit the program

Test Steps: Choose Exit from the main menu.

Test Data: Menu option 6

Expected Result: The program shows Exiting program and closes normally.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Integration Testing

Integration testing checks if different parts of the program work together.



# Summary Integration Testing

These tests check if the profile, calories, workouts, and daily summary work together.



## Integration Test 1

Test Case ID: Integration Test 1

Test Case Description: Calorie entry connects to daily summary

Test Steps: Create a sample profile. Add one sample calorie entry. Choose Daily Summary.

Test Data: Daily Goal: 2200, Food: Sample Meal, Calories: 650

Expected Result: The daily summary shows 650 calories consumed.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Integration Test 2

Test Case ID: Integration Test 2

Test Case Description: Workout entry connects to daily summary

Test Steps: Add one sample workout. Choose Daily Summary.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The daily summary shows 300 calories burned.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Integration Test 3

Test Case ID: Integration Test 3

Test Case Description: Net calories calculate correctly

Test Steps: Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Calories Consumed: 650, Calories Burned: 300

Expected Result: The net calories show 350.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Integration Test 4

Test Case ID: Integration Test 4

Test Case Description: Profile goal connects to daily summary

Test Steps: Create a sample profile with a calorie goal. Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Daily Goal: 2200, Net Calories: 350

Expected Result: The program compares net calories to the profile goal and shows On track.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Reminder and Menu Integration Testing

These tests check if reminders and the main menu connect correctly.



## Integration Test 5

Test Case ID: Integration Test 5

Test Case Description: Reminder status updates correctly

Test Steps: Add a sample reminder. View reminders. Mark the reminder complete. View reminders again.

Test Data: Reminder: Sample reminder for testing

Expected Result: The reminder changes from Pending to Complete.

Actual Result: Fill in after testing

Pass/Fail: Fill in



## Integration Test 6

Test Case ID: Integration Test 6

Test Case Description: Main menu connects all main features

Test Steps: Use each main menu option at least once.

Test Data: Menu options 1 through 6

Expected Result: The user can open profile, calories, workouts, reminders, daily summary, and exit from the main menu.

Actual Result: Fill in after testing

Pass/Fail: Fill in



# Testing Notes

The Actual Result part should be filled in after running the program.

Use sample information when testing. Do not use real personal information.

If the program works, mark the test as Pass.

If the program does not work, write what happened and mark the test as Fail.

These tests help show what parts of the program work and what parts may need to be fixed.