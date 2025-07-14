using TestLamaWithDocker;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();


app.MapOpenApi();


app.MapGet("/hi", () =>
{
    var myClass = new MyClass();
    return myClass.ReturnHello();
});
 

app.Run();



public class MyClass
{
[LogAspect]
public string ReturnHello()
{
global::System.Console.WriteLine("before MyClass.ReturnHello() Calling");try{    Console.WriteLine("Executing ReturnHello method");
    return "Hello from a method!";
}finally{global::System.Console.WriteLine("After MyClass.ReturnHello() Calling");}}
}

