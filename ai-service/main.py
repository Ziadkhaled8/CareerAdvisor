# ai-service/main.py
from fastapi import FastAPI
from pydantic import BaseModel
from typing import List

app = FastAPI()

class UserProfileData(BaseModel):
    skills: List[str]
    interests: List[str]
    goals: List[str]

@app.post("/recommendations")
def get_recommendations(data: UserProfileData):
    # Fake logic for now
    return {
        "recommendations": [
            f"Explore jobs in {data.interests[0]}" if data.interests else "Software Engineer",
            f"Look into opportunities around {data.skills[0]}" if data.skills else "Full Stack Developer"
        ]
    }
