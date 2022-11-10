using System.ComponentModel.DataAnnotations;
using VottingAPI.Data.Base;

namespace VottingAPI.Model
{
    public class Contestant : EntityBase
    {
        
        public int VoteCount {get; set;}
        public string Description { get; set; }
        public int StudentId {get; set;}
        public Student Student {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
        public int PositionId {get; set;} 
        public Position Position {get; set;} 
        public List<Student> Students {get; set;} = new List<Student>();
    }

}