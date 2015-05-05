using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BingBot2._0
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        // Random Dictionary of words / top searches in Bing
        private static string wordsFile = Properties.Resources.words;
        // Separates each word by the newline character and stores them in an array
        private string[] words = wordsFile.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

        public Form1()
        {
            InitializeComponent();

       
        }
        public void Login(int accountNum)
        {
            // Just Login
        }

        public void Search(bool desktop, int accountNum)
        {
         
            // Search Bing
            string query = GenerateRandomWords(random.Next(1, 5));
            string searchURL = "http://bing.com/search?q=";

            if (desktop)
            {
                //Main.webBrowser.Navigate(searchURL + query, null, null, Accounts.GetUserAgent(accountNum,true));
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            }
            else
            {
                //Main.webBrowser.Navigate(searchURL + query, null, null, Accounts.GetUserAgent(accountNum,false));
                webBrowser1.Navigate(searchURL + query, null, null, "User-Agent: Mozilla/5.0 (Linux; U; Android 2.2; en-gb; LG-P500 Build/FRF91) AppleWebKit/533.0 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1");
            }
        }
        
        public string GenerateRandomWords(int numWords)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < numWords; i++)
            {
                // Select a random word from the array
                builder.Append(words[random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim();

            // Set the first letter of the first word in the sentenece to uppercase
            if (numWords >= 4)
            {
                sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            }

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();

        }
        public void Redeem(int accountNum)
        {
            // Redeem Amazon Gift Card from Bing Redeem store
        }

        public string RetrieveCodes(int accountNum)
        {
            // Go to email and get/return code
            return "code";
        }

        public void DepositToAmazon(string code)
        {
            // Give money to Amazon account
        }

        public void UpdatePoints(int accountNum)
        {
            // Grab the number of points from Bing for the account
            // Call SetPoints(int accountNum)

        }

        public void ResetBrowser()
        {
            // Somehow switch accounts
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search(true, 1);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }
        
    }

}
