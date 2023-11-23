﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redbrow;
using redbrow.Data;


[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsuariosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios([FromQuery] int pagina = 1, [FromQuery] int elementosPorPagina = 5)
    {
        // Validar y ajustar los parámetros de paginación si es necesario
        if (pagina < 1)
            pagina = 1;

        if (elementosPorPagina < 1)
            elementosPorPagina = 5;

        // Calcular la posición de inicio
        int posicionInicio = (pagina - 1) * elementosPorPagina;

        // Obtener la lista de usuarios paginada
        var usuarios = _context.Usuarios
            .Skip(posicionInicio)
            .Take(elementosPorPagina)
            .ToList();

        return Ok(usuarios);
    }

    // GET: api/Usuarios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }

    // POST: api/Usuarios
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
    }

    // PUT: api/Usuarios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Usuarios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}
