using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddEducationSteps
    {
        [Given(@"I clicked on the Eduction tab under Profile page")]
        public void GivenIClickedOnTheEductionTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath(" //*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }
        
        [When(@"I add a new Education")]
        public void WhenIAddANewEducation()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("*//[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Add Education
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input ")).SendKeys("B.E");

            //Choose COUNTRY
            IWebElement country = Driver.driver.FindElements(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"))[1];
            country.Click();

            //Choose title
            IWebElement     Title = Driver.driver.FindElements(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"))[1];
            Title.Click();
            //Add Degree
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input ")).SendKeys("Engineering");
            //year of graduation
            IWebElement yearofgraduation = Driver.driver.FindElements(By.XPath(" //*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"))[1];
            yearofgraduation.Click();
        }

        [Then(@"that Education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "B.E";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }
        }
    }
