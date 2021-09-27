using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first.DBContext;
using first.Models;

namespace first
{
    public static class SampleData
    {
        public static async Task Initialize(DBContext.DBContext context)
        {
            var footballers = await context.GetFootballers();
            if (!footballers.Any())
            {
                await context.AddFootballer(
                    new Footballer
                    {
                        Name = "First",
                        Surname = "FirstSur",
                        Sex = Sex.Мужской,
                        Country = Country.Россия,
                        DateOfBirth = DateTime.Today,

                    });

                await context.AddFootballer(
                    new Footballer
                    {
                        Name = "second",
                        Surname = "secondSur",
                        Sex = Sex.Мужской,
                        Country = Country.США,
                        DateOfBirth = DateTime.Today,

                    });
                context.SaveChanges();
            }
        }
    }
}
