//using System;
//
//namespace EssentialTDD
//{
//	public class AdminPasswordValidator : PasswordValidator
//	{
//		public AdminPasswordValidator (int minLengthAccepted)
//			: base(minLengthAccepted)
//		{
//		}
//
//		public override bool Validate(string password)
//		{
//			if (IsEmpty(password))
//				return false;
//			
//			if (IsMinLength(password) ==false)
//				return false;
//
//			return true;
//		}
//	}
//}
//
