Title: Entity Framework Core Tips I Wish I Knew Earlier
Published: 3/20/2026
Tags:
  - dotnet
  - csharp
  - tips
---
# Entity Framework Core Tips I Wish I Knew Earlier

EF Core is powerful but has footguns. Here are the things that would have saved me hours of debugging.

## Use AsNoTracking for Read-Only Queries

If you are not going to modify the entities, skip change tracking:

```csharp
var users = await db.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToListAsync();
```

## Beware the N+1 Problem

Always check your queries with logging enabled. Use `.Include()` or projection to avoid lazy-loading traps.

## Split Queries for Large Includes

When you have multiple `.Include()` calls, EF can generate a massive cartesian product. Use `.AsSplitQuery()` to break it into separate SQL queries.

## Raw SQL When Needed

Do not fight the ORM. For complex reports or bulk operations, use `FromSqlRaw` or `ExecuteSqlRaw`. There is no shame in writing SQL when it is the right tool.

## Migrations in CI

Always run `dotnet ef migrations script` in your CI pipeline to catch migration issues before they hit production.
