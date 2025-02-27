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
      with open(os.path.join(os.path.dirname(__file__), ".aria", 'pg_path.txt'), 'r') as file:
        return file.read().strip()
    except FileNotFoundError:
      return None
  
  @staticmethod
  def _db_path() -> str:
    folder = os.path.dirname(__file__)
    return os.path.join(folder, 'db')
  
  @staticmethod
  def set(path):
    with open(os.path.join(os.path.dirname(__file__), ".aria", 'pg_path.txt'), 'w') as file:
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
  
  @staticmethod
  def resolve_command(command):
    if len(command) == 0:
      print("Unknown command. Use help.")
      
    elif len(command) >= 1 and command[0] == "start":
      PostgreManager.start()
      
    elif len(command) >= 1 and command[0] == "stop":
      PostgreManager.stop()
      
    elif len(command) >= 1 and command[0] == "path":
      if len(command) >= 3 and command[1] == "set":
        path = " ".join(command[2:])
        PostgreManager.set(path)
      elif len(command) >= 2 and command[1] == "get":
        print(PostgreManager._pg_path())
      else:
        print("Usage: path [set <path>|get]")
        
    elif len(command) >= 1 and command[0] == "install":
      if len(command) >= 2:
        PostgreManager.install_postgre(command[1])
      else:
        print("Usage: install <path>")
        sys.exit(1)
        
    elif len(command) >= 1 and command[0] == "help":
      print("Commands for postgre")
      print("postgre start - Start PostgreSQL server")
      print("postgre stop - Stop PostgreSQL server")
      print("postgre path set <path> - Get or set the path to PostgreSQL server")
      print("postgre path get - Get or set the path to PostgreSQL server")
      print("postgre install <path> - Install PostgreSQL server")
      print("postgre exit - Exit the program")
    
    elif len(command) >= 1 and command[0] == "exit":
      sys.exit(1)
    
    else:
      print("Unknown command.") 

class HelpManager:
  @staticmethod
  def resolve_command(command):
    print("Commands")
    print("help - Show this help message")
    print("postgre - Manage PostgreSQL server")
    print("exit - Exit the program")

def main():
  command = ""
  
  while True:
    command = input("Enter command: ").strip().split()
    
    if len(command) == 0:
      print("Unknown command. Use help.")
      continue
    
    elif len(command) >= 1 and command[0] == "exit":
      break
    
    elif len(command) >= 1 and command[0] == "postgre":
      PostgreManager.resolve_command(command[1:])
    
    elif len(command) >= 1 and command[0] == "help":
      HelpManager.resolve_command(command[1:])
    
    else:
      print("Unknown command. Use help.")
  
if __name__ == "__main__":
  main()