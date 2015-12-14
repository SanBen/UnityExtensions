using UnityEngine;

namespace Extensions
{
    public static class TransformExtensions
    {

        public static void Billboard(this Transform transform, Camera camera)
        {
            transform.rotation = camera.transform.rotation;
        }

        public static T GetComponentInChildren<T>(this Transform transform, bool includeInactive)
        {
            return transform.gameObject.GetComponentInChildren<T>(includeInactive);
        }

        public static T FindComponent<T>(this Transform transform, string name) where T : Component
        {
            return transform.gameObject.FindComponent<T>(name);
        }

        public static T TryFindComponent<T>(this Transform transform, string name) where T : Component
        {
            return transform.gameObject.TryFindComponent<T>(name);
        }

        public static void CopyStateTo(this Transform transform, Transform target, bool local = true)
        {
            if (local)
            {
                target.localPosition = transform.localPosition;
                target.localRotation = transform.localRotation;
            }
            else
            {
                target.position = transform.position;
                target.rotation = transform.rotation;
            }
            target.localScale = transform.localScale;
        }

        /// <summary>
        /// Gets the full path to a Transform.
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="transform">Transform.</param>
        public static string GetPath(this Transform transform, Transform topLevel, bool includeTopLevel)
        {
            if (transform.parent == null || transform == topLevel)
            {
                if (includeTopLevel)
                {
                    return "/" + transform.name;
                }
                else
                {
                    return string.Empty;
                }
            }
            return transform.parent.GetPath(topLevel, includeTopLevel) + "/" + transform.name;
        }
    }
}