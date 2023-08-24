using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace translationapptesting
{
    public partial class Form1 : Form
    {
         string connectionString = "SERVER = localhost ;DATABASE = spm ;USERNAME = root ;PASSWORD = '' ;";



        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {


            string sentence = textBox1.Text;
            string[] words = sentence.Split(' ');

            List<string> verbs = new List<string>();
            List<string> nouns = new List<string>();
            List<string> nounEnds = new List<string>();
            List<string> remainingVariables = new List<string>();

          /*  using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                // Compare verbs, nouns, and nounEnds with the word column in the database
                CompareAndDisplay(connection, verbs, textBox2);
                CompareAndDisplay(connection, nouns, textBox3);
                CompareAndDisplay(connection, nounEnds, textBox4);
                CompareAndDisplay(connection, remainingVariables, textBox5);

                // ... handle remainingWords in a similar way if needed ...
            }*/

            foreach (string word in words)
            {
                string verb = "";
                string noun = "";
                string noun_end = "";

                if (word.EndsWith("nnemi") || word.EndsWith("nnemu") || word.EndsWith("nniya") || word.EndsWith("nneya") || word.EndsWith("nnoya"))
                {
                    if (word.StartsWith("duwa") || word.StartsWith("ka") || word.StartsWith("andi") || word.StartsWith("kiya")
                        || word.StartsWith("nata") || word.StartsWith("ya") || word.StartsWith("pani") || word.StartsWith("kara")
                        || word.StartsWith("gaya") || word.StartsWith("kada") || word.StartsWith("bala"))
                    {
                        string lastCharsToRemove = word.EndsWith("nnemi") ? "nnemi" : word.EndsWith("nnemu") ? "nnemu" : word.EndsWith("nniya") ? "nniya" : word.EndsWith("nneya") ? "nneya" : "nnoya";
                        verb = word.Substring(0, word.Length - lastCharsToRemove.Length);
                    }
                }


                else if (word.EndsWith("emi") || word.EndsWith("emu") || word.EndsWith("aya") || word.EndsWith("eya") || word.EndsWith("oya"))
                {
                    if (word.StartsWith("duwa") || word.StartsWith("ka") || word.StartsWith("andi") || word.StartsWith("kiya")
                        || word.StartsWith("nata") || word.StartsWith("ya") || word.StartsWith("pani") || word.StartsWith("kara")
                        || word.StartsWith("gaya") || word.StartsWith("kada") || word.StartsWith("bala"))
                    {
                        string lastCharsToRemove = word.EndsWith("emi") ? "emi" : word.EndsWith("emu") ? "emu" : word.EndsWith("aya") ? "aya" : word.EndsWith("eya") ? "eya" : "oya";
                        verb = word.Substring(0, word.Length - lastCharsToRemove.Length);
                    }
                }
                else if (word.EndsWith("mi") || word.EndsWith("mu") || word.EndsWith("yi") || word.EndsWith("thi"))
                {
                    if (word.StartsWith("duwa") || word.StartsWith("ka") || word.StartsWith("andi") || word.StartsWith("kiya")
                        || word.StartsWith("nata") || word.StartsWith("ya") || word.StartsWith("pani") || word.StartsWith("kara")
                        || word.StartsWith("gaya") || word.StartsWith("kada") || word.StartsWith("bala"))
                    {
                        string lastCharsToRemove = word.EndsWith("mi") ? "mi" : word.EndsWith("mu") ? "mu" : word.EndsWith("yi") ? "yi" : "thi";
                        verb = word.Substring(0, word.Length - lastCharsToRemove.Length);
                    }
                }
                else if (word.EndsWith("ta") || word.EndsWith("ge") || word.EndsWith("k") || word.EndsWith("kin") || word.EndsWith("nak") ||
                         word.EndsWith("uva") || word.EndsWith("en") || word.EndsWith("sin") || word.EndsWith("gen") || word.EndsWith("vala") ||
                         word.EndsWith("ehi") || word.EndsWith("ka") || word.EndsWith("ee") || word.EndsWith("aa") || word.EndsWith("or") ||
                         word.EndsWith("hi") || word.EndsWith("nva") || word.EndsWith("nta") || word.EndsWith("uta"))
                {
                    string[] nounEnd = { "ta", "ge", "k", "kin", "nak", "uva", "en", "sin", "gen", "vala", "ehi", "ka", "ee", "aa", "or", "hi", "nva", "nta", "uta" };

                    foreach (string end in nounEnd)
                    {
                        if (word.EndsWith(end))
                        {
                            noun_end = end;
                            noun = word.Substring(0, word.Length - noun_end.Length);
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(verb))
                {
                    verbs.Add(verb);
                       textBox2.Text = verb;
                }
                else if (!string.IsNullOrEmpty(noun))
                {
                    nouns.Add(noun);
                    noun_end = noun_end != "" ? noun_end : "None";
                    nounEnds.Add(noun_end);

                     textBox3.Text = string.Join(",",nouns);
                      textBox4.Text = string.Join(",", nounEnds);
                }
                else
                {
                    remainingVariables.Add(word);
                      textBox5.Text = string.Join(",", remainingVariables);
                }



            }

        }
       /* public void CompareAndDisplay(MySqlConnection connection, List<string> words, System.Windows.Forms.TextBox targetTextBox)
        {
            string query = "SELECT type FROM wordlist WHERE word = @word";
            foreach (string word in words)
            {
              //  string query = "SELECT type FROM wordlist WHERE word = @word";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@word", word);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string type = reader.GetString("type");
                            //targetTextBox.Text = string.Join(",", $"Word: {word}, Type: {type}\r\n");
                            targetTextBox.AppendText($"Word: {word}, Type: {type}\r\n");
                        }
                    }
                }
            }
        }*/
    }



}


