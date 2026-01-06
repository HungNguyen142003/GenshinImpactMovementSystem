using System;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class PlayerLayerData
    {
        [field: SerializeField] public LayerMask GroundLayer { get; private set; }

        public bool ContainsLayer(LayerMask layerMask, int layer)
        {
            // Shift 1 to the left to create a bitmask for the layer
            // AND it with the LayerMask
            // If result is not zero, the layer exists in the mask
            return (1 << layer & layerMask) != 0;
        }

        public bool IsGroundLayer(int layer)
        {
            return ContainsLayer(GroundLayer, layer);
        }
    }
}
