using System.Drawing;

namespace Telegram.Bot.AztecDiamond
{
    public static class AztecDiamondDrawer
    {
        public static void Draw(AztecDiamond diamond, string fileName)
        {

            int bitMapSize = 1000;
            Bitmap bitmap = new Bitmap(bitMapSize, bitMapSize);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.White,  new Rectangle(0, 0, bitMapSize, bitMapSize));
            int cellWidth = bitMapSize / (diamond.Rank * 2);
            for (int i = 0; i < diamond.Rank * 2; i++)
            {
                for (int j = 0; j < diamond.Rank * 2; j++)
                {
                    if (!diamond.IsBlackCell(i, j))
                    {
                        if (diamond.Map[i, j] == 'D')
                            graphics.FillRectangle(Brushes.Yellow,
                                new Rectangle(i * cellWidth, j * cellWidth, cellWidth * 2, cellWidth));
                        if (diamond.Map[i, j] == 'R')
                            graphics.FillRectangle(Brushes.Red,
                                new Rectangle(i * cellWidth, j * cellWidth, cellWidth, cellWidth * 2));
                    }
                    else
                    {
                        if (diamond.Map[i, j] == 'D')
                            graphics.FillRectangle(Brushes.Blue,
                                new Rectangle(i * cellWidth, j * cellWidth, cellWidth * 2, cellWidth));
                        if (diamond.Map[i, j] == 'R')
                            graphics.FillRectangle(Brushes.Green,
                                new Rectangle(i * cellWidth, j * cellWidth, cellWidth, cellWidth * 2));
                    }
                }
            }

            bitmap.Save(fileName);

        }
    }
}
