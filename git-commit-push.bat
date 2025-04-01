@echo off

echo Current folder: %cd%

for /f "delims=" %%i in ('git status --porcelain') do set status=%%i
if not defined status (
  echo There are no changes to the repository.
  pause
  exit /b 0
)

set /p "commit_message=Enter the commit message: "

git add --all
git commit -m "%commit_message%"
git push origin HEAD:main

echo Git operations completed successfully.
echo --------------------------------------
pause