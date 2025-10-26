# Assignment 7 - COMP 3300

This project implements a Windows Forms application for reading and sorting car data from a JSON file.

## Project Structure

- `CarForm.cs` - Main form with three buttons and list display
- `Models/Car.cs` - Car model class implementing IComparable
- `Comparers/CarComparer.cs` - Custom comparer implementing IComparer<Car>
- `CarData.json` - Sample data file with 40 car entries
- `Program.cs` - Application entry point

## Project Details

This project has been customized for **Bernard Bawak**.

- Project Name: `BernardBawakA7`
- Namespace: `BernardBawakA7`
- Form Title: "Bernard Bawak Assignment 7"

## Features Implemented

✅ Choose File button - Opens file dialog to load JSON data  
✅ Sort by Make button - Uses IComparable for natural sorting  
✅ Sort by Make and Price button - Uses IComparer for custom sorting  
✅ Display area - Shows "No Data Loaded" or formatted car data  
✅ Proper namespace organization (Models and Comparers folders)

## How to Run

1. Open the solution in Visual Studio 2022
2. Build the solution (F6 or Build → Build Solution)
3. Run the application (F5)
4. Click "Choose File" and select the CarData.json file
5. Click either sorting button to sort the data

## Submission

1. Clean the solution (Build → Clean Solution)
2. Zip the entire project folder
3. Submit as BernardBawakA7.zip

