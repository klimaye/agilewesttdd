using System;
using System.Text.RegularExpressions;

namespace EssentialTDD
{
	public class UserPasswordValdiator : PasswordValidator
	{
		public UserPasswordValdiator (int minLengthAccepted)
			: base(minLengthAccepted)
		{
		}

		public override bool Validate(string password)
		{
			if (IsEmpty(password))
				return false;
			
			if (IsMinLength(password) ==false)
				return false;
			
			if (MatchingPatterns(password, "[a-zA-Z]") == 0)
				return false;
			
			if (MatchingPatterns(password, "[\\d]") == 0)
				return false;
			
			return true;
		}
	}
}

