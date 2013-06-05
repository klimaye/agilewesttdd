using System;
using NUnit.Framework;

namespace EssentialTDD
{
	[TestFixture()]
	public class Test
	{
		PasswordValidator validator;

		[TestFixtureSetUp()]
		public void Initialize()
		{
			validator = new PasswordValidator(7);
		}

		[Test()]
		public void adderWorks()
		{
			Assert.AreEqual(2*2,4);
		}

		[Test()]
		public void whenPasswordIsEmptyValidatorShouldReturnFailure() 
		{
			var messages = validator.Validate("");
			Assert.IsTrue(messages.Count > 0);
			Assert.AreEqual(true, messages.Contains(PasswordValidator.passwordCannotBeEmpty));
		}

		[Test()]
		public void whenPasswordIsWhitespaceValidatorShouldReturnFailure()
		{
			var messages = validator.Validate("   ");
			Assert.IsTrue(messages.Count > 0);
			Assert.AreEqual(true, messages.Contains(PasswordValidator.passwordCannotBeEmpty));
		}

		[Test()]
		public void whenPasswordIsLessThan7CharactersValidatorShouldReturnFailure()
		{
			var messages = validator.Validate("a");
			Assert.IsTrue(messages.Count > 0);
			Assert.AreEqual(true,
			                messages.Contains(
							string.Format(PasswordValidator.passwordNeedsToBeDAtLeastFormat,7)));
		}

		[Test()]
		public void whenPasswordIsMoreThan7CharactersValidatorShouldReturnSuccess()
		{
			var messages = validator.Validate("aaabb7bbx");
			Assert.AreEqual(0, messages.Count);
		}

		[Test()]
		public void whenPasswordHasNoCharactersValidatorShouldReturnFailure()
		{
			var messages = validator.Validate("7778888");
			Assert.IsTrue(messages.Count > 0);
			//Assert.Greater(0, messages.Count);
			Assert.AreEqual(true,
			                messages.Contains(PasswordValidator.passwordNeedsToBeHaveAtLeastOneCharacter));
		}

		[Test()]
		public void whenPasswordHasNoDigitsValidatorShouldReturnFailure()
		{
			var messages = validator.Validate("aaavvvvv");
			Assert.AreEqual(true, messages.Contains(PasswordValidator.passwordNeedsToHaveAtLeastOneDigit));
		}

		[Test()]
		public void whenUserIsAnAdminAndPasswordIsLessThan10CharsValidatorShouldReturnFailure()
		{
			var adminValidator = new PasswordValidator(10, true);
			var messages = adminValidator.Validate("1a!223344");
			Assert.IsTrue(messages.Count > 0);
			Assert.AreEqual(true,
			                messages.Contains(
				string.Format(PasswordValidator.passwordNeedsToBeDAtLeastFormat,10)));
//			Assert.AreEqual(false, adminValidator.Validate("11"));
//			Assert.AreEqual(false, adminValidator.Validate("11223344"));
		}

		[Test()]
		public void whenUserIsAnAdminAndPasswordIsMoreThan10CharsValidatorShouldReturnSuccess()
		{
			var adminValidator = new PasswordValidator(10, true);
			var messages = adminValidator.Validate("aa2!334466");
			Assert.IsTrue(messages.Count == 0);
//			Assert.AreEqual(true, adminValidator.Validate("1122334455"));
		}

		[Test()]
		public void whenUserIsAnAdminAndPasswordHasNoSpecialCharsValidatorShouldReturnFailure()
		{
			var adminValidator = new PasswordValidator(10, true);
			var messages = adminValidator.Validate("aa22334466");
			Assert.IsTrue(messages.Count > 0);
			Assert.IsTrue(messages.Contains(PasswordValidator.passwordNeedsToHaveAtLeastOneSpecialCharacter));
		}
	}
}

