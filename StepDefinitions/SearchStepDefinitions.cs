using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        IWebDriver driver;
        public SearchStepDefinitions()
        {
            driver = new ChromeDriver();
        }
        [Given(@"that I have to navigate google search bar")]
        public void GivenThatIHaveToNavigateGoogleSearchBar()
        {
            driver.Navigate().GoToUrl("http://google.com");
        }

        [Then(@"Enter the search item in google serach bar")]
        public void ThenEnterTheSearchItemInGoogleSerachBar()
        {
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("java");
        }

        [Then(@"Click on search button")]
        public void ThenClickOnSearchButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Name("btnK")).Click();
        }

        [Then(@"find number of related links found in page")]
        public void ThenFindNumberOfRelatedLinksFoundInPage()
        {
            ReadOnlyCollection<IWebElement> ele = driver.FindElements(By.XPath("//h3[contains(text(),\"Java\")]"));
            int count = ele.Count;
            Console.WriteLine($"Number of link found for related search is : {count}");
        }

        [Then(@"scroll down page and click to next page")]
        public void ThenScrollDownPageAndClickToNextPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)", "");
            driver.FindElement(By.XPath("//*[@id=\"botstuff\"]/div/div[2]/table/tbody/tr/td[3]/a")).Click();
        }

        [Then(@"Click on first link")]
        public void ThenClickOnFirstLink()
        {
            driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div[1]/div/a/h3")).Click();

        }

        [Then(@"displayy the title of page")]
        public void ThenDisplayyTheTitleOfPage()
        {
            var data = driver.Title;
            Console.WriteLine($"Title : {data}");
        }

        [Then(@"close the browser")]
        public void ThenCloseTheBrowser()
        {
            driver.Close();
        }
    }
}
