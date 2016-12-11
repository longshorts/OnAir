using UnityEngine;

namespace Utility
{
    public class Persistant : MonoBehaviour
    {

        public static Persistant i;

        void Awake()
        {
            if (!i)
            {
                i = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
