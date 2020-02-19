using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private MOCK_DATA MOCK_DATA;
    [SerializeField] ScrollView scrollView = default;

    private void Start()
    {
        var items = MOCK_DATA.dataArray
            .Select(i => new ItemData(i))
            .ToArray();
        scrollView.UpdateData(items);
    }
}
