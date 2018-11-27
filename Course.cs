using System;
using System.Collections.Generic;
using Students;
public class Course{
    string cName;
    public Professor professor{get;set;}
    public int cId{get; set;}
    int nCredits;
    List <Assessment> crsAsses;
    List<Enrollment> enrollments = new List<Enrollment>();
    public Course(string cn, int id, int credits){
        cName = cn;
        cId = id;
        nCredits = credits;
        crsAsses = new List<Assessment>();
    }
     public Course(string[] cData){
         cId = int.Parse(cData[0].Trim());
        cName = cData[1].Trim();
        
        nCredits = int.Parse(cData[2].Trim());
        crsAsses = new List<Assessment>();
    }

    public void addEnrollment(Enrollment e){
            enrollments.Add(e);
    }
    public void AddCourseAssesment(Assessment a){
        crsAsses.Add(a);
    }
    public void displayCourseInfo(){
        Console.WriteLine(" {0}, {1}, {2} ",cId, cName, nCredits);
    }
    public Assessment getAssesmentById(string assesId){

        foreach(Assessment a in crsAsses)
           if(a.getId().Equals(assesId)) return a;
        return null;   
    }
    public void displayCourseAssessments(){
        foreach(Assessment a in crsAsses)
           Console.Write("{0}, ", a.getId());
        Console.WriteLine();
    }
    public void displayCourseStudents(){
        foreach(Enrollment e in enrollments)
            e.displEnrolledStudInfo();
             //Console.WriteLine("{0}: {1}",);
    }
    public Student getStudentByName(string sName){
        foreach(Enrollment e in enrollments)
            if(e.getStudent().getName().Equals(sName)) 
                return e.getStudent();
             //Console.WriteLine("{0}: {1}",);
         return null;    
    }

}

public abstract class Assessment{
    protected string asId; // name e.g HW3
    protected float percent;
    protected float totPoints;
    protected string DueDate;
    public abstract float calcGrade(float stdPoints, string subDate);
    public string getId(){return asId;}
}
public class Assignment:Assessment{
    string assignmentDescr;
    string subDate;
    
    float latePenalty=0;

public Assignment(string asName, float percentage, string descr, float points, string duedate, float latePen ){
    this.asId = asName;
    percent = percentage;
    assignmentDescr = descr;
    totPoints = points;
    DueDate = duedate;
    latePenalty  = latePen;
  }
     public override float calcGrade(float stdPoints, string subDate){
         //compare subDate with DueDate, then claculate penality
         return ((stdPoints-latePenalty*stdPoints)/totPoints *percent *100);
     } 
}
public class Exam:Assessment{
    
    string totalTime;
    int numofAttempts=1;

    public Exam(string asName, float percentage, float points, string duedate, int nOfAtt ){
    this.asId = asName;
    percent = percentage;
    totPoints = points;
    DueDate = duedate;
    numofAttempts = nOfAtt;
  }
     public override float calcGrade(float stdPoints, string subDate){
         //compare subDate with DueDate, then claculate penality
         return ((stdPoints)/totPoints *percent *100);
     } 


}

public class StudAssessment{
    Assessment StdAsses;
    float assessmentPoints;
    bool graded; 
    string subDate;
    public StudAssessment(Assessment StdAsses, string sDate){
        this.StdAsses = StdAsses;
        //assessmentPoints = points;
        subDate = sDate;
        graded = false;
    }
    public float getGrade(){
        return StdAsses.calcGrade(assessmentPoints,subDate);
    }
    public Assessment getAssessment(){
        return StdAsses;
    }
    public void updateAssessmentPoints(float p){
        assessmentPoints = p;
    }
}
public class Enrollment{
    Course course;
    Student student;
    List <StudAssessment> StdAssessments;
    float stdGrade;
    public Enrollment(Course regCrs,Student std){
        course = regCrs;
        student = std;
        StdAssessments = new List<StudAssessment>();
        stdGrade = 0;
    }
    public void submitAssesment(string assesId, string sDate){
        Assessment a = course.getAssesmentById(assesId);
        if (a!=null)
             StdAssessments.Add(new StudAssessment(a,sDate));
        else Console.WriteLine("\n Err: No such assesment in the course");
    }
    
    public Course getCourse(){
        return course;
    }
    public StudAssessment getStudAssessmentById(string assesId){
        foreach(StudAssessment s in StdAssessments){
            if(s.getAssessment().getId().Equals(assesId))
              return s;
        }
        return null;
    }
    public Student getStudent(){
        return student;
    }
    
    public float getStudCourseGrade(){
        foreach(StudAssessment sa in StdAssessments)
            stdGrade+=sa.getGrade();
        return stdGrade;
    }

    public void displEnrolledStudInfo(){
        student.DisplayStdInfo();
        course.displayCourseInfo();
        foreach(var a in StdAssessments)
             Console.Write("Assess Id = {0}, Grade = {1,8:F2}",a.getAssessment().getId(), a.getGrade());
        Console.Write("{0,8:F2} \n", stdGrade);     

    }
}