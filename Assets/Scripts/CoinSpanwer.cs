using UnityEngine;

public class CoinSpanwer : Spanwer
{
    void Reset()
    {
        count = 10;
        InitBatchMinMaxTime(1f, 1.5f);
    }
}
