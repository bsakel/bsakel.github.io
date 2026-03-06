# bsakel.github.io

Personal blog hosted on GitHub Pages, built with [Statiq Framework](https://www.statiq.dev/) and styled with a terminal-inspired Gruvbox dark theme.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Run Locally

```bash
dotnet run --project src/bsakel.github.io -- preview
```

Builds the site and starts a local preview server at `http://localhost:5080`.

## Add Content

Create Markdown files in `src/bsakel.github.io/input/`. Use YAML front matter for metadata:

```markdown
Title: My Post Title
Published: 2026-03-05
Tags:
  - dotnet
  - tutorial
---
# Hello

Post content goes here.
```

Place blog posts in `src/bsakel.github.io/input/posts/` for automatic blog pipeline handling.

### Drafts

Create Markdown files in `src/bsakel.github.io/input/drafts/` using the same front matter format. Drafts are only rendered when running in preview mode (`-- preview`) and are not included in production builds. In preview mode a "drafts" link appears in the header nav, draft posts show a `[draft]` badge, and draft tags are merged into the tags page.

To promote a draft to a published post, move it from `input/drafts/` to `input/posts/`.

A template reference post is available at `input/drafts/template-reference.md` demonstrating all supported content types (images, links, YouTube embeds, code blocks, tables, etc.).

## Project Structure

```
bsakel.github.io/
  bsakel.github.io.slnx             # Solution file (root, XML format)
  src/
    bsakel.github.io/               # Main project
      bsakel.github.io.csproj
      Program.cs                    # Statiq bootstrapper + preview server
      Pipelines/                    # Custom pipelines (Posts, Pages, Archive, Tags, Drafts, Assets)
      input/                        # All site content (Markdown, Razor, assets)
        _Layout.cshtml              # Root layout with terminal theme
        assets/css/terminal.css     # Gruvbox dark terminal stylesheet
        posts/*.md                  # Published blog posts
        drafts/*.md                 # Draft posts (preview-only)
```

## Theme

The site uses a custom terminal CSS theme with Gruvbox dark colors:

- **Background:** `#1d2021`
- **Foreground:** `#ebdbb2`
- **Accent:** `#8ec07c`
- **Font:** [Fira Code](https://github.com/tonsky/FiraCode)

## TODO

- **E2E tests** (`tests/`) — The old Playwright-based tests validated the generated site structure and content. New tests should be written to cover the current Statiq Framework pipelines and output.
