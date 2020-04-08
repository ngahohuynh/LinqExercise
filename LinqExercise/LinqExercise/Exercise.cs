using LinqExercise.Data;
using LinqExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    public class Exercise
    {
        List<Class> classes;
        List<Student> students;

        public Exercise()
        {
            DataFactory dataFactory = new DataFactory();
            classes = dataFactory.Classes;
            students = dataFactory.Students;
        }

        //1
        public Double? GetStudentScore(int id)
        {
            return students.Where(s => s.Id == id).Select(s => s.Score).FirstOrDefault();
        }

        //2
        public List<Student> GetStudentsOfBirthYear(int year)
        {
            return students.Where(s => s.Birthday.Year == year).Select(s => s).ToList();
        }

        //3
        public List<string> GetStudentNamesOfClass(string className)
        {
            return students.Where(s => string.Equals(s.Class.Name, className)).Select(s => s.Name).ToList();
        }

        //4
        public Double? GetAverageScoreOfClass(string className)
        {
            return students.Where(s => string.Equals(s.Class.Name, className)).Select(s => s.Score).Average();
        }

        //5
        public List<Student> GetStudentsWithHighestScoreOfClass()
        {
            var result = new List<Student>();

            students.GroupBy(s => s.Class.Id).ToList()
                    .ForEach(c => result.Add(c.OrderByDescending(s => s.Score).FirstOrDefault()));

            return result;
        }

        //6
        public List<Student> GetStudentsWithNameContains(string str)
        {
            return students.Where(s => s.Name.Contains(str)).ToList();
        }

        //7
        public List<Double?> GetAllScores()
        {
            return students.Where(s => s.Score != null).Select(s => s.Score).ToList();
        }

        //8
        public List<Student> GetStudentsWithScoreBelow(double score)
        {
            return students.Where(s => s.Score < score).ToList();
        }

        //9
        public List<Student> GetStudentsWithNoScore()
        {
            return students.Where(s => s.Score == null).ToList();
        }

        //10
        public List<string> GetClassesWithStudentsScoreAbove(double score)
        {
            var r = students.GroupBy(s => s.Class.Name, (className, stGroup) => new
            {
                ClassName = className,
                Count = stGroup.Count(s => s.Score > score)
            });

            var result = new List<string>();

            foreach (var item in r)
            {
                result.Add($"{item.ClassName} {item.Count}");
            }

            return result;
        }

        //11
        public Class GetClassWithHighestAvgScore()
        {
            var classId = students.GroupBy(s => s.Class.Id, (stClass, stGroup) => new
            {
                ClassId = stClass,
                AvgScore = stGroup.Average(s => s.Score)
            }).OrderByDescending(c => c.AvgScore).FirstOrDefault().ClassId;

            return classes.Where(c => c.Id == classId).FirstOrDefault();
        }

        //12
        public List<Student> GetRandomStudentsFromClass(int classId, int number)
        {
            var random = new Random();
            var result = new List<Student>();

            var l = Enumerable.Range(1, number).ToList();

            var r = students.Where(s => s.Class.Id == classId).ToList();

            l.ForEach(n => result.Add(r[random.Next(r.Count)]));

            return result;
        }

        //13
        public bool CheckStudentInClass(int classId, int birthYear, double score)
        {
            return students.Any(s => s.Class.Id == classId && s.Birthday.Year == birthYear && s.Score >= score);
        }
    }
}
