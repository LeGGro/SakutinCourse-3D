using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ClickActionBase : MonoBehaviour
{
    public abstract void Act(ClickableObjectBase clickableObject);
}
