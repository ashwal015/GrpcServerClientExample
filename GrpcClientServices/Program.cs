using Grpc.Net.Client;
using GrpcService;

Console.WriteLine("Press any key to continue");
Console.ReadLine();
using var channel = GrpcChannel.ForAddress("https://localhost:7040");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine($"Greetings:{reply.Message}");
Console.WriteLine("Press any key to exit");
Console.ReadLine();