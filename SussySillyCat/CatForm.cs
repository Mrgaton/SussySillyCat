using SussySillyCat.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SussySillyCat
{
    public partial class CatForm: Form
    {
        [DllImport("wininet.dll")] private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckNet() => InternetGetConnectedState(out int i, 0);
        public CatForm()
        {
            InitializeComponent();

            if (!CheckNet())
            {
                MessageBox.Show("How i will stole all your information if you dont even have internet 😭");
                return;
            }

            this.catPictureBox.Image = Resources.sillyCat;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = Icon.ExtractAssociatedIcon(Environment.ExpandEnvironmentVariables("%SystemRoot%\\System32\\EhStorAuthn.exe"));
        }

        private void thanksTextBox_Click(object sender, EventArgs e)
        {
            ValidateCard();
        }


        private static Random rand = new Random();
        private static string RandomEntry(params string[] entryes) => entryes[rand.Next(entryes.Length)];

        private void ValidateCard()
        {
            string card = cardNumberTextBox.Text;
            string expirity = expirityTextBox.Text;
            string code = securityCodeTextBox.Text;

            if (card.Length != 16)
            {
                MessageBox.Show(RandomEntry(
                    "Bro the card is not even the correct size are you making fun of me?",
                    "If this is a card i am millionare please put a real card to stea- i mean to help you.",
                    "This is  a fake card and you and we know it please dont be silly :p"
                ));

                return;
            }

            if (expirity.Length != 6 + 2)
            {
                MessageBox.Show(RandomEntry(
                    "This date doesnt even follow the standard date system what are you even doing?",
                    "I dont uderstand this thing please put the correct date of the card is for good prupose for real."z
                ));
            }
            else
            {

            }
        }

        private void cardNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(cardNumberTextBox.Text,out long card))
            {
                cardNumberTextBox.Text = cardNumberTextBox.Text.Replace(" ", "").Trim();
            }
        }
        private void expirityTextBox_TextChanged(object sender, EventArgs e)
        {
            expirityTextBox.Text = expirityTextBox.Text.Replace(" ", "").Replace('\\','/').Trim();

            var splited = expirityTextBox.Text.Split('/');

            if (short.TryParse(splited.Last(),out var lastDate))
            {
                expirityTextBox.Text = string.Join("/", splited.Take(splited.Length - 1).Append((lastDate% 100).ToString()));
            }
        }

        private int CloseIndex = 0;
        private void CatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (CloseIndex == 0)
            {
                MessageBox.Show(RandomEntry(
                    "You are absolutely not closing me today :C",
                    "Why do you even want to kill this beauty.", 
                    "It makes me angry even thinking that you want to kill me."
                ));
            }
            else if (CloseIndex >= 1)
            {
                MessageBox.Show(RandomEntry(
                    "Ok this is too much you cant just try and just close this malware.",
                    "You realy fool you realy think that i will even let get out without me?",
                    "Poor creatures when they see that a malware just take over his computer.",
                    "You just loose all your data you just must admit its probably already uploaded :C"
                ));
            }
            else if (CloseIndex >= 3)
            {
                MessageBox.Show(RandomEntry(
                    "If you keep tring to close me bad things will happend -_-",
                    "Dont make fun of me you will loose more than me im getting tired.",
                    "I wont say it again stop tring to stop me you will realy regret it.",
                    "This computer will be absolutely destroyed if you dont let me controll it"
                ));
            }
            else if (CloseIndex >= 5)
            {

            }

            CloseIndex++;
        }

       
    }
}
