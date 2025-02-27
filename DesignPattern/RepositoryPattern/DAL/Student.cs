﻿using System;

namespace RepositoryPattern.DAL
{
	public class Student
	{

		public int StudentID { get; set; }  
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }

		public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

		public string FormattedDateOfBirth
		{
			get { return DateOfBirth.ToString("yyyy-MM-dd"); }
		}
	}
}
