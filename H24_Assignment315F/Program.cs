
using H24_Assignment315F;

const int blankSquare = 0;
int[] numbers = [blankSquare, 1, 3, 4, 2, 5, 7, 8, 6];
int[] solution = [1, 2, 3, 4, 5, 6, 7, 8, blankSquare];

while (true)
{
    PrintBoard();
    Console.Write("Hvor vil du flytte? ");
    var moveInput = Console.ReadLine();

    if (!Enum.TryParse(moveInput, out MoveDirection moveDirection))
    {
        Console.WriteLine("Ugyldig valg. Gyldige valg er: Up / Down / Left / Right");
        continue;
    }
    
    var currentEmptyIndex = numbers.Index().FirstOrDefault(x => x.Item == blankSquare).Index;
    int moveToIndex;
    switch (moveDirection)
    {
        case MoveDirection.Up:
            moveToIndex = currentEmptyIndex - 3;
            break;
        case MoveDirection.Down:
            moveToIndex = currentEmptyIndex + 3;
            break;
        case MoveDirection.Left:
            moveToIndex = currentEmptyIndex - 1;
            break;
        case MoveDirection.Right:
            moveToIndex = currentEmptyIndex + 1;
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    if (!IsValidMove(currentEmptyIndex, moveToIndex))
    {
        Console.WriteLine("Ugyldig trekk. Prøv igjen");
        continue;
    }

    numbers[currentEmptyIndex] = numbers[moveToIndex];
    numbers[moveToIndex] = blankSquare;

    if (IsGameCompleted())
    {
        Console.WriteLine("You did it!");
        PrintBoard();
        break;
    }
}

bool IsGameCompleted()
{
    return numbers.SequenceEqual(solution);
}

bool IsValidMove(int currentEmptyIndex, int moveToIndex)
{
    if (moveToIndex < 0)
    {
        return false;
    }

    if (moveToIndex >= numbers.Length)
    {
        return false;
    }

    if (currentEmptyIndex == 3 && moveToIndex == 2)
    {
        return false;
    }

    if (currentEmptyIndex == 6 && moveToIndex == 5)
    {
        return false;
    }

    if (currentEmptyIndex == 5 && moveToIndex == 6)
    {
        return false;
    }

    if (currentEmptyIndex == 2 && moveToIndex == 3)
    {
        return false;
    }

    return true;
}
void PrintBoard()
{
    var count = 0;
    Console.WriteLine(" -----------");
    foreach (var number in numbers)
    {
        if (count != 0 && count % 3 == 0)
        {
            Console.WriteLine("|");
        }
        if (number == blankSquare)
        {
            Console.Write("|   ");
        }
        else
        {
            Console.Write($"| {number} ");
        }

        count++;
    }
    Console.WriteLine("|");
    Console.WriteLine(" -----------");
}