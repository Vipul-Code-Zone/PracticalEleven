using PracticalEleven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalEleven.Controllers
{
    public class Test2Controller : Controller
    {
		// GET: Employee
		public ActionResult Index()
		{
			List<Employee> employee = EmployeeData.EmployeeData.GetAllEmployee();
			return View(employee);
		}

		// GET: Employee/Details/5
		public ActionResult Details(int id)
		{
			Employee employee = EmployeeData.EmployeeData.GetEmployee(id);
			return View(employee);
		}

		// GET: Employee/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Employee/Create
		[HttpPost]
		public ActionResult Create(Employee employee)
		{
			try
			{
				Employee newEmp = new Employee();
				newEmp.Name = employee.Name;
				newEmp.DateOfBirth = employee.DateOfBirth;
				newEmp.Address = employee.Address;
				EmployeeData.EmployeeData.AddEmployee(newEmp);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Employee/Edit/5
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Error");
			}

			var employee = EmployeeData.EmployeeData.GetEmployee(id ?? 0);

			if (employee == null)
			{
				return RedirectToAction("Error");
			}
			return View(employee);
		}

		// POST: Employee/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Employee employee)
		{
			try
			{
				if (employee == null)
				{
					return RedirectToAction("Error");
				}

				EmployeeData.EmployeeData.UpdateEmployee(employee);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Employee/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Error");
			}
			var employee = EmployeeData.EmployeeData.GetEmployee(id ?? 0);

			if (employee == null)
			{
				return RedirectToAction("Error");
			}
			return View(employee);
		}

		// POST: Employee/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, Employee employee)
		{
			try
			{
				if (employee == null)
				{
					return RedirectToAction("Error");
				}

				EmployeeData.EmployeeData.DeleteEmployee(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
