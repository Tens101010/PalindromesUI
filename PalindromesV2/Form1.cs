using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PalindromesV2
{
    public partial class Palindromes : Form
    {
        public Palindromes()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            bool result = IsA_Palindrome(textBox1.Text);
            resultLabel.Text = result.ToString();
            textBox1.Focus();
        }

        private bool IsA_Palindrome(string palin)
        {
            string s1 = palin.ToLower(); //taking input and setting to lowercase

            //This will remove everything in the string that IS NOT in the regex arguement "[^a-z]". Only letters remain. 
            string forwardString = Regex.Replace(s1, "[^a-z]", "", RegexOptions.Compiled);

            //Handling the reversal of the string
            char[] zReversed = forwardString.ToCharArray();  //Turing string into an array of characters
            Array.Reverse(zReversed);  //Reversing that array
            string backwardString = new string(zReversed);  //Reforming the new string

            return forwardString.Equals(backwardString);  //Will return true if the strings match.
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CheckButton_Click(sender, e);
            }
        }

        private void palindromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A palindrome is a word, phrase, number, or other sequence of characters which " +
                            "reads the same backward or forward. Allowances may be made for adjustments to " +
                            "capital letters, punctuation, and word dividers.", "Palindromes?");
        }
    }
}