using AIS.Models;
using AIS.Repositories;
using System;
using System.Collections.Generic;

namespace AIS.Database
{
    internal class DatabaseSeeder
    {
        public static void Seed()
        {
            var userRepo = new UserRepository();
            var studentRepo = new StudentRepository();
            var teacherRepo = new TeacherRepository();
            var groupRepo = new StudentGroupRepository();
            var subjectRepo = new SubjectRepository();
            var teacherSubjectRepo = new TeacherSubjectRepository();
            var groupSubjectRepo = new GroupSubjectRepository();

            //Prevent duplicate seeding
            if (userRepo.GetAllUsers().Any())
                return;

            //Create admin
            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Role = "admin"
            };
            userRepo.AddUser(admin);

            //Create student group
            var group = new StudentGroup
            {
                StudentGroupName = "PI24E"
            };
            groupRepo.AddStudentGroup(group);

            //Create students
            var s1 = new User { FirstName = "Shelly", LastName = "Fourer", Role = "student" };
            var s2 = new User { FirstName = "Hamza", LastName = "Bouzaidi", Role = "student" };

            userRepo.AddUser(s1);
            userRepo.AddUser(s2);

            studentRepo.AddStudent(new Student { UserId = s1.UserId, StudentGroupId = group.StudentGroupId });
            studentRepo.AddStudent(new Student { UserId = s2.UserId, StudentGroupId = group.StudentGroupId });

            //List of subjects
            string[] subjectNames =
            {
                "Law",
                "Management",
                "Calculating and Optimization Methods",
                "Object - Oriented Programming",
                "Database Design",
                "Information Systems",
                "Second Programming Practice"
            };

            List<Subject> subjects = new List<Subject>();

            foreach (var sub in subjectNames)
            {
                var subject = new Subject { SubjectName = sub };
                subjectRepo.AddSubject(subject);
                subjects.Add(subject);

                //Assign subject to group
                groupSubjectRepo.AddGroupSubject(new GroupSubject
                {
                    StudentGroupId = group.StudentGroupId,
                    SubjectId = subject.SubjectId
                });
            }


            // Create unique teachers + assign each to a subject
            string[] teacherFirstNames =
            {
            "John", "Emily", "Michael", "Laura",
            "David", "Sophia", "Daniel", "Emma"
            };

            string[] teacherLastNames =
            {
            "Smith", "Johnson", "Brown", "Taylor",
            "Wilson", "Davis", "Miller", "Anderson"
            };

            
            int teacherIndex = 0;

            foreach (var subject in subjects)
            {
                var teacherUser = new User
                {
                    FirstName = teacherFirstNames[teacherIndex],
                    LastName = teacherLastNames[teacherIndex],
                    Role = "teacher"
                };

                userRepo.AddUser(teacherUser);

                var teacher = new Teacher
                {
                    UserId = teacherUser.UserId
                };

                teacherRepo.AddTeacher(teacher);

                teacherSubjectRepo.AddTeacherSubject(new TeacherSubject
                {
                    TeacherId = teacher.TeacherId,
                    SubjectId = subject.SubjectId
                });

                teacherIndex++;
            }


        }
    }
}
