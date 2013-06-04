using System;
using System.Text.RegularExpressions;

namespace EssentialTDD
{
	public abstract class PasswordValidator
	{
		protected int minLength;

		public PasswordValidator (int minLengthAccepted)
		{
			minLength = minLengthAccepted;
		}

		protected bool IsEmpty(string password)
		{
			return string.IsNullOrWhiteSpace(password);
		}

		protected bool IsMinLength(string password)
		{
			return password.Length >= minLength;
		}

		protected int MatchingPatterns(string password, string pattern)
		{
			return Regex.Matches(password, pattern).Count;
		}

		public abstract bool Validate(string password);
	}
}

