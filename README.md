# Loan Application API Documentation

Welcome to the Loan Application API documentation.
This API is designed to manage loan applications for a bank, allowing you to perform CRUD operations on loan applications, retrieve applications based on various criteria, and simulate data using hardcoded objects.

## Endpoints

### 1. Get all loan applications

**Endpoint:** `GET /api/LoanApplication`

**Description:** Retrieve a list of all loan applications.

**Example Response:**
```json
[
  {
    "id": 1,
    "borrower": {
      "id": 101,
      "firstName": "John",
      "surname": "Doe",
      "income": 50000
    },
    "amount": 10000,
    "status": "Submitted",
    "date": "2024-01-20T12:00:00"
  },
  {
    "id": 2,
    "borrower": {
      "id": 102,
      "firstName": "Jane",
      "surname": "Smith",
      "income": 60000
    },
    "amount": 15000,
    "status": "Approved",
    "date": "2024-01-22T12:00:00"
  },
  {
    "id": 3,
    "borrower": {
      "id": 103,
      "firstName": "Bob",
      "surname": "Johnson",
      "income": 75000
    },
    "amount": 12000,
    "status": "Rejected",
    "date": "2024-01-24T12:00:00"
  }
]


### 2. Get a specific loan application by ID
Endpoint: GET /api/LoanApplication/{id}

Description: Retrieve a specific loan application by providing its ID.

Example Response:

{
  "id": 2,
  "borrower": {
    "id": 102,
    "firstName": "Jane",
    "surname": "Smith",
    "income": 60000
  },
  "amount": 15000,
  "status": "Approved",
  "date": "2024-01-22T12:00:00"
}

### 3. Get all loan applications with a certain status
Endpoint: GET /api/LoanApplication/status/{status}

Description: Retrieve all loan applications with a specific status.

Example Response:

[
  {
    "id": 1,
    "borrower": {
      "id": 101,
      "firstName": "John",
      "surname": "Doe",
      "income": 50000
    },
    "amount": 10000,
    "status": "Submitted",
    "date": "2024-01-20T12:00:00"
  }
]

### 4. Get all loan applications made by a specific borrower
Endpoint: GET /api/LoanApplication/borrower/{borrowerId}

Description: Retrieve all loan applications made by a specific borrower, identified by their ID.

Example Response:

[
  {
    "id": 1,
    "borrower": {
      "id": 101,
      "firstName": "John",
      "surname": "Doe",
      "income": 50000
    },
    "amount": 10000,
    "status": "Submitted",
    "date": "2024-01-20T12:00:00"
  }
]

### 5. Create a new loan application
Endpoint: POST /api/LoanApplication

Description: Create a new loan application by providing the necessary details in the request body.

Example Request Body:

{
  "borrower": {
    "id": 104,
    "firstName": "Alice",
    "surname": "Johnson",
    "income": 70000
  },
  "amount": 20000,
  "status": "Submitted"
}

Example Response:

{
  "id": 4,
  "borrower": {
    "id": 104,
    "firstName": "Alice",
    "surname": "Johnson",
    "income": 70000
  },
  "amount": 20000,
  "status": "Submitted",
  "date": "2024-01-25T12:00:00"
}

### 6. Update an existing loan application
Endpoint: PUT /api/LoanApplication/{id}

Description: Update an existing loan application by providing its ID and the updated information in the request body.

Example Request Body:

{
  "amount": 18000,
  "status": "Approved"
}

Example Response:

{
  "id": 4,
  "borrower": {
    "id": 104,
    "firstName": "Alice",
    "surname": "Johnson",
    "income": 70000
  },
  "amount": 18000,
  "status": "Approved",
  "date": "2024-01-25T12:00:00"
}

### 7. Delete an existing loan application
Endpoint: DELETE /api/LoanApplication/{id}

Description: Delete an existing loan application by providing its ID.

Example Response:

{} // Empty response on successful deletion

Request and Response Format
Request Format
For POST and PUT requests, the request body should be in JSON format, following the structure of the loan application.
Response Format
Successful responses will have an HTTP status code of 200 OK or 201 Created along with the requested or created data.
Error responses will include an appropriate HTTP status code along with an error message.