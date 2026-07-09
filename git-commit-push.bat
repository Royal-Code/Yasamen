@echo off
setlocal EnableExtensions

echo Current folder: %cd%

git rev-parse --is-inside-work-tree >nul 2>&1
if errorlevel 1 (
  echo Error: current folder is not a Git repository.
  pause
  exit /b 20
)

git status --porcelain >nul 2>&1
if errorlevel 1 (
  echo Error: failed to read Git status.
  pause
  exit /b 20
)

set "status="
for /f "delims=" %%i in ('git status --porcelain') do set "status=1"
if not defined status (
  echo There are no changes to the repository.
  pause
  exit /b 10
)

set /p "commit_message=Enter the commit message: "
set "commit_message_check=%commit_message: =%"
if not defined commit_message_check (
  echo Error: commit message cannot be empty.
  pause
  exit /b 30
)

git add --all
if errorlevel 1 (
  echo Error: failed to stage files with git add --all.
  pause
  exit /b 40
)

git commit -m "%commit_message%"
if errorlevel 1 (
  echo Error: failed to create commit.
  pause
  exit /b 50
)

git push
if errorlevel 1 (
  echo Error: failed to push changes to remote.
  pause
  exit /b 60
)

echo Git operations completed successfully.
echo --------------------------------------
pause
exit /b 0