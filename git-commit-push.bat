@echo off

echo Current folder: %cd%

git status --porcelain > nul
if errorlevel 1 (
  echo There are no changes to the repository.
  pause
  exit /b 0
)

set /p "commit_message=Enter the commit message: "

git add --all
git commit -m "%commit_message%"
git push

echo Git operations completed successfully.
echo --------------------------------------
pause