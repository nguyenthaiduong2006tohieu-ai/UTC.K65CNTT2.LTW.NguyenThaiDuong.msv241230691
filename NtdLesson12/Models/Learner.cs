namespace NtdLesson12.Models
{
    public class Learner
    {
        public int LearnerID { get; set; }
        public string FirstMidName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }

        public int MajorID { get; set; }
        public Major Major { get; set; } = null!;
    }
}