using PracticalEleven.Models;
using System;
using System.Collections.Generic;
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
		public PartialViewResult Details(int id)
		{
			Employee employee = EmployeeData.EmployeeData.GetEmployee(id);
			return PartialView("_DetailsPartialView", employee);
		}

		// GET: Employee/Create
		public PartialViewResult Create()
		{
			return PartialView("_CreatePartialView");
		}

		// POST: Employee/Create
		[HttpPost]
		public ActionResult Create(Employee employee)
		{
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
		public PartialViewResult Edit(int id)
		{
			var employee = EmployeeData.EmployeeData.GetEmployee(id);

			if (employee == null)
			{
				return PartialView("Error");
			}
			return PartialView("_EditPartialView", employee);
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
				return View("Index");
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
