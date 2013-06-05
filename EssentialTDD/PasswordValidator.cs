using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EssentialTDD
{
	public class PasswordValidator
	{
		protected int minLength;
		protected bool isAdmin;

		public PasswordValidator (int minLengthAccepted, bool isAdministrator = false)
		{
			isAdmin = isAdministrator;
			minLength = isAdmin ? 10 : 7;
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

		public const string passwordCannotBeEmpty = "password cannot be empty";

		public const string passwordNeedsToBeHaveAtLeastOneCharacter = "password needs to be have at least one character";

		public const string passwordNeedsToHaveAtLeastOneDigit = "password needs to have at least one digit";

		public const string passwordNeedsToBeDAtLeastFormat = "password needs to be %d at least";

		public const string passwordNeedsToHaveAtLeastOneSpecialCharacter = "password needs to have at least one special character";

		public List<string> Validate(string password)
		{
			var validationMessages = new List<String>();
			if (IsEmpty(password))
				validationMessages.Add (passwordCannotBeEmpty);

			if (IsMinLength(password) ==false)
				validationMessages.Add(string.Format (passwordNeedsToBeDAtLeastFormat, minLength));
			
			if (MatchingPatterns(password, "[a-zA-Z]") == 0)
				validationMessages.Add (passwordNeedsToBeHaveAtLeastOneCharacter);
			
			if (MatchingPatterns(password, "[\\d]") == 0)
				validationMessages.Add (passwordNeedsToHaveAtLeastOneDigit);

			if (isAdmin) {
				if (MatchingPatterns(password, "^[a-zA-Z0-9]+$") != 0)
					validationMessages.Add (passwordNeedsToHaveAtLeastOneSpecialCharacter);
			}
			return validationMessages;
		}
	}
}

