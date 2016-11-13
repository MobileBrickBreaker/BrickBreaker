using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Graphics.DynamicRenderer {

	public class Tinter : MonoBehaviour {
		public Renderer targetRenderer;
		public string propertyName = "_Color";
		public bool autodestruct;

		private float alpha = 1;
		private int ID_PROPERTY_NAME;

		protected virtual void Awake() {
			if (targetRenderer == null)
				AutoSetTargetRenderer();

			if (autodestruct)
				Tinted += Remove;

			alpha = targetRenderer.material.color.a;
			ID_PROPERTY_NAME = Shader.PropertyToID(propertyName);
		}

		public void Tint(Color color) {
			color.a = alpha;
			targetRenderer.material.SetColor(ID_PROPERTY_NAME, color);

			EventArgs args = EventArgs.Empty;
			OnTint(args);
		}

		public void Remove() {
			Destroy(this);
		}

		private void AutoSetTargetRenderer() {
			targetRenderer = GetComponent<Renderer>();
		}

		// HANDLER
		private void Remove(object sender, EventArgs e) {
			Remove();
		}

		// EVENT
		public EventHandler Tinted;

		protected virtual void OnTint(EventArgs e) {
			if (Tinted != null)
				Tinted(this, e);
		}
	}
}
