using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBApp.dbEntityClasses;
using MySql.Data.MySqlClient;

namespace DBApp
{
    public class Database
    {
        readonly MySqlConnection connection = new("user=root; password=goydaDB1337; port=3306; server=localhost; database=collegedb");

        public List<Student> GetStudents()
        {
            List<Student> studentslst = [];


            connection.Open();

            string querry = "select * from students";

            MySqlCommand command = new(querry, connection);


            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                {
                Student student = new()
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                    Email = reader["Email"].ToString()
                };

                studentslst.Add(student);
            }
            reader.Close();

            connection.Close();

            return studentslst;
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teacherslst = [];

            connection.Open();

            string query = "select * from teachers";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new()
                {
                    TeacherID = Convert.ToInt32(reader["TeacherID"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString()
                };

                teacherslst.Add(teacher);
            }
            reader.Close();

            connection.Close();

            return teacherslst;
        }

        public List<Group> GetGroups()
        {
            List<Group> groupslst = [];

            connection.Open();

            string query = "select * from groupes";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Group group = new()
                {
                    GroupID = Convert.ToInt32(reader["GroupID"]),
                    GroupName = reader["GroupName"].ToString()
                };

                groupslst.Add(group);
            }
            reader.Close();

            connection.Close();

            return groupslst;
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjectlst = [];

            connection.Open();

            string query = "select * from subjects";

            MySqlCommand command = new(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Subject subject = new()
                {
                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                    SubjectName = reader["SubjectName"].ToString()
                };

                subjectlst.Add(subject);
            }

            reader.Close();

            connection.Close();

            return subjectlst;
        }

        public void AddStudent(string firstName, string lastname, DateTime birthDate, string email)
        {
            try
            {
                connection.Open();

                string querry = "INSERT INTO students (FirstName, LastName, BirthDate, Email) VALUES (@FirstName, @LastName, @BirthDate, @Email)";

                MySqlCommand cmd = new(querry, connection);

                cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = firstName;
                cmd.Parameters.Add("@Lastname", MySqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@BirthDate", MySqlDbType.Date).Value = birthDate;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = email;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddTeacher(string firstName, string lastName, string email)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO teachers (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";

                MySqlCommand cmd = new(query, connection);

                cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = lastName;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = email;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void AddGroup(string groupName)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO groupes (GroupName) VALUES (@GroupName)";

                MySqlCommand cmd = new(query, connection);

                cmd.Parameters.Add("@GroupName", MySqlDbType.VarChar).Value = groupName;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteStudent(int studentId)
        {
            string query = "DELETE FROM students WHERE StudentID = @id";

            MySqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@id", studentId);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteTeacher(int teacherId)
        {
            string query = "DELETE FROM teachers WHERE TeacherID = @id";

            MySqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@id", teacherId);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteGroup(int groupId)
        {
            string query = "DELETE FROM groupes WHERE GroupID = @id";

            MySqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@id", groupId);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
