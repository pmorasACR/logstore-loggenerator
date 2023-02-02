
using System.ServiceProcess;
using System.Text.Json;
using acrloggerlib;

namespace Logstore_logger
{
    public class LogService : ServiceBase
    {
        readonly LogGeneratorSettings settings;
        public LogService(LogGeneratorSettings settings){
            this.settings = settings;
            if(OperatingSystem.IsWindows())
                ServiceName = "Logstore Log Generator";
        }
        protected override void OnStart(string[] args)
        {
            _ = LogUpdate(); //async task
            //Task.Run()
        }
        public async Task LogUpdate(){
            while(true){
                await Task.Delay(1000 * settings.SecondsPerLog);
                RecordLog();
            }
        }

        public void RecordLog(){
            var directory = Path.GetDirectoryName(settings.OutputFileLocation);
            if(!Directory.Exists(directory)){
                Directory.CreateDirectory(directory);
            }
            using var f = File.OpenWrite(settings.OutputFileLocation);
            using var writer = new StreamWriter(f);
            
            var log = GenerateLog();
            writer.WriteLine(log.GetLogData());
        }

        public AuditJsonData GenerateLog(){
            AuditJsonData appData = new AuditJsonData();
            appData.Module = ACRAppModule.DART_MLP; // Select your module. If module is not available please notify ACRLogStore team.
            appData.Host = "testmachine"; // IP or host name
            appData.Outcome = Outcome.Success; // Select outcome. Use unknown for no outcome
            appData.Userid = "pprasad"; // Userid
            appData.MType = MType.GCP;
            appData.App = ACRApp.DART;

            // Extended app information - Optional elements
            Dictionary<object, object> jsonDict = new Dictionary<object, object>()
                {
                    { "client" , "Windows"},
                    { "domain" , "ATI"}
                };
            appData.JsonData = JsonSerializer.Serialize(jsonDict);
            return appData;
        }

    }
}