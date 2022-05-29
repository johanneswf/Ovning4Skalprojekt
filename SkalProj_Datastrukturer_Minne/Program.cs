using System;

/*

Questions:

1. 
The stack is lower level and stores local variables as well as parameters that get passed to methods.
It's literally a stack of values, organized linearly (Last In First Out).

The heap is a disorganized mess of values (objects in C#) that has to be managed by the program and/or the garbage collector.
In lower level languages you have to manually free heap memory. 
The garbage collector in .NET handles this for us but it's valuable to know how to help it, and how 
to prevent needless buildup of objects in memory.


2.
Value type variables IS an instance of the type. If you copy it you create a new instance of it.

Reference type variables REFERS to an instance of the type. As such it points to something on the heap and 
if you blindly copy the variable it will still point to the original reference. When the original reference gets changed,
so too does anything that references it.


3.
ReturnValue() returns 3, because x and y are separate instances of the integer value type. Changing one doesn't change the other.

ReturnValue2() returns 4, because x and y both refer to the object reference type. While this method returns an int
it's still creating the variables internally as objects, and thus they get treated as reference types.

*/

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        ///<summary>
        ///The main method, vill handle the menus for the program
        ///</summary>

        /* <param name="args"></param> */


        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Parenthesis"
                    + "\n0. Exit the Application");
                var input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            var theList = new List<string>();
            Console.Write("Add(+)/Remove(-) string: ");
            var input = Console.ReadLine()!;
            var nav = input[0];
            var value = input.Substring(1);

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"\"{value}\" added to the list.");
                    break;

                case '-':
                    if (theList.Remove(value)) Console.WriteLine($"\"{value}\" removed from the list.");
                    else Console.WriteLine($"There's no \"{value}\" in the list.");
                    break;

                default:
                    Console.WriteLine("Prefix your string with + to add it to the list.)");
                    Console.WriteLine("Prefix your string wtih - to remove it from the list.");
                    break;

            }

            /*
            Övning 1:
            var theListCapacity = theList.Capacity; 

            The list begins with a capacity of 0, once you add an element it increases to 4.

            Every 4 elements the capacity increases by 4: 0/4/8/12... etc. The capacity doesn't get smaller by removing elements from the list.

            Because of this behavior it makes sense to specify fixed size arrays whenever we know how many elements we're going to be working with,
            because performance with arrays will always be better. Especially if you're working with collections that are just over the threshold,
            such as lists of 5, 9, 13 etc. elements. 
            */


        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            var theQueue = new Queue<string>();

            bool run = true;
            do
            {
                Console.WriteLine("Examine a Queue (ICA)");
                Console.WriteLine("+: Queue an item");
                Console.WriteLine("-: Dequeue");
                Console.WriteLine("q: Quit");


                Console.Write(" + | - | q : ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "+":
                        Console.Write("Queue item: ");
                        theQueue.Enqueue(Console.ReadLine()!);
                        break;

                    case "-":
                        theQueue.Dequeue();
                        break;

                    case "q":
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Use +, - or q to navigate the menu.");
                        break;
                }
            } while (run);


            /*
            Övning 2:
            1/2: 
            Queue<string> ICA = new Queue<string>();
            ICA.Enqueue("Kalle"); // { Kalle }
            ICA.Enqueue("Greta"); // { Kalle, Greta }
            ICA.Dequeue(); // { Greta }
            ICA.Enqueue("Stina"); { Greta, Stina }
            ICA.Dequeue(); // { Stina }
            ICA.Enqueue("Olle"); // { Stina, Olle }
            */

        }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            Stack<string> theStack = new Stack<string>();

            bool run = true;
            do
            {
                Console.WriteLine("Examine a Stack (ICA)");
                Console.WriteLine("+: Push an item");
                Console.WriteLine("-: Pop");
                Console.WriteLine("q: Quit");


                Console.Write(" + | - | q : ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "+":
                        Console.Write("Push item: ");
                        theStack.Push(Console.ReadLine()!);
                        break;

                    case "-":
                        theStack.Pop();
                        break;

                    case "q":
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Use +, - or q to navigate the menu.");
                        break;
                }


            } while (run);


            /*
            
            Övning 3:

            1.
            Stack<string> ICA = new Stack<string>();
            ICA.Push("Kalle"); // { Kalle }
            ICA.Push("Greta"); // { Kalle, Greta }
            ICA.Pop(); // { Kalle }
            ICA.Push("Stina"); // { Kalle, Stina }
            ICA.Pop(); // { Kalle }
            ICA.Push("Olle"); // { Kalle, Olle }

            2.

            */

            static void ReverseText()
            {
                var input = Console.ReadLine()!;

                Stack<char> text = new Stack<char>(); // Create stack to store our characters

                foreach (var c in input) text.Push(c); // Push characters from string to stack

                // Write characters from stack
                // The order will be reversed because of the FILO principle
                foreach (var c in text) Console.Write(c); 
            }
        }

        static void CheckParenthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // Receive input from user
            Console.Write("Input: ");
            var input = Console.ReadLine()!;

            // We make a two-dimensional array with the characters we want to balance.
            // Hardcoding the characters in the if/else (or probable switch) below is more repetitive/boring.
            // We could've made a list, dictionary, struct or class, but a arrays are leaner.
            // If we wanted to code more functionality, such as checking for html-tags we would create a class for this.
            var balancedPairs = new char[,]
                {
                    { '(', ')' },
                    { '{', '}' },
                    { '[', ']' }
                };

            // Variable that holds the number of rows in our array.
            var balancedPairsRows = balancedPairs.GetLength(0);

            // Stack where we push our matched characters
            var inputMatchFirstColumn = new Stack<char>();

            // Flag if we get a mismatch.
            var failure = false;

            // For every character in our input string...
            foreach (char c in input)
            {
                // For every row in balancedPairs...
                for (int i = 0; i < balancedPairsRows - 1; i++)
                {
                    // If the input character matches the first column character, push it to the stack
                    if (c == balancedPairs[i, 0]) inputMatchFirstColumn.Push(c);
                    // Else if the input character matches the second column character
                    else if (c == balancedPairs[i, 1])
                    {
                        // First check if the stack is empty because we can't pop it otherwise. Flag failure if empty.
                        // Pop the stack and compare it to the first column character of the same row. Flag failure if they don't match.
                        if (inputMatchFirstColumn.Count == 0 || inputMatchFirstColumn.Pop() != balancedPairs[i, 0]) { failure = true; break; }
                    }
                }
                // All these breaks and failure flags makes me want the method to return a boolean instead of void.
                // Then we could just return the false immediately and handle it elsewhere.
                // But we'll stick to the exercise spec.
                if (failure) break;
            }

            // We might end up with a stack full of first column characters that never gets popped
            // Therefore we flag for failure if the stack isn't empty.
            if (inputMatchFirstColumn.Count != 0) failure = true;

            // Conditionally indicates to the user if there was a failure flag.
            Console.WriteLine($"\" {input} \" is{(failure ? " NOT " : " ")}formatted correctly.");

        }

    }
}

