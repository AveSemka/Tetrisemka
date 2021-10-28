using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tetrisemka
{
    public class Block
    {
        public Point[] Map;
        public Brush Color;
        public Block(Point[] map, Brush color)
        {
            Map = map;
            Color = color;
        }

        public static Dictionary<BlockType, Block> Blocks = new Dictionary<BlockType, Block>();
        public static void GenerateBlocks()
        {
            Dictionary<BlockType, Block> keys = new Dictionary<BlockType, Block>();
            keys.Add(BlockType.I, new Block(new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(0, 2),
                        new Point(0, -1)
                    }, Brushes.Blue));
            keys.Add(BlockType.O, new Block(new Point[]
                    {
                        new Point(0, 0),
                        new Point(1, 0),
                        new Point(1, 1),
                        new Point(0, 1)
                    }, Brushes.Red));

            Blocks = keys;


                /*
                case 1: //Палка
                    Color = Brushes.Blue;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(0, 2),
                        new Point(0, -1)
                    };

                case 2: //Треугольник
                    Color = Brushes.Yellow;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(1, 0),
                        new Point(0, -1)
                    };

                case 3: //Зигзаг
                    Color = Brushes.Black;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, -1),
                        new Point(1, 0),
                        new Point(1, 1)
                    };

                case 4: //Обратный зигзаг
                    Color = Brushes.Green;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(1, 0),
                        new Point(1, -1),
                        new Point(0, 1)
                    };

                case 5: //Уголочек
                    Color = Brushes.Violet;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, -1),
                        new Point(0, 1),
                        new Point(1, 1)
                    };

                case 6: //Обратный уголочек
                    Color = Brushes.Orange;
                    return new Point[]
                    {
                        new Point(0, 0),
                        new Point(0, -1),
                        new Point(0, 1),
                        new Point(-1, 1)
                    };

                default:
                    return null;
            }*/

        }
    }
}
