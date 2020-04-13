﻿using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Exceptions;
using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.TodoItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
