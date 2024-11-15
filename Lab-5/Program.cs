using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomEnumerableExample
{
    public class RandomNumberSeries : IEnumerable<double>, IEnumerator<double>
    {
        private int _count;
        private int _currentIndex = -1;
        private double _currentValue;
        private Random _random;

        public RandomNumberSeries(int count)
        {
            _count = count;
            _random = new Random();
        }

        // Реализация IEnumerator<double>
        public double Current => _currentValue;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_currentIndex + 1 < _count)
            {
                _currentValue = _random.NextDouble();
                _currentIndex++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public void Dispose()
        {
            // Не требует ресурсов для освобождения, но метод необходим для интерфейса
        }

        // Реализация IEnumerable<double>
        public IEnumerator<double> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {
            int count = 10;
            var randomSeries = new RandomNumberSeries(count);

            Console.WriteLine("Сгенерированный ряд случайных чисел:");
            foreach (var number in randomSeries)
            {
                Console.WriteLine(number);
            }
        }
    }
}
