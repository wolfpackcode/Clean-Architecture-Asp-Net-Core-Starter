﻿using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Exceptions;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.CreateTodoItem;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.UpdateTodoItem;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Commands.CreateTodoList;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Enums;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemDetailTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateTodoItemCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            var command = new UpdateTodoItemDetailCommand
            {
                Id = itemId,
                ListId = listId,
                Note = "This is the note.",
                Priority = PriorityLevel.High
            };

            await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.ListId.Should().Be(command.ListId);
            item.Note.Should().Be(command.Note);
            item.Priority.Should().Be(command.Priority);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
