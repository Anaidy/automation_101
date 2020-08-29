using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

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
             * Lesson 006 - Set implicit wait and timeout at the very beginning
             * 
             * We move such settings to Step 1, right after we create the Driver
             * 
             * 
             * ***/


            IWebDriver WDObject = new ChromeDriver();  // We open a Chrome Web Browser
            WDObject.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            WDObject.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string url = "https://pokemondb.net/";
            WDObject.Manage().Window.Maximize();

            WDObject.Navigate().GoToUrl(url);

            IWebElement NationalPokedexQuickLink = WDObject.FindElement(By.CssSelector("main[id='main'] a[href='/pokedex/national']"));
            NationalPokedexQuickLink.Click();

            IWebElement Gen8Link = WDObject.FindElement(By.CssSelector("a[href='#gen-8']"));
            Gen8Link.Click();

            string SelectPokemon = "dreepy"; //We manually select a Pokemon to click

            string Selector = "a[href='/pokedex/"+ SelectPokemon + "']";  //We have to manually forge HOW we are going to find this pokemon
            IWebElement PokemonTile = WDObject.FindElement(By.CssSelector(Selector));  //Here we find the Pokemon element
            Actions actions = new Actions(WDObject);  //Since this Pokemon is at the bottom of the page we WANT to scroll there first
            actions.MoveToElement(PokemonTile);  //Here we move to the Pokemon tile
            PokemonTile.Click();

            IWebElement PokemonNameHeader = WDObject.FindElement(By.CssSelector("main>h1"));
            Console.WriteLine(PokemonNameHeader.Text);  //The element name is printed in console 

            //Step 8 tweak
            IWebElement PokemonInfoContainer = WDObject.FindElement(By.CssSelector("div[class='tabs-panel active'][id^='tab-basic-']"));
            IWebElement PokemonInfoContainer_BasicInfo = PokemonInfoContainer.FindElement(By.CssSelector("div:nth-child(1)>div[class$='text-center']+div:nth-child(2)>h2+table.vitals-table"));
            IWebElement PokemonNationalDexNumber = PokemonInfoContainer_BasicInfo.FindElement(By.CssSelector("tbody>tr:nth-child(1) >td"));
            Console.WriteLine(PokemonNationalDexNumber.Text);  //The element name is printed in console 

            // Step 9
            IWebElement PokemonInfoContainer_StatsContainer = PokemonInfoContainer.FindElement(By.CssSelector("div:nth-child(2)>div:nth-child(1)"));
            IWebElement PokemonInfoContainer_StatsContainer_BaseStatHP = PokemonInfoContainer_StatsContainer.FindElement(By.CssSelector("table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)"));
            Console.WriteLine(PokemonInfoContainer_StatsContainer_BaseStatHP.Text);  //The element name is printed in console 

            //Step 10
            IWebElement TacosElement = WDObject.FindElement(By.CssSelector("tacomon"));  

            //Step 11
            Thread.Sleep(3000);
            WDObject.Quit(); // We end the execution
        }
    }
}
