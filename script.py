import os
import shutil
import subprocess
import sys
import time
import zipfile

try:
    import requests
except ImportError:
    subprocess.check_call([sys.executable, "-m", "pip", "install", "requests"])
    import requests

class PostgreManager:
  @staticmethod
  def start():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()

    if pg_path is None or db_path is None:
      print("Error: PostgreSQL path or database path is None.")
      return

    os.chdir(pg_path)
    print(os.path.join(pg_path, "bin", "pg_ctl"))
    subprocess.run([os.path.join(pg_path, "bin", "pg_ctl"), "start", "-D", db_path])
  
  @staticmethod
  def stop():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()

    if pg_path is None or db_path is None:
      print("Error: PostgreSQL path or database path is None.")
      return

    os.chdir(pg_path)
    subprocess.run([os.path.join(pg_path, "bin", "pg_ctl"), "stop", "-D", db_path])
    print("Stopped postgresql server.")
  
  @staticmethod
  def _pg_path() -> str:
    try:
      with open(os.path.join(os.path.dirname(__file__), ".aria", 'pg_path.txt'), 'r') as file:
        return file.read().strip()
    except FileNotFoundError:
      return None
  
  @staticmethod
  def _py_path() -> str:
    try:
      with open(os.path.join(os.path.dirname(__file__), ".aria", 'py_path.txt'), 'r') as file:
        return file.read().strip()
    except FileNotFoundError:
      return None
  
  @staticmethod
  def _db_path() -> str:
    folder = os.path.dirname(__file__)
    return os.path.join(folder, 'db')
  
  @staticmethod
  def set(path):
    if path == None:
      path = os.path.join(os.path.dirname(__file__), "postgresql")
      
    with open(os.path.join(os.path.dirname(__file__), ".aria", 'pg_path.txt'), 'w') as file:
      file.write(path)
    print("Saved.")
  
  @staticmethod
  def install_postgre(path:str = None):
    path = path if path else os.path.join(os.path.dirname(__file__), "postgre")
    try:
      # Create the directory if it doesn't exist
      os.makedirs(path, exist_ok=True)
      
      # Download PostgreSQL server
      #subprocess.run(["wget", "https://get.enterprisedb.com/postgresql/postgresql-17.4-1-windows-x64-binaries.zip", "-O", os.path.join(path, "postgresql.zip")], check=True)
      #subprocess.run(["wget", "https://get.enterprisedb.com/postgresql/postgresql-13.3-1-windows-x64-binaries.zip", "-O", os.path.join(path, "postgresql.zip")], check=True)
      
      print("Downloading...")
      url = "https://get.enterprisedb.com/postgresql/postgresql-17.4-1-windows-x64-binaries.zip"
      response = requests.get(url)
      with open(os.path.join(path, "postgresql.zip"), 'wb') as file:
        file.write(response.content)
      
      # Unzip the downloaded file
      print("Unzipping...")
      PostgreManager._unzip_file(os.path.join(path, "postgresql.zip"), path)
      #subprocess.run(["unzip", os.path.join(path, "postgresql.zip"), "-d", path], check=True)
      
      # Set the path to the text file
      PostgreManager.set(os.path.join(path, "pgsql"))
      
      print("PostgreSQL installed successfully.")
    except subprocess.CalledProcessError as e:
      print(f"Error during installation: {e}")
      try:
        PostgreManager.uninstall_postgre(path)
      except:
        print("Fatal error")
  
  @staticmethod
  def uninstall_postgre(path:str = None):
    path = path if path else os.path.join(os.path.dirname(__file__), "postgre")
    print("Uninstalling.")
    try:
      if os.path.exists(path):
        shutil.rmtree(path)
        print(f"PostgreSQL uninstalled successfully from {path}.")
      else:
        print(f"Path {path} does not exist.")
    except subprocess.CalledProcessError as e:
      print(f"Error during uninstallation: {e}")
  
  @staticmethod
  def reinstall_postgre(path:str = None):
    PostgreManager.uninstall_postgre(path)
    PostgreManager.install_postgre(path)
  
  def init_database():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()

    if pg_path is None or db_path is None:
        print("Error: PostgreSQL path or database path is None.")
        return

    os.chdir(pg_path)
    print(os.path.join(pg_path, "bin", "pg_ctl"))
    subprocess.run([os.path.join(pg_path, "bin", "initdb"), "-E", "UTF8", "-U", "postgres", "-D", db_path])

  @staticmethod
  def fill_database():
    pg_path = PostgreManager._pg_path()
    db_path = PostgreManager._db_path()
    py_path = PostgreManager._py_path()
    folder = os.path.dirname(__file__)

    subprocess.run([py_path, os.path.join(folder, "scripts", "db_init.py")])

  @staticmethod
  def remove_database():
    path = PostgreManager._db_path()
    print("Uninstalling.")
    try:
      if os.path.exists(path):
        shutil.rmtree(path)
        print(f"PostgreSQL uninstalled successfully from {path}.")
      else:
        print(f"Path {path} does not exist.")
    except subprocess.CalledProcessError as e:
      print(f"Error during uninstallation: {e}")

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
        path = str.join(command[3:])
        PostgreManager.set(path)
      elif len(command) >= 2 and command[1] == "get":
        print(PostgreManager._pg_path())
      else:
        print("Usage: path [set <path>|get]")
        
    elif len(command) >= 1 and command[0] == "install":
      PostgreManager.install_postgre(command[1] if len(command) >= 2 else None)
        
    elif len(command) >= 1 and command[0] == "uninstall":
      PostgreManager.uninstall_postgre(command[1] if len(command) >= 2 else None)
        
    elif len(command) >= 1 and command[0] == "reinstall":
      PostgreManager.reinstall_postgre(command[1] if len(command) >= 2 else None)
        
    elif len(command) >= 1 and command[0] == "database":
      if len(command) >= 2 and command[1] == "init":
        PostgreManager.init_database()
      elif len(command) >= 2 and command[1] == "fill":
        PostgreManager.fill_database()
      elif len(command) >= 2 and command[1] == "remove":
        PostgreManager.remove_database()
      elif len(command) >= 2 and command[1] == "reinstall":
        PostgreManager.stop()
        PostgreManager.remove_database()
        PostgreManager.init_database()
        PostgreManager.start()
        PostgreManager.fill_database()
        PostgreManager.stop()
      else:
        print("Usage: database [init|fill")
        
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

  @staticmethod
  def _unzip_file(zip_path, extract_to):
    try:
      with zipfile.ZipFile(zip_path, 'r') as zip_ref:
        for file_info in zip_ref.infolist():
          try:
            zip_ref.extract(file_info, extract_to)
            print(f"Unzipped {file_info.filename} to {extract_to}")
          except (zipfile.BadZipFile, Exception) as e:
            print(f"Error unzipping {file_info.filename}: {e}")
    except (zipfile.BadZipFile, Exception) as e:
      print(f"Error opening zip file {zip_path}: {e}")
      return False
    return True
  
class HelpManager:
  @staticmethod
  def resolve_command(command):
    print("Commands")
    print("help - Show this help message")
    print("faq - Frequently Asked Questions")
    print("postgre - Manage PostgreSQL server")
    print("exit - Exit the program")

class FAQManager:
  @staticmethod
  def resolve_command(command):
    if len(command) == 0:
      print("FAQ")
      print("1. What is pg_path and py_path?")
      print("   - pg_path is the path to the PostgreSQL installation directory.")
      print("   - py_path is the path to the Python installation directory.")
      print("2. This tool failed installing PostgreSQL. What now?")
      print("   - You tried to install PostgreSQL by running the 'postgre install <path>' command.")
      print("   - Alternatively, you can manually install PostgreSQL by downloading it from the official website (https://www.postgresql.org/download/), running the installer, and following the installation instructions.")
      print("   - You can start the PostgreSQL server by running the 'pg_ctl start -D <data_directory>' command in the PostgreSQL command line interface.")
      print("   - You can stop the PostgreSQL server by running the 'pg_ctl stop -D <data_directory>' command in the PostgreSQL command line interface.")
      print("5. How do I get help with commands?")
      print("   - You can get help with commands by running the 'help' command.")
    else:
      print("Unknown FAQ command.")

def main():
  if not os.path.exists(os.path.join(os.path.dirname(__file__), ".aria", "has_been_run_before.check")):
    display_first_time_message()
  command = ""
  
  while True:
    command_line = input("Enter command: ")
    command = command_line.strip().split()
    os.system("clear")
    print(">", command_line)
    print()
    
    if len(command) == 0:
      print("Unknown command. Use help.")
      continue
    
    elif len(command) >= 1 and command[0] == "exit":
      print("Bye!")
      print()
      break
    
    elif len(command) >= 1 and command[0] == "postgre":
      PostgreManager.resolve_command(command[1:])
    
    elif len(command) >= 1 and command[0] == "help":
      HelpManager.resolve_command(command[1:])
    
    elif len(command) >= 1 and command[0] == "faq":
      FAQManager.resolve_command(command[1:])
    
    else:
      print("Unknown command. Use help.")
    
    print()

def reopen():
  subprocess.run([sys.executable, __file__])

def display_first_time_message():
  print()
  print("Welcome! It looks like this is your first time running the script.")
  print("We recommend you to run the following commands to get started:")
  print("    faq - Frequently Asked Questions")
  print("    help - Show help message")
  print("    <command> help - Get help for a specific command")
  os.makedirs(os.path.join(os.path.dirname(__file__), ".aria"), exist_ok=True)
  with open(os.path.join(os.path.dirname(__file__), ".aria", "has_been_run_before.check"), 'w') as file:
    file.write("This file is used to check if the script has been run before.")
  print()

if __name__ == "__main__":
  if len(sys.argv) > 1 and sys.argv[1] == "batch":
    reopen()
  else:
    main()