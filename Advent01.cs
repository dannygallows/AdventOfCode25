int result = 50;
int count = 0;

using (var reader = new StreamReader("input.txt"))
{
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
        int number = int.Parse(line[1..]);

        while (number > 99)
        { 
            number -= 100;
            count++;
        }

        if (line[0] == 'L')
        {
            result -= number;
            if (result < 0)
            {
                result += 100;
                count++;
            }
        }
        else
        {
            result += number;
            if (result > 99)
            {
                result -= 100;
                count++;
            }
        }
    }
}
Console.WriteLine(result);
Console.WriteLine(count);