# Atrin Recovery & Development Roadmap

_Last consolidated: 2026-08-10_

## Phase 0 — Baseline recovery

- [x] Identify the canonical repository: `mahmadifarpooyagroup-png/Atrin`
- [x] Confirm `main` as the canonical branch
- [x] Preserve `enterprise-government-platform-foundation-6b1c0` as a recovery reference
- [x] Move `main` to the latest foundation commit
- [x] Record consolidated project memory
- [x] Record this recovery roadmap
- [ ] Remove generated build artifacts from the tracked repository history/tree
- [ ] Verify the solution builds from a clean checkout

## Phase 1 — Local synchronization

1. Save any valuable local work separately before changing the checkout.
2. Fetch `origin`.
3. Compare the local branch with `origin/main`.
4. Do not discard local changes until they have been reviewed.
5. Reset/synchronize the working copy to the canonical `main` only after the comparison.
6. Rebuild the backend and frontend from the synchronized tree.

## Phase 2 — Multi-agent consolidation

For each external copy (Gemini, Qwen, or another local copy):

- identify its commit/file set;
- compare it with `main`;
- classify changes as **keep**, **merge**, **obsolete**, or **unknown**;
- bring only verified changes into a dedicated branch;
- review and then merge into `main`.

Never merge an entire external working directory merely because it is newer by timestamp.

## Phase 3 — Architecture stabilization

- Finalize bounded-context map.
- Finalize dependency direction between Domain, Application, Infrastructure, and API.
- Establish architecture decision records where a major design choice is made.
- Keep product requirements and implementation details separate.

## Phase 4 — Core implementation

Priority order:

1. Identity/authentication foundation
2. Organization and permissions
3. Service Registry
4. Execution/workflow foundation
5. Ticket/queue/appointment
6. Asset and functional-location foundation
7. PM scheduling MVP
8. Finance and government integrations
9. Audit/reporting/notifications
10. Offline/outbox capabilities where justified

## Phase 5 — Quality gate

Before considering a baseline stable:

- clean build
- tests passing
- no generated `bin/` or `obj/` files tracked
- no secrets in source control
- configuration separated by environment
- documented database setup
- documented local development commands
- repository structure matches `PROJECT_STRUCTURE.md`

## Current recovery note

The GitHub foundation branch contains useful application code, but it also contains generated build artifacts despite the accompanying `.gitignore`. The next cleanup should remove those generated artifacts from the tracked tree without deleting legitimate source code.
