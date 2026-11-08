namespace NtdLesson12.Models
{
    public class Major
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; } = null!;
        public ICollection<Learner> Learners { get; set; } = new List<Learner>();
    }
}