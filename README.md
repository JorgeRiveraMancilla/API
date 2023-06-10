# Simple Application

This is a simple application that demonstrates the basic setup and execution of a .NET project. Follow the instructions below to get started.

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download) installed on your machine.

## Getting Started

### Clone the Repository

1. Open a terminal or command prompt.
2. Run the following command to clone the repository:
   ```
   git clone https://github.com/JorgeRiveraMancilla/API.git
   ```

### Build and Run the Application

1. Navigate to the project directory:
   ```
   cd API
   ```

2. Run the following command to restore the project dependencies:
   ```
   dotnet restore
   ```

3. Once the dependencies are restored, you can run the application:
   ```
   dotnet run
   ```

   The application will build and start running. You should see the output on the console.

### Testing the Application

To test the application's endpoints, you can import the included Postman file:

1. Open Postman.
2. Click on "Import" and select the provided `Requests.postman_collection.json` file.
3. The collection will be imported into Postman, containing the necessary endpoints to test the application.
4. You can then send requests to the application's endpoints and examine the responses.