using Microsoft.AspNetCore.Mvc;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class APIControler : ControllerBase
{
    private static List<Student> student = new List<Student>();

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return student;
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var stud = student.FirstOrDefault(w => w.Id == id);

        if (stud == null)
            return NotFound();

        return stud;
    }

    [HttpPost]
    public ActionResult<Student> Create(Student stud)
    {
        stud.Id = student.Count + 1;
        student.Add(stud);

        return CreatedAtAction(nameof(GetById), new { id = stud.Id }, stud);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student update)
    {
        var exist = student.FirstOrDefault(w => w.Id == id);

        if (exist == null)
            return NotFound();

        exist.Id = update.Id;
        exist.Imie = update.Imie;
        exist.Nazwisko = update.Nazwisko;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var stud = student.FirstOrDefault(w => w.Id == id);

        if (stud == null)
            return NotFound();

        student.Remove(stud);

        return NoContent();
    }
}
