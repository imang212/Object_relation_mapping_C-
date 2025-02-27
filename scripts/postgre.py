import os
import subprocess
import sys

def open_new_command_line():
  subprocess.run(["start", "cmd", "/K"], shell=True)

class PostgreManager:
  @staticmethod
  def start():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()

    if pg_path is None or db_path is None:
      print("Error: PostgreSQL path or database path is None.")
      return

    os.chdir(pg_path)
    subprocess.run([os.path.join(pg_path, "pg_ctl"), "start", "-D", db_path])
    print("Started postgresql server.")
  
  @staticmethod
  def stop():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()

    if pg_path is None or db_path is None:
      print("Error: PostgreSQL path or database path is None.")
      return

    os.chdir(pg_path)
    subprocess.run([os.path.join(pg_path, "pg_ctl"), "stop", "-D", db_path])
    print("Stopped postgresql server.")
  
  @staticmethod
  def _pg_path() -> str:
    try:
      with open(os.path.join(os.path.dirname(__file__), 'pg_path.txt'), 'r') as file:
        return file.read().strip()
    except FileNotFoundError:
      return None
  
  @staticmethod
  def _db_path() -> str:
    return os.path.join(os.path.dirname(__file__), 'db')
  
  @staticmethod
  def set(path):
    with open(os.path.join(os.path.dirname(__file__), 'pg_path.txt'), 'w') as file:
      file.write(path)
    print("Saved.")
  
  @staticmethod
  def install_postgre(path):
    try:
      # Download PostgreSQL server
      subprocess.run(["wget", "https://get.enterprisedb.com/postgresql/postgresql-13.3-1-windows-x64-binaries.zip", "-O", os.path.join(path, "postgresql.zip")], check=True)
      
      # Unzip the downloaded file
      subprocess.run(["unzip", os.path.join(path, "postgresql.zip"), "-d", path], check=True)
      
      # Set the path to the text file
      PostgreManager.set(path)
      
      print("PostgreSQL installed successfully.")
    except subprocess.CalledProcessError as e:
      print(f"Error during installation: {e}")
      


if __name__ == "__main__":
  if len(sys.argv) == 0:
    print("Usage: script postgre [start|stop|install] [path]")
    sys.exit(1)
    
  elif len(sys.argv) >= 1 and sys.argv[0] == "start":
    PostgreManager.start()
    
  elif len(sys.argv) >= 1 and sys.argv[0] == "stop":
    PostgreManager.stop()
    
  elif len(sys.argv) >= 1 and sys.argv[0] == "path":
    if len(sys.argv) >= 3 and sys.argv[0] == "set":
      PostgreManager.set(sys.argv[1])
    elif len(sys.argv) >= 2 and sys.argv[0] == "get":
      print(PostgreManager._pg_path())
    else:
      print("Usage: script postgre path [set <path>|get]")
      
  elif len(sys.argv) >= 1 and sys.argv[0] == "install":
    if len(sys.argv) >= 2:
      PostgreManager.install_postgre(sys.argv[1])
    else:
      print("Usage: script postgre install <path>")
      sys.exit(1)
  
  else:
    print("Unknown command.")
    sys.exit(1)