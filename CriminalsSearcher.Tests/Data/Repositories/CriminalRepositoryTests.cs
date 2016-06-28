using System;
using System.Collections;
using System.Linq;
using CriminalsSearcher.Data.Repositories;
using CriminalsSearcher.Model.DTO;
using NUnit.Framework;

namespace CriminalsSearcher.Tests.Data.Repositories {
    public class CriminalRepositoryTests : DataRepositoryTests {
        private CriminalRepository _criminalRepository;
        private Random _random;

        [SetUp]
        public void SetUp() {
            _criminalRepository = new CriminalRepository();
            _random = new Random();            
        }
        

        [Test]
        public void Search_should_search_by_name() {
            var searchParameter = new CriminalSearchParameters { Name = "Bob" };
            var names = new[] { "Bob Dylan", "Bob Marley" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_minimum_birthday() {            
            var searchParameter = new CriminalSearchParameters { MinimumBirthDate = new DateTime(2000,10,25) };
            var names = new[] { "Joey Tribiani" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_maximum_birthday() {
            var searchParameter = new CriminalSearchParameters { MaximumBirthDate = new DateTime(1949, 2, 26) };
            var names = new[] { "Amy Winehouse" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_gender_male() {
            var searchParameter = new CriminalSearchParameters { Gender = "M" };
            var names = new[] { "John Dylan", "Bob Dylan", "Bob Marley", "Elvis Presley", "Bill Gates", "Takuma Sato", "Paul Gonzalez", "John Travolta", "Joey Tribiani", "Chandler Bing", "Ross Geller" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_gender_female() {
            var searchParameter = new CriminalSearchParameters { Gender = "F" };
            var names = new[] { "Monica Geller", "Phoebe Buffay", "Rachel Green", "Hillary Clinton", "Steff Johson", "Amy Winehouse", "Venus Willians", "Fabiana Murer", "Claire Smith" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_minimum_height() {
            var searchParameter = new CriminalSearchParameters { MinimumHeight = 87 };
            var names = new[] { "Bill Gates", "Rachel Green", "Paul Gonzalez", "Bob Marley", "Phoebe Buffay" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_maximum_height() {
            var searchParameter = new CriminalSearchParameters { MaximumHeight = 64 };
            var names = new[] { "Claire Smith", "Chandler Bing", "Fabiana Murer", "Joey Tribiani" };

            AssertResults(searchParameter, names);
        }


        [Test]
        public void Search_should_search_by_minimum_weight() {
            var searchParameter = new CriminalSearchParameters { MinimumWeight = 236 };            
            var names = new[] { "Elvis Presley", "Monica Geller", "Phoebe Buffay" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_maximum_weight() {
            var searchParameter = new CriminalSearchParameters { MaximumWeight = 198 };
            var names = new[] { "Bill Gates", "Amy Winehouse" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_nationality() {
            var searchParameter = new CriminalSearchParameters { Nationality = "Brazilian" };
            var names = new[] { "John Dylan", "Venus Willians", "Fabiana Murer", "John Travolta", "Monica Geller", "Phoebe Buffay" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_father_name() {
            var searchParameter = new CriminalSearchParameters { FatherName = "Geller" };
            var names = new[] { "Ross Geller", "Monica Geller" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_mother_name() {
            var searchParameter = new CriminalSearchParameters { MotherName = "Mary" };
            var names = new[] { "Amy Winehouse", "Claire Smith", "Bob Marley", "Bill Gates", "John Dylan", "Hillary Clinton", "Phoebe Buffay" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_passport_number() {
            var searchParameter = new CriminalSearchParameters { PassportNumber = "11" };
            var names = new[] { "Takuma Sato", "Claire Smith" };

            AssertResults(searchParameter, names);
        }

        [Test]
        public void Search_should_search_by_driver_license_number() {
            var searchParameter = new CriminalSearchParameters { DriverLicenseNumber = "X" };
            var names = new[] { "Bill Gates", "Takuma Sato", "John Dylan" };

            AssertResults(searchParameter, names);
        }

        [TestCaseSource("GetSomeCriminals")]
        public void Search_should_return_all_criminal_data(string name, DateTime? birthDate, string gender, int height, int weight, string nationality, string fatherName, string motherName, string passportNumber, string driverLicenseNumber) {
            var searchParameter = new CriminalSearchParameters { Name = name };
            var criminal = _criminalRepository.Search(searchParameter).Single();

            Assert.AreEqual(name, criminal.Name);
            Assert.AreEqual(birthDate, criminal.BirthDate);
            Assert.AreEqual(gender, criminal.Gender);
            Assert.AreEqual(height, criminal.Height);
            Assert.AreEqual(weight, criminal.Weight);
            Assert.AreEqual(nationality, criminal.Nationality);
            Assert.AreEqual(fatherName, criminal.FatherName);
            Assert.AreEqual(motherName, criminal.MotherName);
            Assert.AreEqual(passportNumber, criminal.PassportNumber);
            Assert.AreEqual(driverLicenseNumber, criminal.DriverLicenseNumber);
        }

        private void AssertResults(CriminalSearchParameters searchParameter, string[] names) {
            var criminals = _criminalRepository.Search(searchParameter);

            Assert.AreEqual(names.Length, criminals.Count);
            Assert.True(names.All(name => criminals.Any(criminal => criminal.Name.Equals(name))));
        }

        private static IEnumerable GetSomeCriminals() {
            yield return new object[] { "Rachel Green", new DateTime(1949, 2, 27), "F", 90, 221, "Canadian", "Bill Buffay", "Hillary Buffay", null, null };
            yield return new object[] { "Takuma Sato", null, "M", 81, 221, "Japanese", "Bill Sato", "Akiuna Sato", "98765432117", "3456455-5X" };
            yield return new object[] { "John Dylan", new DateTime(1996, 3, 15), "M", 70, 220, "Brazilian", "Mark Dylan", "Mary Dylan", "00123121456", "1098875-5X" };
            yield return new object[] { "Monica Geller", new DateTime(1976, 3, 30), "F", 69, 237, "Brazilian", "Richard Geller", "Claire Geller", null, "4565667889" };
        }
    }
}
