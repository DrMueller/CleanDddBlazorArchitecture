using AutoMapper;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanBlazor.Application.Infrastructure.Mediation.Services;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Overview;
using Moq;
using Xunit;

namespace Mmu.CleanBlazor.Presentation2.UnitTests.Areas.Individuals.Overview
{
    public class IndividualsOverviewUnitTests : TestContext
    {
        private readonly Mock<IMediationService> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<NavigationManager> _navManagerMock;

        private readonly IRenderedComponent<IndividualsOverview> _sut;

        public IndividualsOverviewUnitTests()
        {
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediationService>();
            _navManagerMock = new Mock<NavigationManager>();

            Services.AddSingleton(_mapperMock.Object);
            Services.AddSingleton(_mediatorMock.Object);
            Services.AddSingleton(_navManagerMock.Object);
        }

        [Fact]
        public void LoadingList_LoadsList()
        {
            // Arrange
            var entries = CreateEntries();
            _mapperMock.Setup(f => f.Map<List<IndividualOverviewEntryVm>>(It.IsAny<object>()))
                .Returns(entries);

            var sut = RenderComponent<IndividualsOverview>();

            // Assert
            sut.Instance.OverviewEntries.Should().BeEquivalentTo(entries);
        }

        [Fact]
        public void LoadingList_RendersTable()
        {
            // Arrange
            var entries = CreateEntries();
            _mapperMock.Setup(f => f.Map<List<IndividualOverviewEntryVm>>(It.IsAny<object>()))
                .Returns(entries);

            var sut = RenderComponent<IndividualsOverview>();

            // Assert
            var tableRows = sut.Find("table")
                .Children.Single(f => f.TagName == "TBODY")
                .Children;

            tableRows.Count().Should().Be(entries.Count);
        }

        private static List<IndividualOverviewEntryVm> CreateEntries()
        {
            return new List<IndividualOverviewEntryVm>
            {
                new()
                {
                    IndividualId = 1,
                    BirthDate = new DateTime(),
                    FirstName = "FirstName2",
                    GenderDescription = "Female",
                    LastName = "LastName2",
                    Length = 2.5
                },
                new()
                {
                    IndividualId = 2,
                    BirthDate = new DateTime(),
                    FirstName = "FirstName1",
                    GenderDescription = "Male",
                    LastName = "LastName1",
                    Length = 85.5
                }
            };
        }
    }
}