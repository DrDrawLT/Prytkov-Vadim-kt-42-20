using Prytkov_Vadim_kt_42_20_Lab_3.DB;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.TeacherFilters;
using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.TeachersInterfaces;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Prytkov_Vadim_kt_42_20_lab_3.Tests
{
    public class AppIntegrationTests
    {
        public readonly DbContextOptions<PrepodDBContext> _dbContextOptions;

        public AppIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDBContext>().UseInMemoryDatabase(databaseName: "dbbb").Options;
        }
        public async Task GetTeachersByDepartAsync_TwoObjects()
        {
            // Arrange
            var ctx = new PrepodDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);
            //
            var departs = new List<Departments>
            {
                new Departments
                {
                    Name = "Прикладная информатика",
                    CreateDate = new DateTime(2002,02,02),
                    CountTeach = 30,
                    TeachId = 1
                },
                new Departments
                {
                    Name = "Общая физика",
                    CreateDate = new DateTime(2003,03,03),
                    CountTeach = 50,
                    TeachId = 2
                }
            };
            await ctx.Set<Departments>().AddRangeAsync(departs);
            //
            var ADs = new List<AcademicDegrees>
            {
                new AcademicDegrees
                {
                    Name = "Кандидат наук"
                },
                new AcademicDegrees
                {
                    Name = "Доктор наук"
                }
            };
            await ctx.Set<AcademicDegrees>().AddRangeAsync(ADs);
            //
            var positions = new List<Positions>
            {
                new Positions
                {
                    Name = "Преподаватель"
                },
                new Positions
                {
                    Name = "Старший преподаватель"
                },
                new Positions
                {
                    Name = "Доцент"
                },
                new Positions
                {
                    Name = "Профессор"
                }
            };
            await ctx.Set<Positions>().AddRangeAsync(positions);
            //
            var teachs = new List<Teachers>
            {
                new Teachers
                {
                    Name ="константин",
                    SecName ="Константинов",
                    ThirdName ="Константинович",
                    DepId = 2,
                    AcDegId=1,
                    PosId=3
                },
                new Teachers
                {
                    Name ="Олег",
                    SecName ="Олегов",
                    ThirdName ="Олегович",
                    DepId = 1,
                    AcDegId=2,
                    PosId=4
                },
            };
            await ctx.Set<Teachers>().AddRangeAsync(teachs);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new TeacherDepartFilter
            {
                DepartName = "Общая физика"
            };
            var teachersResult = await teacherService.GetTeacherByDepartAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, teachersResult.Length);


        }
    }
}

