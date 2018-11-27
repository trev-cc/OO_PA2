using System;
using System.Collections.Generic;
using Students;
public class Professor:User{
    string pName;
    string degree;
    string rank;
    List<Course> teaching = new List<Course>();

    public Professor(string[] pData){
        //uId, pw  , pName, degree, rank
        uId = pData[0].Trim();
        passWord = pData[1].Trim();
        pName = pData[2].Trim();
        degree = pData[3].Trim();
        rank = pData[4].Trim();
    }
    public void addCourseToTeach(Course c){
        teaching.Add(c);
    }
    public void displayCourses(){
        foreach(Course c in teaching)
            c.displayCourseInfo();
    }
    public void updateStudentAssessmentPoints(StudAssessment sa, float p){
        sa.updateAssessmentPoints(p);
    }
 public char Menu()
        {
            char ch;
            Console.WriteLine("1- List my courses");
            //Console.WriteLine("2- Select course");
            Console.WriteLine("2- Add Assesment to course");
            Console.WriteLine("3- Update student's Assesment points");
            Console.WriteLine("4- list students in a course");
            Console.WriteLine("0- EXIT");
            Console.WriteLine("=================================");
            Console.WriteLine("Select 1..4 or 0 to exit");

            ch = Console.ReadKey(true).KeyChar;
            return ch;

        }
       

}