
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var tareas = new List<TareaAPI>
{
    new TareaAPI(1, "Revisar las clases", "Repasar los materiales", true),
    new TareaAPI(2, "Completar las asignaciones", "Terminar los trabajos pendientes", false),
    new TareaAPI(3, "Estudiar para los exámenes", "Prepararse para las evaluaciones", false)
};

app.MapGet("/", () => "API REST de UniPlan funcionando");

app.MapGet("/api/tareas", () => tareas);

app.MapGet("/api/tareas/{id}", (int id) =>
{
    var tarea = tareas.FirstOrDefault(t => t.Id == id);

    return tarea is not null
        ? Results.Ok(tarea)
        : Results.NotFound();
});

app.Run();

record TareaAPI(int Id, string Nombre, string Descripcion, bool Completada);
