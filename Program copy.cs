// using System.Text.Json;
// using acrloggerlib;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
// using Serilog;
// using ILogger = Microsoft.Extensions.Logging.ILogger;

// const string logFile = "log/log.txt";

// AuditJsonData appData = new AuditJsonData();
// appData.Module = ACRAppModule.DART_MLP; // Select your module. If module is not available please notify ACRLogStore team.
// appData.Host = "testmachine"; // IP or host name
// appData.Outcome = Outcome.Success; // Select outcome. Use unknown for no outcome
// appData.Userid = "pprasad"; // Userid
// appData.MType = MType.GCP;
// appData.App = ACRApp.DART;

// // Extended app information - Optional elements
// Dictionary<object, object> jsonDict = new Dictionary<object, object>()
//                 {
//                     { "client" , "Windows"},
//                     { "domain" , "ATI"}
//                 };
// appData.JsonData = JsonConvert.SerializeObject(jsonDict);

// var sLogger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

// var serviceProvider = new ServiceCollection()
//     .AddLogging(builder => builder.AddSerilog(sLogger))
//     .BuildServiceProvider();


// try
// {
//     var factory = serviceProvider.GetService<ILoggerFactory>();
//     //var _logger = serviceProvider.GetService<ILogger<Program>>();
//     var _logger = factory.CreateLogger<Program>();
//     _logger.LogInformation("Test? info");
//     AuditLogger logger = new AuditLogger(_logger); // Pass ILogger object here instead of null
//     logger.Login(appData); // Write formatted log information to log file
//     logger.Log("hello world");
// }
// catch (Exception ex)
// {
//     throw;
// }

// //run as service


// //string lg = appData.GetLogData();
// //Console.WriteLine(lg);