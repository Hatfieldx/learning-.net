using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Metanit
{
    class Word
    {
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }
    class Dictionary
    {
        Word[] words;

        public string this[string index]
        {
            get
            {
                for (int i = 0; i < words.Length-1; i++)
                {
                    if (words[i].Source == index)
                    {
                        return words[i].Target;
                    }
                }

                return "word is not found";                    
            }

            set
            {
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (words[i].Source == index)
                    {
                        words[i].Target = value;
                    }
                }
            }
        }

        public Dictionary()
        {
            words = new Word[]
            {
            new Word("red", "красный"),
            new Word("blue", "синий"),
            new Word("green", "зеленый")
            };
        }
    }

    abstract class Figure 
    {
        public string Name { get; set; }
        public abstract double Area(params double[] lines);
        public abstract void Show();

        public Figure(string name)
        {
            Name = name;
        }
    }

    class Triangle : Figure
    {
        double line1, line2, line3;

        public override double Area(double[] lines)
        {
            double area = 1;

            foreach (var item in lines)
            {
                area *= item;
            }
            return area;
        }
        public override void Show()
        {
            Console.WriteLine($"Figure name {Name}, Area {Area(line1, line2, line3)}");
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Triangle(string name):base(name)
        {
            line1 = 5;
            line2 = 10;
            line3 = 2;            
        }
    }
}
