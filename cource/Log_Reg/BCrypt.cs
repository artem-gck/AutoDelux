using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace cource.Log_Reg
{
	public class Hashing
	{
		private static string GetRandomSalt()
		{
			return BCrypt.Net.BCrypt.GenerateSalt(12);
		}

		public static string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password + "12gh%", GetRandomSalt());
		}

		public static bool ValidatePassword(string password, string correctHash)
		{
			return BCrypt.Net.BCrypt.Verify(password + "12gh%", correctHash);
		}
	}
}
