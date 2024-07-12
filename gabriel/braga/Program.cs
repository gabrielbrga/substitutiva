using braga.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//http://localhost:5179
app.MapPost("/aluno/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Aluno aluno) =>
{
    if (ctx.Alunos.Any(a => a.Nome == aluno.Nome && a.Sobrenome == aluno.Sobrenome))
    {
        return Results.BadRequest("esse aluno ja existe");
    }

    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created($"/aluno/{aluno.AlunoId}", aluno);
});

app.Run();
