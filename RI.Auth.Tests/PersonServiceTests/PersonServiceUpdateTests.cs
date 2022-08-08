using System.Linq.Expressions;
using AutoFixture;
using FluentAssertions;
using Moq;
using RI.Auth.Business.Services;
using RI.Auth.Commons.Models;
using RI.Auth.DataAccess;
using RI.Auth.DataAccess.Repositories;
using RI.Auth.Domain.Models;
using Xunit;

namespace RI.Auth.Tests.PersonServiceTests;

public sealed class PersonServiceUpdateTests
{
    [Fact]
    public async Task Update_Null_ShouldReturn_False()
    {
        const string? id = null;

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();
        var uow = new Mock<IUnitOfWork>();

        var service = new PersonService(uow.Object);

        var result = await service.Update(id, dto);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Update_Empty_ShouldReturn_False()
    {
        const string? id = "";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();
        var uow = new Mock<IUnitOfWork>();

        var service = new PersonService(uow.Object);

        var result = await service.Update(id, dto);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Update_WhiteSpace_ShouldReturn_False()
    {
        const string? id = "    ";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();
        var uow = new Mock<IUnitOfWork>();

        var service = new PersonService(uow.Object);

        var result = await service.Update(id, dto);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Update_TabSpace_ShouldReturn_False()
    {
        const string? id = "\t \t";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();
        var uow = new Mock<IUnitOfWork>();

        var service = new PersonService(uow.Object);

        var result = await service.Update(id, dto);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Update_If_UnitOfWork_ReturnNull_ShouldReturn_False()
    {
        const string? id = "12";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();

        var person = new Mock<IPersonRepository>();
        var uow = new Mock<IUnitOfWork>();

        person.Setup(x => x.GetOne(
                It.IsAny<Expression<Func<Person, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Person?)null);
        uow.Setup(x => x.Person)
            .Returns(person.Object);

        var service = new PersonService(uow.Object);
        var result = await service.Update(id, dto);

        result.Should().BeFalse();
    }

    [Fact]
    public async Task Update_ShouldReturn_True()
    {
        const string? id = "12";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();

        var person = new Mock<IPersonRepository>();
        var uow = new Mock<IUnitOfWork>();

        person.Setup(x => x.GetOne(
                It.IsAny<Expression<Func<Person, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Person());

        uow.Setup(x => x.Person)
            .Returns(person.Object);

        var service = new PersonService(uow.Object);
        var result = await service.Update(id, dto);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task Update_ShouldThrowException_If_Exception()
    {
        const string? id = "12";

        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();

        var person = new Mock<IPersonRepository>();
        var uow = new Mock<IUnitOfWork>();

        person.Setup(x => x.GetOne(
                It.IsAny<Expression<Func<Person, bool>>>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());
        uow.Setup(x => x.Person)
            .Returns(person.Object);

        var service = new PersonService(uow.Object);
        var act = () => service.Update(id, dto);

        await act.Should().ThrowAsync<Exception>();
    }
}