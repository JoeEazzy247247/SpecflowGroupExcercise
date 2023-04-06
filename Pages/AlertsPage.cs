﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Playwright;

namespace SpecflowGroupExcercise.Pages
{
    public class AlertsPage
    {
        private IPage _page;
        public AlertsPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator AlertButton(string option) => _page.Locator($"//span[@class='mr-3'][.='{option}']//following::div/button");



        //public async Task CompleteForm(string option1, string option2, string Addressoption1, string Addressoption2,
        //    string FullName, string UserEmail, string currentaddress, string permAddress)
        //{
        //    await inputFields(option1).First.FillAsync(FullName);
        //    await inputFields(option2).FillAsync(UserEmail);
        //    await AddressFields(Addressoption1).First.FillAsync(currentaddress);
        //    await AddressFields(Addressoption1).Last.FillAsync(permAddress);
        //    await submit.ClickAsync();
        //}

        //public async Task<bool> IsOutPutDisplayed() => await Output.IsVisibleAsync();
    }
}