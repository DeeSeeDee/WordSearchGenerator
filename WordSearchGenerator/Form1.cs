using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WordSearchGenerator
{
    public partial class Form1 : Form
    {
        public List<string> listOfWords = new List<string>();
        private bool debug = true;

        public Form1()
        {
            InitializeComponent();
            wordList.Items.Clear();
            totalWords.Text = wordList.Items.Count.ToString();
            statusLabel.Text = "Please Enter a Title";
            doneButton.Enabled = false;
            if (debug)
            {
                puzzleTitle.Text = "Football";
                string[] wordsToAdd = new string[] { "CHEERLEADER", "QUARTERBACK", "PENALTY", "HALFBACK", "FULLBACK", "LINEBACKER", "RECEIVER", "REFEREE", "TOUCHDOWN", "FIELDGOAL", "KICKER", "PUNTER", "WILDFANS", "HALFTIME", "CONCESSIONS", "COACH", "SAFETY", "TIGHTEND", "TACKLE", "GUARD", "CENTER", "PIGSKIN", "FIRSTDOWN", "KICKOFF", "HELMET", "SHOULDERPADS" };
                foreach (string word in wordsToAdd)
                {
                    wordList.Items.Add(word);
                }
                UpdateWordCount();
                doneButton.Enabled = true;
            }
        }

        private bool ValidateWord(string word, out string wordToValidate)
        {
            wordToValidate = word.ToUpper();
            if (wordToValidate.Length < 3)
            {
                MessageBox.Show("The word you typed should have three or more characters.", "Word is too short");
                return false;
            }
            if (wordToValidate.Length > 15)
            {
                MessageBox.Show("The word you typed should have no more than 15 characters.", "Word is too long");
                return false;
            }
            if (!Regex.IsMatch(wordToValidate, "^[A-Z]{3,}$"))
            {
                MessageBox.Show("The word you typed should have only letters. No numbers, symbols, or spaces.", "Words only");
                return false;
            }
            if (wordList.Items.Contains(wordToValidate))
            {
                MessageBox.Show("The word you have entered already exists in the list of words.", "Duplicate word");
                return false;
            }
            if (wordList.Items.Count > 40)
            {
                MessageBox.Show("The maximum number of words is 40.", "Max Words Reached");
                return false;
            }
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddWord(wordInput.Text);
        }

        private void wordInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                AddWord(wordInput.Text);
        }

        private bool AddWord(string word)
        {
            string wordToAdd;
            if (ValidateWord(word, out wordToAdd))
            {
                wordList.Items.Add(wordToAdd);
                wordInput.Clear();
                UpdateWordCount();
                return true;
            }
            else
            {
                statusLabel.Text = "Please try again";
                return false;
            }

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            for (int i = wordList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                wordList.Items.RemoveAt(wordList.SelectedIndices[i]);
                UpdateWordCount();
            }
        }

        private void UpdateWordCount()
        {
            int wordCount = wordList.Items.Count;
            totalWords.Text = wordCount.ToString();
            if (wordCount > 0 && puzzleTitle.Text.Length > 0)
                doneButton.Enabled = true;
            else
                doneButton.Enabled = false;
            if (wordCount == 40)
                statusLabel.Text = "Word limit reached";
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            foreach (string item in wordList.Items)
            {
                listOfWords.Add(item);
            }
            this.Hide();
            Form2 form2 = new Form2(listOfWords, puzzleTitle.Text);
            form2.Show();
        }

        private void puzzleTitle_TextChanged(object sender, EventArgs e)
        {
            if (puzzleTitle.Text.Length > 0)
            {
                statusLabel.Text = "";
                if (wordList.Items.Count > 0)
                    doneButton.Enabled = true;
            }
            else
            {
                statusLabel.Text = "Please Enter a Title";
                doneButton.Enabled = false;
            }
        }

        private void puzzleTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                wordInput.Focus();
        }


    }
}
