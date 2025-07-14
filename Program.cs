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

app.MapGet("/by", () =>
{
    var myClass = new MyClass();


    return myClass.ReturnBy();
});

app.MapGet("/test", () =>
{
    var myClass = new MyClass();


    return myClass.ReturnTest();
});


app.Run();



public class MyClass
{
    [LogAspect]
    public string ReturnHello()
    {
        Console.WriteLine("Executing ReturnHello method");
        return "Hello from a method!";

    }

    [LogAspect]
    public string ReturnTest()
    {
        Console.WriteLine("Executing ReturnTest method");
        return "Test from a method!";

    }

    [LogAspect]
    public string ReturnBy()
    {
        Console.WriteLine("Executing ReturnHello method");
        return "By from a method!";

    }
}

