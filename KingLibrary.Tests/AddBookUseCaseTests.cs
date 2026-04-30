using System;
using KingLibrary.Application.Interfaces;
using KingLibrary.Application.UseCases;
using KingLibrary.Domain.Entities;
using Moq;

namespace KingLibrary.Tests;

public class AddBookUseCaseTests
{
    [Fact]
    public async Task Execute_ShouldCallRepository_AddAsync()
    {
        var mock = new Mock<IBookRepository>();

        var book = new Book
        {
            Title = "Test Book",
            Year = 2020,
            Publisher = "Test"
        };

        var useCase = new AddBookUseCase(mock.Object);

        await useCase.Execute(book);

        mock.Verify(x => x.AddAsync(book), Times.Once);
    }

    [Fact]
    public async Task Execute_ShouldNotAddBook_WhenBookAlreadyExists()
    {
        var mock = new Mock<IBookRepository>();

        var existingBook = new Book
        {
            Id = "1",
            Title = "Test"
        };

        mock.Setup(x => x.GetByIdAsync("1"))
            .ReturnsAsync(existingBook);

        var useCase = new AddBookUseCase(mock.Object);

        var book = new Book { Id = "1", Title = "Test Book" };

        await useCase.Execute(book);

        mock.Verify(x => x.AddAsync(It.IsAny<Book>()), Times.Never);
    }
}
