Title: Minimal APIs in .NET
Published: 3/10/2026
Tags:
  - dotnet
  - csharp
  - tutorial
---
# Minimal APIs in .NET

Minimal APIs strip away the ceremony of controllers and let you define endpoints inline. They are great for microservices and small APIs where a full MVC setup is overkill.

## Basic Example

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => "Hello, world!");
app.MapGet("/users/{id}", (int id) => new { Id = id, Name = "User " + id });

app.Run();
```

## When to Use Them

- Small services with a handful of endpoints
- Prototyping
- Background job APIs

For larger applications with complex routing, filters, and model binding, controllers still make sense. Pick the right tool for the job.
