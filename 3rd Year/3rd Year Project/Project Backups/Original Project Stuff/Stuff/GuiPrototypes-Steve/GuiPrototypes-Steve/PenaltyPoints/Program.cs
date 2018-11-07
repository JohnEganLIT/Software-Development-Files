using System.Windows.Forms;
using View;

namespace PenaltyPoints {
    public static class Program {
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frame());
        }
    }
}
