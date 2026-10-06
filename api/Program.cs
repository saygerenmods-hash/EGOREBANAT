var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(); // разрешение для фронтенда

var app = builder.Build();

app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Временные данные — пока без базы данных
var listings = new[]
{
    new { id = 1, title = "Chevrolet Cobalt", price = 15000, area = 2022 },
    new { id = 2, title = "Chevrolet Malibu", price = 25000, area = 2021 },
    new { id = 3, title = "Toyota Camry", price = 32000, area = 2023 },
    new { id = 4, title = "Kia K5", price = 28000, area = 2022 },
    new { id = 5, title = "Hyundai Sonata", price = 27000, area = 2021 },
    new { id = 6, title = "BMW 5 Series", price = 45000, area = 2020 },
    new { id = 7, title = "Mercedes-Benz E-Class", price = 52000, area = 2022 },
    new { id = 8, title = "Lada Vesta", price = 12000, area = 2023 }
};

app.MapGet("/api/listings", () => listings);

app.MapGet("/api/listings/{id:int}", (int id) =>
    listings.FirstOrDefault(l => l.id == id) is {} found
        ? Results.Ok(found)
        : Results.NotFound());

app.Run();