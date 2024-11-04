using TekkenTracker.Core.Repository;

internal class Program
{
    private const string HelpCommand = """ 
Usage:
  stats add win                Adds a win for today.
  stats add lose               Adds a loss for today.
  stats show                   Displays today's stats in the format: Wins/Losses (e.g., 5W/3L).
  stats show --week            Displays stats for the past 7 days.

Commands:
  add <type>                   Adds a win or a loss to today's stats.
                               <type> should be either 'win' or 'lose'.
  
  show                         Displays stats.
                               By default, shows stats for today. Use --week for weekly stats.

Options:
  --help                       Displays this help message.

Examples:
  stats add win                Adds one win to today's stats.
  stats add lose               Adds one loss to today's stats.
  stats show                   Shows today's stats, e.g., 5W/3L.
  stats show --week            Shows the stats for the last 7 days.
  
Description:
  This program allows you to track wins and losses daily. Use the 'add' command to add a win or loss for the day, 
  and the 'show' command to view your current stats, either for today or for the past week.


""";

    private static readonly IMatchRepository _repo = new JsonMatchRepository();
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine(HelpCommand);
            return;
        }
        string command = args[0].Trim().ToLower();
        switch (command)
        {
            case "add":
                Console.WriteLine("It is add");
                HandleAdd(args[1..]);
                break;
            case "show":
                Console.WriteLine("It is show");
                break;
            default:
                Console.WriteLine(HelpCommand);
                break;
        }


    }

    static private void HandleAdd(string[] args)
    {
        string cmd = args[0].Trim().ToLower();
        if (!cmd.Equals("win") && !cmd.Equals("lose"))
        {
            Console.WriteLine("Usage: add <win/lose> - adds a win or lose for today.");
            return;
        }
        switch (cmd)
        {
            case "win":
                _repo.AddMatch(true);
                break;
            case "lose":
                _repo.AddMatch(false);
                break;
        }
    }

    static private void HandleShow()
    {

    }
}