using System;
using System.Collections.Generic;
using FluentAssertions;
using ProjectBC.Domain.Entities.Exceptions;
using Xunit;

namespace ProjectBC.Domain.Entities.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void GivenProjectWithSprintsThenAddingOverlappingSprintThrowsException()
        {
            // Arrange
            var project = new Project();
            project.AddSprint(new Sprint{ DateRange = new DateRange(new DateTime(2019, 12, 18), new DateTime(2019, 12, 30))});
            
            FluentActions.Invoking(() => 
                project.AddSprint(new Sprint {DateRange = new DateRange(new DateTime(2018, 12, 12), new DateTime(2020, 12, 12) )})).
                Should().Throw<DomainException>();
        }
    }
}