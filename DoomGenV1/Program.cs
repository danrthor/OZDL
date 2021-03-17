using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


class DeclareVars
{
    public string WriteString = "";
    
    public string IwadString = "";
    public string DoomString = "";
    public string MusicString = "";

    public DeclareVars()
    {
    }
}


namespace DoomGenV1
{
    static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
