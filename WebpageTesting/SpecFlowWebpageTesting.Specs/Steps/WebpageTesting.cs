using TechTalk.SpecFlow;
using SpecFlowAmazonShopping;
using OpenQA.Selenium;
using System.IO;
using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowWebpageTesting.Specs.Steps
{
    [Binding]
    public sealed class WebpageTesting
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private WebDriver driver;
        private WebDriver driverChrome;
        private string url = "https://lambdatest.github.io/sample-todo-app/";

        public WebpageTesting(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            
        }

        [Before]
        public void SetupWebpage()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driverChrome = new ChromeDriver(path + @"\drivers\");

            driver = driverChrome;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
        }

        [After]
        public void Teardown()
        {
            driver.Close();
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            Assert.AreEqual(driver.Url, url);
        }

        [When(@"I select checkbox in row (.*)")]
        public void WhenISelectCheckboxInRow(int rowNumber)
        {
            driver.FindElement(By.XPath($"//ul/li[{rowNumber}]/input")).Click();
        }

        [When(@"I enter value ""(.*)"" into the text box")]
        public void WhenIEnterValueIntoTheTextBox(string textValue)
        {
            driver.FindElement(By.Id("sampletodotext")).SendKeys(textValue);
        }

        [When(@"I click the add button")]
        public void WhenIClickTheAddButton()
        {
            driver.FindElement(By.Id("addbutton")).Click();
        }


        [Then(@"the row (.*) is crossed out")]
        public void ThenTheRowIsCrossedOut(int rowNumber)
        {
            var elementClass = driver.FindElement(By.XPath($"//ul/li[{rowNumber}]/input")).GetAttribute("class");
            StringAssert.Contains("ng-dirty", elementClass);
        }

        [Then(@"Value ""(.*)"" will be in the list")]
        public void ThenValueWillBeInTheList(string listValue)
        {
            var elementList = driver.FindElements(By.XPath($"//span[text()='{listValue}']"));
            Assert.IsTrue(elementList.Count == 1);
        }
    }
}
