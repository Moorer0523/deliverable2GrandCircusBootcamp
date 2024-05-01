class CoinFlipGame
{
    //generates a random seed each time to prevent repeat patterns
    readonly Random flip = new(Guid.NewGuid().GetHashCode());

    public string[] entryQuestions() //Captures user's name and if they agree or not.
    {
        string[] userInfo;

        Console.WriteLine("Welcome to the COIN FLIP CHALLENGE! To start, please enter your name.");
        string userName = Console.ReadLine();

        Console.WriteLine("Are you interested in playing " + userName + "? Y/N");
        string userAnswer = Console.ReadLine();

        //attempted to use Try-Catch but still don't fully understand it.

        if (userName != null && userAnswer != null) //Check if user answers exists
        {
            if (userAnswer.ToLower().Contains("n") && !userAnswer.ToLower().Contains("y"))
            {
                Console.WriteLine("You are a coward " + userName);
                System.Environment.Exit(0);
                throw new Exception(); //This exception exists to satisify compiler requirements.

            }
            else if (userAnswer.ToLower().Contains("y") && !userAnswer.ToLower().Contains("n"))
            {
                userInfo = [userName, userAnswer];
                return userInfo;
            }
            else
            {
                Console.WriteLine("There was an error with one of your answers, please try again.");
                entryQuestions();
                throw new Exception(); //This exception exists to satisfy complier requirements.
            }
        }
        else
        {
            Console.WriteLine("There was an error with one of your answers, please try again.");
            entryQuestions();
            throw new Exception(); //This exception exists to satisfy complier requirements.
        }
    }
    public int coinFlipRound(string userName, int currentRound) //Primary method used for running each round
    {

        int userValue = 0;
        int score = 0;
        int flippedValue = flip.Next(2);

        Console.WriteLine("Round " + (currentRound+1) + " START! Flipping complete...  " + userName + ", choose heads or tails:");
        string userInput = Console.ReadLine();
        if (userInput.ToLower().Contains("h") && !userInput.ToLower().Contains("t"))
        {
            userValue = 0;
        }
        else if (userInput.ToLower().Contains("t") && !userInput.ToLower().Contains("h"))
        {
            userValue = 1; 
        }
        else //alternate exit criteria until better else statement is debugged
        {
            Console.WriteLine("There was an error processing your request. Please launch the game again.");
            System.Environment.Exit(0);
        }

        //Else statement captures prior inputs and stores it for later use. Need further debug so commenting out recursion. 
        //else
        //{
        //    Console.WriteLine("There was an error with understanding your guess, please try again.");
        //    coinFlipRound(userName, currentRound);
        //}

        Console.WriteLine("Your guess was :" + userInput + "...");
        if (flippedValue == userValue)
        {
            Console.WriteLine("This is correct!");
            score = 1;
            //Console.WriteLine(flippedValue);
            return score;
        }
        else
        {
            Console.WriteLine("This is incorrect");
            score = 0;
            //Console.WriteLine(flippedValue);
            return score;
        }

    }
    static void Main()
    {
        Console.WriteLine("Starting Program");

        CoinFlipGame user = new CoinFlipGame();
        int maxRound = 5;
        int[] score = new int [maxRound];

        string[] entryAnswers = user.entryQuestions();


        //Prints the entryAnswers array to ensure valid answers.
        //for (int i = 0; i < entryAnswers.Length; i++)
        //{
        //    Console.WriteLine(entryAnswers[i]);
        //}

        Console.WriteLine("The rules of the game are simple. I'll flip a coin and you have to guess if the answer is 'heads' or 'tails'.");

        //starts the coin flip rounds
        for (int currentRound = 0; currentRound < maxRound; currentRound++)
        {

            score[currentRound] = user.coinFlipRound(entryAnswers[0], currentRound);
            Console.WriteLine("Current score: " + score.Sum());
        }

        Console.WriteLine("Thank you for playing! Your total score was: " + score.Sum() + ". Your score for each round is:");
        for (int i=0; i < score.Length; i++) { Console.WriteLine("Round "+(i+1)+": "+score[i]); }

        Console.WriteLine("Please restart the game to try again.");

    }
}