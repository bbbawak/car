using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using BernardBawakA7.Comparers;
using BernardBawakA7.Models;

namespace BernardBawakA7
{
    public partial class CarForm : Form
    {
        // This is where we'll store all the cars we load from the file
        private List<Car> _cars = new List<Car>();
        
        // This is the list box where we'll show all the cars to the user
        private ListBox _displayListBox;

        public CarForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Set up the window title and size
            this.Text = "Bernard Bawak Assignment 7";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create the first button - lets user pick a JSON file to load
            var btnChooseFile = new Button
            {
                Text = "Choose File",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(120, 35)
            };
            btnChooseFile.Click += BtnChooseFile_Click;

            // Second button - sorts all cars alphabetically by Make (Honda, Ford, Toyota, etc.)
            var btnSortByMake = new Button
            {
                Text = "Sort by Make",
                Location = new System.Drawing.Point(200, 50),
                Size = new System.Drawing.Size(120, 35),
                Enabled = false  // Can't sort until we have data
            };
            btnSortByMake.Click += BtnSortByMake_Click;

            // Third button - sorts by Make first, then by Price within each Make
            var btnSortByMakeAndPrice = new Button
            {
                Text = "Sort by Make and Price",
                Location = new System.Drawing.Point(350, 50),
                Size = new System.Drawing.Size(180, 35),
                Enabled = false  // Can't sort until we have data
            };
            btnSortByMakeAndPrice.Click += BtnSortByMakeAndPrice_Click;

            // The big list box where we'll display all the cars
            _displayListBox = new ListBox
            {
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(800, 400),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            // Add controls to form
            this.Controls.Add(btnChooseFile);
            this.Controls.Add(btnSortByMake);
            this.Controls.Add(btnSortByMakeAndPrice);
            this.Controls.Add(_displayListBox);

            DisplayData();
        }

        // This runs when the user clicks "Choose File"
        private void BtnChooseFile_Click(object? sender, EventArgs e)
        {
            // Show a file picker dialog so user can select the JSON file
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // If user clicked OK (not Cancel)
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Read the entire JSON file as text
                        var jsonString = File.ReadAllText(openFileDialog.FileName);
                        
                        // Convert the JSON text into a list of Car objects
                        _cars = JsonSerializer.Deserialize<List<Car>>(jsonString) ?? new List<Car>();

                        // If we loaded some cars, enable the sort buttons so user can use them
                        if (_cars.Count > 0)
                        {
                            // Find all buttons that have "Sort" in their text
                            var sortButtons = this.Controls.OfType<Button>()
                                .Where(b => b.Text.Contains("Sort"));
                            
                            // Turn them on so they're clickable
                            foreach (var btn in sortButtons)
                            {
                                btn.Enabled = true;
                            }
                        }

                        // Update the display to show all the cars we just loaded
                        DisplayData();
                    }
                    // If something goes wrong (file is corrupted, wrong format, etc.)
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // This runs when user clicks "Sort by Make"
        private void BtnSortByMake_Click(object? sender, EventArgs e)
        {
            // Safety check - don't sort if there's nothing to sort
            if (_cars.Count == 0) return;

            // This uses the CompareTo method in the Car class
            // It will sort cars A-Z by Make (Ford comes before Honda)
            _cars.Sort();
            DisplayData();
        }

        // This runs when user clicks "Sort by Make and Price"
        private void BtnSortByMakeAndPrice_Click(object? sender, EventArgs e)
        {
            // Safety check - don't sort if there's nothing to sort
            if (_cars.Count == 0) return;

            // This uses our special CarComparer class
            // It sorts by Make first, then by Price (cheaper Hondas come first)
            _cars.Sort(new CarComparer());
            DisplayData();
        }

        // This method refreshes the display with whatever cars we have loaded
        private void DisplayData()
        {
            // Clear out whatever was showing before
            _displayListBox.Items.Clear();

            // If we don't have any cars, show a friendly message
            if (_cars.Count == 0)
            {
                _displayListBox.Items.Add("No Data Loaded");
            }
            // Otherwise, show each car using its ToString() method
            else
            {
                foreach (var car in _cars)
                {
                    _displayListBox.Items.Add(car.ToString());
                }
            }
        }
    }
}

