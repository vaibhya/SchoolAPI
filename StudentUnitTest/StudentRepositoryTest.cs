using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Moq;
using SchoolAPI.Enum;
using SchoolAPI.Model;
using SchoolAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace StudentUnitTest
{
    internal class StudentRepositoryTest
    {
        private Mock<StudentDBContext> studentDBContext = new Mock<StudentDBContext>();


        [Test]
        public void Student_Creation_Returns_Ok()
        {
            var connectionString = " server=localhost; port=3306; database=school; user=root; password=Kvaibhav@7; Persist Security Info=False;";
            var optionBuilder = new DbContextOptionsBuilder<StudentDBContext>();
            optionBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(6, 0, 0)));

            var dbContext = new StudentDBContext(optionBuilder.Options);

            var fiveRecords = dbContext.Students.Take(5).ToList();

            IStudentRepository studentRepository = new StudentRepository(dbContext);

            Assert.AreEqual(fiveRecords.Count, studentRepository.GetAll("", "", "", 1, 5).Count<Student>());


            //IStudentRepository studentRepository = new StudentRepository(studentDBContext.Object);
        }
    }
}
