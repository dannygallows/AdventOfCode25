int res = 0;
string[] lines = File.ReadAllLines("input.txt");
int rowsLength = lines.Length;
int colsLength = lines[0].Length;

char[,] grid = new char[rowsLength, colsLength];

for (int i = 0; i < rowsLength; i++)
{
    for (int j = 0; j < colsLength; j++)
    {
        grid[i, j] = lines[i][j];
    }
}

int[,] directions = new int[,]
{
                {-1, -1}, {-1, 0}, {-1, 1},
                {0, -1},          {0, 1},
                {1, -1}, {1, 0}, {1, 1}
};

rowsLength = grid.GetLength(0);
colsLength = grid.GetLength(1);

bool canForklift = true;

while (canForklift)
{ 
    List<(int, int)> toRemove = new List<(int, int)>();
    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < colsLength; j++)
        {
            if (grid[i, j] == '@')
            {
                int rolls = 0;

                for (int k = 0; k < 8; k++)
                {
                    int row = i + directions[k, 0];
                    int column = j + directions[k, 1];

                    if (row >= 0 && row < rowsLength && column >= 0 && column < colsLength)
                    {
                        if (grid[row, column] == '@')
                        {
                            rolls++;

                        }
                    }
                }

                if (rolls < 4)
                {
                    res++;
                    toRemove.Add((i, j));
                }
            }
        }
    }
    if (toRemove.Count == 0)
    {
        canForklift = false;
    }
    else
    {
        foreach (var (i, j) in toRemove)
        {
            grid[i, j] = 'x';
        }
    }
}
Console.WriteLine(res);