using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackTask
{
    class Backpack
    {
        //Далее создаем класс Backpack, который составляет и перебирает все
        //наборы предметов и выбирает из них самый лучший (его общая масса не более W,
        //а стоимость среди соответствующих по массе наборов – максимальная).
        private List<Item> bestItems = null;
        //В полях хранится: лучший набор предметов для рюкзака, максимальная масса рюкзака и
        //общая стоимость предметов лучшего набора bestItems соответственно.
        private double maxW;

        private double bestPrice;

        public Backpack(double _maxW)
        {
            maxW = _maxW;
            Console.WriteLine("\nNew backpack:" +
                              $"\nSize: {maxW}");
        }
        
        // создание всех наборов перестановок значений
        public void MakeAllSets(List<Item> items)
        {
            Console.WriteLine("\nMakeAllSets");
            if (items.Count > 0)
                CheckSet(items);

            for (int i = 0; i < items.Count; i++)
            {
                List<Item> newSet = new List<Item>(items);

                newSet.RemoveAt(i);

                MakeAllSets(newSet);
            }

        }

        // проверка, является ли данный набор лучшим решением задачи
        private void CheckSet(List<Item> items)
        {
            Console.WriteLine("\nCheckSet");
            if (bestItems == null)
            {
                if (CalcWeigth(items) <= maxW)
                {
                    bestItems = items;
                    bestPrice = CalcPrice(items);
                }
            }
            else
            {
                if(CalcWeigth(items) <= maxW && CalcPrice(items) > bestPrice)
                {
                    bestItems = items;
                    bestPrice = CalcPrice(items);
                }
            }
        }

        // вычисляет общий вес набора предметов
        private double CalcWeigth(List<Item> items)
        {
            Console.WriteLine("\nCalcWeigth");
            double sumW = 0;

            foreach(Item i in items)
            {
                sumW += i.weigth;

            }

            return sumW;
        }

        // вычисляет общую стоимость набора предметов
        private double CalcPrice(List<Item> items)
        {
            Console.WriteLine("\nCalcPrice");
            double sumPrice = 0;

            foreach (Item i in items)
            {
                sumPrice += i.price;
            }

            return sumPrice;
        }
        
        // возвращает решение задачи (набор предметов)
        public List<Item> GetBestSet()
        {
            Console.WriteLine("\nGetBestSet");
            return bestItems;
        }
    }

}