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
        /*
        Set Layers for Ball so the Ball can equal the layer of the paddle when facing the backside of the paddle.
        Therefore, the ball can go through the paddle, and not collide with t.
        */
		body = GetComponent<Rigidbody>();
		layerIndexUp = LayerMask.NameToLayer(layerNameUp);
		layerIndexDown = LayerMask.NameToLayer(layerNameDown);
	}

	protected virtual void FixedUpdate() {
		float y = body.velocity.y;
		gameObject.layer = (y > 0) ? layerIndexUp : layerIndexDown;
	}
}
