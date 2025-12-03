using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
namespace AIS.Repositories
{
    public interface IGroupSubjectRepository
    {
        GroupSubject? GetGroupSubjectById(int groupSubjectId); 
        List<GroupSubject> GetAllGroupSubjects(); 
        List<int> GetSubjectsByGroupId(int studentGroupId);
        List<int> GetGroupsBySubjectId(int subjectId);
        void AddGroupSubject(GroupSubject groupSubject);
        void DeleteGroupSubject(int groupSubjectId);
        void UpdateGroupSubject(GroupSubject groupSubject);
    }
}
