using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tetrisemka
{
    public class GameField
    {
        public WriteableBitmap FieldBase;
        private Point CurrentPosition = new Point(5, 0);
        private byte[] color = { 150, 160, 80, 255 };
        public byte[,] Map = new byte[0, 0];
        public BlockType CurrentBlock = BlockType.None;


        public void Create()
        {
            Map = new byte[10, 20];
            FieldBase = new WriteableBitmap(Map.GetLength(0), Map.GetLength(1), 96, 96, PixelFormats.Pbgra32, null);

            /*for (int i = 0; i < Map.GetLength(0); i++)
            {
                Map[i, Map.GetLength(1) - 1] = 1;
                FieldBase.WritePixels(new Int32Rect(i, Map.GetLength(1) - 1, 1, 1), color, 4, 0);
            }*/
            
        }

        public WriteableBitmap GetMap() 
        {
            return FieldBase;
        }

        public WriteableBitmap Calc()
        {
            if (CurrentBlock == BlockType.None)
            {
                CurrentBlock = BlockType.I;
            }
            if (CheckCollision())
            {
                FieldBase.WritePixels(new Int32Rect((int)CurrentPosition.X, (int)CurrentPosition.Y, 1, 1), color, 4, 0);
                FieldBase.WritePixels(new Int32Rect((int)CurrentPosition.X, (int)CurrentPosition.Y, 1, 1), color, 4, 0);
                return FieldBase;
            }
            else
            {
                var map = FieldBase.Clone();
                CurrentPosition.Y += 1;
                map.WritePixels(new Int32Rect((int)CurrentPosition.X, (int)CurrentPosition.Y, 1, 1), color, 4, 0);
                map.WritePixels(new Int32Rect((int)CurrentPosition.X, (int)CurrentPosition.Y, 1, 1), color, 4, 0);
                return map;
            }
            /*if (x == 9)
            {
                y++;
                x = 0;
                _gameBoardBase = _gameBoard;
            }
            WriteableBitmap bitmap = _gameBoardBase.Clone();
            byte[] color = { 150, 160, 80, 255 };
            bitmap.WritePixels(new Int32Rect(x, y + 1, 1, 1), color, 4, 0);
            bitmap.WritePixels(new Int32Rect(x + 1, y, 1, 1), color, 4, 0);
            bitmap.WritePixels(new Int32Rect(x, y, 1, 1), color, 4, 0);
            bitmap.WritePixels(new Int32Rect(x + 3, y, 1, 1), color, 4, 0);
            GameBoard = bitmap;
            i++;*/
        }

        public bool CheckCollision()
        {
            var offsetPoint = CurrentPosition;
            offsetPoint.Offset(0, 0);
            if (offsetPoint.Y == Map.GetLength(1) - 1)
            {
                return true;
            }
            if (Map[(int)offsetPoint.X, (int)offsetPoint.Y + 1] == 1)
            {
                return true;
            }
            return false;
            
        }

        public WriteableBitmap Draw()
        {
            return null;
        }
    }
}
