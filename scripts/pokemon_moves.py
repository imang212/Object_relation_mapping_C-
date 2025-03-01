from sqlalchemy import create_engine, MetaData, Table
from sqlalchemy.orm import sessionmaker

# Database connection details
DATABASE_URL = "postgresql://postgres:@localhost/postgres"

# Create an engine and connect to the PostgreSQL database
engine = create_engine(DATABASE_URL)
metadata = MetaData()

# Reflect the tables
pokemon_data = Table('pokemon_data', metadata, autoload_with=engine)
pokemon_moves = Table('pokemon_moves', metadata, autoload_with=engine)
competitive_pokemon = Table('competitive_pokemon', metadata, autoload_with=engine)
pokemon_move_learn = Table('pokemon_move_learn', metadata, autoload_with=engine)

# Create a configured "Session" class
Session = sessionmaker(bind=engine)

# Create a Session
session = Session()

# Update the pokemon_move_learn table


# Commit the transaction
session.commit()