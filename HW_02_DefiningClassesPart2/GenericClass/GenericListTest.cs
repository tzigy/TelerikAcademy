namespace GenericClass
{
    using System;

    class GenericListTest
    {
        public static void Main()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            Console.WriteLine("Making a new list:\n " + list);
            
            Console.WriteLine("Inserting a number 6 at position 2!");
            list.Insert(2, 6);
            Console.WriteLine(list);
            
            Console.WriteLine("The position of number 3 is {0}!", list.IndexOf(3));
            
            Console.WriteLine("Remove an element on position 3.");
            list.RemoveAt(3);
            Console.WriteLine(list);

            Console.WriteLine("The MIN element in the list is {0}", list.Min());
            Console.WriteLine("The MAX element in the list is {0}", list.Max());

            list.Clear();

            Console.WriteLine("The list after list.Clear()! \n" + list);

            //Console.WriteLine(list.Min());



            

        }
    }
}
