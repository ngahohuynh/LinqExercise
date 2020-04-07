using System;
using LinqExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqExericise.Test
{
    [TestClass]
    public class ExerciseTest
    {
        Exercise exercise = new Exercise();

        [TestMethod]
        public void Test_GetStudentScore()
        {
            Assert.AreEqual(exercise.GetStudentScore(1), 3.5);
            Assert.AreEqual(exercise.GetStudentScore(4), null);
        }

        [TestMethod]
        public void Test_GetStudentOfBirthYear()
        {
            var result = exercise.GetStudentOfBirthYear(1998);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[1].Name, "Lessie");
        }

        [TestMethod]
        public void Test_GetStudentNameOfClass()
        {
            var result = exercise.GetStudentNameOfClass("16T2");
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], "Sargent");
        }

        [TestMethod]
        public void Test_GetAverageScoreOfClass()
        {
            Assert.AreEqual(exercise.GetAverageScoreOfClass("16T1"), 3.6);
        }

        [TestMethod]
        public void Test_GetStudentsWithHighestScoreOfClass()
        {
            var result = exercise.GetStudentsWithHighestScoreOfClass();
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Name, "Hodges");
            Assert.AreEqual(result[1].Name, "Goff");
        }
    }
}
