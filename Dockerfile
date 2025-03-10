# Use a stable version of Python
FROM python:3.9

# Set working directory to /src
WORKDIR /src

# Copy requirements.txt to /src and install dependencies
COPY requirements.txt /src/requirements.txt
RUN pip install --no-cache-dir --upgrade -r /src/requirements.txt

# Copy all application code from src to /src
COPY ./src /src

# Expose the application port (default FastAPI port is 8000)
EXPOSE 80

# Run the application using Uvicorn
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "80"]
