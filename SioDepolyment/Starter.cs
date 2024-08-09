using System;

namespace SioDepolyment
{
    internal class Starter
    {
        [STAThread]
        public static void Main(string[] args)
        {
            _ = new App().Run();
        }
    }
}
