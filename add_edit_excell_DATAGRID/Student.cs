using System;

public class Student
{
    public string name { get; set; }
    public string mail { get; set; }
    public string fcNumber { get; set; }
    public double grade { get; set; }

    public Student() { }

    public Student(string name, string mail, string fcNumber)
	{
        this.name = name;
        this.mail = mail;
        this.fcNumber = fcNumber;
        this.grade = 0;
	}
}
