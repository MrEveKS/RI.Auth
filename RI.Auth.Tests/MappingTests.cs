using AutoFixture;
using FluentAssertions;
using Mapster;
using RI.Auth.Commons.Models;
using RI.Auth.Domain.Models;
using Xunit;

namespace RI.Auth.Tests;

public sealed class MappingTests
{
    [Fact]
    public void PersonAddDto_To_Person()
    {
        var fixture = new Fixture();
        var dto = fixture.Create<PersonAddDto>();
        
        var result = dto.Adapt<Person>();

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(dto);
    }

    [Fact]
    public void PersonUpdateDto_To_Person()
    {
        var fixture = new Fixture();
        var dto = fixture.Create<PersonUpdateDto>();
        var entity = fixture.Create<Person>();

        dto.Should().NotBeEquivalentTo(entity);

        dto.Adapt(entity);
        entity.Should().BeEquivalentTo(dto);
    }
}