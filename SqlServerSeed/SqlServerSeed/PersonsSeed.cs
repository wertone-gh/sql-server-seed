using Bogus;
using SqlServerSeed.Models;
using Person = SqlServerSeed.Models.Person;

namespace SqlServerSeed;

public class PersonsSeed
{
    private readonly Bogus.Faker<Person> _personGenerator;

    public PersonsSeed()
    {
        var addressGenerator = new Faker<Address>("pl")
            .Ignore(x => x.Id)
            .RuleFor(x => x.City, o => o.Person.Address.City)
            .RuleFor(x => x.Street, o => o.Person.Address.Street)
            .RuleFor(x => x.ZipCode, o => o.Person.Address.ZipCode);

        _personGenerator = new Faker<Person>("pl")
            .Ignore(x => x.Id)
            .RuleFor(x => x.FirstName, o => o.Person.FirstName)
            .RuleFor(x => x.LastName, o => o.Person.LastName)
            .RuleFor(x => x.Email, o => o.Person.Email)
            .RuleFor(x => x.PhoneNumber, o => o.Person.Phone)
            .RuleFor(x => x.DateOfBirth, o => o.Person.DateOfBirth)
            .RuleFor(x => x.Address, o => addressGenerator);
    }

    public IEnumerable<Person> GenerateData(int amount) => _personGenerator.Generate(amount);
}