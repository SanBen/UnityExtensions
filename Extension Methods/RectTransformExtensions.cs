using UnityEngine;
using System;

namespace Extensions
{
    public static class RectTransformExtensions
    {
        public static void AnchorToCorners(this RectTransform transform)
        {
            if (transform == null)
                throw new ArgumentNullException("transform");

            if (transform.parent == null)
                return;

            var parent = transform.parent.GetComponent<RectTransform>();

            Vector2 newAnchorsMin = new Vector2(transform.anchorMin.x + transform.offsetMin.x / parent.rect.width,
                              transform.anchorMin.y + transform.offsetMin.y / parent.rect.height);

            Vector2 newAnchorsMax = new Vector2(transform.anchorMax.x + transform.offsetMax.x / parent.rect.width,
                              transform.anchorMax.y + transform.offsetMax.y / parent.rect.height);

            transform.anchorMin = newAnchorsMin;
            transform.anchorMax = newAnchorsMax;
            transform.offsetMin = transform.offsetMax = new Vector2(0, 0);
        }

        public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
        {
            trans.pivot = aVec;
            trans.anchorMin = aVec;
            trans.anchorMax = aVec;
        }

        public static Vector2 GetSize(this RectTransform trans)
        {
            return trans.rect.size;
        }

        public static float GetWidth(this RectTransform trans)
        {
            return trans.rect.width;
        }

        public static float GetHeight(this RectTransform trans)
        {
            return trans.rect.height;
        }

        public static void SetSize(this RectTransform trans, Vector2 newSize)
        {
            Vector2 oldSize = trans.rect.size;
            Vector2 deltaSize = newSize - oldSize;
            trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
            trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
        }

        public static void SetWidth(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(newSize, trans.rect.size.y));
        }

        public static void SetHeight(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(trans.rect.size.x, newSize));
        }

        public static void SetBottomLeftPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }

        public static void SetTopLeftPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }

        public static void SetBottomRightPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }

        public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }

        public static Vector3 GetCenter(this RectTransform trans)
        {
            float xOffset = trans.GetWidth() / 2;
            float yOffset = trans.GetHeight() / 2;
            return new Vector3(trans.position.x + xOffset, trans.position.y + yOffset, trans.position.z);
        }
		
				/// <summary>
		/// Sets the position of the RectTransform based on a percentage in relation to the referenceTransform.
		/// e.g. Passing in (0.5,0.5) will position the RectTransform exactly in the middle of the referenceTransform.
		/// Note that values under 0 and over 1 are also possible.
		/// </summary>
		/// <param name="rectTransform">Rect transform.</param>
		/// <param name="positionPercentage">Position percentage.</param>
		/// <param name="referenceTransform">Reference transform.</param>
		public static void SetPositionRelative (this RectTransform rectTransform, Vector2 positionPercentage, RectTransform referenceTransform = null) {
			if (referenceTransform == null) {
				referenceTransform = rectTransform.parent.GetComponent<RectTransform> ();
				if (referenceTransform == null) {
					Debug.LogError ("You must either specify an explicit reference Transform, or the RectTransform must have a parent RectTransform!");
					return;
				}
			}
			Vector2 parentCenter = referenceTransform.rect.center;
			Vector2 parentDimensions = new Vector2 (referenceTransform.rect.width, referenceTransform.rect.height);
			Vector2 offset = new Vector2 (parentDimensions.x * positionPercentage.x, parentDimensions.y * positionPercentage.y);
			Vector3 targetPosition = new Vector3 (parentCenter.x + offset.x, parentCenter.y + offset.y, 0f);
			rectTransform.position = targetPosition;
			Debug.Log ("Object:" + rectTransform.name + ", PosPercentage:" + positionPercentage + ", ParentMin: " + parentCenter + ", Offset: " + offset + ", TargetPosition: " + targetPosition);
		}
		
		/// <summary>
		/// Interpolates between AnchorMin and AnchorMax based on Pivot.
		/// e.g. AnchorMin(0.25,0.25), AnchorMax(0.75,0.75), Pivot(0.2,0.8) will return (0.35,0.65)
		/// </summary>
		/// <returns>The anchor position at pivot.</returns>
		/// <param name="rectTransform">Rect transform.</param>
		/// <param name="referenceTransform">Reference transform.</param>
		public static Vector2 GetAnchorPositionAtPivot (this RectTransform rectTransform, RectTransform referenceTransform = null) {
			if (referenceTransform == null) {
				referenceTransform = rectTransform.parent.GetComponent<RectTransform> ();
				if (referenceTransform == null) {
					Debug.LogError ("You must either specify an explicit reference Transform, or the RectTransform must have a parent RectTransform!");
					return Vector2.zero;
				}
			}
			Vector2 pivot = rectTransform.pivot;
			Vector2 anchorMin = rectTransform.anchorMin;
			Vector2 anchorMax = rectTransform.anchorMax;

			Vector2 simulatedAnchoredPosition = new Vector2 (
			anchorMin.x + (anchorMax.x - anchorMin.x) * pivot.x,
			anchorMin.y + (anchorMax.y - anchorMin.y) * pivot.y
			);
			return simulatedAnchoredPosition;
		}
		
		public static void StretchToAnchoredPosition (this RectTransform rectTransform) {
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
		}
		
		public static void FitToParent (this RectTransform rectTransform) {
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			rectTransform.localScale = Vector3.one;
		}
    }
}
