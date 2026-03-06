Title: How I Run Code Reviews
Published: 3/7/2026
Tags:
  - leadership
  - engineering
  - culture
---
# How I Run Code Reviews

Code reviews are one of the highest-leverage activities an engineering team can invest in. Done well, they spread knowledge, catch bugs early, and raise the bar for everyone. Done poorly, they slow teams down and breed resentment.

## My Principles

1. **Review the intent, not just the code.** Understand what the author is trying to achieve before nitpicking style.
2. **Be specific.** "This could be better" is not actionable. "Consider extracting this into a method because X" is.
3. **Time-box it.** Reviews sitting open for days lose context. I aim for same-day turnaround.
4. **Separate blocking from non-blocking feedback.** Use a clear convention so authors know what must change vs. what is a suggestion.

## What I Look For

- Does it do what the ticket says?
- Are there tests?
- Will the next developer understand this in six months?
- Are there security or performance concerns?

The goal is not perfection. It is continuous improvement.
