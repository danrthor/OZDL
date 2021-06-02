using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


public class DeclareVars
{
    public string WriteString = "";

    public string IwadString = "";
    public string DoomString = "";
    public string MusicString = "";
    public int CampCount = 0;

    public string cPath = "CampaignCount.txt";
    public string mynewarg = "";
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
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                MessageBox.Show(args[0]);
            }
            //MessageBox.Show("Shortcut saved.");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
    }
}
