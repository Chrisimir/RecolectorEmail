using System;
using System.Collections.Generic;

namespace RecolectorEmail
{
    static class MainRE
    {
        [STAThread]
        static void Main()
        {
            HistoryData.LoadLastUpdate();
            HistoryData.LoadBlacklist();
            GUI.Start();
        }
    }
}