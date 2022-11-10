using System;
using VottingAPI.Data.Base;

namespace VottingAPI.Model
{
    public class Election : EntityBase
    {
        public string ElectionName {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public bool IsDisplay {get; set;}
        public List<Position> PositionId {get; set;} = new List<Position>();  
    }
}