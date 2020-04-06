using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public DateTime Birthday { get; set; }
        public Double? Score { get; set; }
    }
}
