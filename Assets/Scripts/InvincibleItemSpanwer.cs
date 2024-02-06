using UnityEngine;
using UnityEngine.UI;

public class InvincibleItemSpanwer : Spanwer
{

    [HideInInspector]
    public bool isUsingItem = false;
    [HideInInspector]
    public Image uiImage;
    public float FirstBatchTime;
    private void Reset()
    {
        count = 1;
        FirstBatchTime = 8f;
        InitBatchMinMaxTime(10f, 15f);
    }
   

    void Start()
    {
        Init();
        uiImage = GameObject.Find("Canvas").transform.Find("InvincibleItemUI").GetComponent<Image>();
        batchInterval.timeInterval = FirstBatchTime;
    }
    void Update()
    {
        if (GameManager.Instance.IsGameover || isUsingItem) return;

        if (!IsEnableBatch()) return;

        BatchPrefab(GetRandomPositoin());
    }

    public void HideAllItems()
    {
        foreach(var item in prefabs)
        {
            item.SetActive(false);
        }
    }
}
