@echo off
setlocal

REM Read the Python interpreter path from the file
set "PY_PATH_FILE=%~dp0.aria\py_path.txt"
set /p PYTHON_PATH=<"%PY_PATH_FILE%"

REM Run the script.py using the Python interpreter
"%PYTHON_PATH%" "%~dp0script.py" batch

endlocal