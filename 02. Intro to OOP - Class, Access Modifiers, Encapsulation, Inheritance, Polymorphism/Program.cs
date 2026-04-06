using System;

// ------------------------------ 1. Class ------------------------------
// OOP - Object Oriented Programming
// Student management system
// Student - Name, Age, Roll, Marks, Courses -> Properties
// Student - Registration, AttendClass, SubmitAssignment -> Methods/ Funtionality

// ----------------------------- 2. Access Modifires ------------------------------
// public
// private
// protected

// ------------------------------ 4. Authentication ------------------------------
public class Auth{
  public bool IsAuthenticated(){
    return true;
  }
}

public class Student {
  private string name;
  private int age;

  Auth auth = new Auth();
  

  // Constructor
  // public Student( string nameP, int ageP ){
  //   name = nameP;
  //   age = ageP;
  // }

  // public Student( string name, int age ){
  //   this.name = name;
  //   this.age = age;
  // }

  // -------------------------- 3. Encapsulation --------------------------
  // setter
  // getter
  public void SetName(string name) {
    if(auth.IsAuthenticated()){
      this.name = name;
    }
    else {
      Console.WriteLine("You are not authenticated");
    }
  }

  public string GetName(){
    return this.name;
  }

  public void SetAge(int age){
    if(auth.IsAuthenticated()){
      this.age = age;
    }
    else {
      Console.WriteLine("You are not authenticated");
    }
  }
  public int GetAge(){
    return this.age;
  }

  public void ShowInfo() {
      Console.WriteLine("Name : {0}, Age : {1}", name, age);
  }
}

// ------------------------------ 5. Inheritance ------------------------------
public class Std{
  public string name;
  private int age;

  public Std(string name, int age){
    this.name = name;
    this.age = age;
  }
  public void ShowInfo(){
    Console.WriteLine("Name : {0}, Age : {1}", name, age);
  }
}

public class JIStudent : Std {      // extends Std (inherit Std class)
    
  public JIStudent(string name, int age) : base(name, age){ }
  
  public void Givequiz(){
     Console.WriteLine("Give quiz");
  } 
}

public class CPStudent : Std {     // extends Std (inherit Std class)
    public CPStudent(string name, int age) : base(name, age){ }
  public void Contest(){
     Console.WriteLine("Give contest");
  }
}

// ---------------- 6.1 Polymorphism / Compile Time Polymorphism ------------------
public class JIPCourse{
  // public void QuizWithTime(int startTime, int endTime, int duration){
  //   Console.WriteLine("Quiz with time");
  // }

  // public void QuizForPractice(){
  //   Console.WriteLine("Quiz For Practice");
  // }

  // public void QuizForPreparation(int duration){
  //   Console.WriteLine("Quiz For Preparation");
  // }

  // method/function overloading
  public void Quiz(){
    Console.WriteLine("Quiz For Practice");
  }

  public void Quiz(int duration){
    Console.WriteLine("Quiz For Preparation");
  }
  public void Quiz(int startTime, int endTime, int duration){
    Console.WriteLine("Quiz with time");
  }
}

// ---------------- 6.1 Polymorphism / Run Time Polymorphism ------------------
public class Course {
  public string Title;
  public string Description;

  public void ShowInfo(){
    Console.WriteLine("Title : {0}, Description : {1}", Title, Description);
  }
  
  public virtual void Quiz(){
    Console.WriteLine("Quiz score ");
  }
}
// overriding
public class ProCourse : Course {
  public override void Quiz(){
    int start = 10;
    int end = 50;
    Console.WriteLine("Quiz start : {0}, end : {1}", start, end);
  }
}

class Program
{
  public static void Main()
  {
      // Student student = new Student();
      // student.name = "John Doe";
      // student.age = 20;
      // student.ShowInfo();

      // Student student2 = new Student("Tom", 21);
      // student2.ShowInfo();

    // Student student3 = new Student();
    // student3.SetName("Lily");
    // student3.SetAge(22);

    // Console.WriteLine("Name : {0}, Age : {1}", student3.GetName(), student3.GetAge());

    // JIStudent std = new JIStudent();
    // std.name = "Kalu";
    // std.age = 20;

    // JIStudent jiStd = new JIStudent("Kalu", 20);
    // jiStd.ShowInfo();
    // jiStd.Givequiz();

    // JIPCourse jipc = new JIPCourse();
    // jipc.Quiz();
    // jipc.Quiz(10);
    // jipc.Quiz(10, 30, 20);

    Course course = new Course();
  
    course.Title = "C#";
    course.Description = "C# is a programming language";
    course.Quiz();
    course.ShowInfo();
  }
}


