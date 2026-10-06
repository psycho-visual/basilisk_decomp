using System;

namespace Razer.AccountManager
{
	public class ConsentRequiredException : Exception
	{
		public string Scope { get; set; }

		public ConsentRequiredException()
			: this(string.Empty)
		{
		}

		public ConsentRequiredException(string scope)
			: base("The user needs to consent to the latest ToS")
		{
			Scope = scope;
		}
	}
}
