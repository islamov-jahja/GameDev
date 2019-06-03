using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class GameManager
    {
        private static object _sync = new object();

        private static volatile GameManager _instance;

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
