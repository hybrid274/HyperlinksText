using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataBase : MonoBehaviour
{
    [SerializeField] private MOCK_DATA MOCK_DATA;
    [SerializeField] private ScrollView scrollView = default;
    [SerializeField] private InputField InputField;
    [SerializeField] private LinkText.LinkText LinkText;
    [SerializeField] private string enterStr;

    private void Start()
    {
        var items = MOCK_DATA.dataArray
            .Select(i => new ItemData(i) { OnClick = OnItemBoxClick })
            .ToArray();
        scrollView.UpdateData(items);
    }
 
    public void OnInputField(string str)
    {
        Debug.Log(str);
        enterStr = str;
    }

    public void OnItemBoxClick(string itemhref)
    {
        InputField.text += itemhref;
    }

}
