using LogExplorer.Models;
using LogExplorer.Services;

var filePaths = new List<string> { "logs.csv" };

// Parse the logs
try
{
    var logEntries = LogParser.ParseFiles(filePaths);
}
catch (Exception ex)
{
    Console.WriteLine($"Error parsing files: {ex.Message}");
    return;
}

// Get the user's query


// Parse query


// Filter the logs

Console.ReadKey();