using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticalEleven.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is Required Please Fill")]
		public string Name { get; set; }
		[DisplayName("Date of Birth")]
		[Required(ErrorMessage = "Date of Birth is Required Please Fill")]
		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public string DateOfBirth { get; set; }
		[Required(ErrorMessage = "Address is Required Please Fill")]
		public string Address { get; set; }
	}
}