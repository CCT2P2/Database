from fastapi import FastAPI
import sqlite3

app = FastAPI()
DATABASE = "src/GNUF.sqlite"

class Database:
    def __init__(self):
        self.conn = sqlite3.connect(DATABASE)
        self.cursor = self.conn.cursor()

    def execute_query(self, query: str):
        self.cursor.execute(query)
        return self.cursor.fetchall()

    def execute_one(self, query: str):
        self.cursor.execute(query)
        return self.cursor.fetchone()

    def close(self):
        self.conn.close()

db = Database()

@app.get("/")
async def root():
    return {"message": "Hello World"}

@app.get("/user/{USER_ID}")
async def get_user(USER_ID: int):
    return db.execute_one(f"SELECT * FROM USER WHERE USER_ID = {USER_ID}")

@app.get("/comm/{communityID}")
async def get_community(communityID: int):

    return db.execute_one(f"SELECT * FROM COMMUNITY WHERE COMMUNITY_ID = {communityID}")

@app.get("/login/{userName}")
async def check_login(userName: str):
    return db.execute_one(f"SELECT PASSWORD FROM USER WHERE USER_NAME = {userName}")

@app.get("/userposts/{authorID}")
async def user_posts(authorID: int):
    return db.execute_query(f"SELECT * FROM POST WHERE AUTHOR_ID = {authorID} ORDER BY timestamp DESC")

@app.get("/commposts/{communityID}")
async def comm_posts(communityID: int):
    return db.execute_query(f"SELECT * FROM POST WHERE COMMUNITY_ID = {communityID} ORDER BY timestamp DESC")

@app.get("/commuserposts/{data}") # "COMMUNITY_ID,AUTHOR_ID
async def comm_user_posts(data: str):
    data = data.split(",")
    return db.execute_query(f"SELECT * FROM POST WHERE COMMUNITY_ID = {data[0]} AND AUTHOR_ID = {data[1]} ORDER BY timestamp DESC")
