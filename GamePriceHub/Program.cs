using GamePriceHub.Gorunumler; // Güncellenmiş klasör referansı
using System;
using System.Windows.Forms;

namespace GamePriceHub
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Sistem Türkçe isimlendirilmiş GirisFormu ile başlar
            Application.Run(new GirisFormu());
        }
    }
}