using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using RelevantCodes.ExtentReports;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkillsSteps
    {
        [Given(@"I clicked on the skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2] ")).Click();

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

            //Add skills
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input ")).SendKeys("Asp.net");

            //Click on skill level
            Driver.driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the skill level
            IWebElement skill = Driver.driver.FindElements(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option"))[1];
            skill.Click();

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Asp.net";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "skillAdded");
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
