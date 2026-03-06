# bsakel.github.io - Project Instructions

## Overview

Personal blog/site hosted on GitHub Pages, built with [Statiq Framework](https://www.statiq.dev/) (.NET static site generator) using individual Statiq packages (App, Core, Common, Markdown, Razor, Yaml, Hosting).

## Prerequisites

- .NET 10 SDK

## Commands

- `dotnet run --project src/bsakel.github.io` — Build and generate the static site
- `dotnet run --project src/bsakel.github.io -- preview` — Clean build + start local preview server (port 5080)
- `dotnet build` — Compile the project (from solution root)
- `dotnet restore` — Restore NuGet packages

## Project Structure

```
bsakel.github.io/
  bsakel.github.io.slnx                  # Solution file (root, XML format)
  src/
    bsakel.github.io/                    # Main project
      bsakel.github.io.csproj            # Project file (net10.0, Statiq packages)
      Program.cs                         # Bootstrapper entry point (CreateDefault + preview server)
      Pipelines/                         # Custom Statiq pipelines
        PostsPipeline.cs                 # Read/render blog posts from input/posts/*.md
        PagesPipeline.cs                 # Read/render standalone pages (profile.md, etc.)
        ArchivePipeline.cs               # Paginated post listing (homepage, 10 per page)
        TagsPipeline.cs                  # Tag grouping + per-tag pages + tag cloud
        DraftsPipeline.cs                # Read/render drafts (preview-only)
        DraftsArchivePipeline.cs         # Drafts listing page (preview-only)
        AssetsPipeline.cs                # Copy static files (CSS, images)
      input/                             # All site content goes here
        index.cshtml                     # Archive page Razor template
        _Layout.cshtml                   # Root Razor layout (terminal theme)
        _ViewImports.cshtml              # Razor imports for Statiq
        _ViewStart.cshtml                # Sets _Layout as default layout
        assets/css/terminal.css          # Terminal/Gruvbox dark theme
        posts/*.md                       # Published blog posts (YAML front matter: Title, Published, Tags)
        drafts/*.md                      # Draft posts (preview-only, same front matter format)
        drafts/index.cshtml              # Drafts listing page template
        tags/index.cshtml                # Tag page Razor template (tag cloud + per-tag listing)
        profile.md                       # About me page
```

## Adding Content

- Create `.md` files in `src/bsakel.github.io/input/` for pages
- Create `.md` files in `src/bsakel.github.io/input/posts/` for published blog posts (use front matter with `Title`, `Published`, and `Tags` keys)
- Create `.md` files in `src/bsakel.github.io/input/drafts/` for draft posts (same front matter format, only rendered in preview mode)
- See `input/drafts/template-reference.md` for a reference post demonstrating all supported content types
- To promote a draft, move the file from `input/drafts/` to `input/posts/`
- All markdown files are wrapped by `input/_Layout.cshtml`

## Theme

The site uses a terminal-style CSS theme (Gruvbox dark colors):
- Background: `#1d2021`, Foreground: `#ebdbb2`, Accent: `#8ec07c`
- Font: Fira Code (monospace)
- Layout is defined in `input/_Layout.cshtml`

## Architecture

Uses Statiq Framework (individual packages, no Statiq.Web) with 7 custom pipelines:
- **PostsPipeline**: Reads `posts/*.md`, extracts YAML front matter, renders Markdown + Razor
- **PagesPipeline**: Reads standalone `.md` pages, renders Markdown + Razor
- **ArchivePipeline**: Depends on PostsPipeline, paginates posts (10 per page), renders with `index.cshtml`
- **TagsPipeline**: Depends on PostsPipeline + DraftsPipeline, groups by Tags metadata, creates per-tag pages + tag cloud overview. In preview mode, includes drafts (marked with `[draft]` badge)
- **DraftsPipeline**: Reads `drafts/*.md`, only active when `IsPreview` setting is true (preview mode)
- **DraftsArchivePipeline**: Depends on DraftsPipeline, lists all drafts at `/drafts/`, only active in preview mode
- **AssetsPipeline**: Copies `assets/**/*` to output
