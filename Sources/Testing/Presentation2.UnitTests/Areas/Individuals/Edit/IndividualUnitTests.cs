using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Common.Services;
using Mmu.CleanBlazor.Presentation2.Areas.Individuals.Edit;
using Moq;
using Xunit;

namespace Mmu.CleanBlazor.Presentation2.UnitTests.Areas.Individuals.Edit
{
    public class IndividualUnitTests : TestContext
    {
        private readonly Mock<IIndividualService> _individualServiceMock;

        public IndividualUnitTests()
        {
            _individualServiceMock = new Mock<IIndividualService>();
            Services.AddSingleton(_individualServiceMock.Object);
        }

        [Fact]
        public void Saving_InputsBeingValid_SavesData()
        {
            // Arrange
            const int IndividualId = 123;
            const string FirstName = "Tra";
            const string LastName = "Tra2";
            var birthdate = new DateTime(1988, 12, 12);
            const double Length = 45.5;

            IndividualVm? actualVm = null;
            _individualServiceMock.Setup(f => f.SaveAsync(It.IsAny<IndividualVm>()))
                .Returns(Task.CompletedTask)
                .Callback<IndividualVm>(vm => actualVm = vm);

            _individualServiceMock.Setup(f => f.LoadAsync(IndividualId))
                .ReturnsAsync(new IndividualVm
                {
                    IndividualId = IndividualId
                });

            var sut = RenderComponent<Individual>(f => { f.Add(g => g.Id, IndividualId); });

            sut.Find("#firstName").Change(FirstName);
            sut.Find("#lastName").Change(LastName);
            sut.Find("#birthDate").Change(birthdate);
            sut.Find("#length").Change(Length);

            // Act
            var button = sut.Find(".btn-save");
            button.Click();

            // Assert
            actualVm.Should().NotBeNull();
            actualVm!.Length.Should().Be(Length);
            actualVm!.BirthDate.Should().Be(birthdate);
            actualVm!.FirstName.Should().Be(FirstName);
            actualVm!.LastName.Should().Be(LastName);
        }
    }
}