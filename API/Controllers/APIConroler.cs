using Microsoft.AspNetCore.Mvc;
using API.Models;
using API;

[ApiController]
[Route("api/[controller]")]
public class APIControler : ControllerBase
{
    private readonly AppDbContext _context;

    public APIControler(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return _context.Students.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var stud = _context.Students.FirstOrDefault(w => w.Id == id);

        if (stud == null)
            return NotFound();

        return stud;
    }

    [HttpPost]
    public ActionResult<Student> Create(Student stud)
    {
        _context.Students.Add(stud);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = stud.Id }, stud);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student update)
    {
        var exist = _context.Students.FirstOrDefault(w => w.Id == id);

        if (exist == null)
            return NotFound();

        exist.Imie = update.Imie;
        exist.Nazwisko = update.Nazwisko;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var stud = _context.Students.FirstOrDefault(w => w.Id == id);

        if (stud == null)
            return NotFound();

        _context.Students.Remove(stud);
        _context.SaveChanges();

        return NoContent();
    }
}
