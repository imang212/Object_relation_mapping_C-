import os
import subprocess
import sys

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
        PostgreManager.set(path)
      elif len(command) >= 2 and command[1] == "get":
        print(PostgreManager._pg_path())
      else:
        print("Usage: path [set <path>|get]")
        
    elif len(command) >= 1 and command[0] == "install":
      PostgreManager.install_postgre(command[1] if len(command) >= 2 else None)
        
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