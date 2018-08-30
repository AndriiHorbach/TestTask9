using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;
using System.Reflection;
using TestTask.Infrastructure.Controls.Elements;

namespace TestTask.Infrastructure.Common
{
    public class PageFactory
    {
        const BindingFlags NonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;

        public static T GetPage<T>()
        {
            var page = Activator.CreateInstance<T>();
            typeof(T).GetFields(BindingFlags.Public | NonPublicInstance)
                .ToList()
                .ForEach(field =>
                {
                    var fieldType = field.FieldType;
                    var attributes = field.GetCustomAttributes<FindsByAttribute>();
                    var findsByAttributes = attributes as FindsByAttribute[] ?? attributes.ToArray();
                    if (findsByAttributes.Any())
                    {
                        var obj = Activator.CreateInstance(fieldType);
                        var attribute = findsByAttributes.Single();
                        fieldType.GetField(nameof(HtmlControl.Locator), NonPublicInstance)
                            ?.SetValue(obj, typeof(By)
                                .GetMethod(attribute.How.ToString(), BindingFlags.Public | BindingFlags.Static)
                                ?.Invoke(null, new object[] { attribute.Using }));
                        field.SetValue(page, obj);
                    }
                });
            return page;
        }
    }
}
