using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_07_11
{
    internal class Password
    {
        int length;
        string password;

        public Password(int lenght)
        {
            this.length = lenght;
            GenPass();
        }

        public Password()
        {
            length = 8;
            GenPass();
        }

        public int GetLength()
        {
            return length;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetLenght(int length)
        {
            this.length = length;
        }
        public void GenPass()
        {
            password = "";
            int letterNum; //The number that we´ll converto to an ascii character
            char letterChar; //The already generated ascii character
            Random random = new Random();
            for (int counter = 0; counter < length; counter = counter + 1)
            {
               int type = random.Next(3); //This will decide what kind of character we´ll generate (0 = number, 1 = lowerCase, 2 = upperCase)
               
                switch(type) 
                {
                    case 0: //Number generation
                        int num = random.Next(1,10);
                        password = password + num;
                        break;

                    case 1: //lowerCase generation
                        letterNum = random.Next(97,123);
                        letterChar = Convert.ToChar(letterNum);
                        password = password + letterChar;
                        break;

                    case 2: //upperCase generation
                    
                        letterNum = random.Next(65, 91);
                        letterChar = Convert.ToChar(letterNum);
                        password = password + letterChar;
                        break ;
                }
            }
        }
        public bool IsPassStrong()
        {
            bool strong = true; //here we´ll save the bool of the strenght of the password
            int asciiValue; //Here we will get the ascii value of the caracter
            int numUpper = 0; //the number of upper case characters
            int numLower = 0; //the number of lower case characters
            int numNumbers = 0; //the number of numbers
            foreach (char character in password) //We use this to convert each character to its ascii value
            {
                asciiValue = Convert.ToInt32(character);
                if (asciiValue >= 48 && asciiValue <= 57) //This will tell us if its a number, and add +1 to our total numbers
                {
                    numNumbers = numNumbers + 1;
                }
                else if (asciiValue >= 65 && asciiValue <= 90) //The same as before but with upper cases
                {
                    numUpper = numUpper + 1;
                }
                else //Same with the lower cases
                {
                    numLower = numLower + 1;
                }
            }

            if (numUpper >= 2 && numLower >= 1 && numNumbers >= 2) //If we fulfill all the requirements the password will qualify as strong
            {
                strong = true;
            }
            else
            {
                strong = false;
            }

            return strong;
        }
    }
}
