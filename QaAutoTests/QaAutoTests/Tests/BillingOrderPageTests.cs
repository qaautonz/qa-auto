using NUnit.Allure.Attributes;
using NUnit.Framework;
using QaAutoTests.DataStructures;
using QaAutoTests.Tests;
using QaAutoTests.Pages;

namespace QaAutoTests
{
	[AllureSuite("Billing order feature")]
	[Parallelizable(ParallelScope.Fixtures)]
	public class BillingOrderPageTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			var authorizationPage = new AuthorizationPage(Driver);

			authorizationPage
				.GoToPage()
				.LogIn("Testing");
		}

		[TestCase("John", "Doe", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.AK, 1, "Comment")]
		public void SubmitFormWithAllParametersTest(string firstName, string lastName, string email,
			string phone, string addresLine1, string addresLine2, string city, string zipCode, State state, int itemNumber, string comment)
		{
			var billingOrderPage = new BillingOrderPage(Driver);

			billingOrderPage.SendOrderForm(
				firstName: firstName,
				lastName: lastName,
				email: email,
				phone: phone,
				addressLine1: addresLine1,
				addressLine2: addresLine2,
				city: city,
				zipCode: zipCode,
				state: state,
				itemNumber: itemNumber,
				comment: comment);

			Assert.IsTrue(billingOrderPage.IsSuccessMessageDisplayed(),
				"Error: there is no success message on the page");
		}
	}
}
