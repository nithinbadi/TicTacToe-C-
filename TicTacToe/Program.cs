// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;

int i = 0;
bool resetBoard = true;
char[] newArray = new char[9];
while (true)
{
    char[] reset = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    Console.Clear();
    if (resetBoard)
    {
        newArray = reset;
        resetBoard = false;
    }
    DisplayBoard(newArray);
    char pl = ' ';
    int pos = -1;
    bool invalid;
    do
    {
        invalid = false;
        Console.WriteLine("Player {0}: Choose a position - ", (i) % 2);
        try
        {
            pos = int.Parse(Console.ReadLine());
            pl = newArray[pos - 1];

        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid response, Please try again");
            invalid = true;
        }
    } while (pl == 'X' || pl == 'O' || invalid);
    newArray[pos - 1] = i % 2 != 0 ? 'O' : 'X';
    i++;
    char winner = CheckWinner(newArray);
    if(winner == ' ')
    {
        continue;
    }
    else
    {
        Console.Clear();
        DisplayBoard(newArray);
        Console.WriteLine("Player {0} has won",winner);
        Console.WriteLine("Would you like to reset? Press q to exit. Press r to reset");
        char r = (char)Console.Read();
        if (Char.ToLower(r) == 'r') resetBoard = true;
        else break;
    }
}

static void DisplayBoard(char[] reset)
{
    Console.WriteLine("   |   |   ");
    Console.WriteLine(" "+ reset[0] + " | " + reset[1] + " | "+ reset[2] + " ");
    Console.WriteLine("___|___|___");
    Console.WriteLine(" " + reset[3] + " | " + reset[4] + " | " + reset[5] + " ");
    Console.WriteLine("___|___|___");
    Console.WriteLine(" " + reset[6] + " | " + reset[7] + " | " + reset[8] + " ");
    Console.WriteLine("   |   |   ");


}


static char CheckWinner(char[] board)
{

    bool rowO1 = (board[0] == 'O' && board[1] == 'O' && board[2] == 'O');
    bool rowO2 = (board[3] == 'O' && board[4] == 'O' && board[5] == 'O');
    bool rowO3 = (board[6] == 'O' && board[7] == 'O' && board[8] == 'O');
    if (rowO1 || rowO2 || rowO3) return 'O';

    bool colO1 = (board[0] == 'O' && board[3] == 'O' && board[6] == 'O');
    bool colO2 = (board[1] == 'O' && board[4] == 'O' && board[7] == 'O');
    bool colO3 = (board[3] == 'O' && board[5] == 'O' && board[8] == 'O');
    if (colO1 || colO2 || colO3) return 'O';

    bool diagO1 = (board[0] == 'O' && board[4] == 'O' && board[8] == 'O');
    bool diagO2 = (board[2] == 'O' && board[4] == 'O' && board[6] == 'O');
    if (diagO1 || diagO2) return 'O';

    bool rowX1 = (board[0] == 'X' && board[1] == 'X' && board[2] == 'X');
    bool rowX2 = (board[3] == 'X' && board[4] == 'X' && board[5] == 'X');
    bool rowX3 = (board[6] == 'X' && board[7] == 'X' && board[8] == 'X');
    if (rowX1 || rowX2 || rowX3) return 'X';

    bool colX1 = (board[0] == 'X' && board[3] == 'X' && board[6] == 'X');
    bool colX2 = (board[1] == 'X' && board[4] == 'X' && board[7] == 'X');
    bool colX3 = (board[3] == 'X' && board[5] == 'X' && board[8] == 'X');
    if (colX1 || colX2 || colX3) return 'X';

    bool diagX1 = (board[0] == 'X' && board[4] == 'X' && board[8] == 'X');
    bool diagX2 = (board[2] == 'X' && board[4] == 'X' && board[6] == 'X');
    if (diagX1 || diagX2) return 'X';
    return ' ';
}
