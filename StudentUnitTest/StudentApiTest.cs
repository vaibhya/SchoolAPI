using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolAPI.Controllers;
using SchoolAPI.ModelDTO;
using SchoolAPI.Service;
using System.Security.Cryptography.X509Certificates;

namespace StudentUnitTest
{
    public class Tests
    {
        private Mock<IStudentService> mockStudentService = new Mock<IStudentService>();


        [Test]
        public void GetAllStudents_Returns_OKObjectResult()
        {
            //Arrange
            
            mockStudentService.Setup(x => x.GetAllStudents("", "", "", 1, 10))
                .Returns(new List<StudentResponseDTO>()
                {
                    new StudentResponseDTO() { FirstName="Vaibhav", LastName="Kamble", DateOfBirth=DateTime.Now, Age=2,Email="vk@gmail.com"},
                    new StudentResponseDTO() { FirstName="V", LastName="Kamble", DateOfBirth=DateTime.Now, Age=2,Email="vk2@gmail.com"}
                });

            var studentController = new StudentController(mockStudentService.Object);

            //Act
            var result = studentController.GetAllStudents("", "", "", 1, 10);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetAllStudents_Record_Limit_Check()
        {
            //Arrange
            mockStudentService.Setup(x => x.GetAllStudents("", "", "", 1, 1))
                .Returns(new List<StudentResponseDTO>()
                {
                    new StudentResponseDTO() { FirstName="Vaibhav", LastName="Kamble", DateOfBirth=DateTime.Now, Age=2,Email="vk@gmail.com"}
                    
                });

            var studentController = new StudentController(mockStudentService.Object);

            //Act
            var result = studentController.GetAllStudents("", "", "", 1, 1) as OkObjectResult;
            var students = result.Value as IEnumerable<StudentResponseDTO>;

            //Assert
            Assert.AreEqual(students.Count(),1);
        }

        [Test]
        public void PostStudent_Returns_Ok()
        {
            //Arrange
            mockStudentService.Setup(x => x.AddStudent(new StudentCreateDTO()
            {
                FirstName = "vaibhav",
                LastName = "k",
                DateOfBirth = new DateTime(2002, 2, 2),
                Email = "vk@gmail.com",
                Gender = SchoolAPI.Enum.Gender.Male,
                RollNumber = 12
            }))
            .Returns(1);
            
            var studentController = new StudentController(mockStudentService.Object);

            //Act
            var result = studentController.CreateStudent(new StudentCreateDTO()
            {
                FirstName = "vaibhav",
                LastName = "k",
                DateOfBirth = new DateTime(2002, 2, 2),
                Email = "vk@gmail.com",
                Gender = SchoolAPI.Enum.Gender.Male,
                RollNumber = 12
            });

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

        }

        [Test]
        public void GetStudentById_Returns_Ok_And_CorrectId()
        {
            //Arrange
            mockStudentService.Setup(x => x.GetStudentById(2))
                .Returns(new StudentUpdateDTO(){
                    Id = 2,
                    FirstName = "vaibhav",
                    LastName = "k",
                    DateOfBirth = new DateTime(2002, 2, 2),
                    Email = "vk@gmail.com",
                    Gender = SchoolAPI.Enum.Gender.Male,
                    RollNumber = 12
                });

            var studentController = new StudentController(mockStudentService.Object);

            //Act
            var result = studentController.GetStudentById(2) as OkObjectResult;
            var student = result.Value as StudentUpdateDTO;

            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(student.Id, 2);

        }

        [Test]
        public void UpdateStudent_Returns_Ok()
        {
            //Arrange
            mockStudentService.Setup(x => x.UpdateStudent(new StudentUpdateDTO()
            {
                Id= 2,
                FirstName = "vaibhav",
                LastName = "k",
                DateOfBirth = new DateTime(2002, 2, 2),
                Email = "vk@gmail.com",
                Gender = SchoolAPI.Enum.Gender.Male,
                RollNumber = 12
            }))
            .Returns(1);

            var studentController = new StudentController(mockStudentService.Object);

            //Act
            var result = studentController.UpdateStudent(new StudentUpdateDTO()
            {
                Id= 2,
                FirstName = "vaibhav",
                LastName = "k",
                DateOfBirth = new DateTime(2002, 2, 2),
                Email = "vk@gmail.com",
                Gender = SchoolAPI.Enum.Gender.Male,
                RollNumber = 12
            });

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

        }

        [Test]
        public void DeleteStudent_Returns_Ok()
        {
            mockStudentService.Setup(x => x.DeleteStudent(11))
                .Returns(1);
            var studentController = new StudentController(mockStudentService.Object);

            var response = studentController.DeleteStudent(11) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

    }
}