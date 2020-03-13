using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace QaAutoTests.Pages
{
	class BasePage
	{
		public IWebDriver Driver { get; }

		protected BasePage(IWebDriver driver)
		{
			Driver = driver ?? throw new ArgumentNullException(nameof(driver));
			PageFactory.InitElements(driver, this);
		}
	}
}
