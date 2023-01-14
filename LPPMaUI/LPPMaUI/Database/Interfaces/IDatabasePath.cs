using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Database.Interfaces
{
    public interface IDatabasePath
    {
        string GetDatabasePath(string filename = "lpp.db");
        void DeleteFile(string path);
    }
}
