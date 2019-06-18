using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assets.scripts
{
    class GameManager
    {
        private GameManager()
        {
            try{
                StreamReader fileWithData = new StreamReader("./userData.txt");
                while(!fileWithData.EndOfStream)
                {
                    levelsAndRatings.Add(fileWithData.ReadLine());
                }
                fileWithData.Close();
            }catch(Exception e)
            {
                levelsAndRatings.Add("1*0-54:6:");
                levelsAndRatings.Add("2*0-50:7:");
                levelsAndRatings.Add("3*0-38:1:");
            }
        }

        public int[] results;
        private static object _sync = new object();

        private static volatile GameManager _instance;

        public int minutesResult;

        public int secondsResult;

        public List<String> levelsAndRatings = new List<String>();

        public int level;

        public int lastLevel = 6;

        public int state { get; set; }

        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_sync)
                {
                    if (_instance == null)
                    {
                        _instance = new GameManager();
                    }
                }
            }

            return _instance;
        }
    }
}
