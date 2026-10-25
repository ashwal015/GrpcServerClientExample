# gRPC Greeter Demo (.NET 10)

A simple gRPC example with a **server** and a **client** in one repository.

The client sends a name to the server, and the server replies with a greeting.

## Project structure

```
.
├── GrpcService/          # gRPC server (ASP.NET Core)
│   ├── Protos/greet.proto
│   ├── Services/GreeterService.cs
│   └── Program.cs
├── GrpcClientServices/   # gRPC client (console app)
│   ├── Protos/greet.proto
│   └── Program.cs
├── .gitignore
└── README.md
```

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- A trusted dev certificate (one-time setup):

```bash
dotnet dev-certs https --trust
```

## Getting started

### 1. Start the server

```bash
cd GrpcService
dotnet run --launch-profile https
```

The server listens on:

- `https://localhost:7040`
- `http://localhost:5078`

### 2. Run the client

Open a second terminal:

```bash
cd GrpcClientServices
dotnet run
```

Expected output:

```
Greetings: Hello <name>
```

## Configuration

The client connects to the server with:

```csharp
using var channel = GrpcChannel.ForAddress("https://localhost:7040");
```

If you change the server port in `GrpcService/Properties/launchSettings.json`, update the address in the client as well.

## Troubleshooting

**`Status(StatusCode="Unavailable", Detail="Error connecting to subchannel.")`**

- Make sure the server is running before starting the client.
- Check that the client address matches the server port.
- If using plain `http://`, the server needs an HTTP/2-only endpoint configured in Kestrel.
- Try `127.0.0.1` instead of `localhost` if `localhost` resolves to IPv6.

## Tech stack

- C# / .NET 10
- gRPC (Grpc.AspNetCore, Grpc.Net.Client)
- Protocol Buffers
