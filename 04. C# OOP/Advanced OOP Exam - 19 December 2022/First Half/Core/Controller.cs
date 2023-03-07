using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;

            if (subjectType != "Technical" &&
                subjectType != "Economical" &&
                subjectType != "Humanity")
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(x => x.Name == subjectName))
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            int id = subjects.Models.Count;
            id++;

            if (subjectType == "Technical")
            {
                subject = new TechnicalSubject(id, subjectName); // fix id
            }
            else if (subjectType == "Economical")
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else if (subjectType == "Humanity")
            {
                subject = new HumanitySubject(id, subjectName);
            }

            subjects.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(x => x.Name == universityName))
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> ids = new List<int>();

            foreach (var subject in requiredSubjects)
            {
                int id = subjects.Models.First(x => x.Name == subject).Id;
                ids.Add(id);
            }

            int uniId = universities.Models.Count;
            uniId++;

            IUniversity university = new University(uniId, universityName, category, capacity, ids);

            universities.AddModel(university);

            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models
                .Any(x => x.FirstName == firstName && 
                          x.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int id = students.Models.Count;
            id++;

            IStudent student = new Student(id, firstName, lastName);
            students.AddModel(student);

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(x => x.Id == studentId))
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }

            if (!subjects.Models.Any(x => x.Id == subjectId))
            {
                return String.Format(OutputMessages.InvalidSubjectId);
            }

            var student = students.FindById(studentId);

            var subject = subjects.FindById(subjectId);

            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return  String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentNameArgs = studentName.Split(' ');
            string firstName = studentNameArgs[0];
            string lastName = studentNameArgs[1];

            var student = students.Models.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            var university = universities.Models.FirstOrDefault(x => x.Name == universityName);

            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            if (student.CoveredExams != university.RequiredSubjects)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, firstName);
            }

            if (student.University.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return String.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string UniversityReport(int universityId)
        {
            StringBuilder sb = new StringBuilder();

            var university = universities.FindById(universityId);

            var studentsCount = students.Models.Where(x => x.Id == universityId).Count();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().Trim();
        }
    }
}
