using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_number_1
{
    public class Person
    {
        public Person(string name, string surname, int age, float weight, float height)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Weight = weight;
            Height = height;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
    }
}
