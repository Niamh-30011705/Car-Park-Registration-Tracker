// Niamh Cavanagh
// Date: 12 April 2025
// Version: 1.0
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

        // Declare two lists<string> to store the licence plates and tagged licence plates separately
        List<string> MainList = new List<string>();
        List<string> TaggedList = new List<string>();
        // Declare the currently opened file to use later
        string currentFileName = "";

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

        // Method to display selected licence plate in Main list box into text box
        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected
            if (listBoxMain.SelectedItem != null)
            {
                // Display selected licence plate in the text box
                textBoxInput.Text = listBoxMain.SelectedItem.ToString();
                toolStripStatusLabel1.Text = "Licence plate loaded into input box";
                // Auto focus the textbox
                textBoxInput.Focus();
            }
        }

        // Method to display selected licence plate in Tagged list box into text box
        private void listBoxTagged_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected
            if (listBoxTagged.SelectedItem != null)
            {
                // Display selected licence plate in the text box
                textBoxInput.Text = listBoxTagged.SelectedItem.ToString();
                toolStripStatusLabel1.Text = "Tagged licence plate loaded into input box";
                // Auto focus the textbox
                textBoxInput.Focus();
            }
        }
        #endregion General

        #region TextFileIO
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
                    while (!reader.EndOfStream)
                    {
                        string mainPlate = reader.ReadLine();
                        string taggedPlate = reader.EndOfStream ? "" : reader.ReadLine();

                        MainList.Add(mainPlate);
                        TaggedList.Add(taggedPlate);
                    }
                }
                // Diaplay updated lists
                DisplayMainList();
                DisplayTaggedList();
                toolStripStatusLabel1.Text = $"Text file '{Path.GetFileName(currentFileName)}' opened successfully";
                statusStrip.Refresh();
            }
            catch (IOException)
            {
                // Show error if file read fails
                toolStripStatusLabel1.Text = "An error occured: Unable to open text file";
            }
        }

        // Method to write the current lists to a text file
        private void SaveToFile(string fileName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt",
                DefaultExt = "txt",
                Title = "Save Licence Plate Data"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        // Save both lists line by line (in pairs)
                        int count = Math.Max(MainList.Count, TaggedList.Count);
                        for (int i = 0; i < count; i++)
                        {
                            // Avoid index errors
                            writer.WriteLine(i < MainList.Count ? MainList[i] : "");
                            writer.WriteLine(i < TaggedList.Count ? TaggedList[i] : "");
                        }
                    }
                    toolStripStatusLabel1.Text = $"Data saved successfully to {Path.GetFileName(fileName)}";
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Error: Could not save file.";
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Save cancelled.";
            }
        }
        
        // Method to call the save method when the "Save" button is clicked
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        // Method called when the form is closed - saved the list to a new file with an incremented number
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Extracts a number from the current file name and increments it
                int num = int.Parse(Path.GetFileNameWithoutExtension(currentFileName).Remove(0, 10));
                num++;
                string newValue;
                if (num <= 9)
                {
                    // Ensures two-digit format
                    newValue = "0" + num.ToString();
                }
                else
                {
                    newValue = num.ToString();
                }
                string newfilename = "day_" + newValue + ".txt";
                // Auto-save to incremented filename
                SaveToFile(newfilename);
            }
            catch
            {
                // Ignore errors
                return;
            }
        }
        #endregion TextFileIO

        #region AddEditDelete
        #region Add
        // Method to add a new licence plate to the main list
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Check that input is not empty and is a valid (non-duplicate) licence plate
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text) && (ValidPlate(textBoxInput.Text)))
            {
                // Add user input to main list
                MainList.Add(textBoxInput.Text);
                // Sort list alphabetically with built-in function
                MainList.Sort();
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
                toolStripStatusLabel1.Text = "Text box is empty or input is invalid. Please try again.";
            }
        }
        #endregion Add

        #region Edit
        // Method to edit an existing licence plate in either list
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Check updated licence plate is not a duplicate
            if (ValidPlate(textBoxInput.Text))
            {
                if (listBoxMain.SelectedIndex != -1)
                {
                    // Replace selected item
                    MainList[listBoxMain.SelectedIndex] = textBoxInput.Text;
                    // Update list box
                    DisplayMainList();
                }
                if (listBoxTagged.SelectedIndex != -1)
                {
                    // Replace selected item
                    TaggedList[listBoxTagged.SelectedIndex] = textBoxInput.Text;
                    // Update list box
                    DisplayTaggedList();
                }
                // Clear text box and display updated lists
                textBoxInput.Clear();
                textBoxInput.Focus();
                // Update status strip
                toolStripStatusLabel1.Text = "Licence plate updated successfully";
            }
            else
            {
                // Display error to user
                toolStripStatusLabel1.Text = $"Updated licencce plate '{textBoxInput.Text}' is a duplicate. Please try again.";
            }
        }
        #endregion Edit

        // Method to check for duplicate licence plates in the lists
        private bool ValidPlate(string checkThisPlate)
        {
            return !MainList.Contains(checkThisPlate) && !TaggedList.Contains(checkThisPlate);
        }

        #region Delete
        // Method to delete selected licence plate from either list
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedIndex != -1)
            {
                // Remove selcted licence plate from Main List
                MainList.RemoveAt(listBoxMain.SelectedIndex);
                // Refresh display
                DisplayMainList();
            }
            if (listBoxTagged.SelectedIndex != -1)
            {
                // Remove selected licence plate from Tagged List
                TaggedList.RemoveAt(listBoxTagged.SelectedIndex);
                // Refresh display
                DisplayTaggedList();
            }
            // Clear and refocus the input field
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

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
        #endregion AddEditDelete

        #region Reset
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
    } // end class
} // end namespace