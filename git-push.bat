@echo off
for /f %%i in ('git rev-parse --abbrev-ref HEAD') do set current_branch=%%i
for /f %%i in ('git rev-list origin/%current_branch%..HEAD ^| find /c /v ""') do set pending_commits=%%i
if %pending_commits% gtr 0 (
  echo There are %pending_commits% commits pending to be pushed in branch %current_branch%.
  git push origin %current_branch%
  echo Push completed for branch %current_branch%.
) else (
  echo No commits pending to be pushed in branch %current_branch%.
)
pause