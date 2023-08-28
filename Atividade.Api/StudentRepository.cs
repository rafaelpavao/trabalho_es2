// using Microsoft.EntityFrameworkCore;
// using Atividade.Api.DbContexts;
// using Atividade.Api.Entities;

// namespace Atividade.Api.Repositories;

// public class StudentRepository : IStudentRepository
// {
//     private readonly StudentContext _context;

//     public StudentRepository(StudentContext context)
//     {
//         _context = context;
//     }


// ////////////////////////////////////////////////////////////////////////////
// // Teams
// ////////////////////////////////////////////////////////////////////////////
//     ///////////////////////////
//     // Create
//     public async Task<bool> AddTeamAsync(Team team)
//     {
//         await _context.Teams.AddAsync(team);

//         return true;
//     }

//     ///////////////////////////
//     // Read   
//     public async Task<Team?> GetTeamByIdAsync(int teamId)
//     {
//         return await _context.Teams.FirstOrDefaultAsync(c => c.Id == teamId);
//     }
//     public async Task<Team?> GetTeamWithStudentsByIdAsync(int teamId)
//     {
//         return await _context.Teams
//             .Include(c => c.Students)
//             .FirstOrDefaultAsync(c => c.Id == teamId);
//     }
//     public async Task<IEnumerable<Team>> GetTeamsAsync()
//     {
//         return await _context.Teams.ToListAsync();
//     }
//     public async Task<IEnumerable<Team>> GetTeamsAsync(string? subject, string? searchQuery)
//     {
//         if(string.IsNullOrWhiteSpace(subject) && string.IsNullOrEmpty(searchQuery)) return await GetTeamsAsync();
        
//         var collection = _context.Teams as IQueryable<Team>;

//         if(!string.IsNullOrWhiteSpace(subject))
//         {
//             subject = subject.Trim();
//             collection = collection.Where(c => c.Subject == subject);

//         }

//         if(!string.IsNullOrWhiteSpace(searchQuery)){
//             searchQuery = searchQuery.Trim();
//             collection = collection.Where(c => c.Subject.Contains(searchQuery)); 

//         }

//         return await collection.ToListAsync();

//     }

//     // public async Task<Team?> GetTeamWithStudentsByIdAsync(int teamId)
//     // {
//     //     return await _context.Teams
//     //         .Include(c => c.TeamStudents!)
//     //             .ThenInclude(cs => cs.Student)
//     //         .FirstOrDefaultAsync(team => team.Id == teamId);
//     // }

//     ///////////////////////////
//     // Delete
//     public async Task<bool> DeleteTeam(int teamId)
//     {
//         var teamEntity = _context.Teams.FirstOrDefault(c => c.Id == teamId);

//         if (teamEntity == null) return false;

//         _context.Teams.Remove(teamEntity);
        
//         return await SaveChangesAsync();
//     }

//     ///////////////////////////
//     // Utils
//     public async Task<bool> TeamExistsAsync(int teamId)
//     {
//         return await _context.Teams.AnyAsync(c => c.Id == teamId);
//     }

    

// ////////////////////////////////////////////////////////////////////////////
// // Students
// ////////////////////////////////////////////////////////////////////////////
//     ///////////////////////////
//     // Create
//     public async Task<bool> AddStudent(Student student)
//     {
//         _context.Students.Add(student);
//         return await SaveChangesAsync();
//     }

//     ///////////////////////////
//     // Read
//     public async Task<Student?> GetStudentByIdAsync(int studentId)
//     {
//         return await _context.Students.FirstOrDefaultAsync(student => student.Id == studentId);
//     }
//     public async Task<Student?> GetStudentWithTeamsByIdAsync(int studentId)
//     {
//         return await _context.Students.Include(a => a.Teams).FirstOrDefaultAsync(student => student.Id == studentId);
//     }

//     ///////////////////////////
//     // Delete
//     public async Task<bool> DeleteStudent(Student student)
//     {
//         _context.Students.Remove(student);

//         return await SaveChangesAsync();
//     }

//     public async Task<StudentTeam> JoinTeamAndStudent(int studentId, int teamId)
//     {
//         var studentEntity = _context.Students.FirstOrDefault(s => s.Id == studentId);
//         var teamEntity = _context.Teams.FirstOrDefault(s => s.Id == teamId);

//         studentEntity.Teams.Add(teamEntity);
//         teamEntity.Students.Add(studentEntity);

//         var studentTeam = new StudentTeam{
//             StudentId = studentId,
//             TeamId = teamId
//         };
//         await SaveChangesAsync();
//         return studentTeam;
//     }

//     public async Task<bool> SaveChangesAsync()
//     {
//         return await _context.SaveChangesAsync() > 0;
//     }



// }
