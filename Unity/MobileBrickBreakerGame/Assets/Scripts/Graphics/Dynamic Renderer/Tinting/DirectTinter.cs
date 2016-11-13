using UnityEngine;
using System.Collections;

namespace Andtech.Graphics.DynamicRenderer {

	public class DirectTinter : Tinter {
		public Color tintColor;

		protected override void Awake() {
			base.Awake();
			Tint(tintColor);
		}
	}
}
