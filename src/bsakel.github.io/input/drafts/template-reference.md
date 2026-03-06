Title: Template Reference Post
Published: 1/1/2000
Tags:
  - template
  - reference
---
# Template Reference Post

This post demonstrates all supported content types. Use it as a starting point for new posts.

## Text Formatting

Regular paragraph text. You can use **bold**, *italic*, ***bold italic***, and ~~strikethrough~~.

Inline `code` looks like this.

## Links

- [External link](https://example.com)
- [Link to another post](/posts/ai-tools-engineering-manager)
- [Link to a section on this page](#images)

## Images

Image from the assets folder (place files in `input/assets/images/`):

![Alt text describing the image](/assets/images/your-giffed-face.gif)

Image from an external URL:

![Octocat](https://github.githubassets.com/images/icons/emoji/octocat.png)

Image with a caption using HTML figure:

<figure>
  <img src="/assets/images/your-giffed-face.gif" alt="Description of the image" />
  <figcaption>This is the image caption</figcaption>
</figure>

## Embedded YouTube Video

<div class="video-container">
  <iframe src="https://www.youtube.com/embed/dQw4w9WgXcQ" title="YouTube video" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
</div>

## Blockquotes

> This is a blockquote. Use it for callouts or citations.

## Code Blocks

```csharp
public class Example
{
    public string Name { get; set; }

    public void Greet()
    {
        Console.WriteLine($"Hello, {Name}!");
    }
}
```

## Lists

Unordered:

- Item one
- Item two
  - Nested item
  - Another nested item
- Item three

Ordered:

1. First step
2. Second step
3. Third step

## Tables

| Column A | Column B | Column C |
|----------|----------|----------|
| Row 1    | Data     | More     |
| Row 2    | Data     | More     |

## Horizontal Rule

---

## HTML in Markdown

You can use raw HTML when Markdown isn't enough:

<details>
<summary>Click to expand</summary>

Hidden content goes here. You can put any Markdown or HTML inside.

</details>

## Front Matter Reference

Every post needs YAML front matter at the top:

```yaml
Title: My Post Title
Published: 3/6/2026
Tags:
  - tag-one
  - tag-two
---
```

- **Title** -- displayed as the page title
- **Published** -- date in M/D/YYYY format, used for sorting
- **Tags** -- list of tags, shown on the post and in the tag cloud
