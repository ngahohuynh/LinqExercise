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

        public Double? GetStudentScore(int id)
        {
            return students.Where(s => s.Id == id).Select(s => s.Score).FirstOrDefault();
        }

        public List<Student> GetStudentOfBirthYear(int year)
        {
            return students.Where(s => s.Birthday.Year == year).Select(s => s).ToList();
        }

        public List<string> GetStudentNameOfClass(string className)
        {
            return students.Where(s => string.Equals(s.Class.Name, className)).Select(s => s.Name).ToList();
        }
    }
}
