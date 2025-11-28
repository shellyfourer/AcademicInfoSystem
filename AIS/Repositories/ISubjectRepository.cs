using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface ISubjectRepository
    {
        Subject? GetSubjectById(int subjectId); 
        List<Subject> GetAllSubjects(); 
        void AddSubject(Subject subject);
        void DeleteSubject(int subjectId);
        void UpdateSubject(Subject subject);
    }
}
