using System;

class ItemData
{
    public MOCK_DATAData data { get; }
    public Action<MOCK_DATAData> OnClick;

    public ItemData(MOCK_DATAData data)
    {
        this.data = data;
    }
}
