using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface IGradeRepository
    {
        Grade? GetGradeById(int gradeId);     
        List<Grade> GetAllGrades();      
        void AddGrade(Grade grade);
        void DeleteGrade(int gradeId);
        void UpdateGrade(Grade grade);
    }
}
