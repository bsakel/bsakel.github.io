Title: Feature Flags Done Right
Published: 3/28/2026
Tags:
  - engineering
  - devops
  - dotnet
---
# Feature Flags Done Right

Feature flags decouple deployment from release. Ship code to production behind a flag, then turn it on when you are ready. This is one of the most underused techniques in software delivery.

## Why Use Them

- Deploy to production without exposing incomplete features
- Gradual rollouts to a percentage of users
- Quick kill switch if something goes wrong
- A/B testing

## Keep It Simple

You do not need a fancy feature flag service to start. A config file or environment variable works for basic flags:

```csharp
if (config.GetValue<bool>("Features:NewCheckout"))
{
    // new code path
}
```

## The Hard Part: Cleanup

Feature flags are technical debt the moment the feature is fully rolled out. Track them and remove them. I add a "remove by" date to every flag. If a flag is still in the code after its expiry, it shows up in our tech debt dashboard.

## Rules

1. Every flag has an owner
2. Every flag has an expiry date
3. Short-lived flags only (weeks, not months)
4. Test both paths in CI
