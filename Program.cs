using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18673753_Benjamin_Fung_Attempt_2
{
    class Program
    {
        public static int counter = 0;
        static void Main(string[] args)
        {
            //Initialise
            string size;
            string temp;
            //User interface
            Console.WriteLine("which size array would you like to look at? \nEnter 256 for 256 \nEnter 2048 for 2048 \nEnter 4096 for 4096 \nEnter 'merge' to merge data sizes \nBeware! Any of incorrect inputs and you will have to restart the application");
            Console.WriteLine("Enter 'done' if you would like to exit the app");
            size = Console.ReadLine();
            if (size != "merge")
            {
                Console.WriteLine("Would you like to look at the low, mean or high results? \nEnter 'low' for the lowest temperatures \nEnter 'mean' for the mean of the temperatures \nEnter 'high' for the highest of temperatures \nBeware! Any of incorrect inputs and you will have to restart the application");
                string option = Console.ReadLine();
                Console.WriteLine("Would you like to see them in ascending order or descending order? \nEnter 'asc' for ascending order \nEnter 'des' for descending order \nBeware! Any of incorrect inputs and you will have to restart the application");
                string order = Console.ReadLine();
                if (size == "256")
                {
                    if (option == "low")
                    {
                        temp = "Low_256.txt"; //Once selected function is ran with parameter
                        Sort(temp, order);
                    }
                    if (option == "mean")
                    {
                        temp = "Mean_256.txt";
                        Sort(temp, order);
                    }
                    if (option == "high")
                    {
                        temp = "High_256.txt";
                        Sort(temp, order);
                    }
                }
                else if (size == "2048")
                {
                    if (option == "low")
                    {
                        temp = "Low_2048.txt";
                        Sort(temp, order);
                    }
                    if (option == "mean")
                    {
                        temp = "Mean_2048.txt";
                        Sort(temp, order);
                    }
                    if (option == "high")
                    {
                        temp = "High_2048.txt";
                        Sort(temp, order);
                    }
                }
                else if (size == "4096")
                {
                    if (option == "low")
                    {
                        temp = "Low_4096.txt";
                        Sort(temp, order);
                    }
                    if (option == "mean")
                    {
                        temp = "Mean_4096.txt";
                        Sort(temp, order);
                    }
                    if (option == "high")
                    {
                        temp = "High_4096.txt";
                        Sort(temp, order);
                    }
                }
            }
            else if (size == "merge")
            {
                Console.WriteLine("Which sizes would you like to merge? \nEnter 256 for 256 \nEnter 2048 for 2048 \nEnter 4096 for 4096 ");
                string mergeSize = Console.ReadLine();
                Console.WriteLine("Would you like to see them in ascending order or descending order? \nEnter 'asc' for ascending \nEnter 'des' for descending");
                string order = Console.ReadLine();
                Merging(mergeSize, order);
            }
            else if (size == "done")
            {
                Console.WriteLine("Thank you for viewing");
            }
            else
            {
                Console.WriteLine("This doesn't meet either requirement, please refer to the bracketed options in the questions");
            }
            Console.ReadLine();
        }
        static void Sort(string a, string order)
        {
            try
            {
                using (StreamReader sr = new StreamReader(a))
                {
                    //My method in acquiring data
                    var list = new List<string>();
                    var doubleList = new List<string>();
                    var merge = new List<double>();
                    string[] temp;
                    string[] array;
                    double[] doubleArray;
                    double[] SortedArray;
                    double val;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(line); //Reads in data from text file and adds to list
                    }
                    temp = list.ToArray(); //Turn the list into an array and feed to temporary array
                    for (int i = 0; i < temp.Length; i += 2)
                    {
                        doubleList.Add(temp[i]); //Removes whitespace from array
                    }
                    array = doubleList.ToArray(); //Finalises list to array so we now have the data without the whitespace in an array
                    doubleArray = Array.ConvertAll<string, double>(array, Convert.ToDouble); //Conversion to double variable type
                    if (doubleArray.Length == 256)
                    {
                        BubbleSort(doubleArray, order); //Application of Bubble Sort
                        for (int i = 0; i < doubleArray.Length; i += 9) //Print every 10th value
                        {
                            Console.WriteLine(doubleArray[i]);
                        }
                        Console.WriteLine("What value would you like to search for?");
                        val = Convert.ToDouble(Console.ReadLine());
                        LinearSearch(doubleArray, val); //Application of Linear Search
                    }
                    else if (doubleArray.Length == 2048)
                    {
                        if (order == "asc")
                        {
                            SortedArray = MergeSort(doubleArray); //Application of Merge Sort
                            for (int i = 0; i < doubleArray.Length; i += 9) //Again print every 10th Value
                            {
                                Console.WriteLine(SortedArray[i]);
                            }
                            Console.WriteLine("The 50th value in array size 2048 is:" + SortedArray[49]);
                            Console.WriteLine("Number of operations: " + counter); // Counter for operations
                            Console.WriteLine("What value would you like to search for?");
                            val = Convert.ToDouble(Console.ReadLine());
                            BinarySearch(SortedArray, val);// Application of Binary Search
                        }
                        else if (order == "des")
                        {
                            SortedArray = DesMergeSort(doubleArray); //Application of Merge Sort
                            for (int i = 0; i < doubleArray.Length; i += 9) //Again print every 10th Value
                            {
                                Console.WriteLine(SortedArray[i]);
                            }
                            Console.WriteLine("What value would you like to search for?");
                            Console.WriteLine("The 50th value in array size 2048 is:" + SortedArray[49]);
                            val = Convert.ToDouble(Console.ReadLine());
                            BinarySearch(SortedArray, val); // Application of Binary Search
                        }
                    }
                    else if (doubleArray.Length == 4096)
                    {
                        //Initialisation of Quick Sort algorithm
                        int left = 0;
                        int right = doubleArray.Length - 1;
                        if (order == "asc")
                        {
                            QuickSort(doubleArray, left, right); //Application of Quick Sort algorithm
                            for (int i = 0; i < doubleArray.Length; i += 9) //Again print every 10th Value
                            {
                                Console.WriteLine(doubleArray[i]);
                            }
                            Console.WriteLine("The 80th value in array size 4096 is:" + doubleArray[79]);
                            Console.WriteLine("Number of operations: " + counter); //Counter for operations
                            Console.WriteLine("What value would you like to search for?");
                            val = Convert.ToDouble(Console.ReadLine());
                            BinarySearch(doubleArray, val); //Application of Binary Search
                        }
                        else if (order == "des")
                        {
                            DesQuickSort(doubleArray, left, right); //Application of Quick Sort algorithm
                            for (int i = 0; i < doubleArray.Length; i += 9) //Again print every 10th Value
                            {
                                Console.WriteLine(doubleArray[i]);
                            }
                            Console.WriteLine("The 80th value in array size 4096 is:" + doubleArray[79]);
                            Console.WriteLine("What value would you like to search for?");
                            val = Convert.ToDouble(Console.ReadLine());
                            BinarySearch(doubleArray, val); //Application of Binary Search
                        }
                    }
                }
            }
            catch (Exception e) //If the files cannot be found this catch will show the user where to deposit the files
            {
                Console.WriteLine("The file could not be read, please place all text files for analysis in this location:");
                Console.WriteLine(e.Message);
            }
        }
        static void LinearSearch(double[] a, double val)
        {
            //Initial variables
            int check = -1;
            for (int i = 0; i < a.Length; i++)
            {
                //Simply read through the array and if it is then stop and print number
                if (val == a[i])
                {
                    if (i == 1)
                    {
                        check = i;
                        i = i + 1;
                        Console.WriteLine("The value you have entered is in position No." + i);
                        Console.WriteLine("This search took " + i + " operations to find the value");
                        Console.WriteLine("Press Enter to end program...");
                    }
                    else if (i > 9)
                    {
                        check = i;
                        Console.WriteLine("The value you have entered is in position No." + i);
                        Console.WriteLine("This search took " + i + " operations to find the value");
                        Console.WriteLine("Press Enter to end program...");
                    }
                }
            }
            //If it is not there then start new value
            if (check == -1)
            {
                Console.WriteLine("The value:" + val + " could not be found.");
                NextVal(a, val);
            }
        }
        static void NextVal(double[] a, double val)
        {
            int index = 0;
            double distance = Math.Abs(a[0] - val); // finds the absolute value of the value the user is looking for and the distance from it
            for (int i = 0; i < a.Length; i++)
            {
                double cdistance = Math.Abs(a[i] - val);
                if (cdistance < distance) //Make comparison
                {
                    index = i;
                    distance = cdistance;
                }
            }
            double theNumber = a[index];
            Console.WriteLine("Closest number is: " + theNumber + " in location:" + index); //Output to console
            Console.WriteLine("Press Enter to end program...");
        }
        static object BinarySearch(double[] a, double val)
        {
            //Initial variables
            int min = 0;
            int max = a.Length - 1;
            int check = -1;
            //Simply going through array and divide and conquer
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (val == a[mid])
                {
                    Console.WriteLine("Value found in location: " + mid);
                    Console.WriteLine("Press Enter to end program...");
                    check = mid;
                    return ++mid;
                }
                else if (val < a[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            if (check == -1)
            {
                NextVal(a, val);
            }
            return "Value not found";
        }
        static void BubbleSort(double[] a, string order)
        {
            int counter = 0;
            double holder;
            if (order == "asc")
            {
                //Simple application of Bubble sort
                for (int j = 0; j <= a.Length - 2; j++)
                {
                    for (int i = 0; i <= a.Length - 2; i++)
                    {
                        if (a[i] > a[i + 1])
                        {
                            holder = a[i + 1];
                            a[i + 1] = a[i];
                            a[i] = holder;
                            counter++;
                        }
                    }
                }
                Console.WriteLine("The number of operations using Bubble Sort is:" + counter);
            }
            else if (order == "des")
            {
                for (int j = 0; j <= a.Length - 2; j++)
                {
                    for (int i = 0; i < a.Length - 2; i++)
                    {
                        if (a[i] < a[i + 1])
                        {
                            holder = a[i + 1];
                            a[i + 1] = a[i];
                            a[i] = holder;
                            counter++;
                        }
                    }
                }
                Console.WriteLine("The number of operations using Bubble Sort is:" + counter);
            }
        }
        static void InsertionSort(double[] Array, string order)
        {
            //Though not used it has a similar algorithm to Bubble Sort
            counter = 0;
            int flag;
            double temp;
            if (order == "asc")
            {
                for (int i = 1; i < Array.Length; i++)
                {
                    temp = Array[i];
                    flag = 0;
                    for (int j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (temp < Array[j])
                        {
                            Array[j + 1] = Array[j];
                            j--;
                            Array[j + 1] = temp;
                            counter++;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                }
            }
            else if (order == "des")
            {
                for (int i = 1; i < Array.Length; i++)
                {
                    temp = Array[i];
                    flag = 0;
                    for (int j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (temp > Array[j])
                        {
                            Array[j + 1] = Array[j];
                            j--;
                            Array[j + 1] = temp;
                            counter++;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                }
            }
        }
        static double[] MergeSort(double[] array)
        {
            //Initial variables
            double[] left;
            double[] right;
            double[] result = new double[array.Length];
            if (array.Length <= 1)
                return array;
            int mid = array.Length / 2;
            left = new double[mid];
            //Check for even amount of numbers to account for accomodation
            if (array.Length % 2 == 0)
                right = new double[mid];
            else
                right = new double[mid + 1];
            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            int x = 0;
            for (int i = mid; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursive applications
            left = MergeSort(left);
            right = MergeSort(right);
            result = Merge(left, right);
            return result;
        }
        static double[] Merge(double[] left, double[] right)
        {
            int ResultLength = right.Length + left.Length;
            double[] result = new double[ResultLength];
            int indexleft = 0;
            int indexRight = 0;
            int indexResult = 0;
            //Performance of the swapping
            while (indexleft < left.Length || indexRight < right.Length)
            {
                if (indexleft < left.Length && indexRight < right.Length)
                {
                    if (left[indexleft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexleft];
                        indexleft++;
                        indexResult++;
                        counter++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                        counter++;
                    }
                }
                else if (indexleft < left.Length)
                {
                    result[indexResult] = left[indexleft];
                    indexleft++;
                    indexResult++;
                    counter++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                    counter++;
                }
                counter++;
            }
            return result;
        }
        static double[] DesMergeSort(double[] array)
        {
            double[] left;
            double[] right;
            double[] result = new double[array.Length];
            if (array.Length <= 1)
                return array;
            int mid = array.Length / 2;
            left = new double[mid];
            if (array.Length % 2 == 0)
                right = new double[mid];
            else
                right = new double[mid + 1];
            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            int x = 0;
            for (int i = mid; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = DesMergeSort(left);
            right = DesMergeSort(right);
            result = DesMerge(left, right);
            return result;
        }
        static double[] DesMerge(double[] left, double[] right)
        {
            counter = 0;
            int ResultLength = right.Length + left.Length;
            double[] result = new double[ResultLength];
            int indexleft = 0;
            int indexRight = 0;
            int indexResult = 0;
            while (indexleft < left.Length || indexRight < right.Length)
            {
                if (indexleft < left.Length && indexRight < right.Length)
                {
                    if (left[indexleft] >= right[indexRight])
                    {
                        result[indexResult] = left[indexleft];
                        indexleft++;
                        indexResult++;
                        counter++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                        counter++;
                    }
                }
                else if (indexleft < left.Length)
                {
                    result[indexResult] = left[indexleft];
                    indexleft++;
                    indexResult++;
                    counter++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                    counter++;
                }
                counter++;
            }
            return result;
        }
        static void QuickSort(double[] array, int left, int right)
        {
            //Simple application of Quick Sort
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                if (pivot > 1)
                {
                    QuickSort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(array, pivot + 1, right);
                }
            }
        }
        static private int Partition(double[] array, int left, int right)
        {
            //Application of using the pivot 
            double pivot = array[left];
            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                    counter++;
                }
                while (array[right] > pivot)
                {
                    right--;
                    counter++;
                }
                if (left < right)
                {
                    counter++;
                    if (array[left] == array[right])
                    {
                        counter++;
                        return right;
                    }
                    double temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static void DesQuickSort(double[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = DesPartition(array, left, right);
                if (pivot > 1)
                {
                    DesQuickSort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    DesQuickSort(array, pivot + 1, right);
                }
            }
        }
        static private int DesPartition(double[] array, int left, int right)
        {
            double pivot = array[left];
            while (true)
            {
                while (array[left] > pivot)
                {
                    counter++;
                    left++;
                }
                while (array[right] < pivot)
                {
                    counter++;
                    right--;
                }
                if (left < right)
                {
                    counter++;
                    if (array[left] == array[right])
                    {
                        counter++;
                        return right;
                    }
                    double temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static void Merging(string size, string order)
        {
            //Similar algorithms to the first sorts
            if (size == "256")
            {
                try
                {
                    string line;
                    var list = new List<string>();
                    var list1 = new List<string>();
                    var CompiledList = new List<string>();
                    string[] StringArray;
                    double[] DoubleArray;
                    {
                        using (StreamReader sr = new StreamReader("Low_256.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list.Add(line);
                            }
                            for (int i = 0; i < list.Count; i += 2)
                            {
                                CompiledList.Add(list[i]);
                            }
                        }
                        using (StreamReader sr = new StreamReader("High_256.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list1.Add(line);
                            }
                            for (int i = 0; i < list1.Count; i += 2)
                            {
                                CompiledList.Add(list1[i]);
                            }
                        }
                        StringArray = CompiledList.ToArray();
                        DoubleArray = Array.ConvertAll<string, double>(StringArray, Convert.ToDouble);
                        BubbleSort(DoubleArray, order); //Application of Bubble Sort
                        for (int i = 0; i < DoubleArray.Length; i += 9) //Print every 10th value
                        {
                            Console.WriteLine(DoubleArray[i]);
                        }
                        Console.WriteLine("What value would you like to search for?");
                        double val = Convert.ToDouble(Console.ReadLine());
                        LinearSearch(DoubleArray, val); //Application of Linear Search
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (size == "2048")
            {
                try
                {
                    string line;
                    var list = new List<string>();
                    var list1 = new List<string>();
                    var CompiledList = new List<string>();
                    string[] StringArray;
                    double[] DoubleArray;
                    {
                        using (StreamReader sr = new StreamReader("Low_2048.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list.Add(line);
                            }
                            for (int i = 0; i < list.Count; i += 2)
                            {
                                CompiledList.Add(list[i]);
                            }
                        }
                        using (StreamReader sr = new StreamReader("High_2048.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list1.Add(line);
                            }
                            for (int i = 0; i < list1.Count; i += 2)
                            {
                                CompiledList.Add(list1[i]);
                            }
                        }
                        StringArray = CompiledList.ToArray();
                        DoubleArray = Array.ConvertAll<string, double>(StringArray, Convert.ToDouble);
                        BinaryTree(DoubleArray);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (size == "4096")
            {
                try
                {
                    string line;
                    var list = new List<string>();
                    var list1 = new List<string>();
                    var CompiledList = new List<string>();
                    string[] StringArray;
                    double[] DoubleArray;
                    {
                        using (StreamReader sr = new StreamReader("Low_4096.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list.Add(line);
                            }
                            for (int i = 0; i < list.Count; i += 2)
                            {
                                CompiledList.Add(list[i]);
                            }
                        }
                        using (StreamReader sr = new StreamReader("High_4096.txt"))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                list1.Add(line);
                            }
                            for (int i = 0; i < list1.Count; i += 2)
                            {
                                CompiledList.Add(list1[i]);
                            }
                        }
                        StringArray = CompiledList.ToArray();
                        DoubleArray = Array.ConvertAll<string, double>(StringArray, Convert.ToDouble);
                        BinaryTree(DoubleArray);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void BinaryTree(double[] array)
        {
            //Instantiation of binary tree
            BinaryTree tree = new BinaryTree();
            for (int i = 0; i < array.Length; i++)
            {
                tree.Insert(array[i]);
            }
            tree.display();
            Console.WriteLine("What value would you like to search for?");
            double val = Convert.ToDouble(Console.ReadLine());
            bool found = tree.Search(val); //Confirmation of location or failure to find location
            if (found == true)
            {
                Console.WriteLine("The value you have searched is in the binary tree");
            }
            else
            {
                Console.WriteLine("The value you have entered is not in the binary tree");
            }
        }
    }
    public class BinaryTree
    {
        public Node root;
        public int count;
        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty() //Checking the tree if its empty
        {
            return root == null;
        }
        public void Insert(double d) //Entering new values into tree
        {
            if (isEmpty())
            {
                root = new Node(d);
            }
            else
            {
                root.InsertData(ref root, d); //This leads into the node class
            }
            count++;
        }
        public bool Search(double d) //Searching for values in the tree
        {
            return root.Search(root, d);
        }
        public bool isLeaf(double d)
        {
            if (!isEmpty())
            {
                return root.isLeaf(ref root);
            }
            return true;
        }
        public void display() //Displaying tree
        {
            if (!isEmpty())
            {
                root.Display(root);
            }
        }
        public int Count()
        {
            return count;
        }
    }
    public class Node
    {
        public double number;
        public Node rightLeaf;
        public Node leftLeaf;
        public Node(double value)
        {
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }
        public bool isLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);
        }
        public void InsertData(ref Node node, double data)
        {
            if (node == null)
            {
                node = new Node(data);
            }
            else if (node.number < data)
            {
                InsertData(ref node.rightLeaf, data);
            }
            else if (node.number > data)
            {
                InsertData(ref node.leftLeaf, data);
            }
        }
        public bool Search(Node node, double s)
        {
            if (node == null)
            {
                return false;
            }
            if (node.number == s)
            {
                return true;
            }
            else if (node.number > s)
            {
                return Search(node.leftLeaf, s);
            }
            else if (node.number < s)
            {
                return Search(node.rightLeaf, s);
            }
            return false;
        }
        public void Display(Node node)
        {
            if (node == null)
            {
                return;
            }
            Display(node.leftLeaf);
            Console.WriteLine(node.number);
            Display(node.rightLeaf);
        }
    }
}
