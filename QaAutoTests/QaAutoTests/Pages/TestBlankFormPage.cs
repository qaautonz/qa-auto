using NUnit.Allure.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using QaAutoTests.Extensions;

namespace QaAutoTests.Pages
{
	class TestBlankFormPage : BasePage
	{
		public TestBlankFormPage(IWebDriver driver) : base(driver) { }

		#region Simple methods

		[AllureStep("Fill first name")]
		public TestBlankFormPage FillFirstName(string name)
		{
			TestContext.WriteLine($"Fill first name - '{name}'");
			FirstNameInput.SendKeys(name);

			return this;
		}

		[AllureStep("Fill last name")]
		public TestBlankFormPage FillLastName(string name)
		{
			TestContext.WriteLine($"Fill last name - '{name}'");
			LastNameInput.SendKeys(name);

			return this;
		}

		[AllureStep("Fill email")]
		public TestBlankFormPage FillEmail(string email)
		{
			TestContext.WriteLine($"Fill email - '{email}'");
			EmailInput.SendKeys(email);

			return this;
		}

		[AllureStep("Fill comment")]
		public TestBlankFormPage FillComment(string comment)
		{
			TestContext.WriteLine($"Fill comment - '{comment}'");
			CommentInput.SendKeys(comment);

			return this;
		}
		
		[AllureStep("Click submit button")]
		public TestBlankFormPage ClickSubmitButton()
		{
			TestContext.WriteLine("Click submit button");
			SubmitButton.Click();

			return this;
		}

		#endregion

		#region Complex methods

		[AllureStep("Submit form")]
		public TestBlankFormPage SendForm(
			string firstName,
			string lastName,
			string email,
			string comment)
		{
			FillFirstName(firstName);
			FillLastName(lastName);
			FillEmail(email);
			FillComment(comment);
			ClickSubmitButton();

			return this;
		}

		#endregion

		#region Page conditions methods

		[AllureStep("Check success message displayed")]
		public bool IsSuccessMessageDisplayed()
		{
			TestContext.WriteLine("Check success message displayed");

			return Driver.WaitUntilElementIsDisplay(By.XPath(SUCCESS_MESSAGE));
		}

		#endregion

		#region Elements

		[FindsBy(How = How.Name, Using = "wpforms[fields][0][first]")]
		protected IWebElement FirstNameInput { get; set; }

		[FindsBy(How = How.Name, Using = "wpforms[fields][0][last]")]
		protected IWebElement LastNameInput { get; set; }

		[FindsBy(How = How.Name, Using = "wpforms[fields][1]")]
		protected IWebElement EmailInput { get; set; }

		[FindsBy(How = How.Name, Using = "wpforms[fields][2]")]
		protected IWebElement CommentInput { get; set; }

		[FindsBy(How = How.Name, Using = "wpforms[submit]")]
		protected IWebElement SubmitButton { get; set; }

		#endregion

		#region Locators

		private const string SUCCESS_MESSAGE = "//p[text()='Thanks for contacting us! We will be in touch with you shortly.']";

		#endregion
	}
}
