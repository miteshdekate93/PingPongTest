using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PingPong4.Models;
using System.ComponentModel.DataAnnotations;

namespace PingPongUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDataLayer()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            Player player = new Player()
            {
                FirstName = "Loli",
                LastName = "Han",
                Age = 25,
                SkillLevel = SkillLevel.Intermediate,
                Email = "loli@gmail.com"
            };
            var errorcount = cpv.myValidation(player).Count();
            Assert.AreEqual(0, errorcount);
        }
        public class CheckPropertyValidation
        {
            public IList<ValidationResult> myValidation(object model)
            {
                var result = new List<ValidationResult>();
                var validationContext = new ValidationContext(model);
                Validator.TryValidateObject(model, validationContext, result);
                if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
                return result;
            }
        }
    }
}
