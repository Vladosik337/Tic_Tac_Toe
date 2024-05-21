using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Models
{
    public interface IPlayer
    {
        string Name { get; set; }
        char Symbol { get; set; }
        int GetMove();
    }
}