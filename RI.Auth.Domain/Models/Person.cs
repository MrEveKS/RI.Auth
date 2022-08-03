using RI.Commons.Abstraction;

namespace RI.Auth.Domain.Models;

public sealed class Person : ICreated, IUpdated
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public int Age { get; set; }

    public string Description { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}