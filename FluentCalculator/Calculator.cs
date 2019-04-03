using System;
using System.Collections.Generic;
using System.Data;

namespace Fluent.Calculator
{
    public class FluentCalculator
    {
        public List<object> builder = new List<object>();
        public FluentCalculator Zero => Add(0);
        public FluentCalculator One => Add(1);
        public FluentCalculator Two => Add(2);
        public FluentCalculator Three => Add(3);
        public FluentCalculator Four => Add(4);
        public FluentCalculator Five => Add(5);
        public FluentCalculator Six => Add(6);
        public FluentCalculator Seven => Add(7);
        public FluentCalculator Eight => Add(8);
        public FluentCalculator Nine => Add(9);
        public FluentCalculator Ten => Add(10);
        public FluentCalculator Plus => Add('+');
        public FluentCalculator Minus => Add('-');
        public FluentCalculator DividedBy => Add('/');
        public FluentCalculator Times => Add('*');

        private FluentCalculator Add(object obj)
        {
            builder.Add(obj);
            return this;
        }

        public static implicit operator double(FluentCalculator calculator) =>
            calculator.Result();

        public double Result()
        {
            double y = Convert.ToDouble(new DataTable().Compute(string.Join("", builder), ""));
            builder.Clear();
            return y;
        }
    }
}
