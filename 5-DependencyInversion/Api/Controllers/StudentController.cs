using Microsoft.AspNetCore.Mvc;

namespace DependencyInversion.Controllers;

[ApiController, Route("student")]
public class StudentController : ControllerBase
{

    IStudentRepository studentRepository;

    ILoggable loggable;

    public StudentController(IStudentRepository student, ILoggable loggable)
    {
        studentRepository = student;
        loggable = loggable;
    }

    [HttpGet]

    public IEnumerable<Student> Get()
    {
        loggable.Add($"returning student's list");
        return studentRepository.GetAll();
    }

    [HttpPost]
    public void Add([FromBody]Student student)
    {
        studentRepository.Add(student);
        loggable.Add($"The Student {student.Fullname} have been added");
    }
}
