using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowXUnit
{
    public class RepositoryTests
    {
        private readonly IStudentRepository MockStudentRepository;
        private readonly IClassRepository MockClassRepository;

        public RepositoryTests()
        {
            var mockStudentRepository = new Mock<IStudentRepository>();
            var mockClassRepository = new Mock<IClassRepository>();

            IList<Class> Classs = new List<Class>
                {
                    new Class
                    {
                        Id = Guid.NewGuid(), Name = "Test Class One", Start = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(1)
                    },
                    new Class
                    {
                        Id = Guid.NewGuid(), Name = "Test Class Two", Start = DateTime.Now,
                        Expiration = DateTime.Now.AddDays(3)
                    }
                };

            IList<Student> Students = new List<Student>()
                {
                    new Student
                    {
                        Id = Guid.NewGuid(), Name = "Student One"
                    },
                    new Student
                    {
                        Id = new Guid(), Name = "Student Two"
                    },
                    new Student
                    {
                        Id = Guid.NewGuid(), Name = "Student Three"
                    }
                };
            var rnd = new Random();
            foreach (var p in Students)
            {
                p.ClassId = Classs[rnd.Next(Classs.Count)].Id.ToString();
            }

            mockClassRepository
                .Setup(r => r.GetActiveClasssAsync()).ReturnsAsync(Classs);
            mockStudentRepository
                .Setup(r => r.GetAllStudentsAsync()).ReturnsAsync(Students);
            mockStudentRepository.Setup(r => r.GetStudentByIdAsync(It.IsAny<string>())).ReturnsAsync(Students[0]);

            MockStudentRepository = mockStudentRepository.Object;
            MockClassRepository = mockClassRepository.Object;
        }

        [Fact]
        public void TestCanGetAllStudents()
        {
            var Students = MockStudentRepository.GetAllStudentsAsync().Result.ToList();
            Assert.NotEmpty(Students);
            Assert.IsType<List<Student>>(Students);
        }

        [Fact]
        public void TestCanGetStudentById()
        {
            var Students = MockStudentRepository.GetAllStudentsAsync().Result.ToList();
            // can see there's a student with an id of "00000000-0000-0000-0000-000000000000" but fails.
            var Student = MockStudentRepository
                .GetStudentByIdAsync("00000000-0000-0000-0000-000000000000").Result;
            Assert.NotNull(Student);
            Assert.IsType<Student>(Student);
        }

    }

    internal class Student
    {
        public string Name { get; internal set; }
        public Guid Id { get; internal set; }
        public string ClassId { get; internal set; }
    }

    internal class Class
    {
        public string Name { get; internal set; }
        public DateTime Expiration { get; internal set; }
        public Guid Id { get; internal set; }
        public DateTime Start { get; internal set; }
    }

    internal interface IClassRepository
    {
        Task<IList<Class>> GetActiveClasssAsync();
    }

    internal interface IStudentRepository
    {
        Task<IList<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string v);
    }
}
