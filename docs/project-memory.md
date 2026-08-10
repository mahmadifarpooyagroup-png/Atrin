# Atrin Project Memory

_Last consolidated: 2026-08-10_

## 1. Product identity

- Product: **Atrin Smart Service Platform (ASSP)**
- Business domain: government service counter / Pishkhan, with internet-cafe, mobile-service, accessory-sales, and financial/tax service workflows.
- The long-term goal is an enterprise-grade service platform rather than a one-off counter application.

## 2. Source of truth

From this consolidation point onward, GitHub `main` is the canonical project baseline.

Work may still exist in old local folders or in copies produced with Gemini/Qwen/other coding agents. Those copies are treated as **sources to compare**, not as authoritative versions. No local copy should overwrite `main` blindly.

## 3. Architecture direction

The project follows a domain-oriented modular architecture with bounded contexts. The previously defined target model contains 14 contexts, centered around:

1. Foundation & Core
2. Identity
3. Service Registry
4. Execution / Workflow
5. Ticketing
6. Queue
7. Appointment
8. Asset
9. Finance
10. Infrastructure
11. Government integrations
12. Notifications / communication
13. Audit / compliance
14. Reporting / analytics

The exact context boundaries should be refined from the repository rather than recreated from memory when implementation work resumes.

## 4. Backend foundation

Current repository direction:

- .NET 9
- `Atrin.Api`
- `Atrin.Application`
- `Atrin.Domain`
- `Atrin.Infrastructure`
- `Atrin.Shared`
- PostgreSQL/Npgsql direction
- EF Core
- JWT/authentication foundation
- validation and application behaviors
- centralized exception handling
- health checks
- Docker API foundation

## 5. Frontend foundation

Current foundation uses Vite + TypeScript. The frontend is intended to become the web client for the modular service platform.

## 6. Domain concepts already established

### Identity

- User identity and authentication are foundational.
- `owner_department` and `responsible_user_id` are important ownership/responsibility concepts for managed resources.

### Asset / EAM direction

The platform is intended to support enterprise asset management concepts comparable in capability direction to SAP PM, IBM Maximo, Infor EAM, Hexagon EAM, MaintainX, Fiix, UpKeep, and Limble.

Important asset concepts include:

- Functional Location Tree
- Asset hierarchy
- Criticality Matrix
- ownership and responsibility
- preventive maintenance
- counter-based and time-based scheduling

### PM MVP direction

The previously agreed MVP direction includes:

- Time-Based Scheduling
- Counter-Based Scheduling
- Floating Scheduling
- Master Task Lists
- Batch Work-Order Generation

### Offline-first direction

The platform should be designed for resilient/offline-capable workflows where appropriate, using concepts such as:

- Command Queue
- client-side event/command sourcing where justified
- Outbox pattern
- IndexedDB, with Dexie.js or RxDB as candidates

## 7. Documentation direction

Architecture documentation belongs under `docs/architecture/` and should include, as the structure matures:

- organization context
- identity context
- service registry
- context map
- remaining bounded-context definitions

Do not recreate documents that already exist without first comparing them with the current branch.

## 8. Recovery principle

The current task is **consolidation, not a rewrite**.

Sequence:

1. Preserve the current GitHub history.
2. Keep the latest foundation branch available as a recovery reference.
3. Make `main` the canonical baseline.
4. Record project memory and roadmap in the repository.
5. Inspect the local checkout before replacing it.
6. Compare any Gemini/Qwen/local changes against `main`.
7. Promote only verified, intentional changes.
8. After synchronization, continue development from the clean canonical checkout.

## 9. What is not yet recovered

The repository cannot automatically recover work that exists only inside a separate Gemini session or an uncommitted local folder. Such work must be supplied by exporting it, committing it to a branch, or making the local checkout available for comparison.

Therefore this document records the consolidated architectural/product memory already established, while code remains governed by the actual Git history.
