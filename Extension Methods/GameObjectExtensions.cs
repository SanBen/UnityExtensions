using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
  public static class GameObjectExtensions
  {
    private static int tempI = 0;

    public static void EnableColliders<T>(this GameObject go, bool enable) where T : Collider
    {
      T[] comps = go.GetComponents<T>();
      for (tempI = 0; tempI < comps.Length; tempI++) {
        comps[tempI].enabled = enable;
      }
    }

    /// <summary>
    /// Returns the first Collider.
    /// </summary>
    /// <param name="objWithChildCollider"></param>
    /// <returns></returns>
    public static T GetFirstCollider<T>(GameObject objWithChildCollider, bool IsTrigger) where T : Collider
    {
      T[] colls = objWithChildCollider.GetComponents<T>();

      T coll;
      for (tempI = 0; tempI < colls.Length; tempI++) {
        coll = colls[tempI];
        if (coll.isTrigger == IsTrigger) {
          return coll;
        }
      }

      return null;
    }

    public static List<T> GetColliders<T>(GameObject objWithChildCollider, bool IsTrigger) where T : Collider
    {
      T[] colls = objWithChildCollider.GetComponents<T>();

      List<T> colliders = new List<T>();
      for (tempI = 0; tempI < colls.Length; tempI++) {
        if (colls[tempI].isTrigger == IsTrigger) {
          colliders.Add(colls[tempI]);
        }
      }

      return colliders;
    }

    public static List<GameObject> GetChildrenWithTag(GameObject parent, string tag)
    {
      List<GameObject> children = new List<GameObject>();

      for (int i = 0; i < parent.transform.childCount; i++) {
        Transform child = parent.transform.GetChild(i);
        if (child.gameObject.CompareTag(tag)) {
          children.Add(child.gameObject);
        }
      }

      return children;
    }

    /// <summary>
    /// Gets the transform of the children, exclusive the own Transform (which GetCompontentsInChildren returns)
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="getRecursive"></param>
    /// <returns></returns>
    public static Transform[] GetOnlyChildren(this Transform trans, bool getRecursive = true)
    {
      Transform[] children = trans.GetComponentsInChildren<Transform>();
      //Debug.Log ("GetOnlyChildren initial length " + children.Length);
      //Debug.Log ("GetOnlyChildren recursive: " + children.Length + " parts and direct: " + trans.childCount);

      if (children.Length > 1) {
        List<Transform> exceptMySelf = new List<Transform>();
        int newIndex = 0;

        Transform child;
        for (int i = 0; i < children.Length; i++) {
          child = children[i];

          if (child != trans) {
            if (getRecursive) {
              exceptMySelf.Add(child);
              newIndex++;
            } else if (!getRecursive && child.parent == trans) {
              exceptMySelf.Add(child);
              newIndex++;
            }
          }
        }

        return exceptMySelf.ToArray();
      }

      return null;
    }

    public static void ChangeLayersRecursively(this Transform trans, string name)
    {
      trans.gameObject.layer = LayerMask.NameToLayer(name);
      foreach (Transform child in trans) {
        child.ChangeLayersRecursively(name);
      }
    }

    public static void SetStaticRecursively(this Transform trans, bool isStatic)
    {
      trans.gameObject.isStatic = isStatic;
      foreach (Transform child in trans) {
        child.SetStaticRecursively(isStatic);
      }
    }
  }
}