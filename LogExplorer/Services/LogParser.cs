using System.Globalization;
using CsvHelper;
using LogExplorer.Models;

namespace LogExplorer.Services;

public static class LogParser
{
    public static List<LogEntry> ParseFiles(List<string> filePaths)
    {
        var logEntries = new List<LogEntry>();

        foreach (var filePath in filePaths)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader(); // checks if the headers exist
            var headers = csv.HeaderRecord;
            
            if (headers == null) continue;
            
            while (csv.Read())
            {
                var logEntry = new LogEntry();
                foreach (var header in headers)
                {
                    logEntry.Fields[header] = csv.GetField(header);
                }
                logEntries.Add(logEntry);
            }
        }

        return logEntries;
    }
}