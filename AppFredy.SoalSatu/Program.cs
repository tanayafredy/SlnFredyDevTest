using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFredy.SoalSatu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string hasil = "";
            string inputParameter = "";
            string message = "Input hanya bisa angka 1-100";

            Console.Write("Input Parameter:");

            inputParameter = Console.ReadLine();

            Console.WriteLine("Hasil input :" + inputParameter);
            if (int.TryParse(inputParameter, out int result))
            {
                if (result > 0 && result <= 100)
                {
                    for (int i = result; i > 0; i--) //reverse looping for getting max number
                    {
                        for (int j = 1; j <= result; j++) //normal looping
                        {
                            if (j >= i) //check if normal looping = max number from reverse looping
                            {
                                hasil += "#"; //if true, print hashtag
                            }
                            else
                            {
                                hasil += " "; //if false, print whitespace
                            }
                        }
                        hasil += '\n'; //print newline
                    }
                    Console.WriteLine(hasil); //print result
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.ReadLine();

        }
    }
}
