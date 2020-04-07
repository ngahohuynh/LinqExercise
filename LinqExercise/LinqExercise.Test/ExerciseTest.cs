using System;
using System.Collections.Generic;
using LinqExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqExericise.Test
{
    [TestClass]
    public class ExerciseTest
    {
        Exercise exercise = new Exercise();

        //1
        [TestMethod]
        public void Test_GetStudentScore()
        {
            Assert.AreEqual(exercise.GetStudentScore(1), 3.5);
            Assert.AreEqual(exercise.GetStudentScore(4), null);
        }

        //2
        [TestMethod]
        public void Test_GetStudentOfBirthYear()
        {
            var result = exercise.GetStudentsOfBirthYear(1998);
            Assert.AreEqual(result.Count, 5);
            Assert.AreEqual(result[1].Name, "Lessie");
        }

        //3
        [TestMethod]
        public void Test_GetStudentNameOfClass()
        {
            var result = exercise.GetStudentNamesOfClass("16T2");
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], "Sargent");
        }

        //4
        [TestMethod]
        public void Test_GetAverageScoreOfClass()
        {
            Assert.AreEqual(exercise.GetAverageScoreOfClass("16T1"), 3.6);
        }

        //5
        [TestMethod]
        public void Test_GetStudentsWithHighestScoreOfClass()
        {
            var result = exercise.GetStudentsWithHighestScoreOfClass();
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Name, "Hodges");
            Assert.AreEqual(result[1].Name, "Goff");
        }

        //6
        [TestMethod]
        public void Test_GetStudentsWithNameContains()
        {
            var result = exercise.GetStudentsWithNameContains("ey");
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "Haley");
            Assert.AreEqual(result[1].Name, "Meyers");
        }

        //7
        [TestMethod]
        public void Test_GetAllScores()
        {
            CollectionAssert.AreEqual(exercise.GetAllScores(), new List<Double?>() { 3.5, 3.2, 2.8, 3.9, 3.7, 3.3 });
        }

        //8
        [TestMethod]
        public void Test_GetStudentsWithScoreBelow()
        {
            var result = exercise.GetStudentsWithScoreBelow(3.5);
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Score, 3.2);
            Assert.AreEqual(result[1].Score, 2.8);
        }

        //9
        [TestMethod]
        public void Test_GetStudentsWithNoScore()
        {
            var result = exercise.GetStudentsWithNoScore();
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0].Name, "Newman");
        }

        //10
        [TestMethod]
        public void Test_GetClassesWithStudentsScoreAbove()
        {
            var result = exercise.GetClassesWithStudentsScoreAbove(3.5);
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0], "16T1 1");
            Assert.AreEqual(result[1], "16T2 1");
            Assert.AreEqual(result[2], "16T3 0");
        }
    }
}
