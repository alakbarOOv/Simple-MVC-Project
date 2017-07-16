using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamCalculator.Models
{   
    public class CalculateModels
    {
        public string name { get; set; }
        public string surname { get; set; }
        public float project { get; set; }
        public float visa { get; set; }
        public float final { get; set; }
        public float average { get; set; }
        public bool isdataSuccessModel { get; set; }
        
    }
}
