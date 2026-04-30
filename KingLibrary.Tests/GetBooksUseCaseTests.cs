using KingLibrary.Application.UseCases;
using KingLibrary.Application.Interfaces;
using Moq;
using KingLibrary.Domain.Entities;

namespace KingLibrary.Tests;

public class GetBooksUseCaseTests
{
    [Fact]
    public async Task ExecuteGrouped_ShouldGroupBooks_ByPublisher()
    {
        // Arrange
        var mock = new Mock<IBookRepository>();

        var books = new List<Book>
        {
            new Book { Title = "A1", Publisher = "A" },
            new Book { Title = "A2", Publisher = "A" },
            new Book { Title = "B1", Publisher = "B" }
        };

        mock.Setup(x => x.GetAllAsync())
            .ReturnsAsync(books);

        var useCase = new GetBooksUseCase(mock.Object);

        var result = await useCase.ExecuteGrouped();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, g => g.Key == "A" && g.Count() == 2);
        Assert.Contains(result, g => g.Key == "B" && g.Count() == 1);
    }

    [Fact]
    public async Task ExecuteGrouped_ShouldReturnEmpty_WhenNoBooks()
    {
        // Arrange
        var mock = new Mock<IBookRepository>();

        mock.Setup(x => x.GetAllAsync())
            .ReturnsAsync(new List<Book>());

        var useCase = new GetBooksUseCase(mock.Object);

        // Act
        var result = await useCase.ExecuteGrouped();

        // Assert
        Assert.Empty(result);
    }
}