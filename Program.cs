namespace Adora;
class Program
{
    public enum Hobby
    {

        Music,

        Football,

        Cars,

        Movies

    }

    abstract public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Made the list of Hobbies nullable due to the fact that the hobbies given are limited and that it is likely that list of Hobbies is not necessary information to have/store if not given. 
        public IEnumerable<Hobby>? Hobbies { get; set; }

        public int StreetNo { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }

        public string State { get; set; }

        protected List<string> Disciplines = new List<string>() { "computer science", "math", "biology", "chemistry", "history", "physics", "english" };

        // Given the access modifier "protected" so that the methods of _emailer and  are only accessible within the child classes
        protected Emailer _emailer;

        // Given the access modifier "protected" so that the _academicYear can be modified only by the setter method of AcademicYear (which exists in the child classes) so that the int passed in is validated
        protected int _academicYear;

        public void GoToParty(string partyName)
        {
            //String interpolation used instead of string concatenation 
            Console.WriteLine($"Went to party at {partyName}");

        }

        //Both children used this method, marked as abstract so it can be overriden by the children since they each use different logic.
        public abstract void EmailExamResult(string discipline, int mark);
    }
    public class FirstYearStudent : Student

    {

        public int AcademicYear
        {
            get => _academicYear;
            set
            {
                if (value < 1 || value > 2)
                    throw new Exception("Academic year for a first year student must be 1 or 2.");
                else
                    _academicYear = value;
            }
        }

        public FirstYearStudent(string firstName, string lastName, string email, DateTime dateOfBirth, IEnumerable<Hobby> hobbies, int streetNo, string streetAddress, string city, int zip, string state, int academicYear = 1)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Hobbies = hobbies;
            StreetNo = streetNo;
            StreetAddress = streetAddress;
            City = city;
            Zip = zip;
            State = state;
            AcademicYear = academicYear;
            _emailer = new Emailer();
        }


        public override void EmailExamResult(string discipline, int mark)
        {
            if (!Disciplines.Contains(discipline.ToLower()))
            {
                throw new Exception("Discipline is not available.");
            }
            if (discipline.ToLower() == "math" && AcademicYear > 1)
            {
                throw new Exception("Only students in Academic Year 1 can take the \"Math\" exam.");
            }
            if (discipline.ToLower() == "computer science" && AcademicYear < 2)
            {
                throw new Exception("Students in their first academic year students cannot take \"Computer science\" exam.");
            }

            // Changed from no-replay@emailer.com to "no-reply@emailer.com" -> made string and spelling correction
            _emailer.CreateAndSendExamResultEmail("no-reply@emailer.com", Email, FirstName, LastName, AcademicYear, discipline, mark);

        }


    }
    public class LastYearStudent : Student

    {

        public int AcademicYear

        {

            get => _academicYear;

            set
            {

                if (value < 3 || value > 5)

                    throw new Exception("Academic year for last year student must be in range of 3 to 5");

                else

                    _academicYear = value;

            }

        }

        public LastYearStudent(string firstName, string lastName, string email, DateTime dateOfBirth, IEnumerable<Hobby> hobbies, int streetNo, string streetAddress, string city, int zip, string state, int academicYear = 3)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Hobbies = hobbies;
            StreetNo = streetNo;
            StreetAddress = streetAddress;
            City = city;
            Zip = zip;
            State = state;
            AcademicYear = academicYear;
            _emailer = new Emailer();
        }

        public override void EmailExamResult(string discipline, int mark)

        {
            if (!Disciplines.Contains(discipline.ToLower()))
            {
                throw new Exception("Discipline is not available.");
            }

            if (discipline.ToLower() == "biology" && AcademicYear != 4)

            {

                throw new Exception("Only 4th year students can take \"Biology\" exam.");

            }



            if (discipline.ToLower() == "math" && AcademicYear != 3)

            {
                // Spelling correction: 3th -> 3rd
                throw new Exception("Only 3rd year students can take \"Math\" exam.");

            }
            // Changed from no-replay@emailer.com to "no-reply@emailer.com" -> made string and spelling correction
            _emailer.CreateAndSendExamResultEmail("no-reply@emailer.com", Email, FirstName, LastName, AcademicYear, discipline, mark);

        }

        public void GoToOpera(string operaName)

        {
            // String interpolation instead of concatenation and changed what was written to the console to a more complete snetence
            Console.WriteLine($"Went to the opera show {operaName}");

        }



    }



    public class Email
    {

        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
    public class Emailer

    {
        public bool CreateAndSendExamResultEmail(string from, string to, string firstName, string lastName, int academicYear, string discipline, int mark)
        {
            //String interpolation used  
            Email email = new Email();
            email.From = from;
            email.To = to;
            email.Subject = $"{firstName} {lastName} exam result for discipline {discipline}";
            email.Body = $"Hi there! Here is the exam result for student {firstName} {lastName}: Discipline: {discipline}, Academic year: {academicYear},  Mark: {mark}";

            return Send(email);
        }

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

    }


    static void Main(string[] args)
    {
        int[] myArray = { 3, 4, 6, 10, 11, 15 };

        int[] toddsArray = { 1, 5, 8, 12, 14, 19 };

        int[] MergeArrays(int[] arrOne, int[] arrTwo)
        {
            int pointerOne = 0;
            int pointerTwo = 0;
            int[] result = new int[arrOne.Length + arrTwo.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (pointerOne >= arrOne.Length)
                {
                    result[i] = arrTwo[pointerTwo++];
                }
                else if (pointerTwo >= arrTwo.Length)
                {
                    result[i] = arrOne[pointerOne++];
                }
                else
                {
                    result[i] = arrOne[pointerOne] < arrTwo[pointerTwo] ? arrOne[pointerOne++] : arrTwo[pointerTwo++];
                }
            }
            return result;
        }



        // Prints [1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19]

        Console.WriteLine($"[{string.Join(", ", MergeArrays(toddsArray, myArray))}]");



        // Problem #2

        FirstYearStudent eric = new FirstYearStudent("Eric", "Bush", "ebush@mail.com", new DateTime(2003, 04, 30), new List<Hobby>() { Hobby.Football, Hobby.Music }, 10, "Rosemary Ct.", "Sacramento", 95678, "CA", 1);

        eric.GoToParty("Chris's wedding");

        eric.EmailExamResult("Math", 4);



        LastYearStudent andrew = new LastYearStudent("Andrew", "Hanna", "ahanna@test.com", new DateTime(2000, 11, 15), new List<Hobby>() { Hobby.Movies, Hobby.Music, Hobby.Cars }, 14, "Helen St.", "Rocklin", 95985, "CA", 5);
        andrew.GoToParty("Chris's wedding");

        andrew.GoToOpera("Othello");

        andrew.EmailExamResult("Biologgy", 4);

        Console.ReadKey();
    }
}