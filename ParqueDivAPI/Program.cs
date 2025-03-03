using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using ParqueDivAPI.Data;
using ParqueDivAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



//app.UseHttpsRedirection();

//Get Usuarios
app.MapGet("api/usuarios", async (AppDBContext context) =>
{
    var usuarios = await context.Usuarios.ToListAsync();

    return Results.Ok(usuarios);
});

//Post Usuarios
app.MapPost("api/usuarios", async (AppDBContext context, Usuario usuario) =>
{
    await context.Usuarios.AddAsync(usuario);
    await context.SaveChangesAsync();
    return Results.Created($"/api/usuarios/{usuario.UsuarioId}", usuario);
});


//Update Usuarios
app.MapPut("api/usuarios/{id}", async (AppDBContext context, int id, Usuario usuario) =>
{
    var existingUsuario = await context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == id);
    if (existingUsuario is null)
    {
        return Results.NotFound();
    }
    existingUsuario.Nombre = usuario.Nombre;
    existingUsuario.Apellido = usuario.Apellido;
    existingUsuario.Correo = usuario.Correo;
    existingUsuario.Contrasena = usuario.Contrasena;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

//Delete Usuarios
app.MapDelete("api/usuarios/{id}", async (AppDBContext context, int id) =>
{
    var existingUsuario = await context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == id);
    if (existingUsuario is null)
    {
        return Results.NotFound();
    }
    context.Usuarios.Remove(existingUsuario);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

//Get Tiquetes
app.MapGet("api/tiquetes", async (AppDBContext context) =>
{
    var tiquetes = await context.Tiquetes.ToListAsync();

    return Results.Ok(tiquetes);
});

//Post Tiquetes
app.MapPost("api/tiquetes", async (AppDBContext context, Tiquete tiquete) =>
{
    await context.Tiquetes.AddAsync(tiquete);
    await context.SaveChangesAsync();
    return Results.Created($"/api/tiquetes/{tiquete.TiqueteId}", tiquete);
});

//Update Tiquetes
app.MapPut("api/tiquetes/{id}", async (AppDBContext context, int id, Tiquete tiquete) =>
{
    var existingTiquete = await context.Tiquetes.FirstOrDefaultAsync(x => x.TiqueteId == id);
    if (existingTiquete is null)
    {
        return Results.NotFound();
    }
    existingTiquete.Tipo = tiquete.Tipo;
    existingTiquete.Descripcion = tiquete.Descripcion;
    existingTiquete.Estado = tiquete.Estado;
    existingTiquete.FechaCreacion = tiquete.FechaCreacion;
    existingTiquete.FechaCierre = tiquete.FechaCierre;
    existingTiquete.Ubicacion = tiquete.Ubicacion;
    existingTiquete.EmpleadoId = tiquete.EmpleadoId;
    existingTiquete.UsuarioId = tiquete.UsuarioId;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

//Delete Tiquetes

app.MapDelete("api/tiquete/{id}", async (AppDBContext context, int id) =>
{
    var existingTiquete = await context.Tiquetes.FirstOrDefaultAsync(x => x.TiqueteId == id);
    if (existingTiquete is null)
    {
        return Results.NotFound();
    }
    context.Tiquetes.Remove(existingTiquete);
    await context.SaveChangesAsync();
    return Results.NoContent();
});


//Get Empleados
app.MapGet("api/empleados", async (AppDBContext context) =>
{
    var empleados = await context.Empleados.ToListAsync();

    return Results.Ok(empleados);
});

//Post Empleados
app.MapPost("api/empleados", async (AppDBContext context, Empleado empleado) =>
{
    await context.Empleados.AddAsync(empleado);
    await context.SaveChangesAsync();
    return Results.Created($"/api/empleados/{empleado.EmpleadoId}", empleado);
});

//Update Empleados

app.MapPut("api/empleados/{id}", async (AppDBContext context, int id, Empleado empleado) =>
{
    var existingEmpleado = await context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);
    if (existingEmpleado is null)
    {
        return Results.NotFound();
    }
    existingEmpleado.Nombre = empleado.Nombre;
    existingEmpleado.Apellido = empleado.Apellido;
    existingEmpleado.Telefono = empleado.Telefono;
    existingEmpleado.Email = empleado.Email;
    existingEmpleado.Cargo = empleado.Cargo;
    existingEmpleado.Password = empleado.Password;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

//Delete Empleados

app.MapDelete("api/empleados/{id}", async (AppDBContext context, int id) =>
{
    var existingEmpleado = await context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);
    if (existingEmpleado is null)
    {
        return Results.NotFound();
    }
    context.Empleados.Remove(existingEmpleado);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

//Get Favoritos
app.MapGet("api/favoritos", async (AppDBContext context) =>
{
    var favoritos = await context.Favoritos.ToListAsync();

    return Results.Ok(favoritos);
});

//Post Favoritos

app.MapPost("api/favoritos", async (AppDBContext context, Favorito favorito) =>
{
    await context.Favoritos.AddAsync(favorito);
    await context.SaveChangesAsync();
    return Results.Created($"/api/favoritos/{favorito.FavoritoId}", favorito);
});

//Delete Favoritos

app.MapDelete("api/favoritos/{id}", async (AppDBContext context, int id) =>
{
    var existingFavorito = await context.Favoritos.FirstOrDefaultAsync(x => x.FavoritoId == id);
    if (existingFavorito is null)
    {
        return Results.NotFound();
    }
    context.Favoritos.Remove(existingFavorito);
    await context.SaveChangesAsync();
    return Results.NoContent();
});




app.Run();

