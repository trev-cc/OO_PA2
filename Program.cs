using System;
using System.Collections.Generic;

using Students;

namespace PA1
{
    class Program
    {

        public static char LoginMenu()
        {
            char ch;
            Console.WriteLine("\n\n\n  MAIN MENU   ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1- Login as Admin");
            Console.WriteLine("2- Login as U.grad student");
            Console.WriteLine("3- Login as Grad student");
            Console.WriteLine("4- Login as professor");
            Console.WriteLine("0- EXIT");
            Console.WriteLine("=================================");
            Console.WriteLine("Select 1..2 or 0 to exit");

            ch = Console.ReadKey(true).KeyChar;
            return ch;

        }


        public static void LoadUserData(char utype, List<User> users, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);

            int i = 0;
            foreach (string line in lines)
            {
                string[] stdData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    if (utype == 'G')
                        users.Add(new GradStudent(stdData));
                    if (utype == 'U')
                        users.Add(new UndergradStudent(stdData));
                    if (utype == 'P')
                        users.Add(new Professor(stdData));
                    if (utype == 'A')
                        users.Add(new Registrar(stdData));

                }
                i++;
            }

        }
        public static void LoadStudData(char level, List<User> students, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);

            int i = 0;
            foreach (string line in lines)
            {
                string[] stdData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    if (level == 'G')
                        students.Add(new GradStudent(stdData));
                    if (level == 'U')
                        students.Add(new UndergradStudent(stdData));
                }
                i++;
            }

        }

        public static void LoadProfData(List<User> profList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //uId, pw  , pName, degree, rank
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    profList.Add(new Professor(stdData));
                }
                i++;
            }

        }

        public static void LoadCourseData(List<Course> crsList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //id,  name, credits
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    crsList.Add(new Course(stdData));
                }
                i++;
            }

        }

        public static void LoadRegData(List<User> rList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //id,  name, credits
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    rList.Add(new Registrar(stdData));
                }
                i++;
            }

        }

        public static User findUser(List<User> users, string uid)
        {
            foreach (User u in users)
            {
                if (u.getUid().Equals(uid)) return u;
            }
            return null;
        }

        public static Course findCourse(List<Course> cList, int cId)
        {
            foreach (Course c in cList)
            {
                if (c.cId == cId) return c;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            char ch, ch2;
            bool successLogin = false;
            GradStudent st;
            var admins = new List<User>();
            List<Course> coursesList = new List<Course>();
            List<Enrollment> courseEnrolls = new List<Enrollment>();



            List<User> profList = new List<User>();
            List<User> gslist = new List<User>();
            List<User> ugslist = new List<User>();



            LoadUserData('G', gslist, "GsList.txt");
            LoadUserData('U', ugslist, "UGsList.txt");
            LoadUserData('P', profList, "profData.txt");
            LoadCourseData(coursesList, "coursesData.txt");
            LoadUserData('A', admins, "adminData.txt");

            List<User> students = new List<User>();
            students.AddRange(gslist);
            students.AddRange(ugslist);


            do
            {
                ch = LoginMenu();

                switch (ch)
                {
                    case '1':

                        Console.WriteLine("\n \t Enter your Id:");
                        string tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        string tPw = Console.ReadLine();
                        Registrar admin = (Registrar)findUser(admins, tId);
                        successLogin = false;
                        // User admin =  findUser(admins,tId);
                        if (admin != null)
                            successLogin = admin.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                //1- Add Grad student" , "2- Add undergrad student", "3- List All grad students",
                                //"4- List All undergrad students", "5- Add new course", "6- list students in course");
                                ch2 = admin.Menu();
                                switch (ch2)
                                {
                                    //TODO (1): Add new Grad Student
                                    case '1': break;
                                    //TODO (2): Add new undergrad Student,
                                    case '2': break;
                                    case '3':
                                        foreach (GradStudent std in gslist)
                                        {
                                            Console.WriteLine();
                                            std.DisplayStdInfo();

                                        }
                                        break;
                                    case '4':
                                        foreach (UndergradStudent std in ugslist)
                                        {
                                            Console.WriteLine();
                                            std.DisplayStdInfo();

                                        }
                                        break;

                                    case '5': //TODO (3): Add new  course by asking Admin for course info., verify inputs 1st
                                              //        : ++ Save new list to File if admin agrees
                                             
                                         // Test: Currently adding one specific course
                                        coursesList.Add(new Course("Adv. Prog", 3312, 3));
                                        //coursesList[0].professor = (Professor )profList[0];
                                        break;
                                    case '6': //TODO (4): Assign course to prof by getting ProfId, courseId,
                                              //        : verify inputs, and prof doesnot have >3 courses
                                              //        : ++ Save new list to File, and make the code initialize prof-course-assignment list from a file 

                                        // Test: Currently Assign all courses to 1st prof in the list
                                        foreach (var c in coursesList)
                                        {
                                            c.professor = (Professor)profList[0];
                                            c.professor.addCourseToTeach(c);
                                        }
                                        break;

                                    case '7':
                                        foreach (var std in courseEnrolls)
                                        {
                                            std.displEnrolledStudInfo();
                                        }
                                        break;

                                } //end switch ch2

                            } while (ch2 != '0');
                        } // else 



                        break;

                    case '2':  //  Works for both grad & undergrad using student combined list
                    case '3':
                        Console.WriteLine("\n \t Enter your Id:");
                        tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        tPw = Console.ReadLine();
                        successLogin = false;
                        Student student = (Student)findUser(students, tId);

                        if (student != null)
                            successLogin = student.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                //"1- List My courses", "2- Enroll in a course","3- submit course Assesment"
                                ch2 = student.Menu();
                                switch (ch2)
                                {
                                    case '1':
                                        student.DisplayEnrollments();

                                        break;
                                    case '2':
                                        Console.WriteLine("Enter Course Id: ");
                                        int cId = int.Parse(Console.ReadLine());

                                        Course selectedCourse = findCourse(coursesList, cId);
                                        // TODO (5): check if stud already enrolled in the course before adding
                                        if (selectedCourse != null)
                                        {
                                            Enrollment tEn = new Enrollment(selectedCourse, student);
                                            courseEnrolls.Add(tEn);
                                            student.addEnrollment(tEn);
                                            selectedCourse.addEnrollment(tEn);
                                        }
                                        break;


                                    case '3':
                                        student.DisplayEnrollments();
                                        Console.WriteLine("Select Course Id To submit Assessment for: ");

                                        cId = int.Parse(Console.ReadLine());

                                        //selectedCourse = findCourse(coursesList,  cId);
                                        // 
                                        Enrollment e = student.getEnrolmentByCourseId(cId);
                                        if (e != null)
                                        {
                                            e.getCourse().displayCourseAssessments();
                                            Console.WriteLine("Select Assessment Id To submit: ");
                                            string assessId = Console.ReadLine().Trim();
                                            e.submitAssesment(assessId, "12/12/2018");
                                        }
                                        break;

                                        //case '4': 
                                        // TODO (6): Drop course, get cId, verify cId in student enrollments, then remove enrol.    

                                } // switch ch2
                            } while (ch2 != '0');
                        } //else
                        break;

                    case '4': //prof

                        Console.WriteLine("\n \t Enter your Id:");
                        tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        tPw = Console.ReadLine();
                        successLogin = false;
                        Professor prof = (Professor)findUser(profList, tId);
                        // User admin =  findUser(admins,tId);
                        if (prof != null)
                            successLogin = prof.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                // 1- List my courses, 2- Add Assesment to course,3- Update student's Assesment points");
                                // 4- list students in a course
                                ch2 = prof.Menu();
                                switch (ch2)
                                {
                                    case '1':
                                        prof.displayCourses();
                                        break;
                                    case '2':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        int cId = int.Parse(Console.ReadLine());

                                        Course selectedCourse = findCourse(coursesList, cId);
                                        // TODO (7): get assessment type: assignment, exam, proj,...
                                        //         : then add assessment info 
                                        if (selectedCourse != null)
                                        {

                                            Console.WriteLine("Enter Assessment info: ");
                                            Console.WriteLine("Id = ");
                                            string assesId = Console.ReadLine();
                                            Console.WriteLine("Weight = ");
                                            float aPercent = float.Parse(Console.ReadLine());
                                            Console.WriteLine("Descr = ");
                                            string asDescr = Console.ReadLine();
                                            Console.WriteLine("Points = ");
                                            float aPoints = float.Parse(Console.ReadLine());
                                            Console.WriteLine("Due on = ");
                                            string aDueDate = Console.ReadLine();
                                            Console.WriteLine("Late Pen = ");
                                            float latePen = float.Parse(Console.ReadLine());

                                            selectedCourse.AddCourseAssesment(new Assignment(assesId, aPercent, asDescr, aPoints, aDueDate, latePen));
                                        }


                                        //coursesList[0].AddCourseAssesmsnt(new Assignment("HW1",0.25f,"written assignment",200,"10/22/18",0.1f));
                                        //coursesList[0].AddCourseAssesmsnt(new Exam("MT",0.50f, 200,"10/22/18",2));
                                        //coursesList[0].AddCourseAssesmsnt(new Assignment("HW2",0.25f,"written assignment",300,"10/22/18",0.1f));

                                        break;
                                    case '3':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        cId = int.Parse(Console.ReadLine());

                                        selectedCourse = findCourse(coursesList, cId);

                                        if (selectedCourse != null)
                                        {
                                            selectedCourse.displayCourseStudents();
                                            Console.WriteLine("Select student name  ");
                                            //Console.WriteLine(" sName : ");
                                            string sName = Console.ReadLine().Trim();

                                            Student s = selectedCourse.getStudentByName(sName);

                                            Enrollment e = s.getEnrolmentByCourseId(cId);
                                            if (e != null)
                                            {
                                                e.getCourse().displayCourseAssessments();
                                                Console.WriteLine("Select Assessment Id To update: ");
                                                string assessId = Console.ReadLine().Trim();
                                                StudAssessment studAssessment = e.getStudAssessmentById(assessId);
                                                Console.WriteLine("Enter assessment Points :");
                                                float newPoints = float.Parse(Console.ReadLine());
                                                studAssessment.updateAssessmentPoints(newPoints);
                                            }
                                        }
                                        break;
                                    case '4':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        cId = int.Parse(Console.ReadLine());

                                        selectedCourse = findCourse(coursesList, cId);

                                        if (selectedCourse != null)
                                            selectedCourse.displayCourseStudents();
                                        break;
                                } // switch ch2
                            } while (ch2 != '0');
                        } //else
                        break;

                }// switch ch
            } while (ch != '0');

        }
    }
}
