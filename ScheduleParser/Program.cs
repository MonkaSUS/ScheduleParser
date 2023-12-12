using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScheduleParser;
using System.Collections.ObjectModel;
using System.Data;

const string BaseUrl = "https://schedule.kg-college.ru/";
ChromeDriver baseDriver = new ChromeDriver();

void GoToScheduleForGroup(string GroupName, ChromeDriver driver)
{
    
    driver.Url = BaseUrl;
    driver.FindElement(By.XPath("/html/body/div[4]/div/button[1]")).Click();
    List<IWebElement> Groups = new();
    for (int i = 1; i <= 104; i++)
    {
        Groups.Add(driver.FindElement(By.XPath($"//*[@id=\"selectgroupname\"]/option[{i}]")));
    }
    var group = Groups.FirstOrDefault(x => x.Text == GroupName);
    if (group is not null)
    {
        group.Click();
        driver.FindElement(By.XPath("//*[@id=\"fGroupCase\"]/div[2]/button[2]")).Click();
    }
    GetScheduleForThisWeek(driver);
}
void GetScheduleForThisWeek(ChromeDriver driver)
{
    List<IWebElement> WeekDays = new();
    IWebElement mainContainer = driver.FindElement(By.XPath("/html/body/div[4]/div"));
    for (int i = 1; i <= 5; i++)
    {
    WeekDays.Add(mainContainer.FindElement(By.XPath($"/html/body/div[4]/div/div[{i}]")));
    }
    foreach (var item in WeekDays)
    {
        string WeekDayName = item.FindElement(By.XPath("/html/body/div[4]/div/div[1]/div/div[1]/h5/text()")).Text.Split('/')[0];
        string Date = item.FindElement(By.XPath("/html/body/div[4]/div/div[1]/div/div[1]/h5/text()")).Text.Split('/')[1];
        List<IWebElement> lessons = new();
        for (int i = 1; i <= 7; i++)
        {
            lessons.Add(item.FindElement(By.XPath($"/html/body/div[4]/div/div[1]/div/div[2]/table/tbody/tr[{i}]")));
        }
    }
}
GoToScheduleForGroup("ИС-44к", baseDriver);

