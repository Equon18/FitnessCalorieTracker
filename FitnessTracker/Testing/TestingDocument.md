# Fitness Calorie Tracker Testing Document

## Tester

Quentin Robinson

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

Actual Result: The program accepted the sample user information and saved the profile.

Pass/Fail: Pass



## Profile Test 2

Test Case ID: Profile Test 2

Test Case Description: View a saved profile

Test Steps: Choose Profile. Choose View Profile.

Test Data: Use the sample profile created in Profile Test 1

Expected Result: The program shows the saved name, age, weight, and daily calorie goal.

Actual Result: The program displayed the saved sample profile information correctly.

Pass/Fail: Pass



## Profile Test 3

Test Case ID: Profile Test 3

Test Case Description: View profile before creating one

Test Steps: Start the program without creating a profile. Choose Profile. Choose View Profile.

Test Data: No profile created

Expected Result: The program shows No profile has been created yet.

Actual Result: The program showed that no profile had been created yet.

Pass/Fail: Pass



# Calorie Tracking Testing

These tests check if calorie entries can be added and viewed correctly.



## Calorie Test 1

Test Case ID: Calorie Test 1

Test Case Description: Add a calorie entry

Test Steps: Choose Calorie Tracking. Choose Add Calorie Entry. Enter a sample food name and calories.

Test Data: Food: Sample Meal, Calories: 650

Expected Result: The program saves the entry and shows Calorie entry saved.

Actual Result: The program accepted the sample meal and saved the calorie entry.

Pass/Fail: Pass



## Calorie Test 2

Test Case ID: Calorie Test 2

Test Case Description: View calorie history

Test Steps: Add a sample calorie entry. Choose Calorie Tracking. Choose View Calorie History.

Test Data: Food: Sample Meal, Calories: 650

Expected Result: The program shows the saved calorie entry in the calorie history.

Actual Result: The program displayed the saved calorie entry in the calorie history.

Pass/Fail: Pass



## Calorie Test 3

Test Case ID: Calorie Test 3

Test Case Description: Reject a negative calorie value

Test Steps: Choose Add Calorie Entry. Enter a sample food name. Enter a negative calorie amount.

Test Data: Food: Sample Snack, Calories: -200

Expected Result: The program does not accept the negative number and asks the user to enter calories again.

Actual Result: The program did not accept the negative calorie amount and asked for a valid calorie amount.

Pass/Fail: Pass



# Workout Tracking Testing

These tests check if workout entries can be added and viewed correctly.



## Workout Test 1

Test Case ID: Workout Test 1

Test Case Description: Add a workout entry

Test Steps: Choose Workout Tracking. Choose Add Workout. Enter sample workout information.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The program saves the workout and shows Workout saved.

Actual Result: The program accepted the sample workout information and saved the workout.

Pass/Fail: Pass



## Workout Test 2

Test Case ID: Workout Test 2

Test Case Description: View workout history

Test Steps: Add a sample workout. Choose Workout Tracking. Choose View Workout History.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The program shows the saved workout in the workout history.

Actual Result: The program displayed the saved workout in the workout history.

Pass/Fail: Pass



## Workout Test 3

Test Case ID: Workout Test 3

Test Case Description: Reject a negative workout duration

Test Steps: Choose Add Workout. Enter a sample workout name. Enter a negative number for minutes.

Test Data: Workout: Sample Walk, Minutes: -10

Expected Result: The program does not accept the negative minutes and asks the user to enter minutes again.

Actual Result: The program did not accept the negative workout duration and asked for a valid number of minutes.

Pass/Fail: Pass



# Reminder Testing

These tests check if reminders can be added, viewed, and marked complete.



## Reminder Test 1

Test Case ID: Reminder Test 1

Test Case Description: Add a reminder

Test Steps: Choose Reminders. Choose Add Reminder. Enter sample reminder text.

Test Data: Reminder: Sample reminder for testing

Expected Result: The program saves the reminder and shows Reminder saved.

Actual Result: The program accepted the sample reminder and saved it.

Pass/Fail: Pass



## Reminder Test 2

Test Case ID: Reminder Test 2

Test Case Description: View reminders

Test Steps: Add a sample reminder. Choose Reminders. Choose View Reminders.

Test Data: Reminder: Sample reminder for testing

Expected Result: The program shows the reminder with Pending status.

Actual Result: The program displayed the sample reminder with Pending status.

Pass/Fail: Pass



## Reminder Test 3

Test Case ID: Reminder Test 3

Test Case Description: Mark a reminder complete

Test Steps: Add a sample reminder. Choose Reminders. Choose Mark Reminder Complete. Enter reminder number 1.

Test Data: Reminder number: 1

Expected Result: The program changes the reminder from Pending to Complete.

Actual Result: The program changed the reminder status from Pending to Complete.

Pass/Fail: Pass



# Daily Summary and Exit Testing

These tests check the daily summary and the exit option.



## Summary Test 1

Test Case ID: Summary Test 1

Test Case Description: View the daily summary

Test Steps: Create a sample profile. Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Daily Goal: 2200, Calories Consumed: 650, Calories Burned: 300

Expected Result: The program shows calories consumed, calories burned, net calories, daily goal, and goal status.

Actual Result: The program showed the calories consumed, calories burned, net calories, daily goal, and goal status.

Pass/Fail: Pass



## Exit Test 1

Test Case ID: Exit Test 1

Test Case Description: Exit the program

Test Steps: Choose Exit from the main menu.

Test Data: Menu option 6

Expected Result: The program shows Exiting program and closes normally.

Actual Result: The program showed the exit message and closed normally.

Pass/Fail: Pass



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

Actual Result: The daily summary showed 650 calories consumed.

Pass/Fail: Pass



## Integration Test 2

Test Case ID: Integration Test 2

Test Case Description: Workout entry connects to daily summary

Test Steps: Add one sample workout. Choose Daily Summary.

Test Data: Workout: Sample Workout, Minutes: 30, Calories Burned: 300

Expected Result: The daily summary shows 300 calories burned.

Actual Result: The daily summary showed 300 calories burned.

Pass/Fail: Pass



## Integration Test 3

Test Case ID: Integration Test 3

Test Case Description: Net calories calculate correctly

Test Steps: Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Calories Consumed: 650, Calories Burned: 300

Expected Result: The net calories show 350.

Actual Result: The program calculated the net calories as 350.

Pass/Fail: Pass



## Integration Test 4

Test Case ID: Integration Test 4

Test Case Description: Profile goal connects to daily summary

Test Steps: Create a sample profile with a calorie goal. Add one sample calorie entry. Add one sample workout. Choose Daily Summary.

Test Data: Daily Goal: 2200, Net Calories: 350

Expected Result: The program compares net calories to the profile goal and shows On track.

Actual Result: The program compared the net calories to the daily goal and showed the user was on track.

Pass/Fail: Pass



# Reminder and Menu Integration Testing

These tests check if reminders and the main menu connect correctly.



## Integration Test 5

Test Case ID: Integration Test 5

Test Case Description: Reminder status updates correctly

Test Steps: Add a sample reminder. View reminders. Mark the reminder complete. View reminders again.

Test Data: Reminder: Sample reminder for testing

Expected Result: The reminder changes from Pending to Complete.

Actual Result: The reminder changed from Pending to Complete and displayed correctly when viewed again.

Pass/Fail: Pass



## Integration Test 6

Test Case ID: Integration Test 6

Test Case Description: Main menu connects all main features

Test Steps: Use each main menu option at least once.

Test Data: Menu options 1 through 6

Expected Result: The user can open profile, calories, workouts, reminders, daily summary, and exit from the main menu.

Actual Result: Each main menu option opened the correct part of the program, and the exit option closed the program normally.

Pass/Fail: Pass



# Testing Notes

The manual tests were completed using sample information only.

No real personal information was used in the testing.

The main features tested were profile creation, calorie tracking, workout tracking, reminders, daily summary, and exiting the program.

The tests showed that the main parts of the program worked correctly with the sample data.

If future changes are made to the program, these manual tests should be ran again to make sure the changes do not break the main features.