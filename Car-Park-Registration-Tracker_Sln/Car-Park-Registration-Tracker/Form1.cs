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
        public Form1()
        {
            InitializeComponent();
        }

        // Declare two lists<string> to store the licence plates and tagged licence plates separately
        List<string> MainList = new List<string>();
        List<string> TaggedList = new List<string>();
        // Declare the currently opened file to use later
        string currentFileName = "";

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
                        MainList.Add(reader.ReadLine());
                        TaggedList.Add(reader.ReadLine());
                    }
                }
                // Diaplay updated lists
                DisplayLists();
            }
            catch (IOException)
            {
                // Show error if file read fails
                MessageBox.Show("Open Text File Error");
            }
        }

        // Method to write the current lists to a text file
        private void SaveTextFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (var licencePlate in MainList)
                    {
                        // writes each licence plate on a new line
                        writer.WriteLine(licencePlate);
                    }
                    foreach (var licenceTagged in TaggedList)
                    {
                        // writes each tagged licence plate on a new line
                        writer.WriteLine(licenceTagged);
                    }
                }
            }
            catch (IOException)
            {
                // Show error if write fails
                MessageBox.Show("File NOT saved");
            }
        }

        // Method to open a save dialog and calles the save method when the "Save" button is clicked
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveTextFileDialog = new SaveFileDialog();
            saveTextFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            DialogResult sr = saveTextFileDialog.ShowDialog();
            if (sr == DialogResult.OK)
            {
                // Save list to file
                SaveTextFile(saveTextFileDialog.FileName);
            }
            if (sr == DialogResult.Cancel)
            {
                return;
            }
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
                SaveTextFile(newfilename);
            }
            catch
            {
                // Ignore errors
                return;
            }
        }
        #endregion TextFileIO

        #region Buttons
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
                DisplayLists();
                // Clear and refocus the input field
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
            else
            {
                // Display error message for invalid input
                MessageBox.Show("Text box is empty or input is invalid. Please try again.");
            }
        }

        // Method to edit an existing licence plate in either list
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Replace selected item
            MainList[listBoxMain.SelectedIndex] = textBoxInput.Text;
            TaggedList[listBoxTagged.SelectedIndex] = textBoxInput.Text;
            // Clear text box and display updated lists
            textBoxInput.Clear();
            DisplayLists();
        }

        // Method to delete selected licence plate from either list
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Remove selected licence plate from Main List
            listBoxMain.SetSelected(listBoxMain.SelectedIndex, true);
            MainList.RemoveAt(listBoxMain.SelectedIndex);
            // Refresh display
            DisplayLists();
            // Clear and refocus the input field
            textBoxInput.Clear();
            textBoxInput.Focus();
            // Remove selected licence plate from Tagged List
            listBoxTagged.SetSelected(listBoxTagged.SelectedIndex, true);
            TaggedList.RemoveAt(listBoxTagged.SelectedIndex);
            // Refresh display
            DisplayLists();
            // Clear and refocus the input field
            textBoxInput.Clear();
            textBoxInput.Focus();
        }

        
        #endregion Buttons

        #region Functions
        // Method to refresh the list boxes with the current licence plate list
        private void DisplayLists()
        {
            // Clear list boxes content
            listBoxMain.Items.Clear();
            listBoxTagged.Items.Clear();
            // Add list items to relavent list boxes
            foreach (var licencePlate in MainList)
            {
                listBoxMain.Items.Add(licencePlate);
                MainList.Sort();
            }
            foreach (var licenceTagged in TaggedList)
            {
                listBoxTagged.Items.Add(licenceTagged);
                TaggedList.Sort();
            }
        }

        // Method to check for duplicate licence plates in the lists
        private bool ValidPlate(string checkThisPlate)
        {
            if (MainList.Exists(duplicate => duplicate.Equals(checkThisPlate)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion Functions
    } // end class
} // end namespace
