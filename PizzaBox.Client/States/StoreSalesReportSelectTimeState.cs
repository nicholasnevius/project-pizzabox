using PizzaBox.Client.Contexts;
using PizzaBox.Client.Contexts;
using System.Linq;
using PizzaBox.Client.Singletons;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace PizzaBox.Client.States
{
    public class StoreSalesReportSelectTimeState : AState
    {
        private static ImmutableArray<string> OPTIONS = ImmutableArray.Create(new string[]
        {
            "Week 1",
            "Week 2",
            "Week 3",
            "Week 4",
            "Whole month"
        });

        public override void Handle(Context context)
        {
            var index = 0;
            OPTIONS.ToList().ForEach(option => Console.WriteLine($"{++index} - {option}"));
            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            } while (input <= 0 || input > index);

            DateTime lastDay;
            switch (input)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    context.FirstDay = context.FirstDay.AddDays((input - 1) * 7);
                    context.LastDay = context.FirstDay.AddDays(7);
                    break;
                case 5:    // whole month
                    lastDay = context.FirstDay.AddMonths(1).AddDays(-1);
                    break;
                default:
                    throw new ArgumentException("Somehow got an input for selecting time range that was not expected");
            }

        }
    }
}