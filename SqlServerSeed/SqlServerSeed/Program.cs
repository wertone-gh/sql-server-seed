using CommandLine;
using CommandLine.Text;
using Microsoft.EntityFrameworkCore;
using SqlServerSeed;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options =>
    {
        Console.WriteLine("Started seeding database.");
        using var context = new TestDataContext(options.ConnectionString);
        context.Database.Migrate();
        var generator = new PersonsSeed();
        var data = generator.GenerateData(options.Amount);
        context.Persons.AddRange(data);
        context.SaveChanges();
        Console.WriteLine($"Successfully inserted {options.Amount} records to database.");
    })
    .WithNotParsed(errors =>
    {
        var sentenceBuilder = SentenceBuilder.Create();
        foreach (var error in errors)
            Console.WriteLine(sentenceBuilder.FormatError(error));
    });