using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private MOCK_DATA MOCK_DATA;
    [SerializeField] private ScrollRect ItmeScroller;
    [SerializeField] private GameObject ItemBtnPerfab;

    private void Start()
    {
        foreach (var item in MOCK_DATA.dataArray)
        {
            InstantiateItemButton(item);
        }
    }

    private void InstantiateItemButton(MOCK_DATAData data)
    {
        GameObject go = GameObject.Instantiate(ItemBtnPerfab, ItmeScroller.content);
        ItemButton ib = go.GetComponent<ItemButton>();
        ib.SetData(data);
    }
}
