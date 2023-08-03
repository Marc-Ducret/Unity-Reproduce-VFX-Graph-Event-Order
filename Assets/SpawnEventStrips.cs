using Unity.Mathematics;
using UnityEngine;
using UnityEngine.VFX;

namespace DefaultNamespace {
    public class SpawnEventStrips : MonoBehaviour {
        public int    spawnCount;
        public float3 offset;

        protected void Start() {
            VisualEffect visualEffect = GetComponent<VisualEffect>();

            VFXEventAttribute eventAttribute = visualEffect.CreateVFXEventAttribute();

            float3 position = float3.zero;

            for (int i = 0; i < spawnCount; i++) {
                eventAttribute.SetUint("Emit_Event_Index", (uint)i);
                eventAttribute.SetVector3("Emit_Position", position);
                visualEffect.SendEvent("Emit", eventAttribute);
                position += offset;
            }
        }
    }
}