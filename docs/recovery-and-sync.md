# Atrin Recovery & Sync Procedure

_Last updated: 2026-08-10_

## Canonical source

`main` on GitHub is the canonical baseline.

The old local/Qwen/Gemini copies must not be treated as authoritative until their differences are inspected.

## 1. Protect the current local copy first

From the existing local Atrin folder:

```powershell
git status --short
git branch --show-current
git remote -v
```

If there are valuable uncommitted changes, create a backup branch and a patch before synchronizing:

```powershell
git switch -c backup/local-before-github-sync
 git diff > ..\Atrin-local-before-github-sync.patch
 git status --short
```

If the folder contains important untracked files, copy the entire folder to a separate backup location before deleting/replacing anything.

## 2. Create a complete Git backup

After the remote is configured:

```powershell
git fetch origin --prune
git bundle create ..\Atrin-git-backup.bundle --all
```

The `.bundle` file is a portable Git backup of the repository history.

## 3. Synchronize the working copy to GitHub main

Only after the local backup is safe:

```powershell
git fetch origin --prune
git switch main
git reset --hard origin/main
git clean -fd
```

`git clean -fd` removes untracked files. Do not run it before making the backup above.

## 4. Verify the synchronized checkout

```powershell
git status
cd Atrin\backend
dotnet restore Atrin.sln
dotnet build Atrin.sln
cd ..\frontend\web
npm install
npm run build
```

The expected Git status after synchronization is clean.

## 5. Qwen / Qwen Code migration

Do not ask Qwen to merge its old project directory into the new one. That is how the project became fragmented.

Instead, give Qwen the GitHub repository URL and tell it that `main` is authoritative. The old Qwen workspace should first be backed up, then replaced/synchronized from `origin/main`.

Recommended instruction:

> This is the new canonical Atrin baseline. Ignore the previous Atrin workspace as an authoritative source. Preserve it only as a backup. Fetch the repository from GitHub, switch to `main`, and make the working directory exactly match `origin/main`. Do not merge old uncommitted code automatically. After synchronization, inspect the repository structure and report the build status before making any feature changes.

## 6. Gemini changes

There is no automatic way for this repository connector to recover changes that existed only inside a Gemini conversation or an uncommitted Gemini workspace. Those changes must be exported or committed to a branch before they can be compared with `main`.

When such a branch/copy becomes available, compare it against `main` and classify every difference as:

- KEEP — clearly improves the current architecture/code
- MERGE — useful but requires adaptation
- OBSOLETE — replaced by the current baseline
- REVIEW — unclear or potentially conflicting

Never replace `main` wholesale with an external AI workspace.

## 7. Rule for future AI agents

GitHub `main` is the source of truth. Every agent works from a fresh/synchronized branch and commits intentional changes. No agent should silently rewrite or replace another agent's work.
