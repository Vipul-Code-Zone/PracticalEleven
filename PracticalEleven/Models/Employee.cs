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
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name Should be maximum 50 character")]
		public string Name { get; set; }
		[DisplayName("Date of Birth")]
		[Required]
		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		//[Range(typeof(DateTime), minimum:"01-01-1900", maximum:"01-07-2023", ErrorMessage = "Value for {0} must be between 01-01-1900 and 01-07-2023")]
		public string DateOfBirth { get; set; }
		[Required]
		[MaxLength(100, ErrorMessage = "Address Should be maximum 100 character")]
		public string Address { get; set; }
	}
}