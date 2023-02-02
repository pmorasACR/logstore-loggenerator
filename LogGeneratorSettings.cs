namespace Logstore_logger
{
    public record LogGeneratorSettings
    (
        string OutputFileLocation = "logs/log.txt",
        int SecondsPerLog = 60 //how many seconds before a new log is generated
    ){}
}