namespace MVC1.Models
    {
    public class Fevermodel
        {
       
        public static string grad { get; set; }
        public static string Check()
            {

            if(int.Parse(grad)>=37)
                    return $"Welcome to paradise, you will die and your fever is {grad}";
            else
                return $"You will survive, your feveris {grad}";

        }
    
        }
  
    }
