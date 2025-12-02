using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Repositories;

namespace AIS.Services
{
    internal class UserAdmin:BaseUser
    {
        public void CreateStudentAccount(string firstName, string lastName, int groupId)
        {
            var userRepo = new UserRepository();
            var studentRepo = new StudentRepository();

            //create user
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Login = firstName,
                Password = lastName,
                Role = "student"
            };
            userRepo.AddUser(newUser);

            //create student
            var newStudent = new Student
            {
                UserId = newUser.UserId,
                StudentGroupId = groupId
            };

            studentRepo.AddStudent(newStudent);
        }
        public void DeleteStudentAccount(int studentId) 
        {
            var studentRepo = new StudentRepository();
            var userRepo = new UserRepository();

            var student = studentRepo.GetStudentById(studentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            studentRepo.DeleteStudent(studentId);

            userRepo.DeleteUser(student.UserId);
        }
        public void EditStudentAccount(string firstName, string lastName, int groupId, int studentId)

        {
            var userRepo = new UserRepository();
            var studentRepo = new StudentRepository();
            var studentGroupRepo = new StudentGroupRepository();

            //get student
            var student = studentRepo.GetStudentById(studentId);
            if (student == null)
                throw new Exception("Student not found.");

            //get user linked to this student
            var user = userRepo.GetUserById(student.UserId);
            if (user == null)
                throw new Exception("User not found for this student.");

            //update user info
            user.FirstName = firstName;
            user.LastName = lastName;
            userRepo.UpdateUser(user);

            //find existing group
            var group = studentGroupRepo.GetStudentGroupById(groupId);
            if (group == null)
                throw new Exception("Selected group does not exist.");

            // 5. Update student group
            student.StudentGroupId = groupId;
            studentRepo.UpdateStudent(student);
        }

        public void CreateTeacherAccount(string firstName, string lastName) 
        {
            var userRepo = new UserRepository();
            var teacherRepo = new TeacherRepository();

            //create new user
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Login = firstName,
                Password = lastName,
                Role = "teacher"
            };
            userRepo.AddUser(newUser);

            //create new teacher
            teacherRepo.AddTeacher(new Teacher
            {
                UserId = newUser.UserId,
            });
        }
        public void DeleteTeacherAccount(int teacherId) 
        { 
            var teacherRepo = new TeacherRepository();
            var userRepo = new UserRepository();
            var teacher = teacherRepo.GetTeacherById(teacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }
            teacherRepo.DeleteTeacher(teacherId);
            userRepo.DeleteUser(teacher.UserId);
        }
        public void EditTeacherAccount(string firstName, string lastName, int teacherId) 
        {
            var userRepo = new UserRepository();
            var teacherRepo = new TeacherRepository();

            //get teacher
            var teacher = teacherRepo.GetTeacherById(teacherId);
            if (teacher == null)
                throw new Exception("Teacher not found.");

            //get user linked to this teacher
            var user = userRepo.GetUserById(teacher.UserId);
            if (user == null)
                throw new Exception("User not found for this teacher.");

            //update user info
            user.FirstName = firstName;
            user.LastName = lastName;
            userRepo.UpdateUser(user);

            //update teacher
            teacherRepo.UpdateTeacher(teacher);
        }

        public void CreateStudentGroup(string groupName)
        {
            var studentGroupRepo = new StudentGroupRepository();

            var existing = studentGroupRepo.GetAllStudentGroups()
                                           .FirstOrDefault(g => g.StudentGroupName == groupName);

            if (existing != null)
                throw new Exception("Group already exists.");

            var newGroup = new StudentGroup
            {
                StudentGroupName = groupName
            };

            studentGroupRepo.AddStudentGroup(newGroup);
        }
        public void DeleteStudentGroup(int groupId)
        {
            var studentGroupRepo = new StudentGroupRepository();
            var group = studentGroupRepo.GetStudentGroupById(groupId);

            if (group == null)
                throw new Exception("Group not found.");

            studentGroupRepo.DeleteStudentGroup(groupId);
        }

        public void AssignSubjectToGroup(string subjectName, int groupId)
        {
            var subjectRepo = new SubjectRepository();
            var groupRepo = new StudentGroupRepository();
            var groupSubjectRepo = new GroupSubjectRepository();
            

            var subject = subjectRepo.GetAllSubjects()
                                     .FirstOrDefault(s => s.SubjectName == subjectName);

            if (subject == null) 
            {
                subjectRepo.AddSubject(new Subject { SubjectName = subjectName });
                subject = subjectRepo.GetAllSubjects().Last(); 
            }

            var group = groupRepo.GetAllStudentGroups()
                                 .FirstOrDefault(g => g.StudentGroupId == groupId);

            if (group == null)
                throw new Exception("Group not found.");

            var assignments = groupSubjectRepo.GetAllGroupSubjects();
            if (assignments.Any(a => a.SubjectId == subject.SubjectId && a.StudentGroupId == group.StudentGroupId))
                throw new Exception("This subject is already assigned to that group.");

            groupSubjectRepo.AddGroupSubject(new GroupSubject
            {
                StudentGroupId = group.StudentGroupId,
                SubjectId = subject.SubjectId
            });
        }
        public void AssignTeacherToSubject(string subjectName, int teacherUserId)
        {
            var subjectRepo = new SubjectRepository();
            var teacherRepo = new TeacherRepository();
            var teacherSubjectRepo = new TeacherSubjectRepository();

            var subject = subjectRepo.GetAllSubjects()
                                     .FirstOrDefault(s => s.SubjectName == subjectName);

            if (subject == null)
                throw new Exception("Subject not found.");

            var teacher = teacherRepo.GetAllTeachers()
                                     .FirstOrDefault(t => t.UserId == teacherUserId);

            if (teacher == null)
                throw new Exception("Teacher record not found.");

            var assignments = teacherSubjectRepo.GetAllTeacherSubjects();
            if (assignments.Any(a => a.TeacherId == teacher.TeacherId &&
                                     a.SubjectId == subject.SubjectId))
                throw new Exception("Teacher already assigned to this subject.");

            teacherSubjectRepo.AddTeacherSubject(new TeacherSubject
            {
                TeacherId = teacher.TeacherId,
                SubjectId = subject.SubjectId
            });
        }


        public void EditSubject(int subjectId, string newName, int newTeacherUserId, int newGroupId)
        {
            var subjectRepo = new SubjectRepository();
            var teacherRepo = new TeacherRepository();
            var teacherSubjRepo = new TeacherSubjectRepository();
            var groupSubjRepo = new GroupSubjectRepository();
            var groupRepo = new StudentGroupRepository();


            var subject = subjectRepo.GetSubjectById(subjectId);
            if (subject == null)
                throw new Exception("Subject not found.");

            //update subject name
            subject.SubjectName = newName;
            subjectRepo.UpdateSubject(subject);

            //update teacher assignment
            var teacher = teacherRepo.GetAllTeachers()
                                     .FirstOrDefault(t => t.UserId == newTeacherUserId);
            if (teacher == null)
                throw new Exception("Teacher not found.");

            //remove any existing teacher-subject assignments
            var teacherAssignments = teacherSubjRepo.GetAllTeacherSubjects()
                                                    .Where(ts => ts.SubjectId == subjectId)
                                                    .ToList();

            foreach (var ts in teacherAssignments)
                teacherSubjRepo.DeleteTeacherSubject(ts.TeacherSubjectId);

            //add new assignment
            teacherSubjRepo.AddTeacherSubject(new TeacherSubject
            {
                SubjectId = subjectId,
                TeacherId = teacher.TeacherId
            });

            //update group assignment
            var group = groupRepo.GetStudentGroupById(newGroupId);
            if (group == null)
                throw new Exception("Group not found.");

            //remove existing old assignments
            var groupAssignments = groupSubjRepo.GetAllGroupSubjects()
                                                .Where(gs => gs.SubjectId == subjectId)
                                                .ToList();

            foreach (var gs in groupAssignments)
                groupSubjRepo.DeleteGroupSubject(gs.GroupSubjectId);

            //add new group assignment
            groupSubjRepo.AddGroupSubject(new GroupSubject
            {
                SubjectId = subjectId,
                StudentGroupId = newGroupId
            });
        }
        public void DeleteSubject(int subjectId)
        {
            var subjectRepo = new SubjectRepository();
            var teacherSubjRepo = new TeacherSubjectRepository();
            var groupSubjRepo = new GroupSubjectRepository();


            var subject = subjectRepo.GetSubjectById(subjectId);
            if (subject == null)
                throw new Exception("Subject not found.");

            // remove teacher–subject assignments
            var teacherAssignments = teacherSubjRepo.GetAllTeacherSubjects()
                                                    .Where(ts => ts.SubjectId == subjectId)
                                                    .ToList();

            foreach (var ts in teacherAssignments)
                teacherSubjRepo.DeleteTeacherSubject(ts.TeacherSubjectId);

            // remove group–subject assignments
            var groupAssignments = groupSubjRepo.GetAllGroupSubjects()
                                                .Where(gs => gs.SubjectId == subjectId)
                                                .ToList();

            foreach (var gs in groupAssignments)
                groupSubjRepo.DeleteGroupSubject(gs.GroupSubjectId);

            // delete the subject itself
            subjectRepo.DeleteSubject(subjectId);
        }

    }
}
