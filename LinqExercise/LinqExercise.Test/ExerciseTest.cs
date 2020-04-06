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
            Assert.AreEqual(exercise.GetStudentScore(1), 3.1);
            Assert.AreEqual(exercise.GetStudentScore(3), null);
        }

        [TestMethod]
        public void Test_GetStudentOfBirthYear()
        {
            var result = exercise.GetStudentOfBirthYear(1998);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[1].Name, "C");
        }
    }
}
