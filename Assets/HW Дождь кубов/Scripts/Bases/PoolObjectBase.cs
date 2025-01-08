using System;
using UnityEngine;

namespace Assets.HW_Дождь_кубов.Scripts.Bases
{
    public abstract class PoolObjectBase : MonoBehaviour
    {
        public bool IsReady { get; protected set; } = true;
        public abstract void Initialize(Vector3 position);
    }
}
