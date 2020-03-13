using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QaAutoTests.Pages;

namespace QaAutoTests.Tests
{
	[Parallelizable(ParallelScope.Fixtures)]
	class TestBlankFormPageTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			var authorizationPage = new AuthorizationPage(Driver);

			authorizationPage
				.GoToPage("http://qaauto.co.nz/test-blank-form/")
				.LogIn("Testing");
		}

		[TestCase("John", "Doe", "email@gmail.com", "Comment")]
		public void SubmitFormWithAllParametersTest(string firstName, string lastName, string email, string comment)
		{
			var testBlankFormPage = new TestBlankFormPage(Driver);

			testBlankFormPage.SendForm(firstName: firstName, lastName: lastName, email: email, comment: comment);

			Assert.IsTrue(testBlankFormPage.IsSuccessMessageDisplayed());
		}
	}
}
