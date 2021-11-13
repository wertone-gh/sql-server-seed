using CommandLine;

namespace SqlServerSeed;

public class Options
{
    [Option('a', "amount", Required = false, Default = 1000, HelpText = "Amount of data to generate")]
    public int Amount { get; set; }

    [Option('c', "connectionString", Required = false, Default = "Server=.;Database=TestDb;User Id=sa;Password=admin123@", HelpText = "Connection string to SQL database")]
    public string ConnectionString { get; set; }
}