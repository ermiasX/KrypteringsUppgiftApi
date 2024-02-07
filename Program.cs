using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello world!!!");

app.MapGet("/kryptera", (string namn) => Kryptera(namn)); 

app.MapGet("/avkryptera", (string krypteratNamn) => Avkryptera(krypteratNamn)); 

app.Run();


string Kryptera(string namn)
{
    if (string.IsNullOrEmpty(namn))
    {
        return "Du måste ange ett namn att kryptera.";
    }

    // Invertera namnet för att kryptera det
    string krypteratNamn = InverteraText(namn);

    return $"Krypterat namn: {krypteratNamn}";
}

string Avkryptera(string krypteratNamn)
{
    if (string.IsNullOrEmpty(krypteratNamn))
    {
        return "Du måste ange det krypterade namnet att avkryptera.";
    }

    // Invertera det krypterade namnet för att avkryptera det
    string avkrypteratNamn = InverteraText(krypteratNamn);

    return $"Avkrypterat namn: {avkrypteratNamn}";
}

// Metod för att invertera texten
string InverteraText(string text)
{
    char[] teckenArray = text.ToCharArray();
    Array.Reverse(teckenArray);
    return new string(teckenArray);
}
