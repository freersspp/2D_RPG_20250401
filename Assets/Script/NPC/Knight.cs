using UnityEngine;
namespace PPman
{

    public class Knight : NPC
    {
        private static Knight _instance;
        public static Knight Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Knight>();
                }
                return _instance;

            }
        }

    }
}