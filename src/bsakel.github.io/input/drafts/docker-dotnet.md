Title: Running .NET Apps in Docker
Published: 3/5/2026
Tags:
  - dotnet
  - devops
  - docker
---
# Running .NET Apps in Docker

Containerizing .NET applications is straightforward once you understand the basics. Here is a practical guide to multi-stage builds, optimizing image size, and debugging containers locally.

## Multi-Stage Builds

The key to small .NET Docker images is multi-stage builds. Use the SDK image for building and the runtime image for the final layer.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MyApp.dll"]
```

## Tips

- Always use `.dockerignore` to exclude `bin/`, `obj/`, and `.git/`
- Pin your base image versions for reproducible builds
- Use `dotnet publish` with `-p:PublishTrimmed=true` for smaller images when possible
