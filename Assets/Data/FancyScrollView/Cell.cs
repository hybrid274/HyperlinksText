using FancyScrollView;
using UnityEngine;
using UnityEngine.UI;

class Cell : FancyCell<ItemData>
{
    [SerializeField] Animator animator = default;
    [SerializeField] Text TextName = default;
    [SerializeField] Button Button;
    ItemData Data;

    static class AnimatorHash
    {
        public static readonly int Scroll = Animator.StringToHash("Cell");
    }

    private void Start()
    {
        Button.onClick.AddListener(OnClick);
    }

    public override void UpdateContent(ItemData itemData)
    {
        Data = itemData;
        TextName.text = itemData.data.Name;
    }

    public void OnClick()
    {
        Debug.Log("OnClick");
        Data.OnClick?.Invoke(Data.HrefContent);
    }

    public override void UpdatePosition(float position)
    {
        currentPosition = position;

        if (animator.isActiveAndEnabled)
        {
            animator.Play(AnimatorHash.Scroll, -1, position);
        }

        animator.speed = 0;
    }

    // GameObject が非アクティブになると Animator がリセットされてしまうため
    // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
    float currentPosition = 0;

    void OnEnable() => UpdatePosition(currentPosition);
}
