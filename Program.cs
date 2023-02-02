using System.ServiceProcess;
using Logstore_logger;

internal class Program
{
    private static void Main(string[] args)
    {
        //only allow 1 instance of this program to run
        if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1) return;

        var settings = new LogGeneratorSettings("../logs/log.txt");

        using var logService = new LogService(settings);
        if (!Environment.UserInteractive)
        {
            if (OperatingSystem.IsWindows())
                ServiceBase.Run(logService);
        }
        else
        {
            Console.WriteLine("Running in User interactive mode. Generating single log.");
            logService.RecordLog();
            Console.WriteLine("Exiting.");
        }
    }
}