using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastChance.Utils
{
    public class ScreenCapture
    {
        public static string Capture(IWebDriver driver, String ScreenShotName)
        {
            ITakesScreenshot SC = (ITakesScreenshot)driver;
            Screenshot screen = SC.GetScreenshot();
            String Path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            String uptobinPath = Path.Substring(0, Path.LastIndexOf("bin")) + "ErrorScreenshots\\" + ScreenShotName + ".png";
            String LocalPath = new Uri(uptobinPath).LocalPath;
            screen.SaveAsFile(LocalPath, ScreenshotImageFormat.Png);
            return LocalPath;
        }
    }
}
