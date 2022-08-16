namespace MVC1.Models
    {
    public class Fevermodel
        {

        public static string Degrees { get; set; }
        public static string Check()
            {

            if (int.Parse(Degrees) >= 37)
                return $"Welcome to paradise, you will die and your fever is {Degrees}";
            else
                return $"You will survive, your feveris {Degrees}";

            }

        }

    }
