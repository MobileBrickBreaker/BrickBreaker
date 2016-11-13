using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	public static Transform FindHighestParent(Transform transform) {
		Transform parent = transform.parent;
		if (!parent)
			return transform;

		return FindHighestParent(parent);
	}

	public static Transform FindHighestParent(Transform transform, string tag) {
		Transform parent = transform.parent;
		if (!parent || parent.gameObject.tag.CompareTo(tag) != 0)
			return transform;

		return FindHighestParent(parent, tag);
	}
}
