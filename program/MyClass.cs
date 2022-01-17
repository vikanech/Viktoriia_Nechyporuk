using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;


namespace Chrome_Driver_Launch
{

	public static class GlobalVariables
	{
		public static Dictionary<string, string> my_data;
		public static Driver driver;
		public static string pay_grade_id;
		public static string path_to_driver = "/Users/krolik/Desktop/2";
		public static string url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";


		public static void InitialiseSecret()
		{
			my_data = new Dictionary<string, string>();
			my_data.Add("login", "Admin");
			my_data.Add("password", "admin123");
			my_data.Add("shiftName", "Everyday");
			my_data.Add("employeName", "Ananya Dash");
			my_data.Add("workShift_workHours_from", "09:00");
			my_data.Add("workShift_workHours_to", "18:00");

		}

		public static void InitialiseDriver()
		{
			driver = new Driver(path_to_driver, url, my_data);
		}
	}

	public class Driver : ChromeDriver
	{

		String login;
		String password;
		String shiftName;
		String employeName;
		String workShift_workHours_from;
		String workShift_workHours_to;


		public Driver(string path, string url, Dictionary<string, string> my_data) : base(path)
		{
			this.Url = url;
			this.login = my_data["login"];
			this.password = my_data["password"];
			this.shiftName = my_data["shiftName"];
			this.employeName = my_data["employeName"];
			this.workShift_workHours_from = my_data["workShift_workHours_from"];
			this.workShift_workHours_to = my_data["workShift_workHours_to"];
		}

		public string Exception(string module, string span = ".//span[@class = \"validation-error\"]")
		{
			string answer, error;
			try
			{
				error = this.FindElement(By.XPath(span)).Text;
			}
			catch (NoSuchElementException)
			{
				error = "";
			}


			if (error == "")
			{
				answer = "SUCCESS";
			}
			else
			{
				answer = "ERROR";
			}
			Console.Write($"{answer} {error}, in {module} \n");
			return answer;
		}


		public string LogIn()
		{
			this.FindElement(By.Name("txtUsername")).SendKeys(this.login);
			this.FindElement(By.Name("txtPassword")).SendKeys(this.password);
			this.FindElement(By.Name("Submit")).Click();
			string answer = this.Exception("login", ".//span[@id=\"spanMessage\"]");
			return answer;

		}
		public void ToWorkShifts()
		{
			this.FindElement(By.Id("menu_admin_viewAdminModule")).Click();
			this.FindElement(By.Id("menu_admin_Job")).Click();
			this.FindElement(By.Id("menu_admin_workShift")).Click();
		}
		public string AddWorkShift()
		{
			this.ToWorkShifts();
			this.FindElement(By.Name("btnAdd")).Click();
			this.FindElement(By.Id("workShift_name")).SendKeys(this.shiftName);
			this.FindElement(By.XPath($"//select[@id='workShift_workHours_from']")).Click();
			this.FindElement(By.XPath($"//select[@id='workShift_workHours_from']/option[@value='{this.workShift_workHours_from}']")).Click();
			this.FindElement(By.XPath($"//select[@id='workShift_workHours_to']")).Click();
			this.FindElement(By.XPath($"//select[@id='workShift_workHours_to']/option[@value='{this.workShift_workHours_to}']")).Click();
			this.FindElement(By.XPath($"//select[@id='workShift_availableEmp']/option[text()='{this.employeName}']")).Click();
			this.FindElement(By.Id("btnAssignEmployee")).Click();
			this.FindElement(By.Name("btnSave")).Click();
			string answer = this.Exception("AddUsers");

			return answer;
		}


		public string Delete()
		{
			string answer;
			this.ToWorkShifts();

			this.FindElement(By.XPath($"//td[contains(.,'{this.shiftName}')]/preceding-sibling::td/input")).Click();
			this.FindElement(By.Name("btnDelete")).Click();
			this.FindElement(By.Id("dialogDeleteBtn")).Click();
			try
			{
				this.FindElement(By.XPath($"//*[text()='{this.shiftName}']"));
				answer = "ERROR";
			}
			catch (NoSuchElementException)
			{
				answer = "SUCCESS";
			}
			Console.Write($"Delete: {answer}\n");
			return answer;
		}

		public string IsChangesVisible()
		{
			string answer, result;
			string start_shift_from_site = "";
			string end_shift_from_site = "";

			this.ToWorkShifts();

			try
			{
				start_shift_from_site = this.FindElement(By.XPath($"//td[contains(.,'{this.shiftName}')]/following-sibling::td[1]")).Text;
				end_shift_from_site = this.FindElement(By.XPath($"//td[contains(.,'{this.shiftName}')]/following-sibling::td[2]")).Text;
				result = "SUCCESS";
			}
			catch (NoSuchElementException)
			{
				result = "ERROR";
			}


			if (result == "SUCCESS" && end_shift_from_site == this.workShift_workHours_to && start_shift_from_site == this.workShift_workHours_from)
			{
				answer = "SUCCESS";
			}
			else
			{
				answer = "ERROR";
			}



			return answer;

		}

		public string IsDeleteSuccess()
		{
			string answer;
			this.ToWorkShifts();
			try
			{
				this.FindElement(By.XPath($"//table[@id='resultTable']/tbody/tr/td[@class='left']/a[text()='{this.shiftName}']")).Click();

				answer = "SUCCESS";
			}
			catch (NoSuchElementException)
			{
				answer = "ERROR";
			}



			return answer;

		}




	}




	[TestFixture]
	class MainClass
	{

		[Test]
		public void Test0_Connection()
		{
			GlobalVariables.InitialiseSecret();
			GlobalVariables.InitialiseDriver();
			var actualUrl = GlobalVariables.driver.Url;
			Assert.AreEqual(actualUrl, GlobalVariables.url);
		}

		[Test]
		public void Test1_LogIn()
		{
			var result = GlobalVariables.driver.LogIn();
			Assert.AreEqual(result, "SUCCESS");
		}

		[Test]
		public void Test2_1_AddWorkShift()
		{

			var result = GlobalVariables.driver.AddWorkShift();
			Assert.AreEqual(result, "SUCCESS");
		}


		[Test]
		public void Test2_3_AddInfo_Check()
		{

			var result = GlobalVariables.driver.IsChangesVisible();
			Assert.AreEqual(result, "SUCCESS");
		}


		[Test]
		public void Test4_1_Delete()
		{

			var result = GlobalVariables.driver.Delete();
			Assert.AreEqual(result, "SUCCESS");
		}
		[Test]
		public void Test4_2_DeleteInfo_Check()
		{

			var result = GlobalVariables.driver.IsDeleteSuccess();
			GlobalVariables.driver.Quit();
			Assert.AreEqual(result, "ERROR");
		}
	}

}
