using System;

namespace Indexers
{
    class SimpleArray<T>
    {
        private const int ARR_SIZE = 100;
        private T[] _arr = new T[ARR_SIZE];
        public int curLen = 0;

        public T this[int i]
        {
            set => _arr[i] = value;
            get => _arr[i];
        }

        public SimpleArray(T first)
        {
            Add(first);
        }

        public SimpleArray(){}

        public int Add(T a)
        {
            if (curLen < ARR_SIZE)
            {
                _arr[curLen++] = a;
                return 0;
            }
            return 1;
        }

    }

    class Program
    {
        static void Main()
        {
            SimpleArray<string> A = new SimpleArray<string>();
            var B = new SimpleArray<string>("FirstB");
            Console.WriteLine($"Cur len {nameof(A)}: {A.curLen}");
            A.Add("FirstA");
            A.Add("Bsd");
            Console.WriteLine($"Cur len {nameof(A)}: {A.curLen}");
            Console.WriteLine($"Cur len {nameof(B)}: {B.curLen}");
            Console.WriteLine($"{nameof(A)}[1]: {A[1]}");
            Console.WriteLine($"{nameof(B)}[0]: {B[0]}");
            B.Add("Second B");
            Console.WriteLine($"{nameof(B)}[0]: {B[1]}");
            B[1] = "New Second B";
            Console.WriteLine($"{nameof(B)}[0]: {B[1]}");

        }
    }
}