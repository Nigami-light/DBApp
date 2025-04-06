using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    SubjectName = reader["SubjectName"].ToString()
                };

                subjectlst.Add(subject);
            }

            reader.Close();

            connection.Close();

            return subjectlst;
        }
    }
}
