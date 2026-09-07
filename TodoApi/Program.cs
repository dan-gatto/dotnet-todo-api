var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var todos = new List<object>
{
    new { Id = 1, Title = "Task 1", Completed = false },
    new { Id = 2, Title = "Task 2", Completed = true },
    new { Id = 3, Title = "Task 3", Completed = false }
};

app.MapGet("/todos", () => todos)
    .WithName("GetTodos");

app.Run();
