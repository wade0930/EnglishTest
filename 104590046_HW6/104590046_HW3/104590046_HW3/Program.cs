using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HomeWork
{
    internal class Program
    {
        //主要程式
        [STAThread]
        private static void Main(string[] args)
        {
            ReadFile file = new ReadFile();
            Model textModel = new Model();
            EnglishTestForm form = new EnglishTestForm(new PresentationModel(new Model()));
            AboutSpellingCheckerForm form1 = new AboutSpellingCheckerForm();
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.Run(form);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}