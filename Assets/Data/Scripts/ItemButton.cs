using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private MOCK_DATAData data;
    private Button button;
    private Text text;

    private void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(MOCK_DATAData data)
    {
        this.data = data;
        text.text = this.data.Name;
        button.name = this.data.Name;
    }

    private void OnClick()
    {
        string s = string.Format("<a href={0}>{1}</a>", data.Id, data.Content);
        Debug.Log(s);
    }
}
