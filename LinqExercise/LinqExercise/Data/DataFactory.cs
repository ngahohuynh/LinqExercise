using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using LinqExercise.Model;

namespace LinqExercise.Data
{
    public class DataFactory
    {
        public List<Class> Classes { get; set; }
        public List<Student> Students { get; set; }

        public DataFactory()
        {
            Classes = GetClassData();
            Students = GetStudentData();
        }

        private List<Class> GetClassData()
        {
            var classData = File.ReadAllText("C:/Code/LinqExercise/LinqExercise/LinqExercise/Data/ClassData.json");
            return JsonConvert.DeserializeObject<List<Class>>(classData);
        }

        private List<Student> GetStudentData()
        {
            var studentData = File.ReadAllText("C:/Code/LinqExercise/LinqExercise/LinqExercise/Data/StudentData.json");

            var dateFormat = "dd-MM-yyyy";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = dateFormat };

            return JsonConvert.DeserializeObject<List<Student>>(studentData, dateTimeConverter);
        }
    }
}
