using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastChance.pages
{
   public class PracticePage
    {
        IWebDriver driver;


        By Practic = By.XPath("//a[@class='fedora-navbar-link navbar-link']");
        By RadioButton = By.CssSelector("input#hondaradio");
        By ChekBoxH = By.CssSelector("input#hondacheck");
        By ChekBoxB = By.CssSelector("input#benzcheck");
        By Select = By.CssSelector("select#multiple-select-example");
        By DropDown = By.CssSelector("select#carselect");

        public PracticePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void practicebutton()
        {
            driver.FindElement(Practic).Click();
        }

        public void practicing()
        {
            driver.FindElement(RadioButton).Click();
            SelectElement Sel = new SelectElement(driver.FindElement(DropDown));
            Sel.SelectByValue("honda");
            SelectElement MultiSel = new SelectElement(driver.FindElement(Select));
            MultiSel.SelectByValue("peach");
            driver.FindElement(ChekBoxB).Click();
            driver.FindElement(ChekBoxH).Click();
        }
    }
}
