namespace exercise_1_extract_email_domain_from_string
{
    internal class Program
    {
        //6.	Write a method that extracts the domain from an email address.
        static void Main(string[] args)
        {
            string email = "JoeJoseph@jojo.com";
            int domainIndex = email.IndexOf('@');
            if(domainIndex == -1)
            {
                Console.WriteLine("Invalid Email! Please input your domain.");
                return;
            }

            string emailDomain = email.Substring(domainIndex + 1);
            Console.WriteLine($"Your domain is '{emailDomain}'");
        }
    }
}
