using UnityEngine;

public class CoinSpanwer : Spanwer
{
    void Reset()
    {
        count = 5;
        InitBatchMinMaxTime(2f, 5f);
    }
}
