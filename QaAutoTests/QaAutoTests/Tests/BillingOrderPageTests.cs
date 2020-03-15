using System;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using QaAutoTests.DataObjects;
using QaAutoTests.DataStructures;
using QaAutoTests.Pages;

namespace QaAutoTests.Tests
{
	[AllureSuite("Billing order tests")]
	[Parallelizable(ParallelScope.Fixtures)]
	public class BillingOrderPageTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			var authorizationPage = new AuthorizationPage(Driver);

			authorizationPage
				.GoToPage("http://qaauto.co.nz/billing-order-form/")
				.LogIn("Testing");
		}

		[AllureTms("TestCaseSource-Attribute")]
		[AllureSeverity(SeverityLevel.blocker)]
		[TestCaseSource("FormData")]
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

        [AllureTms("TestCaseSource-Attribute")]
        [AllureSeverity(SeverityLevel.blocker)]
        [TestCaseSource("FormData1")]
        public void SubmitFormWithAllParametersTest_With_DataSets(string i, BillingOrder billingOrder)
        {
            var billingOrderPage = new BillingOrderPage(Driver);
            billingOrderPage.SendOrderForm(billingOrder);
            Assert.IsTrue(billingOrderPage.IsSuccessMessageDisplayed(),
                "Error: there is no success message on the page");
        }

        static object[] FormData1 =
        {
             
            new object[] {"Valid DataSet - 1",new BillingOrder(){FirstName = "John", LastName = "Smith", Email = "email@gmail.com", Phone = "8-800-2990-555", AddressLine1 = "Address Line 1", AddressLine2 =  "Address Line 2", City = "City", ZipCode = "63923", State = State.AK, ItemNumber = 1, Comment = "Simple last name" } },
            new object[] {"Valid DataSet - 2",new BillingOrder(){FirstName = "John", LastName = "smith1", Email = "email@gmail.com", Phone = "8-800-2990-555", AddressLine1 = "Address Line 1", AddressLine2 =  "Address Line 2", City = "City", ZipCode = "63923", State = State.AK, ItemNumber = 1, Comment = "Simple last name" } },
            new object[] { "Valid DataSet - 3", new BillingOrder(){FirstName = "john1",LastName = "smith2", Email = "email@gmail.com", Phone = "8-800-2990-555", AddressLine1 = "Address Line 1", AddressLine2 =  "Address Line 2", City = "City", ZipCode = "63923", State = State.AK, ItemNumber = 1, Comment = "Simple last name" } },

        };

        static object[] FormData =
		{
			new object[] { "John", "Smith", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.AK, 1, "Simple last name" },
			new object[] { "John", "O'Brien", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.DE, 2, "Last name with apostrophe" },
			new object[] { "John", "Smith-Klein", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.NE, 3, "Last name with hypen" },
			new object[] { "John", "Van Kempen", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.OH, 1, "Last name with multiple words" },
			new object[] { "John", "Li", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.WV, 2, "Short last name" },
			new object[] { "John", "Wolfeschlegelsteinhausenbergerdorff", "email@gmail.com", "8-800-2990-555", "Address Line 1", "Address Line 2", "City", "63923", State.WY, 3, "Long last name" }
		};
	}
}
