using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.HW_CubeRain.Scripts
{
    public abstract class SpawnEventSignalizator: MonoBehaviour
    {
        public delegate void SpawnActionHandler(Vector3 transform = default);
        public abstract event SpawnActionHandler SpawnAction;
    }
}
