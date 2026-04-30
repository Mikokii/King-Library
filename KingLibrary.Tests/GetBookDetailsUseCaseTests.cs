using KingLibrary.Application.Interfaces;
using KingLibrary.Application.UseCases;
using KingLibrary.Domain.Entities;
using Moq;

namespace KingLibrary.Tests;

public class GetBookDetailsUseCaseTests
{
    [Fact]
    public async Task Execute_ShouldReturnBook_WhenExists()
    {
        var mock = new Mock<IBookRepository>();

        var expectedBook = new Book
        {
            Id = "1",
            Title = "Test"
        };

        mock.Setup(x => x.GetByIdAsync("1"))
            .ReturnsAsync(expectedBook);

        var useCase = new GetBookDetailsUseCase(mock.Object);

        var result = await useCase.Execute("1");

        Assert.NotNull(result);
        Assert.Equal("Test", result!.Title);
    }
    
    [Fact]
    public async Task Execute_ShouldReturnNull_WhenBookDoesNotExist()
    {
        var mock = new Mock<IBookRepository>();

        mock.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((Book?)null);

        var useCase = new GetBookDetailsUseCase(mock.Object);

        var result = await useCase.Execute("unknown");

        Assert.Null(result);
    }
}
