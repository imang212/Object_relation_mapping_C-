import os
import subprocess

folder_path = os.path.dirname(os.path.abspath(__file__))

for file_name in os.listdir(folder_path):
  if file_name.endswith('.py'):
    print(file_name)