Title: Common Async/Await Pitfalls in C#
Published: 3/22/2026
Tags:
  - csharp
  - dotnet
  - tips
---
# Common Async/Await Pitfalls in C#

Async/await in C# looks simple on the surface but hides several traps that can cause deadlocks, poor performance, or subtle bugs.

## 1. Blocking on Async Code

Never call `.Result` or `.Wait()` on a task in code that has a synchronization context. This is the classic deadlock recipe.

## 2. Async Void

Only use `async void` for event handlers. Everywhere else, return `Task`. Async void methods swallow exceptions and cannot be awaited.

## 3. Forgetting ConfigureAwait

In library code, use `ConfigureAwait(false)` to avoid capturing the synchronization context unnecessarily.

## 4. Not Using ValueTask

For hot paths that complete synchronously most of the time, consider `ValueTask<T>` to reduce allocations.

## 5. Fire and Forget Without Error Handling

If you intentionally do not await a task, at least observe its exceptions:

```csharp
_ = DoWorkAsync().ContinueWith(t =>
    logger.LogError(t.Exception, "Background work failed"),
    TaskContinuationOptions.OnlyOnFaulted);
```

Get these right and async code becomes much more predictable.
