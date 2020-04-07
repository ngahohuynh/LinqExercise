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
    }
}
