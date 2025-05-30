using LRSprojectISS.repository.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LRSprojectISS.domain;
using Microsoft.Data.SqlClient;

namespace LRSprojectISS.repository
{
    internal class MemberRepository : IMemberRepository
    {
        private string _connectionString;
        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Member? FindOne(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Members WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToMember(reader);
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Member> FindAll()
        {
            List<Member> members = new List<Member>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Members";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            members.Add(MapReaderToMember(reader));
                        }
                    }
                }
            }

            return members;
        }

        public Member? FindOneByCnp(long cnp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Members WHERE Cnp = @Cnp";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cnp", cnp);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToMember(reader);
                        }
                    }
                }
            }
            return null;
        }

        private Member MapReaderToMember(SqlDataReader reader)
        {
            long cnp = Convert.ToInt64(reader["Cnp"]);
            string name = reader["Name"].ToString();
            string address = reader["Address"].ToString();
            long phone = Convert.ToInt64(reader["Phone"]);

            Member member = new Member(cnp, name, address, phone);
            member.Id = Convert.ToInt64(reader["Id"]);

            return member;
        }
    }
}

