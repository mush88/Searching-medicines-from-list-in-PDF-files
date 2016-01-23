using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //searchWord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void searchWord(string filename) {
            
            string[] words = { "Взлом", "Хакер", "шаг" };
            List<int> pages = new List<int>();
                //if (File.Exists("C:\\1\\" + filename))
                //if (File.Exists("C:\\1\\Instr.pdf"))
            if (File.Exists(filename))
                {
                    //PdfReader pdfReader = new PdfReader("C:\\1\\" + filename);
                    //PdfReader pdfReader = new PdfReader("C:\\1\\Instr.pdf");
                    PdfReader pdfReader = new PdfReader(filename);

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                         
                        for (int i = 0; i < words.Length; i++)
                            {
                                //bool switch1 = false;

                            if (currentPageText.Contains(words[i]))
                            {
                                pages.Add(page);
                                textBox1.Text += page.ToString();
                                textBox1.AppendText(Environment.NewLine);
                                textBox2.Text += words[i];
                                textBox2.AppendText(Environment.NewLine);
                                textBox2.Text += "\n";
                            }                               
                           }
                        }
                    pdfReader.Close();    
                    }
                    
                }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            string file;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                searchWord(file);
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            

        }
    }
}
