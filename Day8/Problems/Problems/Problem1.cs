using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class Problem1
    {

        public Problem1()
        {
            Calculator calculator = new Calculator();
            int op1, op2, op3;
            bool running = true;
            while ( running )
            {
                Console.WriteLine("\n\nCalculator :");
                Console.WriteLine($"Current Mode : {calculator.GetMode()}");
                Console.WriteLine( "Select Operation : " );
                Console.WriteLine("1 : Add 2 numbers");
                Console.WriteLine("2 : Add 3 numbers");
                Console.WriteLine("3 : Subtract 2 numbers");
                Console.WriteLine("4 : Subtract 3 numbers");
                Console.WriteLine("5 : Change Mode");
                Console.WriteLine("6 : Quit");
                Console.Write("Your Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine().Trim() );

                if ( calculator.GetMode() == Calculator.states.Reverse )
                {
                    if ( choice == 1 || choice == 2 )
                    {
                        choice += 2;
                    }
                    else if( choice == 3 || choice == 4 ){
                        choice -= 2;
                    }
                }

                switch ( choice )
                {
                    case 1:
                        Console.Write("Operand 1 : ");
                        op1 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 2 : ");
                        op2 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.WriteLine( $"{op1} + {op2} = {calculator.Add(op1,op2)}" );
                        break;

                    case 2:
                        Console.Write("Operand 1 : ");
                        op1 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 2 : ");
                        op2 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 3 : ");
                        op3 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.WriteLine($"{op1} + {op2} + {op3} = {calculator.Add(op1, op2 , op3)}");
                        break;

                    case 3:
                        Console.Write("Operand 1 : ");
                        op1 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 2 : ");
                        op2 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.WriteLine($"{op1} - {op2} = {calculator.Sub(op1, op2)}");
                        break;

                    case 4:
                        Console.Write("Operand 1 : ");
                        op1 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 2 : ");
                        op2 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("Operand 3 : ");
                        op3 = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.WriteLine($"{op1} - {op2} - {op3} = {calculator.Sub(op1, op2, op3)}");
                        break;

                    case 5:
                        calculator.ChangeMode();
                        Console.WriteLine($"Changed Mode To : {calculator.GetMode()}");
                        break;

                    case 6:
                        Console.WriteLine("Quiting");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Entry.");
                        break;
                }

            }


        }

        class Calculator
        {
            public enum states { Normal , Reverse };
            private states state;


            public Calculator() { }


            public states GetMode()
            {
                return state;
            }


            public void ChangeMode()
            {
                if ( this.state == states.Normal )
                { 
                    this.state = states.Reverse;
                }
                else
                {
                    this.state = states.Normal;
                }
            }

            public int Add(int op1, int op2)
            {
                return op1 + op2;
            }

            public int Add(int op1, int op2, int op3)
            {
                return op1 + op2 + op3;
            }


            public int Sub(int op1, int op2)
            {
                return op1 - op2;
            }

            public int Sub(int op1, int op2, int op3)
            {
                return op1 - op2 - op3;
            }

        }

    }
}
