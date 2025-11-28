using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface IStudentGroupRepository
    {
        StudentGroup? GetStudentGroupById(int studentGroupId);
        List<StudentGroup> GetAllStudentGroups(); 
        void AddStudentGroup(StudentGroup studentGroup);
        void DeleteStudentGroup(int studentGroupId);
        void UpdateStudentGroup(StudentGroup studentGroup);
    }
}
