using UnityEngine;

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

    public class TimeInterval
    {
        public float lastTime = 0f;
        public float timeInterval = 0f;

        public TimeInterval(float timeInterval = 0f) {
            this.timeInterval = timeInterval;
        }
        public bool IsExceedTimeInterval()
        {
            return Time.time >= lastTime + timeInterval;
        }

    }
}