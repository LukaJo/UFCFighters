using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UFCApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var doc = new HtmlWeb().Load(@"https://www.ufc.com/athlete/"+textBox1.Text+"-"+textBox2.Text);

            var kujsli = doc.DocumentNode.SelectNodes("//div[@class='c-bio__image']//img").Select(a => a.GetAttributeValue("src", null)).ToList();

            var listaInformacija = doc.DocumentNode.SelectNodes("//div[@class='c-bio__text']").Select(a => a.GetDirectInnerText()).ToList().Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            var godine = doc.DocumentNode.SelectNodes("//div[@class='c-bio__text']//div").Select(a => a.GetDirectInnerText()).ToList();

            pictureBox1.ImageLocation = kujsli[0].ToString();

            textBox3.Text = listaInformacija[0].ToString();
            textBox4.Text = listaInformacija[1].ToString();
            textBox5.Text = listaInformacija[2].ToString();
            textBox6.Text = listaInformacija[3].ToString();
            textBox7.Text = listaInformacija[4].ToString();
            textBox8.Text = listaInformacija[5].ToString();
            textBox9.Text = listaInformacija[6].ToString();

            textBox10.Text = godine[0].ToString();

            label9.Text = (textBox1.Text + " " + textBox2.Text).ToUpper();
            label9.Font = new Font(FontFamily.GenericMonospace,18, FontStyle.Bold);
        }
    }
}
