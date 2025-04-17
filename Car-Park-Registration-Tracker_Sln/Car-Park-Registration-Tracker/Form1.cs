// Niamh Cavanagh
// Date: 12 April 2025
// Version: 1.1
// Car Park Registration Tracker aka Licence Plate Management

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Park_Registration_Tracker
{
    public partial class Form1: Form
    {
        #region General
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Program Ready";
        }

        // 2.1
        // Declare two empty lists<string> to store the licence plates and tagged licence plates separately
        List<string> MainList = new List<string>();
        List<string> TaggedList = new List<string>();
        
        // Declare the currently opened file to use later
        string currentFileName = "";
        // Declare boolean flad to use in the save method
        bool userSaved = false;

        #region Display
        // 2.9
        // Method to refresh the main list box with the current main licence plate list
        private void DisplayMainList()
        {
            // Sort list
            MainList.Sort();
            // Clear list box content
            listBoxMain.Items.Clear();
            // Add list items to relavent list box
            foreach (var licencePlate in MainList)
            {
                // Check for empty spaces or empty lines and remove them
                if (!string.IsNullOrWhiteSpace(licencePlate))
                {
                    listBoxMain.Items.Add(licencePlate);
                }
            }
        }

        // 2.10
        // Method to refresh the tagged list box with the current tagged licence plate list
        private void DisplayTaggedList()
        {
            // Sort list
            TaggedList.Sort();
            // Clear list box content
            listBoxTagged.Items.Clear();
            // Add list items to relavent list box
            foreach (var licenceTagged in TaggedList)
            {
                // Check for empty spaces or empty lines and remove them
                if (!string.IsNullOrWhiteSpace(licenceTagged))
                {
                    listBoxTagged.Items.Add(licenceTagged);
                }
            }
        }
        #endregion Display

        #region SelectedDisplay
        // 2.7
        // Method to display selected licence plate in Main list box into textbox
        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected
            if (listBoxMain.SelectedItem != null)
            {
                // Clear any selection from tagged list box
                listBoxTagged.ClearSelected();
                // Display selected licence plate in the text box
                textBoxInput.Text = listBoxMain.SelectedItem.ToString();
                toolStripStatusLabel1.Text = "Licence plate loaded into input box";
                // Auto focus the textbox
                textBoxInput.Focus();
            }
        }

        // 2.8
        // Method to display selected licence plate in Tagged list box into textbox
        private void listBoxTagged_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected
            if (listBoxTagged.SelectedItem != null)
            {
                // Clear any selection from main list box
                listBoxMain.ClearSelected();
                // Display selected licence plate in the text box
                textBoxInput.Text = listBoxTagged.SelectedItem.ToString();
                toolStripStatusLabel1.Text = "Tagged licence plate loaded into input box";
                // Auto focus the textbox
                textBoxInput.Focus();
            }
        }
        #endregion SelectedDisplay

        #region Reset
        // 2.6
        // Method to remove all data from both lists
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Clear licence plate data from both lists
            MainList.Clear();
            TaggedList.Clear();
            // Clear list boxes and text box
            listBoxMain.Items.Clear();
            listBoxTagged.Items.Clear();
            textBoxInput.Clear();
        }
        #endregion Reset
        #endregion General

        #region TextFileIO
        #region Open
        // 2.2
        // Method to open a text file and loads the data from it when the "Open" button is clicked
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            // Declare textFileName variable and a new OpenFileDialog
            string textFileName;
            OpenFileDialog openTextFileDialog = new OpenFileDialog();
            // Start in application folder to look for text file
            openTextFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            // File filter to look for and display text files only
            openTextFileDialog.Filter = "txt files (*.txt)|*.txt";
            DialogResult sr = openTextFileDialog.ShowDialog();
            // user choses a file to open
            if (sr == DialogResult.OK)
            {
                textFileName = openTextFileDialog.FileName;
                currentFileName = textFileName; // Save file path
            }
            else
            {
                return;
            }
            try
            {
                // Clear existing data
                MainList.Clear();
                TaggedList.Clear();
                // Read text file content and add to the lists
                using (StreamReader reader = new StreamReader(File.OpenRead(textFileName)))
                {
                    // Read all lines of the text file
                    foreach (var line in File.ReadAllLines(textFileName))
                    {
                        // Read each line individually
                        var trimmedLine = line.Trim();
                        // Remove all empty lines
                        if (string.IsNullOrWhiteSpace(trimmedLine))
                        {
                            continue;
                        }
                        // Add all items with > symbol to tagged list and remove > symbol for display
                        if (trimmedLine.StartsWith(">"))
                        {
                            TaggedList.Add(trimmedLine.Substring(1).Trim());
                        }
                        // Add all other items to main list
                        else
                        {
                            MainList.Add(trimmedLine);
                        }
                    }
                }
                // Diaplay updated lists
                DisplayMainList();
                DisplayTaggedList();
                // Display message to user
                toolStripStatusLabel1.Text = $"Text file '{Path.GetFileName(currentFileName)}' opened successfully";
                statusStrip.Refresh();
            }
            catch (IOException)
            {
                // Show error if file read fails
                toolStripStatusLabel1.Text = "An error occured: Unable to open text file";
            }
        }
        #endregion Open

        #region Save
        // 2.13 a
        // Method to write the current lists to a text file
        private void SaveToFile()
        {
            // Open save dialog box
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt",
                DefaultExt = "txt",
                Title = "Save Licence Plate Data"
            };
            // If user clicks OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Use the file name selected by the user
                    string fileName = saveFileDialog.FileName;
                    // Write the lists to the selected file
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        // Add main list to file
                        foreach (var item in MainList)
                        {
                            writer.WriteLine(item.ToString());
                        }
                        // Add tagged list to file with > symbol
                        foreach (var item in TaggedList)
                        {
                            writer.WriteLine($">{item}");
                        }
                    }
                    // After saving, refresh the display of lists
                    DisplayMainList();
                    DisplayTaggedList();
                    // Display message to user
                    toolStripStatusLabel1.Text = $"Data saved successfully to {Path.GetFileName(fileName)}";
                }
                catch (IOException ex)
                {
                    // Display error message to user
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Error: Could not save file.";
                }
            }
            // If user clicks anything other than OK
            else
            {
                // Display error message to user
                toolStripStatusLabel1.Text = "Save cancelled.";
            }
        }

        // 2.13 c
        // Method as overload of SaveToFile that accepts a filename argument
        private void SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Write main list
                    foreach (var item in MainList)
                    {
                        writer.WriteLine(item.ToString());
                    }
                    // Write tagged list
                    foreach (var item in TaggedList)
                    {
                        writer.WriteLine($">{item}");
                    }
                }
            }
            catch (IOException ex)
            {
                // Display error message to user
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2.13 b
        // Method to call the save method when the "Save" button is clicked
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
            // Mark that the user has manually saved
            userSaved = true;
        }

        // 2.13 c
        // Method called when the form is closed - saved the list to a new file with an incremented number
        // Extra code has been added so if the user manually saved the file with the button, the auto save on file close is deemed unnessary and doesn't happen
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Skip auto-save if user already saved
            if (userSaved)
            {
                // Just close the program
                return;
            }
            // If the user didn't save manually
            try
            {
                // Check if currentFileName is valid
                if (string.IsNullOrEmpty(currentFileName) || !File.Exists(currentFileName))
                {
                    // If no valid file is opened, exit
                    return;
                }
                // Extract number from the current file name and increment it (assuming format "day_xx.txt")
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(currentFileName);
                if (!fileNameWithoutExt.StartsWith("day_"))
                {
                    // If the file doesn't follow the expected format, exit
                    return;
                }
                // Get number from file name
                string numberPart = fileNameWithoutExt.Substring(4);
                if (!int.TryParse(numberPart, out int num))
                {
                    // If the number is invalid, exit
                }
                // Increment the number
                num++;
                // Ensure 2-digit format
                string newValue = num.ToString("D2");
                string newFileName = Path.Combine(Path.GetDirectoryName(currentFileName), $"day_{newValue}.txt");
                // Call Save method
                SaveToFile(newFileName);
            }
            catch (IOException ex)
            {
                // Display error message to user
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Save
        #endregion TextFileIO

        #region AddEditDeleteTag
        #region Add
        // 2.3
        // Method to add a new licence plate to the main list
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Check that input is not empty and is a valid (non-duplicate) licence plate
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text) && (ValidPlate(textBoxInput.Text)))
            {
                // Add user input to main list
                MainList.Add(textBoxInput.Text);
                // Refresh the list display
                DisplayMainList();
                toolStripStatusLabel1.Text = "Licence plate successfully added";
                // Clear and refocus the input field
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
            else
            {
                // Display error message for invalid input
                toolStripStatusLabel1.Text = "Text box is empty, the input is invalid, or there is a duplicate. Please try again.";
            }
        }
        #endregion Add

        #region Edit
        // 2.5
        // Method to edit an existing licence plate in either list
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Check updated licence plate is not a duplicate
            if (ValidPlate(textBoxInput.Text))
            {
                // If user selected from main list
                if (listBoxMain.SelectedItem != null)
                {
                    // Replace selected item with textBoxInput
                    MainList[listBoxMain.SelectedIndex] = textBoxInput.Text;
                    // Display updated list
                    DisplayMainList();
                    listBoxMain.ClearSelected();
                    // Clear text box and display updated lists
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    // Update status strip
                    toolStripStatusLabel1.Text = "Licence plate updated successfully";
                    return;
                }
                // If user selected from tagged list
                if (listBoxTagged.SelectedItem != null)
                {
                    // Replace selected item with textBoxInput
                    TaggedList[listBoxTagged.SelectedIndex] = textBoxInput.Text;
                    // Display updated list
                    DisplayTaggedList();
                    listBoxTagged.ClearSelected();
                    // Clear text box and display updated lists
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    // Update status strip
                    toolStripStatusLabel1.Text = "Licence plate updated successfully";
                    return;
                }
                // Clear text box and display updated lists
                textBoxInput.Clear();
                textBoxInput.Focus();
                // If nothing is seleced, display error message to user
                toolStripStatusLabel1.Text = "You need to select a licence plate to edit";
            }
            else
            {
                // Display error to user
                toolStripStatusLabel1.Text = $"Updated licencce plate '{textBoxInput.Text}' is a duplicate. Please try again.";
            }
        }
        #endregion Edit

        // 2.3
        // Method to check for duplicate licence plates in the lists
        private bool ValidPlate(string checkThisPlate)
        {
            return !MainList.Contains(checkThisPlate) && !TaggedList.Contains(checkThisPlate);
        }

        #region Delete
        // 2.4 b
        // Method to delete selected licence plate from either list
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // If user selected from the tagged list, display error
            if (listBoxTagged.SelectedItem != null)
            {
                // Display error message
                toolStripStatusLabel1.Text = "You need to untag the licence plate before it can exit";
                listBoxTagged.ClearSelected();
                return;
            }
            // If user selected from the main list - proceed with delete
            if (listBoxMain.SelectedItem != null)
            {
                // Declare selectedPlate as the selected item in the main list
                string selectedPlate = listBoxMain.SelectedItem.ToString();
                // Remove selected licence plate from main list
                MainList.Remove(selectedPlate);
                // Refresh display
                DisplayMainList();
                // Clear and refocus the input field
                textBoxInput.Clear();
                textBoxInput.Focus();
                return;
            }
            // If nothing is seleced, display error message to user
            toolStripStatusLabel1.Text = "You need to select a licence plate from the main list to exit";
        }

        // 2.4 a
        // Method to delete licence plate double clicked in Main list box
        private void listBoxMain_DoubleClick(object sender, EventArgs e)
        {
            // Check if a licence plate is selcted
            if (listBoxMain.SelectedItem != null)
            {
                string selectedPlate = listBoxMain.SelectedItem.ToString();
                // Show confirmation dialog box
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the licence plate: {selectedPlate}?",
                    "Confirm Deletion",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                // If user clicks ok
                if (result == DialogResult.OK)
                {
                    // Remove from MainList
                    MainList.Remove(selectedPlate);
                    // Clear the input text box
                    textBoxInput.Clear();
                    // Refresh the display
                    DisplayMainList();
                    // Update the status strip
                    toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' was removed";
                }
                else
                {
                    // Display error to user
                    toolStripStatusLabel1.Text = "Deletion cancelled";
                }
            }
        }
        #endregion Delete

        #region Tag
        // 2.14
        // Method to tag a licence plate in the main list to move it to the tagged list
        private void buttonTag_Click(object sender, EventArgs e)
        {
            // If user selected from tagged list (warn them it's already tagged)
            if (listBoxTagged.SelectedItem != null)
            {
                // Display error to user
                toolStripStatusLabel1.Text = "This licence plate is already tagged";
                listBoxTagged.ClearSelected();
                return;
            }
            // If user selected from main list - proceed to tag
            if (listBoxMain.SelectedItem != null)
            {
                // Declare selectedPlate as the selected item in the main list
                string selectedPlate = listBoxMain.SelectedItem.ToString();
                // Add plate to tagged list and remove from main list
                TaggedList.Add(selectedPlate);
                MainList.Remove(selectedPlate);
                // Display updated lists
                DisplayMainList();
                DisplayTaggedList();
                // Display message to user
                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' tagged successfully";
                listBoxMain.ClearSelected();
                return;
            }
            // If nothing is seleced, display error message to user
            toolStripStatusLabel1.Text = "You need to select a licence plate from the main list to tag";
        }

        // 2.15
        // Method to remove plate from tagged list if double mouse clicked in the tagged list box
        private void listBoxTagged_DoubleClick(object sender, EventArgs e)
        {
            // Check user selected from the tagged list
            if (listBoxTagged.SelectedItem != null)
            {
                // Declare selectedPlate as the selected item in the tagged list
                string selectedPlate = listBoxTagged.SelectedItem.ToString();
                // Add plate to main list and remove from tagged list
                MainList.Add(selectedPlate);
                TaggedList.Remove(selectedPlate);
                // Display updated lists
                DisplayMainList();
                DisplayTaggedList();
                // Display message to user
                toolStripStatusLabel1.Text = $"Licence plate '{selectedPlate}' untagged successfully";
                listBoxMain.ClearSelected();
                return;
            }
        }
        #endregion Tag
        #endregion AddEditDeleteTag

        #region Search
        // 2.11
        // Method to binary search both lists for target written in the text box
        private void buttonBinary_Click(object sender, EventArgs e)
        {
            // Declare target as textbox input (trim to remove blank spaces)
            string target = textBoxInput.Text.Trim();
            // Check textbox isn't empty
            if (string.IsNullOrWhiteSpace(target))
            {
                toolStripStatusLabel1.Text = "Please enter a licence plate to search";
                return;
            }
            // Use inbuilt binary search on both lists and declare list index of target
            int mainIndex = MainList.BinarySearch(target);
            int taggedIndex = TaggedList.BinarySearch(target);
            // Get results
            if (mainIndex >= 0)
            {
                // Highlights target when found in main list
                listBoxMain.SelectedItem = MainList[mainIndex];
                listBoxMain.Focus();
                // Display message to user
                toolStripStatusLabel1.Text = $"Licence plate '{target}' found in Main List using Binary Search";
            }
            else if (taggedIndex >= 0)
            {
                // Highlights target when found in tagged list
                listBoxTagged.SelectedItem = TaggedList[taggedIndex];
                listBoxTagged.Focus();
                // Display message to user
                toolStripStatusLabel1.Text = $"Licence plate '{target}' found in Tagged List using Binary Search";
            }
            else
            {
                // Display error message if target is not found
                toolStripStatusLabel1.Text = $"Licence plate '{target}' not found using Binary Search";
                // Clear and refocus the input field
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
        }

        // 2.12
        // Method to linear search both lists for target written in the text box
        private void buttonLinear_Click(object sender, EventArgs e)
        {
            // Declare target as textbox input (trim to remove blank spaces)
            string target = textBoxInput.Text.Trim();
            // Check textbox isn't empty
            if (string.IsNullOrWhiteSpace(target))
            {
                toolStripStatusLabel1.Text = "Please enter a licence plate to search";
                return;
            }
            // Set boolean variable for target found
            bool found = false;
            // Search main list
            foreach (var plate in MainList)
            {
                if (plate.Equals(target, StringComparison.OrdinalIgnoreCase))
                {
                    // Highlights target when found in main list
                    listBoxMain.SelectedItem = plate;
                    listBoxMain.Focus();
                    // Display message to user
                    toolStripStatusLabel1.Text = $"Licence plate '{target}' found in Main List using Linear Search";
                    // Set found to true
                    found = true;
                    break;
                }
            }
            // If not found in main list, search tagged list
            if (!found)
            {
                foreach (var plate in TaggedList)
                {
                    if (plate.Equals(target, StringComparison.OrdinalIgnoreCase))
                    {
                        // Highlights target when found in tagged list
                        listBoxTagged.SelectedItem = plate;
                        listBoxTagged.Focus();
                        // Display message to user
                        toolStripStatusLabel1.Text = $"Licence plate '{target}' found in Tagged List using Linear Search";
                        // Set found to true
                        found = true;
                        break;
                    }
                }
            }
            // If still not found
            if (!found)
            {
                // Display error message if target is not found
                toolStripStatusLabel1.Text = $"Licence plate '{target}' not found using Linear Search";
                // Clear and refocus the input field
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
        }
        #endregion Search
    } // end class
} // end namespace