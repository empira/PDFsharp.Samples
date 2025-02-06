using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.IO;

namespace DocumentViewer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create a new MigraDoc document
            var document = SampleDocuments.CreateSample1();

            var ddl = DdlWriter.WriteToString(document);
            Preview.SetDdl(ddl, null);
        }

        private void Sample1Click(object sender, RoutedEventArgs e)
        {
            var document = SampleDocuments.CreateSample1();
            var ddl = DdlWriter.WriteToString(document);
            Preview.SetDdl(ddl, null);
        }

        private void Sample2Click(object sender, RoutedEventArgs e)
        {
            Directory.SetCurrentDirectory(GetProgramDirectory());
            var document = SampleDocuments.CreateSample2();
            var ddl = DdlWriter.WriteToString(document);
            Preview.SetDdl(ddl, null);
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatePdfClick(object sender, RoutedEventArgs e)
        {
            var printer = new PdfDocumentRenderer();
            printer.DocumentRenderer = Preview.Renderer!;
            printer.Document = Preview.Document!;
            printer.RenderDocument();
            Preview.Document!.BindToRenderer(null!);
            printer.Save("test.pdf");

            Process.Start("test.pdf");
        }

        private void OpenDdlClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = "MigraDoc DDL (*.mdddl)|*.mdddl|All Files (*.*)|*.*",
                    FilterIndex = 1,
                    InitialDirectory = Path.GetFullPath(Path.Combine(GetProgramDirectory(), "..\\..\\..\\..\\assets\\ddl"))
                };

                if (dialog.ShowDialog() == true)
                {
                    var document = DdlReader.DocumentFromFile(dialog.FileName);
                    var folder = Path.GetDirectoryName(dialog.FileName)!;
                    Environment.CurrentDirectory = folder;
                    var ddl = DdlWriter.WriteToString(document);
                    Preview.SetDdl(ddl, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title);
                Preview.SetDdl(null!);
            }
            finally
            {
                //if (dialog != null)
                //  dialog.Dispose();
            }
            //UpdateStatusBar();
        }

        private string GetProgramDirectory()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.Location)!;
        }
    }
}
