using PracticalEleven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace PracticalEleven.EmployeeData
{
	public static class EmployeeData
	{
		private static List<Employee> _employees = new List<Employee>();
		static EmployeeData()
		{
			for (int i = 0; i < 10; i++)
			{
				_employees.Add(new Employee()
				{
					Id = i,
					Name = $"Test{i}",
					DateOfBirth = DateTime.Today.ToString("dd-MM-yyyy"),
					Address = $"Hello this is address! {i * 568232}"
				});
			}
		}
        public static List<Employee> GetAllEmployee()
		{
			return _employees;
		}
		public static Employee GetEmployee(int id)
		{
			return _employees.Find(x => x.Id == id);
		}

		public static void AddEmployee(Employee employee)
		{
			employee.Id = _employees.Count;
			_employees.Add(employee);
		}

		public static void UpdateEmployee(Employee employee)
		{
			var GetEmp = _employees.Find(x => x.Id == employee.Id);
			if (GetEmp != null)
			{
				GetEmp.Name = employee.Name;
				GetEmp.DateOfBirth = employee.DateOfBirth;
				GetEmp.Address = employee.Address;
			}
		}

		public static void DeleteEmployee(int id)
		{
			_employees.Remove(_employees.Find(x => id == x.Id));
		}
	}
}