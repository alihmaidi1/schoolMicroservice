using Bogus;
using ClassDomain.Entities.Parent;

namespace ClassInfrutructure.Data;

public static class ParentFaker
{

    public static Faker<Parent> GetParentFaker()
    {

        var parent = new Faker<Parent>();
        parent.RuleFor(x=>x.Name,setter=>setter.Random.Word());
        parent.RuleFor(x => x.Email, setter => setter.Internet.Email());
        parent.RuleFor(x => x.Password, setter => "12345678");
        
        

        return parent;
    }
}