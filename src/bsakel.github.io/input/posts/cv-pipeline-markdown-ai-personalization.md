Title: Building a Markdown-First CV Pipeline
Published: 7/10/2026
Tags:
  - cv
  - ai
  - automation
  - pipelines
  - github-actions
---
# Building a Markdown-First CV Pipeline

Keeping a CV current sounds simple until the updates become frequent, role-specific, and easy to postpone.

My current flow works, but it is still too manual to keep high quality over time. The goal of the next iteration is a pipeline that makes updates cheap, personalization explicit, and output reproducible.

## Problem: CV Drift Is a Process Issue

The real problem is not writing a CV. It is maintaining one under real project velocity.

When experience changes weekly, static documents age fast. Small edits get delayed, then bundled, then forgotten. By the time a role appears, the source CV usually needs cleanup before it can be tailored.

## Why Move Authoring to Markdown + Templates

I already use a markdown-first workflow for this blog, and it scales well: content stays readable, diffable, and easy to version.

Applying the same model to the CV gives a cleaner source of truth:

- Markdown files for canonical experience, skills, and project highlights
- Template-driven HTML render for layout and branding
- Git history as audit trail for every change

This is simpler than editing visual formats directly, and much easier to automate.

## Proposed Pipeline (Including AI Personalization)

The planned flow is:

1. Author canonical CV content in markdown.
2. Parse markdown into structured data.
3. Run an AI personalization step against a role description.
4. Render personalized HTML from templates.
5. Keep the existing HTML -> PDF GitHub Action as the final release step.

The key design choice is where AI runs: **before HTML rendering**, not after.  
That keeps personalization at the content layer while preserving deterministic presentation.

### Guardrails for the AI Layer

Personalization should improve relevance, not invent facts. Initial guardrails:

- Only rewrite approved sections (summary, ordering, emphasis), not core facts
- Never introduce skills or achievements missing from the source markdown
- Produce a machine-readable diff against canonical content
- Require human approval before publishing artifacts
- Keep prompt/version metadata for traceability and reproducibility

## High-Level Architecture

At a high level:

- **Content layer:** markdown CV source files
- **Transformation layer:** parser + schema normalization
- **Personalization layer:** constrained AI rewrite with validation
- **Presentation layer:** HTML templates
- **Distribution layer:** existing PDF action and release artifacts

This separates concerns so each stage can evolve independently.

## Phased Rollout Plan

I will implement this in phases to avoid breaking the current workflow.

1. **Phase 1 - Markdown parity:** Represent current CV in markdown and render equivalent HTML output.
2. **Phase 2 - Optional AI path:** Add role-based personalization as a gated, review-first step.
3. **Phase 3 - Release hardening:** Add validation, metadata capture, and predictable artifact naming.
4. **Phase 4 - Public template repo (`cv-template`):** Extract a reusable template/pipeline so others can bootstrap the same setup.

## Tradeoffs and Risks

This approach has real risks:

- **Hallucination risk:** AI can generate plausible but false claims.
- **Over-customization risk:** Tailoring too aggressively can dilute core positioning.
- **Reproducibility risk:** Non-deterministic model output can make builds hard to compare.

The mitigation strategy is strict constraints, review gates, and full provenance on generated variants.

If this design works, the CV becomes a maintainable system instead of a document that slowly drifts.
