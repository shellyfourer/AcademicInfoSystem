using AIS.Database;

namespace AIS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DatabaseSeeder.Seed();
            Application.Run(new LoginForm());
        }
    }
}