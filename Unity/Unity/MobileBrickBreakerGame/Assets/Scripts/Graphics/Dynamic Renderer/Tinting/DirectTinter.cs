using UnityEngine;
using System.Collections;

namespace Andtech.Graphics.DynamicRenderer {

	public class DirectTinter : Tinter {
		public Color tintColor;

		protected override void Awake() {
            /*
            Gives the color tint at the start of the game
            */
			base.Awake();
			Tint(tintColor);
		}
	}
}
