using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Ex1
{

    /// <summary>
    /// The DebuggerDisplayAttribute constructor has a single argument:
    ///     a string to be displayed in the value column for instances of the type.
    ///     This string can contain braces ({ and }). 
    ///     The text within a pair of braces is evaluated as the name of a field, property, or method.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Id = {Id}")]
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
    

     //   [Obsolete("you must to use the default constructor" , true)]
     //   [Obsolete("please use the default constructor", false)]
         
        [Obsolete]
            public Person(int id, string name)
            {
                Id = id;
                Name = name;
            }
   
            //public override string ToString()
            //{
            //    return Name;
            //}
     }


    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }


    


}
