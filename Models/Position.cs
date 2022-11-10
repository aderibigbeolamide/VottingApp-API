using VottingAPI.Data.Base;

namespace VottingAPI.Model
{
    public class Position : EntityBase
    {
        public string PositionName {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
    }
}