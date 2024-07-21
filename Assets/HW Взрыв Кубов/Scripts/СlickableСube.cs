using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class —lickable—ube : ClickableObjectBase, IPointerClickHandler
{
    [SerializeField] private ClickActionBase _clickAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickAction.Act(this);
    }
}
