using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{


    class BlockSpawner
    {
        public void SpawnTetromino(Game game)
        {
            Random r = new Random();
            Array values = Enum.GetValues(typeof(Tetromino));
            Tetromino newBlock = (Tetromino)values.GetValue(r.Next(values.Length - 1) + 1);
        }

    }
}
