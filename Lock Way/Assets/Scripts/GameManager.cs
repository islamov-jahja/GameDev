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

        public string state { get; set; }
        public Stack<GameObject> steps = new Stack<GameObject>();

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
