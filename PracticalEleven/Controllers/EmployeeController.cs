using PracticalEleven.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PracticalEleven.Controllers
{
	public class EmployeeController : Controller
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
			var test = Convert.ToDateTime(employee.DateOfBirth) - DateTime.Now;
			var test1 = new DateTime(1900, 01, 01) - Convert.ToDateTime(employee.DateOfBirth);
			if (test.Days > 1 || test1.Days > 1)
			{
				ViewBag.Message = "Date Should Be between 1900-01-01 to Today's Date";
				return View();
			}

			Employee newEmp = new Employee();
			newEmp.Name = employee.Name;
			newEmp.DateOfBirth = employee.DateOfBirth;
			newEmp.Address = employee.Address;
			EmployeeData.EmployeeData.AddEmployee(newEmp);
			TempData["AddSuccess"] = "Employee Added Successfully!";
			return RedirectToAction("Index");
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
				TempData["UpdateSuccess"] = "Employee Updated Successfully!";
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
				TempData["deletedSuccess"] = "Employee Deleted!";
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
