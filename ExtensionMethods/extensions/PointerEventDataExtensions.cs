using UnityEngine;
using UnityEngine.EventSystems;

namespace Extensions
{
    public static class PointerEventDataExtensions
    {
        public static Vector3 GetWorldPosition(this PointerEventData eventData)
        {
            return eventData.pointerCurrentRaycast.worldPosition;
        }
    }
}