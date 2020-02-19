﻿using System.Collections;
using System.Collections.Generic;
using FancyScrollView;
using UnityEngine;

class ScrollView : FancyScrollView<ItemData>
{
    [SerializeField] Scroller scroller = default;
    [SerializeField] GameObject cellPrefab = default;

    protected override GameObject CellPrefab => cellPrefab;

    protected override void Initialize()
    {
        base.Initialize();
        scroller.OnValueChanged(UpdatePosition);
    }

    public void UpdateData(IList<ItemData> items)
    {
        UpdateContents(items);
        scroller.SetTotalCount(items.Count);
    }
}
