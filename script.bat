setlocal

if "%1"=="" (
  cmd
)

set script_name=%1
shift
set script_path=%cd%\scripts\%script_name%.py

if not exist %script_path% (
  echo script %script_path% not found!
  exit /b 1
)

python %script_path% %*

endlocal