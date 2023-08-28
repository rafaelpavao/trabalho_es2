// using Microsoft.AspNetCore.Mvc;
// using Atividade.Api.Entities;
// using Atividade.Api.Repositories;

// namespace Atividade.Api.Controllers;

// [ApiController]
// [Route("api/students")]
// public class StudentController : ControllerBase
// {

//     private readonly IStudentRepository _repository;

//     public StudentController(IStudentRepository repository)
//     {
//         _repository = repository;
//     }

//     [HttpPost]
//     public async Task<ActionResult<Student>> CreateStudent(
//     [FromBody] Student student
//     )
//     {
//         await _repository.AddStudent(student);

//         return CreatedAtRoute
//         (
//             "GetAuthorByIdAsync",
//             new { authorId = student.Id },
//             student
//         );
//     }

//     [HttpGet]
//     public async Task<ActionResult<Student>> GetStudentById(int studentId)
//     {
//         return await _repository.GetStudentByIdAsync(studentId);
//     }
    
// }
    

