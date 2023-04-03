using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace SpecflowGroupExcercise.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Custom extensions to click element
        /// </summary>
        /// <param name="element"></param>
        public static async Task ClickElement(this ILocator element)
        {
            await element.WaitForAsync();
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        /// <summary>
        /// Custom extension to click element by text
        /// </summary>
        /// <param name="page"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task ClickByTextAsync(this IPage page, string text)
        {
            await page.GetByText(text).First.WaitForAsync();
            await page.GetByText(text).First.ClickAsync();
        }

        /// <summary>
        /// Custom extension to click on first element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static async Task ClickOnFirstElementAsync(this ILocator element)
        {
            await element.First.WaitForAsync();
            await element.First.ClickAsync();
        }

        /// <summary>
        /// Custom extension to Enter text
        /// </summary>
        /// <param name="element"></param>
        public static async Task EnterText(this ILocator element, string text)
        {
            await element.WaitForAsync();
            await element.ScrollIntoViewIfNeededAsync();
            await element.FillAsync(text);
        }

        /// <summary>
        /// Custom extension to Enter text
        /// </summary>
        /// <param name="element"></param>
        public static async Task EnterText(this ILocator element, string text, int index)
        {
            await element.Nth(index).WaitForAsync();
            await element.Nth(index).ScrollIntoViewIfNeededAsync();
            await element.Nth(index).FillAsync(text);
        }

        /// <summary>
        /// Custom extensions to add timestamp
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddTimeStamp(this string text) => 
            text + DateTime.Now.TimeOfDay;

        /// <summary>
        /// Custom extensions to add timestamp
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddTimeStampTosubFix(this string text) => 
            text + DateTime.Now.ToString("ddMMyyyyhhMMssfff");
        

        /// <summary>
        /// Custom extension to add random digit
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                s = String.Concat(s, random.Next(9).ToString());
            }

            return s;
        }

        /// <summary>
        /// Custom extension to switch to iframe
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="element2"></param>
        public static async Task FindElementInIframe(
            IPage driver, string element, string text) => 
            await Task.FromResult(driver.FrameLocator(element).GetByText(text));

        /// <summary>
        /// Custom extension to ScrollIntoView and Enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="text"></param>
        public static async Task ScrollIntoViewandEnterText(this ILocator element, 
            string text)
        {
            await element.ScrollIntoViewIfNeededAsync();
            await element.EnterText(text);
        }

        /// <summary>
        /// Custom extension to ScrollIntoView and Click
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="text"></param>
        public static async Task ScrollIntoViewandClick(this ILocator element)
        {
            await element.ScrollIntoViewIfNeededAsync();
            await element.ClickAsync();
        }

        /// <summary>
        /// Custom extension to remove white space from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveSpaces(this string text)
        {
            return text.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Custom extension to replace text value
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceString(this string text, string expected, string actual)
        {
            return text.Replace(expected, actual);
        }

        /// <summary>
        /// Custom extensions to remove special characters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string value)
        {
            var reg = new Regex("[\\[\\]*'\"\\s,<>&#^@:]");
            return reg.Replace(value, string.Empty);
        }

        /// <summary>
        /// Custom extension to add white space to end of string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddSpace(this string text)
        {
            return text.Replace(text, text + ' ');
        }

        /// <summary>
        /// DOB less than 18 years
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string AddYearToDate(int year)
        {
            return DateTime.Now.AddYears(year).ToString("dd/MM/yyyy");
        }

        public static async Task ClickOnLinkByLinkNameAsync(this IPage page, string linkName)
        {
            await page.GetByRole(AriaRole.Link, new() { NameString = linkName }).WaitForAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = linkName }).ClickAsync();
        }

        public static async Task LoadState_DOMContentLoaded(this IPage page, bool isEnabled)
        {
            if (isEnabled)
            {
                await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            }
        }


        public static async Task AssertUrlHasSlug(this IPage page, string slug)
        {
            await page.LoadState_DOMContentLoaded(true);
            Assert.True(page.Url.Contains(slug));
        }

        //public static async Task ClickOnFooterLinkByLinkNameAsync(this IPage page, HyperlinkEnums linkName)
        //{
        //    await page.GetByText(linkName.Value).WaitForAsync();
        //    await page.GetByText(linkName.Value).ScrollIntoViewIfNeededAsync();
        //    await page.GetByText(linkName.Value).ClickAsync();
        //}

        //public async Task AssertLinkByLinkNameAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = linkName.Value }).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = linkName.Value }).IsVisibleAsync());
        //}

        //public async Task AssertLinkByLinkNameContentLocatorAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.WaitForAsync();
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.IsVisibleAsync();
        //}

        //public async Task ClickLinkByLinkNameContentLocatorAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.WaitForAsync();
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.ClickAsync();
        //}

        ///// <summary>
        ///// Async Clicks on the hyperlinks on a page.
        ///// </summary>
        ///// <param name="linkName">_navigation links.</param>
        ///// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        //public async Task ClickOnHeaderLinkByLinkNameAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = $"{linkName}" }).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = $"{linkName}" }).GetByText($"{linkName}").ClickAsync();
        //}

        //public async Task ClickOnLinkByLinkNameAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.WaitForAsync();
        //    await _fixture.Page.Locator("#content").GetByText(linkName.Value).First.ClickAsync();
        //}

        //public async Task AssertButtonIsVisibleByButtonNameAsync(ButtonEnums buttonName)
        //{
        //    /*Bug raised 133225*/
        //    try
        //    {
        //        await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).WaitForAsync(new() { Timeout = 1000 });
        //        Assert.True(await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).IsVisibleAsync());
        //    }
        //    catch
        //    {
        //        await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = buttonName.Value }).WaitForAsync();
        //        Assert.True(await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = buttonName.Value }).IsVisibleAsync());
        //    }
        //}


        //public async Task ClickChangeLinkAsync(string fieldToChange)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"Change Change {fieldToChange}" }).First.WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"Change Change {fieldToChange}" }).First.ClickAsync();
        //}

        //public async Task ClickChangeLinkLearnerDetailsAsync(string fieldToChange)
        //{
        //    await _fixture.Page.GetByText($"Change Change {fieldToChange}").First.WaitForAsync();
        //    await _fixture.Page.GetByText($"Change Change {fieldToChange}").First.ClickAsync();
        //}

        //public async Task WaitForChangeLinkAsync(string fieldToChange)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"Change Change {fieldToChange}" }).First.WaitForAsync();
        //}

        //public async Task<bool> IsChangeLinkVisibleAsync(string fieldToChange)
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"Change Change {fieldToChange}" }).First.WaitForAsync(new() { Timeout = 10000 });
        //    }
        //    catch
        //    {
        //    }

        //    return await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"Change Change {fieldToChange}" }).First.IsVisibleAsync();
        //}

        //public async Task ClickButtonByButtonNameAsync(ButtonEnums buttonName)
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).WaitForAsync(new() { Timeout = 3000 });
        //        await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).ClickAsync();
        //    }
        //    catch
        //    {
        //        await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = buttonName.Value }).ClickAsync(); // remove this and try and catch when bug 135433 resolved
        //    }
        //}

        //public async Task ClickButtonByButtonNameAsync(string buttonName)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName }).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName }).ClickAsync();
        //}

        //public async Task<bool> IsButtonDisplayedAsync(ButtonEnums buttonName)
        //{
        //    return await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).IsVisibleAsync();
        //}

        //public async Task ClickButtonLinkByButtonNameAsync(ButtonEnums buttonName)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Button, new() { NameString = buttonName.Value }).ClickAsync();
        //}

        //public async Task ClickLinkByLinkNameAsync(HyperlinkEnums linkName)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = linkName.Value }).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = linkName.Value }).ClickAsync();
        //}

        //public async Task<bool> IsErrorDisplayedAsync(string errorMessage)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = errorMessage }).WaitForAsync();
        //    return await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = errorMessage }).IsVisibleAsync();
        //}

        //public async Task<bool> IsErrorAlertDisplayedAsync()
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = "There is a problem" }).WaitForAsync();
        //    return await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = "There is a problem" }).IsVisibleAsync();
        //}

        //public async Task<bool> IsErrorAlertDisplayedAsync(string msg)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = msg }).WaitForAsync();
        //    return await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = msg }).IsVisibleAsync();
        //}

        //public async Task<string> IsErrorAlertListDisplayedAsync()
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = "There is a problem" }).GetByRole(AriaRole.Listitem).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = "There is a problem" }).GetByRole(AriaRole.Listitem).IsVisibleAsync();
        //    return await _fixture.Page.GetByRole(AriaRole.Alert, new() { NameString = "There is a problem" }).GetByRole(AriaRole.Listitem).TextContentAsync();
        //}

        //public async Task ReloadIfErrorAppearsAsync()
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByText("An unhandled error has occurred. Reload 🗙").WaitForAsync(new() { Timeout = 1000 });
        //        await _fixture.Page.ReloadAsync();
        //        count++;
        //        if (count < 5)
        //        {
        //            await ReloadIfErrorAppearsAsync();
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //public async Task CheckTextIsVisible(string text)
        //{
        //    await _fixture.Page.GetByText(text).First.WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByText(text).First.IsVisibleAsync());
        //}

        //public async Task AssertHeaderDisplayedAsync(HeaderEnums headerName)
        //{
        //    await _fixture.Page.Locator($"h1:has-text(\"{headerName}\")").WaitForAsync();
        //    Assert.True(await _fixture.Page.Locator($"h1:has-text(\"{headerName}\")").IsVisibleAsync());
        //}

        //public async Task AssertHeaderNewTabDisplayedAsync(HeaderEnums headerName)
        //{
        //    await NewPage.Locator($"h1:has-text(\"{headerName}\")").WaitForAsync();
        //    Assert.True(await NewPage.Locator($"h1:has-text(\"{headerName}\")").IsVisibleAsync());
        //}

        //public async Task AssertHeaderDisplayedAsync(string headerName)
        //{
        //    await _fixture.Page.Locator($"h1:has-text(\"{headerName}\")").WaitForAsync();
        //    Assert.True(await _fixture.Page.Locator($"h1:has-text(\"{headerName}\")").IsVisibleAsync());
        //}

        //public async Task<bool> IsHeaderDisplayedAsync(HeaderEnums headerName)
        //{
        //    return await _fixture.Page.Locator($"h1:has-text(\"{headerName}\")").IsVisibleAsync();
        //}

        //public async Task AssertSubHeaderDisplayedAsync(SubHeaderEnums subHeaderName)
        //{
        //    await _fixture.Page.GetByText(subHeaderName.Value).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByText(subHeaderName.Value).IsVisibleAsync());
        //}

        //public async Task AssertSubHeaderNotDisplayedAsync(SubHeaderEnums subHeaderName)
        //{
        //    Assert.False(await _fixture.Page.GetByText(subHeaderName.Value).IsVisibleAsync());
        //}

        //public async Task AssertDynamicHeaderDisplayedAsync(HeaderEnums headerName, string dynamicName)
        //{
        //    await _fixture.Page.Locator($"h1:has-text(\" {headerName.Value} : {dynamicName} \")").WaitForAsync();
        //    Assert.True(await _fixture.Page.Locator($"h1:has-text(\" {headerName.Value} : {dynamicName} \")").IsVisibleAsync());
        //}

        //public async Task AssertNavigationTabsDisplayedAsync(NavigationBarEnums navigationBarEnums)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = navigationBarEnums.Value }).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = navigationBarEnums.Value }).IsVisibleAsync());
        //}

        //public async Task AssertLearnerNameDisplayedAboveHeaderAsync(string learnerName)
        //{
        //    await _fixture.Page.GetByText(learnerName).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByText(learnerName).IsVisibleAsync());
        //}

        //public async Task AssertContentIsBold(ILocator locatorHTML)
        //{
        //    await locatorHTML.WaitForAsync();
        //    Assert.Contains("-font-weight-bold", await locatorHTML.GetAttributeAsync("class"));
        //}

        //public async Task SetValueInDateFieldByLabelNameAsync(string day, string month, string year, int n)
        //{
        //    await _fixture.Page.GetByLabel("Day").Nth(n).WaitForAsync();
        //    await _fixture.Page.GetByLabel("Day").Nth(n).FillAsync(day);
        //    await _fixture.Page.GetByLabel("Month").Nth(n).FillAsync(month);
        //    await _fixture.Page.GetByLabel("Year").Nth(n).FillAsync(year);
        //}

        //public async Task<string> GetValueInDayDateFieldByLabelNameAsync()
        //{
        //    await _fixture.Page.GetByLabel("Day").WaitForAsync();
        //    var dayInput = await _fixture.Page.GetByLabel("Day").InputValueAsync();
        //    var monthInput = await _fixture.Page.GetByLabel("Month").InputValueAsync();
        //    var yearInput = await _fixture.Page.GetByLabel("Year").InputValueAsync();
        //    return $"{dayInput}/{monthInput}/{yearInput}";
        //}

        //public async Task<string> GetTextInInputField(string fieldLabel)
        //{
        //    await _fixture.Page.GetByLabel($"{fieldLabel}").WaitForAsync();
        //    return await _fixture.Page.GetByLabel($"{fieldLabel}").InputValueAsync();
        //}

        //public async Task AssertUrlAsync(string url)
        //{
        //    await _fixture.Page.WaitForLoadStateAsync(LoadState.Load);
        //    Assert.Contains(url, _fixture.Page.Url);
        //}

        //public async Task AssertTextDisplayedAsync(string text)
        //{
        //    await _fixture.Page.GetByText(text).First.WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByText(text).First.IsVisibleAsync());
        //}

        //public async Task AssertTextNotDisplayedAsync(string text)
        //{
        //    Assert.False(await _fixture.Page.GetByText(text).First.IsVisibleAsync());
        //}

        //public async Task AssertLabelIsVisible(string labelText)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = labelText }).First.WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = labelText }).First.IsVisibleAsync());
        //}

        //public async Task<string> FindTextRightOfField(string field)
        //{
        //    await _fixture.Page.Locator($":right-of(:has-text('{field}'))").First.WaitForAsync();
        //    return (await _fixture.Page.Locator($":right-of(:has-text('{field}'))").First.InnerTextAsync()).Trim();
        //}

        ///// <summary>
        ///// Naviagtion Across the different sections.
        ///// </summary>
        ///// <param name="navLink">This is the Enum for the Navigation Link.</param>
        ///// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        //public async Task ClickOnNavigationBarAsync(NavigationBarEnums navLink)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"{navLink.Value}" }).WaitForAsync();
        //    await _fixture.Page.GetByRole(AriaRole.Link, new() { NameString = $"{navLink.Value}" }).ClickAsync();
        //}

        ///// <summary>
        ///// Sets Value in Input field by its label name.
        ///// </summary>
        ///// <param name="labelName"> Label associated with the input field.</param>
        ///// <param name="inputValue">Value to be set in the input field.</param>
        ///// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        //public async Task SetValueInInputFieldsByLabelNameAsync(string labelName, string inputValue)
        //{
        //    await _fixture.Page.GetByLabel(labelName).First.WaitForAsync();
        //    await _fixture.Page.GetByLabel(labelName).First.ClickAsync();
        //    await _fixture.Page.GetByLabel(labelName).First.FillAsync(inputValue);
        //}

        //public async Task ChecksCheckboxByIdAsync(string checkboxId)
        //{
        //    await _fixture.Page.Locator(checkboxId).WaitForAsync();
        //    await _fixture.Page.Locator(checkboxId).CheckAsync();
        //}

        //public async Task UnchecksCheckboxByIdAsync(string checkboxId)
        //{
        //    await _fixture.Page.Locator(checkboxId).WaitForAsync();
        //    await _fixture.Page.Locator(checkboxId).UncheckAsync();
        //}

        //public async Task<bool> AssertTableDisplayedAsync()
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Table).WaitForAsync();
        //    return await _fixture.Page.GetByRole(AriaRole.Table).IsVisibleAsync();
        //}

        //public async Task<string> CapitaliseString(string input)
        //{
        //    return await Task.FromResult(input.ToUpper());
        //}

        //public async Task SetValueInInputFieldsByIdAsync(string id, string inputValue)
        //{
        //    await _fixture.Page.Locator(id).WaitForAsync();
        //    await _fixture.Page.Locator(id).FillAsync(inputValue);
        //}

        //public async Task AssertValueInInputFieldsByIdAsync(string id, string inputValue)
        //{
        //    await _fixture.Page.Locator(id).WaitForAsync();
        //    Assert.Equal((await _fixture.Page.Locator(id).InputValueAsync()).Trim(), inputValue);
        //}

        //public void CheckFieldInfocus(string fieldId)
        //{
        //    Assert.Contains(fieldId, _fixture.Page.Url);
        //}

        //public async Task AssertSuccessBannerDisplayedAsync(string successMessage)
        //{
        //    await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = "Success" }).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = successMessage }).IsVisibleAsync());
        //    await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = successMessage }).WaitForAsync();
        //    Assert.True(await _fixture.Page.GetByRole(AriaRole.Heading, new() { NameString = successMessage }).IsVisibleAsync());
        //}

        /// <summary>
        /// Clickls on a checkbox by its lable.
        /// </summary>
        /// <param name="labelName">label name associated with the CheckBox.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        //public async Task ChecksCheckboxById(string checkboxId)
        //{
        //    await _fixture.Page.Locator(checkboxId).WaitForAsync();
        //    await _fixture.Page.Locator(checkboxId).CheckAsync();
        //}

        //public async Task AssertCheckboxByIdCheckedAsync(string checkboxId)
        //{
        //    await _fixture.Page.Locator(checkboxId).WaitForAsync();
        //    Assert.True(await _fixture.Page.Locator(checkboxId).IsCheckedAsync());
        //}

        //public async Task<bool> IsCheckboxByIdVisible(string checkboxId)
        //{
        //    return await _fixture.Page.Locator(checkboxId).IsVisibleAsync();
        //}

        //public async Task UnchecksCheckboxById(string checkboxId)
        //{
        //    await _fixture.Page.Locator(checkboxId).WaitForAsync();
        //    await _fixture.Page.Locator(checkboxId).UncheckAsync();
        //}

        //public async Task ChecksCheckboxByLabelBelowOfTextAsync(string checkboxLabel, int n)
        //{
        //    await _fixture.Page.Locator($"[type=radio]:below(:has-text(\"{checkboxLabel}\"))").Nth(n).WaitForAsync();
        //    await _fixture.Page.Locator($"[type=radio]:below(:has-text(\"{checkboxLabel}\"))").Nth(n).CheckAsync();
        //}

        //public async Task UnchecksCheckboxByLabelBelowOfTextAsync(string checkboxLabel, int n)
        //{
        //    await _fixture.Page.Locator($"[type=radio]:below(:has-text(\"{checkboxLabel}\"))").Nth(n).WaitForAsync();
        //    await _fixture.Page.Locator($"[type=radio]:below(:has-text(\"{checkboxLabel}\"))").Nth(n).UncheckAsync();
        //}

        //public async Task ChecksCheckboxByLabel(string checkboxLabel)
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByLabel(checkboxLabel).First.WaitForAsync(new() { Timeout = 1000 });
        //        if (!await _fixture.Page.GetByLabel(checkboxLabel).First.IsCheckedAsync())
        //        {
        //            await _fixture.Page.GetByLabel(checkboxLabel).First.CheckAsync();
        //        }
        //    }
        //    catch
        //    {
        //        await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").First.WaitForAsync();
        //        if (!await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").First.IsCheckedAsync())
        //        {
        //            await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").First.CheckAsync();
        //        }
        //    }
    }

        //public async Task AssertCheckboxIsCheckedByLabel(string checkboxLabel)
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByLabel(checkboxLabel).First.WaitForAsync(new() { Timeout = 1000 });
        //        Assert.True(await _fixture.Page.GetByLabel(checkboxLabel).First.IsCheckedAsync());
        //    }
        //    catch
        //    {
        //        await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").First.WaitForAsync();
        //        Assert.True(await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").First.IsCheckedAsync());
        //    }
        //}

        //public async Task UnChecksCheckboxByLabel(string checkboxLabel)
        //{
        //    try
        //    {
        //        await _fixture.Page.GetByLabel(checkboxLabel).WaitForAsync(new() { Timeout = 1000 });
        //        if (await _fixture.Page.GetByLabel(checkboxLabel).IsCheckedAsync())
        //        {
        //            await _fixture.Page.GetByLabel(checkboxLabel).UncheckAsync();
        //        }
        //    }
        //    catch
        //    {
        //        await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").WaitForAsync();
        //        if (await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").IsCheckedAsync())
        //        {
        //            await _fixture.Page.Locator($"input[name=\"{checkboxLabel}\"]").UncheckAsync();
        //        }
        //    }
        //}
}
