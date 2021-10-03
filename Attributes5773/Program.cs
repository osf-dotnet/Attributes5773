using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Attributes5773
{
    [AttributeUsage(AttributeTargets.Property)]
    class PropertyDisplayAttribute : Attribute
    {
        public String DisplayValue { get; set; }
        public PropertyDisplayAttribute(string displayName)
        {
            DisplayValue = displayName;
        }
    }


    public class Person
    {
        [PropertyDisplay("person id ")]
        public int Id { get; set; }
        [PropertyDisplay("person name")]
        public Name PersonName { get; set; }
        [PropertyDisplay("person gender")]
        public Gender PersonGender { get; set; }
        [PropertyDisplay("is married")]
        public bool Married { get; set; }

        public override string ToString()
        {
            return Program.ToStringProperty(this);
        }
    }

    public class Name
    {
        [PropertyDisplay("First Name")]
        public string FirstName { get; set; }
        [PropertyDisplay("Last Name")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return Program.ToStringProperty(this);
        }
    }

    public enum Gender { male, female }



    class Program
    {
        
        public static string ToStringProperty_Old<T>(T t)
        {
            string str = "";
            PropertyInfo[] T_properties = t.GetType().GetProperties();

            foreach (var item in T_properties)
            {
                
                str += string.Format("\nname: {0,-15} value: {1,-15}",
                        item.Name,
                        item.GetValue(t, null));
            }

            return str;
        }

        public static string ToStringProperty<T>(T t)
        {
            string str = "";
            PropertyInfo[] T_properties = t.GetType().GetProperties();

            foreach (PropertyInfo item in T_properties)
            {
                Type myAttributeType = typeof(PropertyDisplayAttribute);
                object[] itemDisplayAtt = item.GetCustomAttributes(myAttributeType, false);

                if (itemDisplayAtt.Length == 1)
                {
                    PropertyDisplayAttribute att = (PropertyDisplayAttribute)itemDisplayAtt[0];
                    str += string.Format("\nname: {0,-15} value: {1,-15}",
                        att.DisplayValue,
                        item.GetValue(t, null));
                }
                else
                {
                    str += string.Format("\nname: {0,-15} value: {1,-15}",
                        item.Name,
                        item.GetValue(t, null));
                }
            }
            return str;
        }

        public static string ToStringProperty_2<T>(T t)
        {
            string str = "";
            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                object[] itemDisplayAtt = item.GetCustomAttributes(false);
                bool isPropertyDisplayAttribute = false;

                foreach (object obj in itemDisplayAtt)
                {
                    PropertyDisplayAttribute displayAttribute = obj as PropertyDisplayAttribute;
                    if (displayAttribute != null)
                    {
                        isPropertyDisplayAttribute = true;
                        str += string.Format("\nname: {0,-15} value: {1,-15}",
                            displayAttribute.DisplayValue,
                            item.GetValue(t, null));

                        break;
                    }
                }
                if (!isPropertyDisplayAttribute)
                {
                    str += string.Format("\nname: {0,-15} value: {1,-15}",
                        item.Name,
                        item.GetValue(t, null));
                }
            }
            return str;
        }

        static void Main(string[] args)
        {
            Person p = new Person
            {
                Id = 123,
                Married = true,
                PersonGender = Gender.male,
                PersonName = new Name { FirstName = "oshri", LastName = "cohen" }
            };

            Console.WriteLine(p);
        }
    }
}
