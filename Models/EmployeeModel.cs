using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Campus_Management_System.Models
{
    public class EmployeeModel
    {
        SqlConnection con = new SqlConnection(@"#");
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Dept")]
        public string Department { get; set; }

        [Required(ErrorMessage = "please enter salary")]
        [Range(5000, 50000, ErrorMessage = "Value should be between 5k to 50k")]
        public int Salary { get; set; }

        public List<EmployeeModel> getData()
        {
            List<EmployeeModel> lstemp = new List<EmployeeModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from tbl_emp", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstemp.Add(new EmployeeModel
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Department = dr["Dept"].ToString(),
                    Salary = Convert.ToInt32(dr["Salary"].ToString()),
                });
            }
            return lstemp;
        }
        public EmployeeModel getData(string Id)
        {
            EmployeeModel emp = new EmployeeModel();
            SqlCommand cmd = new SqlCommand("select * from tbl_emp where Id = '"+Id+"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Department = dr["Dept"].ToString();
                    emp.Salary = Convert.ToInt32(dr["Salary"].ToString());
                }
            }
            con.Close();
            return emp;
        }
        public bool insert(EmployeeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_emp values(@name, @dept, @salary)", con); 
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@dept", Emp.Department);
            cmd.Parameters.AddWithValue("@salary", Emp.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool update(EmployeeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("update tbl_emp set Name=@name, Dept=@dept, Salary=@salary where Id = @id", con);
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@dept", Emp.Department);
            cmd.Parameters.AddWithValue("@salary", Emp.Salary);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(EmployeeModel Emp)
        {
            SqlCommand cmd = new SqlCommand("delete from tbl_emp where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
