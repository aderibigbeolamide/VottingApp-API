using VottingAPI.Data.Base;

namespace VottingAPI.Model
{
    public class Voter : EntityBase
    {
        public int CastVote {get; set;}
        public int StudentId {get; set;}
        public Student Student {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
        public List<Student> Students {get; set;} = new List<Student>();
    }
}