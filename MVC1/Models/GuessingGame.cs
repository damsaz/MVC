namespace MVC1.Models
    {
    public class GuessingGame
        {
        public static int GuessNummer;
        public static bool GameOver { get; internal set; }
        public static int Count { get; internal set; }
        public static string Message { get; private set; }

        internal static int GenerateNumber()
            {
            GameOver = false;
            Count = 0;  
            Random random = new Random();
            return random.Next(1, 100);
            }

        internal static string Game(string playerGuess)
            {
            int ifcase = 0;
            try { 
             ifcase = int.Parse(playerGuess);
                if (ifcase < GuessNummer)
                    Message = "Your guess was too small, enter a bigger number";
                else if (ifcase > GuessNummer)
                    Message = "Your guess was too big, enter a smaller number";
                else
                    {
                    Message = "Well done. Your guess was right. The game started again!!";
                    GameOver = true;
                    }
                }
            catch {
                Message = "Invalid input";
                }   
     
            

            return Message;
            }
        }
    }
