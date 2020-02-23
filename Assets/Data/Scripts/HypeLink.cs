using System.Linq;
using UnityEngine;

public class HypeLink : MonoBehaviour
{
    [SerializeField] private MOCK_DATA MOCK_DATA;
    [SerializeField] private ScrollView scrollView = default;
    [SerializeField] private LinkText.LinkText LinkText;

    private void Start()
    {
        LinkText.OnHrefClick.AddListener(HypesContent);
        var items = MOCK_DATA.dataArray
            .Select(i => new ItemData(i) { OnClick = OnItemBoxClick })
            .ToArray();
        scrollView.UpdateData(items);
    }

    public void OnItemBoxClick(MOCK_DATAData data)
    {
        LinkText.text += "Name: " + HrefName(data) + ".\n";

    }

    private string HrefName(MOCK_DATAData data)
    {
        return string.Format("<a href={0}>{1}</a>", data.Id, data.Name);
    }

    private void HypesContent(string hypeId)
    {
        int id;
        if (int.TryParse(hypeId, out id))
        {
            var data = MOCK_DATA.dataArray.FirstOrDefault(o => o.Id == id);
            Debug.Log(string.Format("Name: <color=red>{0}</color>, Content: <color=blue>{1}</color>.", data.Name, data.Content));
        }
    }
}
