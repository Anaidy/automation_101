using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace automation_101
{
    class Program
    {
        static void Main(string[] args)
        {
            /***
             * 1. Open Browser
             * 2. Navigate to PokemonDB.net
             * 3. Click the Quick Link to National Pokedex
             * 4. Click the top Link to Generation 8 Pokemon
             * 5. Select a Pokemon in a string
             * 6. Scroll to that Pokemon element and click it
             * 7. Find and Print the Pokemon name in the new page header
             * 8. Find and Print the Pokemon # in the new page content
             * 9. Find the Pokemon HP Base Stat
             * 10. Look for the Element that doesnt exist with Implicit Wait
             * 11. Close the browser
             * ***/

            /***
             * Lesson 007 - Create a Static WebPage class 
             * 
             * Since the WebDriver is something that is shared among any page we navigate
             * we are going to create a class specific for it, and the actions we can perform
             * 
             * Possible drawbacks of this approach: the driver will be in a static variable,
             * this means that if we want another WebPage in another driver object we'll need to use tricks
             * But this approach works really good if you only need one browser open at the time
             * 
             * We will create the WebPage.cs class next to this file.
             * This class will have "friendly" static methods for:
             * - Openning Chrome
             * - Navigate to a URL
             * - Maximize Browser
             * - Close Browser
             * - Set Implicit Wait and Timeout
             * 
             * From anywhere, we will be able to interact with the driver using WebPage.TestWebDriver
             * 
             * Compare Lesson005 vs Lesson006 code ;)
             * 
             * ***/


            WebPage.OpenChromeBrowser();
            WebPage.SetPageTimeOutSeconds(15);
            WebPage.SetImplicitWait(5);
            WebPage.MaximizeBrowser();


            string url = "https://pokemondb.net/";
            WebPage.NavigateToThisPage(url);


            IWebElement NationalPokedexQuickLink = WebPage.TestWebDriver.FindElement(By.CssSelector("main[id='main'] a[href='/pokedex/national']"));
            NationalPokedexQuickLink.Click();


            IWebElement Gen8Link = WebPage.TestWebDriver.FindElement(By.CssSelector("a[href='#gen-8']"));
            Gen8Link.Click();


            string SelectPokemon = "dreepy"; //We manually select a Pokemon to click


            string Selector = "a[href='/pokedex/"+ SelectPokemon + "']";  //We have to manually forge HOW we are going to find this pokemon
            IWebElement PokemonTile = WebPage.TestWebDriver.FindElement(By.CssSelector(Selector));  //Here we find the Pokemon element
            Actions actions = new Actions(WebPage.TestWebDriver);  //Since this Pokemon is at the bottom of the page we WANT to scroll there first
            actions.MoveToElement(PokemonTile);  //Here we move to the Pokemon tile
            PokemonTile.Click();


            IWebElement PokemonNameHeader = WebPage.TestWebDriver.FindElement(By.CssSelector("main>h1"));
            Console.WriteLine(PokemonNameHeader.Text);  //The element name is printed in console 


            //Step 8 tweak
            IWebElement PokemonInfoContainer = WebPage.TestWebDriver.FindElement(By.CssSelector("div[class='tabs-panel active'][id^='tab-basic-']"));
            IWebElement PokemonInfoContainer_BasicInfo = PokemonInfoContainer.FindElement(By.CssSelector("div:nth-child(1)>div[class$='text-center']+div:nth-child(2)>h2+table.vitals-table"));
            IWebElement PokemonNationalDexNumber = PokemonInfoContainer_BasicInfo.FindElement(By.CssSelector("tbody>tr:nth-child(1) >td"));
            Console.WriteLine(PokemonNationalDexNumber.Text);  //The element name is printed in console 


            // Step 9
            IWebElement PokemonInfoContainer_StatsContainer = PokemonInfoContainer.FindElement(By.CssSelector("div:nth-child(2)>div:nth-child(1)"));
            IWebElement PokemonInfoContainer_StatsContainer_BaseStatHP = PokemonInfoContainer_StatsContainer.FindElement(By.CssSelector("table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)"));
            Console.WriteLine(PokemonInfoContainer_StatsContainer_BaseStatHP.Text);  //The element name is printed in console 


            //Step 10
            IWebElement TacosElement = WebPage.TestWebDriver.FindElement(By.CssSelector("tacomon"));


            //Step 11
            WebPage.CloseBrowser();
        }
    }
}
