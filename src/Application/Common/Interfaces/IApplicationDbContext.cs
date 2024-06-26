﻿using PulseApi.Domain.Entities;

namespace PulseApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<QuoteItem> QuoteItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
