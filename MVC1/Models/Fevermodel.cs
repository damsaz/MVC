namespace MVC1.Models
    {
    public class Fevermodel
        {

        public static string Degrees { get; set; }
        public static string Check()
            {
            string message="";
            switch (int.Parse(Degrees))
                {
                case <37:
                    message= $"You do,t have fever, your temperature is {Degrees}";
                    break;
                case > 37:
                    message = $"You have fever, your temperature is {Degrees}";
                    break;


                }
            return message; 
            }

        }

    }
