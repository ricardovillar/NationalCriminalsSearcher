using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;

namespace CriminalsSearcher.Tests.Data.Repositories {

    [TestFixture]
    public abstract class DataRepositoryTests {
        private readonly SqlConnection _connection;

        protected DataRepositoryTests() {
            var connectionString = ConfigurationManager.ConnectionStrings["CriminalsSearcherDB"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }        

        [TestFixtureSetUp]
        public void FixtureSetUp() {
            _connection.Open();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown() {
            _connection.Close();
            _connection.Dispose();
        }        

        protected void ExecuteNonQuery(string sql) {
            var command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        protected List<object[]> ExecuteReader(string sql) {
            var result = new List<object[]>();
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read()) {                
                var values = new object[reader.FieldCount];
                reader.GetValues(values);
                result.Add(values);
            }
            reader.Close();
            return result;
        }


    }
}
