using System;
using CriminalsSearcher.Data.Repositories;
using NUnit.Framework;

namespace CriminalsSearcher.Tests.Data.Repositories {
   
    public class UserRepositoryTests : DataRepositoryTests {
        private UserRepository _userRepository;
        private Random _random;

        [SetUp]
        public void SetUp() {
            _userRepository = new UserRepository();
            _random = new Random();
            ClearTable();
        }

        [TearDown]
        public void TearDown() {
            ClearTable();
        }

        [Test]
        public void Create_should_add_users() {
            var count = _random.Next(10);
            for (int x = 1; x <= count; x++) {
                var name = Guid.NewGuid().ToString().Substring(10);
                var email = Guid.NewGuid().ToString().Substring(10);
                var password = Guid.NewGuid().ToString().Substring(10);
                _userRepository.Create(name, email, password);
            }
            var users = ExecuteReader("select * from users");

            Assert.AreEqual(count, users.Count);
        }


        [Test]
        public void GetUserByEmail_should_get_user() {
            var name = Guid.NewGuid().ToString().Substring(10);
            var email = Guid.NewGuid().ToString().Substring(10);
            var password = Guid.NewGuid().ToString().Substring(10);
            _userRepository.Create(name, email, password);

            var user = _userRepository.GetUserByEmail(email);

            Assert.NotNull(user);
            Assert.AreEqual(name, user.Name);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void GetUserByEmail_should__not_get_user() {
            var name = Guid.NewGuid().ToString().Substring(10);
            var email = Guid.NewGuid().ToString().Substring(10);
            var password = Guid.NewGuid().ToString().Substring(10);
            _userRepository.Create(name, email, password);

            var user = _userRepository.GetUserByEmail(name);

            Assert.Null(user);
        }

        private void ClearTable() {
            ExecuteReader("delete from users");
        }

    }
}
