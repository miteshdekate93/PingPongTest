using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPong4.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public string Email { get; set; }
    }
    public enum SkillLevel
    {
        Select, Beginner, Intermediate, Advanced, Expert
    }
}