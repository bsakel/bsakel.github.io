Title: Observability for .NET Services
Published: 3/15/2026
Tags:
  - dotnet
  - devops
  - observability
---
# Observability for .NET Services

Logging is not enough. To understand what is happening in production, you need metrics, traces, and structured logs working together.

## The Three Pillars

- **Logs**: Structured events with context. Use Serilog with a sink that supports structured queries.
- **Metrics**: Counters, histograms, gauges. .NET has built-in support via `System.Diagnostics.Metrics`.
- **Traces**: Distributed traces across service boundaries using OpenTelemetry.

## Getting Started

Add OpenTelemetry to a .NET app in a few lines:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddOtlpExporter());
```

Start with traces. They give you the most insight per unit of effort. Add metrics for dashboards and alerts. Structured logs fill in the details when you need to dig deeper.
