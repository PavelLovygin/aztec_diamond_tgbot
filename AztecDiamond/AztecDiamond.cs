namespace Telegram.Bot.AztecDiamond
{
    public class AztecDiamond
    {
        public char[,] Map { get; private set; }
        private int MapSize;
        public int Rank;
        public static int DefaultRank = 50;

        public AztecDiamond(int rank = 1)
        {
            Rank = 1;
            MapSize = rank * 2;
            Map = GetFilledMap(MapSize, '.');
            GenerateRandomSquare(rank - 1, rank - 1);
            for (int i = 0; i < rank - 1; i++)
                UpDiamondRank();
        }

        public bool IsBlackCell(int row, int column) => (row + column + Rank) % 2 == 0;

        private bool IsRandomDirectionVertical() => new Random().Next(0, 2) == 0;

        private char[,] GetFilledMap(int size, char filledSymbol)
        {
            var newMap = new char[size, size];
            for (int row = 0; row < size; row++)
            for (int column = 0; column < size; column++)
            {
                newMap[row, column] = filledSymbol;
            }

            return newMap;
        }

        protected void GenerateRandomSquare(int row, int column)
        {
            if (IsRandomDirectionVertical())
            {
                Map[row, column] = 'D';
                Map[row, column + 1] = 'D';
                Map[row + 1, column] = 'U';
                Map[row + 1, column + 1] = 'U';
            }
            else
            {
                Map[row, column] = 'R';
                Map[row, column + 1] = 'L';
                Map[row + 1, column] = 'R';
                Map[row + 1, column + 1] = 'L';
            }
        }

        protected bool IsCellInDiamond(int row, int column)
        {
            if (row + column >= -Rank - 1 + MapSize &&
                MapSize - row + column - 1 >= -Rank - 1 + MapSize &&
                MapSize + row - column - 1 >= -Rank - 1 + MapSize &&
                2 * MapSize - row - column - 2 >= -Rank - 1 + MapSize)
                return true;
            return false;
        }

        public void UpDiamondRank()
        {
            DeleteСonflictingDominoes();
            MoveDominoes();
            Rank += 1;
            FillRandomDominoesGaps();
        }

        private void DeleteСonflictingDominoes()
        {
            for (int row = 0; row < MapSize - 1; row++)
            for (int column = 0; column < MapSize - 1; column++)
            {
                if ((Map[row, column] == 'D' && Map[row, column + 1] == 'D' ||
                    Map[row, column] == 'R' && Map[row + 1, column] == 'R') && IsBlackCell(row, column))
                {
                    Map[row, column] = '.';
                    Map[row + 1, column] = '.';
                    Map[row, column + 1] = '.';
                    Map[row + 1, column + 1] = '.';
                }
            }
        }

        private void MoveDominoes()
        {
            var newMap = GetFilledMap(MapSize, '.');

            for (int row = 0; row < MapSize - 1; row++)
            for (int column = 0; column < MapSize - 1; column++)
            {
                if (Map[row, column] == 'R' && IsBlackCell(row, column))
                {
                    newMap[row + 1, column] = 'R';
                    newMap[row + 1, column + 1] = 'L';
                }
                else if (Map[row, column] == 'R' && !IsBlackCell(row, column))
                {
                    newMap[row - 1, column] = 'R';
                    newMap[row - 1, column + 1] = 'L';
                }
                else if (Map[row, column] == 'D' && !IsBlackCell(row, column))
                {
                    newMap[row, column - 1] = 'D';
                    newMap[row + 1, column - 1] = 'U';
                }
                else if (Map[row, column] == 'D' && IsBlackCell(row, column))
                {
                    newMap[row, column + 1] = 'D';
                    newMap[row + 1, column + 1] = 'U';
                }
            }

            Map = newMap;
        }

        private void FillRandomDominoesGaps()
        {
            for (int row = 0; row < MapSize - 1; row++)
            for (int column = 0; column < MapSize - 1; column++)
            {
                if (Map[row, column] != '.' || !IsCellInDiamond(row, column))
                    continue;

                GenerateRandomSquare(row, column);
            }
        }
    }
}
