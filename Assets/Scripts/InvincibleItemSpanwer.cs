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
        count = 3;
        InitBatchMinMaxTime(2f, 3f);
    }
   

    void Start()
    {
        Init();
        uiImage = GameObject.Find("Canvas").transform.Find("InvincibleItemUI").GetComponent<Image>();
        batchInterval.timeInterval = FirstBatchTime;
    }
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover || isUsingItem) return;

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
