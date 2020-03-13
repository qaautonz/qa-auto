using NUnit.Allure.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace QaAutoTests.Pages
{
	class AuthorizationPage : BasePage
	{
		public AuthorizationPage(IWebDriver driver) : base(driver) { }

		#region Simple methods

		public AuthorizationPage GoToPage()
		{
			TestContext.WriteLine("Open authorization page");
			Driver.Navigate().GoToUrl("http://qaauto.co.nz/billing-order-form/");

			return this;
		}

		[AllureStep("Fill password '{0}'")]
		public AuthorizationPage FillPassword(string password)
		{
			TestContext.WriteLine($"Fill password '{password}'");
			PasswordInput.SendKeys(password);

			return this;
		}

		[AllureStep("Click submit button")]
		public BillingOrderPage ClickSubmitButton()
		{
			TestContext.WriteLine("Click submit button");
			SubmitButton.Click();

			return new BillingOrderPage(Driver);
		}

		#endregion

		#region Complex methods

		[AllureStep("Log in")]
		public BillingOrderPage LogIn(string password)
		{
			FillPassword(password);

			return ClickSubmitButton();
		}

		#endregion

		#region Elements

		[FindsBy(How = How.Name, Using = "wpforms[form_locker_password]")]
		protected IWebElement PasswordInput { get; set; }

		[FindsBy(How = How.Name, Using = "wpforms[submit]")]
		protected IWebElement SubmitButton { get; set; }

		#endregion

		#region Locators

		#endregion
	}
}
