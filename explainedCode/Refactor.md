# Adora Refactor
- I will explain class by class which changes I made and why they were made
- Smaller changes will be noted as comments in the code

## **``public enum Hobby``**
- No changes made

## **``public Class Email``**
- No changes
- Did not create a constructor for readability when used and instantiated in ``Emailer`` class

## **``public Class Emailer``**
- Moved and added logic to the ``Send(Email email)`` method and decided to return ``Send(email)`` for the ``CreateAndSendExamResultEmail`` method. 
    - This was done because ``Send(email)`` returns a ``bool`` thus it made sense to return ``Send`` because the value return of ``CreateAndSendExamResultEmail`` was the same and dependent on the value return of ``Send``
- Changed ``int rInt = rand.Next(0, 2);`` to ``int rInt = rand.Next(1, 3)`` to eliminate dividing by 0 which resulted in an error. 
```csharp
//method in Emailer class
public bool Send(Email email)
{
    Random rand = new Random();
    int rInt = rand.Next(1, 3);
    if (1 / rInt == 1)
    {
        Console.WriteLine("Email sent successfully.");
        Console.WriteLine(email.Body);
        return true;
    }
    else
    {
        Console.WriteLine("Email failed to send.");
        return false;
    }
}
```
- The changes above were made to be more explicit. Originally the content of email was sent to the console regardless of whether the condition ``1 / rInt == 1`` was met. This was confusing, so I changed it display "Email was sent successfully" and to display the email content if the conditions were met. If they weren't, then I had it log to the console "Email failed to send" and did not display email content. 

## **``public Class FirstYearStudent`` | ``public Class LastYearStudent``**
- The first change I made was I created a ``abstract`` parent class called ``Student``.
    - I made the ``Student`` class abstract because I did not want instances of student to be created. If a student is to be made, given the information I was given, I thought it was important to specificy whether they were a first year student or last year student.
    - Interface vs. abstract class
        - I chose to used an abstract class in order to have the ability to use access modifers and have logic within methods that we're accessible the children. 
    - All fields except for ``AcademicYear`` we're moved to the parent class since the FirstYearStudent and LastYearStudent classes shared those fields. 
        - ``AcademicYear`` was defined in the child class in order to have a unique setter method that validated whether the Academic Year fit the qualifications for a first year or last year student. 
- The ``Student`` class has the constructor injection, ``Emailer``. This was used so we did not have to create an instance of ``Emailer`` if we were to add other methods within the student classes that needed ``Emailer``.
- Created a field ``List<string> Disciplines`` in the ``Student`` class. This is used in children classes to validate inputs given in case that a discipline is input that is were not valid due to a spelling error, a course that was not given a the institution, and to limit what can be input to the method. Shown below:
```csharp
// field in parent class Student
protected List<string> DisciplinesOptions = new List<string>() {"computer science", "math", "biology", "chemistry", "history", "physics", "english"};

// Example of Discplines being used in child class method 
public override void EmailExamResult(string discipline, int mark)
{
    if (!DisciplinesOptions.Contains(discipline.ToLower()))
    {
        throw new Exception("Discipline is not available.");
    }
// rest of code...
}
```
- I created a constructor for each child class.
    - This was done with scalability in mind.
    - The constructor ensures that all fields of the instance are met as well as limiting lines of code used. If we we're to add thousands of students, the amount of code generated without using a constructor would be lengthy
- ``EmailExamResult`` method in both ``FirstYearStudent`` and ``LastYearStudent``
    - ``discipline.ToLower()`` was added to for accurate comparisons that is not dependent on casing. 

- ``FirstYearStudent`` class:
    - Added validations to ``public int AcademicYear``
    - Done to limit the range between 1 and 2 since LastYearStudent ranged from 3 to 5.
    - Made it possible for a first year student to be an Academic Year 2 due to the possibility of a high school student having AP credits that make them academically a year 2 student. 


