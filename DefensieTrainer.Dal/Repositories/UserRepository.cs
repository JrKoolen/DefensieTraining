using System;
using System.Collections.Generic;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.Logica;
using MySql.Data.MySqlClient;

namespace DefensieTrainer.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateUser(CreateUserDto user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Person (Name, LastName, Email, Password, Weight, Length, ArrivalDate, ArmedForce)
                                 VALUES (@Name, @LastName, @Email, @Password, @Weight, @Length, @ArrivalDate, @ArmedForce)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Weight", user.Weight);
                    command.Parameters.AddWithValue("@Length", user.Length);
                    command.Parameters.AddWithValue("@ArrivalDate", user.ArrivalDate);
                    command.Parameters.AddWithValue("@ArmedForce", user.ArmedForce);

                    command.ExecuteNonQuery();
                }
            }
        }

        public UserDto GetUserByEmail(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Person WHERE Email = @Email";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                Weight = Convert.ToSingle(reader["Weight"]),
                                Length = Convert.ToSingle(reader["Length"]),
                                ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"]),
                                ArmedForce = reader["ArmedForce"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Person WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUsers(int[] ids)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Person WHERE Id IN (" + string.Join(",", ids) + ")";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UserDto> GetAllUsers()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Person";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var users = new List<UserDto>();
                        while (reader.Read())
                        {
                            users.Add(new UserDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Length = Convert.ToInt32(reader["Length"]),
                                Weight = Convert.ToInt32(reader["Weight"]),
                                ArmedForce = reader["ArmedForce"].ToString(),
                                ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"])

                        });
                        }
                        return users;
                    }
                }
            }
        }

        public UserDto GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Person WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Length = Convert.ToInt32(reader["Length"]),
                                Weight = Convert.ToInt32(reader["Weight"]),
                                ArmedForce = reader["ArmedForce"].ToString(),
                                ArrivalDate = Convert.ToDateTime(reader["ArrivalDate"])
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void UpdateUser(CreateUserDto user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"UPDATE Person
                                 SET Name = @Name,
                                     LastName = @LastName,
                                     Email = @Email,
                                     Password = @Password,
                                     Weight = @Weight,
                                     Length = @Length,
                                     ArrivalDate = @ArrivalDate,
                                     ArmedForce = @ArmedForce
                                 WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Weight", user.Weight);
                    command.Parameters.AddWithValue("@Length", user.Length);
                    command.Parameters.AddWithValue("@ArrivalDate", user.ArrivalDate);
                    command.Parameters.AddWithValue("@ArmedForce", user.ArmedForce);
                    command.Parameters.AddWithValue("@Id", user.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
