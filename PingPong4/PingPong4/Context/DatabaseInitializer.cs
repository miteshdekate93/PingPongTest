using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PingPong4.Models;

namespace PingPong4.Context
{
    public class DatabaseInitializer:DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var players = new List<Player>()
            {
                new Player{ FirstName="John",LastName="Davis",Age=25,SkillLevel=SkillLevel.Beginner,Email="john@gmail.com"},
                new Player{ FirstName="Kim",LastName="Davis",Age=45,SkillLevel=SkillLevel.Expert,Email="kim@gmail.com"},
                new Player{ FirstName="Mac",LastName="Doy",Age=24,SkillLevel=SkillLevel.Intermediate,Email="mac@gmail.com"},
                new Player{ FirstName="Jane",LastName="Roy",Age=35,SkillLevel=SkillLevel.Beginner,Email="jane@gmail.com"}
            };
            players.ForEach(x => context.players.Add(x));
            context.SaveChanges();
        }
    }
}