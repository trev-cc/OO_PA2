using System;
using System.Collections.Generic;

namespace Students
{
    
   public  enum Classification {
        Freshman, Sophomore, Junior, Senior
    }
public abstract class Student:User{
    string sName;
    float gpa;
    string DoB;
    List<Enrollment> myEnrollments = new List<Enrollment>();  
    public Student(){

    }

    public Student(string uID, string pw, string sName, string DoB,float gpa)
    {
        this.uId = uID;
        this.passWord = pw;
        this.sName = sName;
        this.gpa = gpa;
        this.DoB = DoB;
    }
    public string getName(){
        return sName;
    }
    public void addEnrollment(Enrollment tEn){
        myEnrollments.Add(tEn);
    }
    public Enrollment getEnrolmentByCourseId(int cId){
        foreach(Enrollment e in myEnrollments){
            if(e.getCourse().cId ==  cId)
                  return e;
        }
        return null;
    }
    public void DisplayEnrollments(){
        foreach(Enrollment e in myEnrollments){
         e.displEnrolledStudInfo();
        }
    }
    public virtual void DisplayStdInfo()
    {
        Console.Write(" {0,-15} {1,5:F2} {2,-15}",sName,gpa,DoB);
    }

        abstract public  float calcGpa();

     public  char Menu()
        {
            char ch;
            Console.WriteLine("1- List My courses");
            Console.WriteLine("2- Enroll in a course");
            Console.WriteLine("3- submit course Assesment");
            Console.WriteLine("0- EXIT");
            Console.WriteLine("=================================");
            Console.WriteLine("Select 1..3 or 0 to exit");

            ch = Console.ReadKey(true).KeyChar;
            return ch;

        }
   
   
   
    }
//-------------------------------------------------
public class GradStudent:Student{
    string PrevUniversity;
    float ugGpa;

    public GradStudent(){

    }
    // File: Id, pw, sName, sID, DoB, Dept, GPA, pDeg, pUni, Dept, uGPA
    //      : 0  1    2      3    4    5     6    7     8     9     10
    //G: j, 12, John, 12234, 01/01/81, CIS, 3.00, BSc, WTAMU, CS, 3.33
    // base Student(string uID, string pw, string sName, string DoB,float gpa)
    // std id = sData[3] not used
     public GradStudent(string[] sData):base( sData[0].Trim(), sData[1].Trim(),sData[2].Trim(),
                         sData[4].Trim(),float.Parse(sData[6])){
     String uid  = sData[0].Trim();
     String pw = sData[1].Trim();
     String sName = sData[2].Trim();
     float gpa = float.Parse(sData[6]);
     string DoB = sData[4].Trim();
     string PrevUniversity= sData[8].Trim();
     float ugGpa = float.Parse(sData[10]);

     this.PrevUniversity = PrevUniversity;
     this.ugGpa = ugGpa;
      
    }
    /* public GradStudent(string sName,float gpa, string DoB, string PrevUniversity, float ugGpa) :base( sName,gpa, DoB)
    {
        this.PrevUniversity = PrevUniversity;
        this.ugGpa = ugGpa;
    }*/
    public override  void DisplayStdInfo(){
        base.DisplayStdInfo();
        Console.Write("{0,-10} {1,5:F2} {2,5:F2}",PrevUniversity,ugGpa,calcGpa());
    }

    public override float calcGpa(){
        return 3.3f;
    }
}



public class UndergradStudent:Student{
    string PrevHSchool;
    Classification stdClass;

    public UndergradStudent(){

    }

    //UG:   B,  54, Bob, 54785, 03/01/99, CIDM, 4.00, PHS, Sophomore
    //File: uId, pw, sName, sID, DoB, Dept, GPA, HS, Class
    //       0    1    2     3    4     5    6    7    8
     public UndergradStudent(string[] sData):base( sData[0].Trim(), sData[1].Trim(),sData[2].Trim(),
                         sData[4].Trim(),float.Parse(sData[6])){
     String uid  = sData[0].Trim();
     String pw = sData[1].Trim();
     String sName = sData[2].Trim();
     float gpa = float.Parse(sData[6]);
     string DoB = sData[4].Trim();
     string PrevHsch = sData[7].Trim(); 
     Classification cl = (Classification) System.Enum.Parse(typeof(Classification),sData[8].Trim());
     this.PrevHSchool = PrevHsch;
     this.stdClass = cl;
      
    }

    //string uID, string pw, string sName, string DoB,float gpa)
    /* public UndergradStudent(string sName,float gpa, string DoB, string PrevHsch, Classification cl) :
    base( sName,gpa, DoB)
    {
        this.PrevHSchool = PrevHsch;
        this.stdClass = cl;
    }*/
    public override  void DisplayStdInfo(){
        base.DisplayStdInfo();
        Console.Write("{0,-10} {1,-10} {2,5:F2}",PrevHSchool,stdClass,calcGpa());
    }

    public override float calcGpa(){
        return 3.3f;
    }
}

}