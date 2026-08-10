# Atrin Smart Service Platform (ASSP)

## Current status

GitHub `main` is the restored project baseline as of 2026-08-10. It currently points to the latest stable-foundation commit previously developed on `enterprise-government-platform-foundation-6b1c0`.

The repository is being consolidated after work was performed in multiple environments (ChatGPT, Gemini, Qwen, and a local checkout). The GitHub repository is the source of truth from this point forward.

## Product

**Atrin Smart Service Platform (ASSP)** is the software platform for the Atrin government-service counter (Pishkhan), designed to evolve into an enterprise service platform.

## Architecture direction

The target architecture is domain-oriented and modular, with bounded contexts covering foundation/core, identity, service registry, execution/workflow, ticket/queue/appointment, asset/finance, infrastructure, and government integrations.

The backend foundation currently uses .NET 9 with separate Domain, Application, Infrastructure, Shared, and API projects. The frontend foundation uses Vite/TypeScript.

## Important rule

Do not treat old local, Qwen, or other uncommitted copies as authoritative. First compare them against `main`; only intentional changes are promoted into GitHub.

See:

- `docs/project-memory.md` — consolidated project memory and decisions
- `docs/roadmap.md` — recovery and next-step plan
- `PROJECT_STRUCTURE.md` — current repository structure
