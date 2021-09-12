using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace RedTenTests
{
    public class Person
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
    }
    public class Student : Person
    {
        public string SchoolName { get; set; }
    }

    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals([AllowNull] Person x, [AllowNull] Person y)
        {
            return x?.ID == y?.ID;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            return obj.ID.GetHashCode();
        }
    }

    [TestFixture]
    public class LINQPractices
    {

        IEnumerable<Person> _people;
        IEnumerable<Student> _students;
        [SetUp]
        public void Setup()
        {
            var students = new List<Student>();
            var people = new List<Person>();
            people.Add(new Person()
            {
                ID = 1,
                Age = 1,
                Name = "P1",
                Address = "Main Street, Salem"
            });
            students.Add(new Student()
            {
                ID = 2,
                Age = 13,
                Name = "P2",
                Address = "Main Street, Salem",
                SchoolName  = "Sumprton"
            });
            students.Add(new Student()
            {
                ID = 3,
                Age = 18,
                Name = "P3",
                Address = "Main Street, Salem",
                SchoolName = "OSU"
            });
            students.Add(new Student()
            {
                ID = 4,
                Age = 8,
                Name = "P4",
                Address = "Commecial Street, Salem",
                SchoolName = "Pringle"
            });
            this._students = students;
            foreach (var s in _students)
                people.Add(s);
            this._people = people;
        }
        [Test]
        public void Select()
        {
            //get all the ages from people regardless they are in school or not
            var ages = _people.Select(p => p.Age);
            Assert.AreEqual(4, ages.Count());
            //get the age and  Name of the people, no other information is need
            var ageAndNames = _people.Select(p =>new {p.Age, name=p.Name});          
            Assert.AreEqual(4, ageAndNames.Count());
            var first = ageAndNames.First();
            var type = first.GetType();
            var properties = type.GetProperties();
            Assert.AreEqual(2, properties.Length);
            Assert.AreEqual("Age", properties[0].Name);
            Assert.AreEqual("name", properties[1].Name);
        }
        [Test]
        public void Where()
        {
            //Find all people that has a school
            var PeopleWithSchool = _people.Where(p => p is Student);
            Assert.AreEqual(3, PeopleWithSchool.Count());
            var ListOfStudents = _people.Where(p => p is Student).Select(p => (Student)p).ToList();
            var Teenagers = _people.Where(p => p.Age > 12).Where(p => p.Age < 20).Select(p => (Student)p).ToList();
            Assert.AreEqual(2, Teenagers.Count());
            //Find people is teenager or live Main street
            var ThosePeople = _people.Where(p => (p.Age > 12 && p.Age < 20) || p.Address == "Main Street, Salem");
            Assert.AreEqual(3, ThosePeople.Count());
        }
        [Test]
        public void Any()
        {
            //Find people age below 1
            var YoungerThanOne = _people.Any(p => p.Age < 1);
            Assert.AreEqual(false, YoungerThanOne);
            //Find if theres any people in people list
            var PeopleInList = _people.Any();
            Assert.AreEqual(true, PeopleInList);
            //Find any people below age 1 or greater than 15
            var LessOneGreaterTwenty = _people.Any(p => p.Age < 1 || p.Age > 15);
            Assert.AreEqual(true, LessOneGreaterTwenty);
        }
        [Test]
        public void All()
        {
            //Find all Id > 10
            var GreaterThanTen = _people.All(p => p.ID > 10);
            Assert.AreEqual(false, GreaterThanTen);
            //Find all Id > 0 and age < 18
            var IdGreat0AgeLess18 = _people.All(p => p.ID > 0 && p.Age < 18);
            Assert.AreEqual(false, IdGreat0AgeLess18);
            //Find all people in Salem
            var InSalem = _people.All(p => p.Address.Contains("Salem"));
            Assert.AreEqual(true, InSalem);
        }

        [Test]
        public void Except()
        {
            //People except student
            var NoStudents = _people.Except(_students);
            Assert.AreEqual(1, NoStudents.Count());


            var students = new List<Person>();         
            students.Add(new Student()
            {
                ID = 2,
                Age = 13,
                Name = "P2",
                Address = "Main Street, Salem",
                SchoolName = "Sumprton"
            });
            students.Add(new Student()
            {
                ID = 3,
                Age = 18,
                Name = "P3",
                Address = "Main Street, Salem",
                SchoolName = "OSU"
            });
            students.Add(new Student()
            {
                ID = 4,
                Age = 8,
                Name = "P4",
                Address = "Commecial Street, Salem",
                SchoolName = "Pringle"
            });

            NoStudents = _people.Except(students);
            Assert.AreEqual(4, NoStudents.Count()); //Why 4 here?

            NoStudents = _people.Except(students, new PersonComparer());
            Assert.AreEqual(1, NoStudents.Count());
        }

        [Test]
        public void Contains()
        {
            //Find first student in people list
            var FirstStudent = _people.Contains(_students.First());
            Assert.AreEqual(true, FirstStudent);

            var student = new Student()
            {
                ID = 2,
                Age = 13,
                Name = "P2",
                Address = "Main Street, Salem",
                SchoolName = "Sumprton"
            };
            var NewStudent = _people.Contains(student);
            Assert.AreEqual(false, NewStudent);
            var NewStudentByVal = _people.Contains(student, new PersonComparer());
            Assert.AreEqual(true, NewStudentByVal);
        }

        [Test]
        public void Intersect()
        {
            //Find people in student list
            var PeopleInStudent = _students.Intersect(_people);
            Assert.AreEqual(3, PeopleInStudent.Count());
        }

        [Test]
        public void Count()
        {
            var OlderThanOne = _people.Count(p => p.Age > 1);
            Assert.AreEqual(3, OlderThanOne);
        }

        [Test]
        public void Distinct()
        {
            var DistinctAddress = _people.Select(p => p.Address).Distinct().ToList();
            Assert.AreEqual(2, DistinctAddress.Count());
        }

        [Test] 
        public void Reverse()
        {
            var ReversePeople = _people.Reverse().ToList();
            Assert.AreEqual(4, ReversePeople.First().ID);
        }

        [Test]
        public void OrderBy()
        {
            var ByAge = _people.OrderBy(p => p.Age).ToList();
            Assert.AreEqual(18, ByAge.Last().Age);
        }
    }
}
