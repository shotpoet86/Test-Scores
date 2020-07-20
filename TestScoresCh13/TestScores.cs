//Programmer: Austin Parkere
//Date: June 24, 2020
//Assignment: Ch13/ PE7/ Test Scores
//Purpose: To read input scores from teacher and writing average of scores to text file 

using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestScoresCh13
{
    class TestScores
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Reading from studentInfo.txt file...");

                //stream for reading file
                //TXT FILE ATTACHED TO PROGRAM IN DEBUG FOLDER
                StreamReader reading = new StreamReader(@"studentInfo.txt");

                //stream for writing to file
                //TXT FILE ATTACHED TO PROGRAM IN DEBUG FOLDER
                StreamWriter writing = File.AppendText(@"studentResults.txt");

                //num of lines in txt files
                int numOfLines = 0;

                //read file line by line
                string line = reading.ReadLine();

                while (line != null)
                {
                    numOfLines++;

                    //splits string line information
                    string[] seperate = line.Split(' ');



                    //sum of scores
                    double sumScores = 0.0;

                    //num of scores
                    int numOfScores = 0;

                    int i;
                    for (i = 0; i < seperate.Length; i++)
                    {
                        //checks data type
                        //inline scoreValue variable decleration
                        if (int.TryParse(seperate[i], out int scoreValue) == true)
                        {
                            //calculate sum
                            sumScores += scoreValue;

                            //increment numOfScores
                            numOfScores++;
                        }
                        else
                        {
                            //prints student name
                            WriteLine("Writing name: " + seperate[i]);

                            //writes student name in txt file
                            writing.Write(seperate[i] + " ");
                        }
                    }
                    //average scores in each row
                    WriteLine("Writing average grade in row " + numOfLines + ", " +
                        string.Format("{0:f2}", sumScores / numOfScores));

                    //writes the average of scores in file
                    writing.Write(string.Format("{0:f2}", sumScores / numOfScores));

                    //inserts new line in file
                    writing.WriteLine();
                    line = reading.ReadLine();
                }
                writing.Close();
                reading.Close();
            }

            //handles directory not found exception 
            catch (DirectoryNotFoundException e)
            {
                WriteLine(e.Message);
            }

            //file not found exception
            catch (FileNotFoundException e)
            {
                WriteLine(e.Message);
            }

            //divide by zero exception
            catch (DivideByZeroException e)
            {
                WriteLine(e.Message);
            }
            ReadKey();
        }
    }
}
