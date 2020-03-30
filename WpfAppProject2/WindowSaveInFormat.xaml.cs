using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Spire.Doc;

namespace WpfAppProject2
{
    /// <summary>
    /// Логика взаимодействия для WindowSaveInFormat.xaml
    /// </summary>
    public partial class WindowSaveInFormat : Window
    {
        public WindowSaveInFormat()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void BtnPdf_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            Person person = new Person();
            string path = person.FilePath;

            fileDialog.Filter = "Text documents (.pdf)|*.pdf";
            fileDialog.Title = "Save an Pdf File";
            fileDialog.ShowDialog();

            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                string extesion = System.IO.Path.GetExtension(fileName);
                switch (extesion)
                {
                    case ".pdf"://do something here   
                        StreamReader rdr = new StreamReader(path);
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();
                        PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                        doc.Open();

                        doc.Add(new iTextSharp.text.Paragraph(rdr.ReadToEnd()));
                        doc.Close();

                        MessageBox.Show("Conversion Successful....");
                        break;
                }
            }
            //  this.Close();
        }


        private void BtnDoc_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog fileDialog = new SaveFileDialog();
            Person person = new Person();
            string path = person.FilePath;

            fileDialog.Filter = "Text documents (.doc)|*.doc";
            fileDialog.Title = "Save an Doc File";
            fileDialog.ShowDialog();
           
            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                string extesion = System.IO.Path.GetExtension(fileName);
                switch (extesion)
                {
                    case ".doc"://do something here   
                        Spire.Doc.Document document = new Spire.Doc.Document();
                        document.LoadText(path);
                        document.SaveToFile(fileName, FileFormat.Doc);
                        document.Close();

                        MessageBox.Show("Conversion Successful....");
                        break;
                }
            }
            /*
            document.SaveToFile(System.IO.Path.Combine(path, "TestWordDoc.docx"), FileFormat.Doc);
            document.LoadFromFile(System.IO.Path.Combine(path, "TestTxt.txt"));

            document.LoadFromFile(System.IO.Path.Combine(docPath, "TestWordDoc.docx"));
            string readText = File.ReadAllText(System.IO.Path.Combine(docPath, "TestTxt.txt"));
            */
        }

        private void BtnDocx_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog fileDialog = new SaveFileDialog();
            Person person = new Person();
            string path = person.FilePath;

            fileDialog.Filter = "Text documents (.docx)|*.docx";
            fileDialog.Title = "Save an Docx File";
            fileDialog.ShowDialog();

            if (fileDialog.ShowDialog() == true)
            {

                string fileName = fileDialog.FileName;
                string extesion = System.IO.Path.GetExtension(fileName);
                switch (extesion)
                {
                    case ".docx"://do something here   
                        Spire.Doc.Document document = new Spire.Doc.Document();
                        document.LoadText(path);
                        document.SaveToFile(fileName, FileFormat.Docx);
                        document.Close();

                        MessageBox.Show("Conversion Successful....");
                        break;
                }
            }


        }
    }
}
