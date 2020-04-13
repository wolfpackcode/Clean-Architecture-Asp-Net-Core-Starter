using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Exceptions;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.CreateTodoItem;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.DeleteTodoItem;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Commands.CreateTodoList;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
