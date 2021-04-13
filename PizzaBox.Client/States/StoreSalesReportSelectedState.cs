using System.Linq;
using PizzaBox.Client.Contexts;
using System;
using System.Globalization;

namespace PizzaBox.Client.States
{
    public class StoreSalesReportSelectedState : AState
    {
        public override void Handle(Context context)
        {
            // let them pick either a month or a week
            Console.WriteLine("Select a month:");
            Enumerable.Range(1, 12).Select(i => new { I = i, M = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) })
                .ToList().ForEach(pair => Console.WriteLine($"{pair.I} - {pair.M}"));
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
            } while (input <= 0 || input > 12);

            context.FirstDay = new DateTime(DateTime.Now.Year, input, 1);
            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<StoreSalesReportSelectTimeState>();
        }
    }
}