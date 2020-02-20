using UnityEngine;

class ItemData
{

    public MOCK_DATAData data { get; }

    public string HrefContent
    {
        get { return string.Format("<a href={0}>{1}</a>", data.Id, data.Content); }
    }

    public System.Action<string> OnClick;

    public ItemData(MOCK_DATAData data)
    {
        this.data = data;
    }
}
