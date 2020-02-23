using System.Linq;
using UnityEngine;

public class HypeLink : MonoBehaviour
{
    [SerializeField] private MOCK_DATA MOCK_DATA;
    [SerializeField] private ScrollView scrollView = default;
    [SerializeField] private LinkText.LinkText LinkText;

    private void Start()
    {
        var items = MOCK_DATA.dataArray
            .Select(i => new ItemData(i) { OnClick = OnItemBoxClick })
            .ToArray();
        scrollView.UpdateData(items);
    }

    public void OnItemBoxClick(MOCK_DATAData data)
    {
        LinkText.text += "Name: " + data.Content + ". Content: " + HrefContent(data) + ".\n";

    }

    private string HrefContent(MOCK_DATAData data)
    {
        return string.Format("<a href={0}>{1}</a>", data.Id, data.Content);
    }
}
