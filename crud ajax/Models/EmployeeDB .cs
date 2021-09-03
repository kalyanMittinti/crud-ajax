using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace crud_ajax.Models
{
    public class EmployeeDB
    {
        //declare connection string  
         string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        

        //Return list of all Employees  
        public List<Employee> ListAll()
        {
            List<Employee> lst = new List<Employee>();
            //The "using" statement allows you to specify multiple resources in a single statement.
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectEmployee1", con);
                //The CommandType enumeration decides what type of object a command will be executed
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        employeeid = Convert.ToInt32(rdr["employeeid"]),
                        name = rdr["name"].ToString(),
                        age = Convert.ToInt32(rdr["age"]),
                        state = rdr["state"].ToString(),
                        country = rdr["country"].ToString(),
                    });
                }
                return lst;
            }
        }
        //Method for Adding an Employee  
        public int Add(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", emp.employeeid);
                com.Parameters.AddWithValue("@name", emp.name);
                com.Parameters.AddWithValue("@age", emp.age);
                com.Parameters.AddWithValue("@state", emp.state);
                com.Parameters.AddWithValue("@country", emp.country);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record  
        public int Update(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", emp.employeeid);
                com.Parameters.AddWithValue("@name", emp.name);
                com.Parameters.AddWithValue("@age", emp.age);
                com.Parameters.AddWithValue("@state", emp.state);
                com.Parameters.AddWithValue("@country", emp.country);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }

}