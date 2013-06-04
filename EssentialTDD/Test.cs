using System;
using NUnit.Framework;

namespace EssentialTDD
{
	[TestFixture()]
	public class Test
	{
		UserPasswordValdiator validator;

		[TestFixtureSetUp()]
		public void Initialize()
		{
			validator = new UserPasswordValdiator(7);
		}

		[Test()]
		public void adderWorks()
		{
			Assert.AreEqual(2*2,4);
		}

		[Test()]
		public void whenPasswordIsEmptyValidatorShouldReturnFailure() 
		{
			Assert.AreEqual(false, validator.Validate(""));
		}

		[Test()]
		public void whenPasswordIsWhitespaceValidatorShouldReturnFailure()
		{
			Assert.AreEqual(false, validator.Validate("  "));
		}

		[Test()]
		public void whenPasswordIsLessThan7CharactersValidatorShouldReturnFailure()
		{
			Assert.AreEqual(false, validator.Validate("a"));
		}

		[Test()]
		public void whenPasswordIsMoreThan7CharactersValidatorShouldReturnSuccess()
		{
			Assert.AreEqual(true, validator.Validate("aaabb7bbx"));
		}

		[Test()]
		public void whenPasswordHasNoCharactersValidatorShouldReturnFailure()
		{
			Assert.AreEqual(false, validator.Validate("7778888"));
		}

		[Test()]
		public void whenPasswordHasNoDigitsValidatorShouldReturnFailure()
		{
			var result = validator.Validate("aaavvvvv");
			Assert.AreEqual(false, result);
		}

		[Test()]
		public void whenUserIsAnAdminAndPasswordIsLessThan10CharsValidatorShouldReturnFailure()
		{
			var adminValidator = new AdminPasswordValidator(10);
			Assert.AreEqual(false, adminValidator.Validate("11"));
			Assert.AreEqual(false, adminValidator.Validate("11223344"));
		}

		[Test()]
		public void whenUserIsAnAdminAndPasswordIsMoreThan10CharsValidatorShouldReturnSuccess()
		{
			var adminValidator = new AdminPasswordValidator(10);
			Assert.AreEqual(true, adminValidator.Validate("1122334455"));
		}
	}
}

