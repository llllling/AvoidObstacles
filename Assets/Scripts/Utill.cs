using UnityEngine;

namespace Utill
{
   static public class Utills
    {
        static public bool CheckForObjectAtPoint(Vector2 point)
        {
            Collider2D collider = Physics2D.OverlapPoint(point);

            return (collider != null);
        }
    }
}