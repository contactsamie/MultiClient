using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientLib
{
    public static class StepsUtility
    {
        public static void CheckedBoxSelectById(this WebBrowserComponent browser, string id, bool select)
        {
            ((HTMLInputElement)browser.WebBrowserInterface.Document.GetElementById(id).DomElement).@checked = select;
        }

        public static HtmlElement GetElementById(this WebBrowserComponent browser, string Id)
        {
            if (browser != null && browser.WebBrowserInterface != null && browser.WebBrowserInterface.Document != null)
            {
                return browser.WebBrowserInterface.Document.GetElementById(Id);
            }
            else
            {
                return null;
            }
        }

        public static List<HtmlElement> GetElementByClass(this WebBrowserComponent browser, string className)
        {
            return GetElementByAttribute(browser, "class", className);
        }

        public static List<HtmlElement> GetElementByAttribute(this WebBrowserComponent browser, string attribute, string value)
        {
            var result = new List<HtmlElement>();
            if (browser?.WebBrowserInterface?.Document == null) return result;
            result.AddRange(browser.WebBrowserInterface.Document.GetElementsByTagName("body").Cast<HtmlElement>().Where(el => el.GetAttribute(attribute) == value));
            return result;
        }

        public static void SelectItemFromDropDownById(this WebBrowserComponent browser, string id, int position)
        {
            browser.SelectItemFromDropDown(GetElementById(browser, id), position);
        }

        public static void SelectItemValueById(this WebBrowserComponent browser, string id, string value)
        {
            browser.SelectItemValue(GetElementById(browser, id), value);
        }

        public static void SelectItemValueByClassName(this WebBrowserComponent browser, string id, string value)
        {
            browser.SelectItemValue(GetElementByClass(browser, id).First(), value);
        }

        public static void SelectItemValue(this WebBrowserComponent browser, HtmlElement dropdown, string value)
        {
            dropdown.Enabled = true;
            dropdown.SetAttribute("value", value);
        }

        public static void SelectItemFromDropDown(this WebBrowserComponent browser, HtmlElement dropdown, int position)
        {
            dropdown.Enabled = true;
            dropdown.InvokeMember("CLICK");
            dropdown.InvokeMember("onChnage");

            var e = dropdown.DomElement as HTMLSelectElement;
            e.selectedIndex = position - 1;
            e.FireEvent("onChange", null);
        }

        public static void RunJavascript(this WebBrowserComponent browser, string script)
        {
            HtmlDocument doc = browser.WebBrowserInterface.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement s = doc.CreateElement("script");
            var name = "method_" + Guid.NewGuid().ToString().Replace("-", "");
            var finalScript = "function " + name + "() { " + script + ";}";
            s.SetAttribute("text", finalScript);
            head.AppendChild(s);
            browser.WebBrowserInterface.Document.InvokeScript(name);
        }

        public static void ClickBySelector(this WebBrowserComponent browser, string selector)
        {
            browser.RunJavascript("$('" + selector + "').trigger('click')");
            //  browser.ClickMe(GetElementById(browser,Id));
        }

        public static void ClickById(this WebBrowserComponent browser, string Id)
        {
            browser.RunJavascript("$('#" + Id + "').trigger('click')");
            //  browser.ClickMe(GetElementById(browser,Id));
        }

        public static void ClickMe(this WebBrowserComponent browser, params HtmlElement[] elements)
        {
            foreach (var htmlElement in elements)
            {
                htmlElement.InvokeMember("CLICK");
            }
        }

        public static void RunEvent(this WebBrowserComponent browser, string eventName, params HtmlElement[] elements)
        {
            foreach (var htmlElement in elements)
            {
                htmlElement.InvokeMember(eventName);
            }
        }
    }
}