using System;
using System.Windows.Forms;

namespace DocumentViewer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Viewer());
        }
    }
}
