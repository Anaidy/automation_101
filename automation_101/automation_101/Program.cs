﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
             * 9. Close the browser
             * ***/


            IWebDriver WebDriver = new ChromeDriver();  // We open a Chrome Web Browser

            string url = "https://pokemondb.net/";
            WebDriver.Manage().Window.Maximize(); 

            WebDriver.Navigate().GoToUrl(url);

            IWebElement NationalPokedexQuickLink = WebDriver.FindElement(By.CssSelector("main[id='main'] a[href='/pokedex/national']"));
            NationalPokedexQuickLink.Click();

            IWebElement Gen8Link = WebDriver.FindElement(By.CssSelector("a[href='#gen-8']"));
            Gen8Link.Click();

            string SelectPokemon = "dreepy"; //We manually select a Pokemon to click

            string Selector = "a[href='/pokedex/"+ SelectPokemon + "']";  //We have to manually forge HOW we are going to find this pokemon
            IWebElement PokemonTile = WebDriver.FindElement(By.CssSelector(Selector));  //Here we find the Pokemon element
            Actions actions = new Actions(WebDriver);  //Since this Pokemon is at the bottom of the page we WANT to scroll there first
            actions.MoveToElement(PokemonTile);  //Here we move to the Pokemon tile
            PokemonTile.Click();

            IWebElement PokemonNameHeader = WebDriver.FindElement(By.CssSelector("main>h1"));
            Console.WriteLine(PokemonNameHeader.Text);  //The element name is printed in console 

            string NationalDexSelector = "div[class='tabs-panel active'][id^='tab-basic-'] div:nth-child(1)>div[class$='text-center']+div:nth-child(2)>h2+table.vitals-table tbody>tr:nth-child(1) >td";
            IWebElement PokemonNationalDexNumber = WebDriver.FindElement(By.CssSelector(NationalDexSelector));
            Console.WriteLine(PokemonNationalDexNumber.Text);  //The element name is printed in console 

            Thread.Sleep(3000);
            WebDriver.Quit(); // We end the execution
        }
    }
}
