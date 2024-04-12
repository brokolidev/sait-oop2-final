using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Managers
{
    public static class UserManager
    {
        public static List<User> users = new List<User>();

        

        //public static Student? GetStudentById(int studentId)
        //{
        //    var student = students.FirstOrDefault(x => x.StudentId == studentId);

        //    if (student != null)
        //    {
        //        return new Student(student.StudentId, student.Name, student.Address, student.Email, student.Phone);
        //    }

        //    return null;
        //}

        //public static void UpdateStudentDetails(int studentId, Student student)
        //{
        //    if (studentId != student.StudentId)
        //    {
        //        return;
        //    }

        //    var studentUpdate = students.FirstOrDefault(
        //       x => x.StudentId == studentId);
        //    if (studentUpdate != null)
        //    {
        //        studentUpdate.Name = student.Name;
        //        studentUpdate.Address = student.Address;
        //        studentUpdate.Email = student.Email;
        //        studentUpdate.Phone = student.Phone;
        //    }
        //}

        //public static List<Student> SearchforStudents(string filterText)
        //{
        //    // create function for searching students
        //    var studentsFound = students.Where(x => !string.IsNullOrWhiteSpace(x.Name) &&
        //        x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();

        //    if (studentsFound == null || studentsFound.Count == 0)
        //    {
        //        studentsFound = students.Where(x => !string.IsNullOrWhiteSpace(x.Email) &&
        //        x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }

        //    if (studentsFound == null || studentsFound.Count == 0)
        //    {
        //        studentsFound = students.Where(x => !string.IsNullOrWhiteSpace(x.Address) &&
        //        x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }

        //    return studentsFound;
        //}
    }
}
