using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QaAutoTests.Extensions
{
	public static class WebDriverExtensions
	{
		public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

		public static bool WaitUntilElementIsDisplay(this IWebDriver driver, By by, TimeSpan? timeout = null)
		{
			var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

			try
			{
				return wait.Until(d => d.FindElement(by).Displayed);
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
			catch (StaleElementReferenceException)
			{
				return wait.Until(d => d.FindElement(by).Displayed);
			}
		}
	}
}
