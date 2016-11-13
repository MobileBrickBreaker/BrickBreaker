using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallLayerLogic : MonoBehaviour {
	public string layerNameUp;
	public string layerNameDown;

	private Rigidbody body;
	private int layerIndexUp;
	private int layerIndexDown;

	protected virtual void Awake() {
		body = GetComponent<Rigidbody>();
		layerIndexUp = LayerMask.NameToLayer(layerNameUp);
		layerIndexDown = LayerMask.NameToLayer(layerNameDown);
	}

	protected virtual void FixedUpdate() {
		float y = body.velocity.y;
		gameObject.layer = (y > 0) ? layerIndexUp : layerIndexDown;
	}
}
