using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Utill
{
    static public class Utills
    {
        static public bool CheckOverlapWithinRange(Vector2 position, float radius)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
            return colliders.Length > 0;
        }
    }
}