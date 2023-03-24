using static BeautySalon.Logger.IPrint;
using System.Configuration;
using BeautySalon.Exceptions;

namespace BeautySalon.Logger
{
    public class PrintLog : IPrintLog
    {
        private readonly string fileNameConfig = ConfigurationManager.AppSettings.Get("logFile");
        private readonly string filePathConfig = ConfigurationManager.AppSettings.Get("logFilePath");

        public void ToFile(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePathConfig + $"\\{fileNameConfig}", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Log: " + message);
                }
            }
            catch(CustomException ex)
            {
                throw new CustomException(ex.Message, -1);
            }
        }

        public void ToConsole(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }
}
