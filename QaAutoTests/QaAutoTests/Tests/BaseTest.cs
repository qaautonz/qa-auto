using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QaAutoTests.Tests
{
	[AllureNUnit]
	public class BaseTest
	{
		public IWebDriver Driver;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Driver = new ChromeDriver();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver.Dispose();
		}
	}
}
