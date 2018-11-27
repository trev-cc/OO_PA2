using System;

public class Registrar:User{
    string rName;


public Registrar(string[] rData){
    //Reg1, 000, name
    uId = rData[0].Trim();
    passWord = rData[1].Trim();
    rName = rData[2].Trim();

}
 public char Menu()
        {
            char ch;
            Console.WriteLine("\n\n\n1- Add Grad student");
            Console.WriteLine("2- Add undergrad student");
            Console.WriteLine("3- List All grad students");
            Console.WriteLine("4- List All undergrad students");
            Console.WriteLine("5- Add new course");
            Console.WriteLine("6- Assign Prof. to course");
            Console.WriteLine("7- list students in course");
            Console.WriteLine("0- EXIT");
            Console.WriteLine("=================================");
            Console.WriteLine("Select 1..7 or 0 to exit");

            ch = Console.ReadKey(true).KeyChar;
            return ch;

        }
}