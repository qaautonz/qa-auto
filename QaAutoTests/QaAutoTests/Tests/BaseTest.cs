using System;
using System.IO;

using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using QaAutoTests.Extensions;

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
			Driver.Manage().Window.Maximize();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver.Dispose();
		}

		[TearDown]
		public void TearDown()
		{
			try
			{
				if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
				{
					Driver.TakeScreenshot(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FailedTests"));
				}
			}
			catch (Exception ex)
			{
				TestContext.WriteLine("Ошибка при снятии скриншота {0}", ex.ToString());
			}
		}
	}
}
