using System;
using UnityEngine;

namespace Andtech.Audio {

	[RequireComponent(typeof(AudioSource))]
	public abstract class SoundPlayer : MonoBehaviour {
		public AudioSource audioSource { get; protected set; }

		protected virtual void Awake() {
			audioSource = GetComponent<AudioSource>();
		}

		protected virtual void Update() {
			if (!audioSource.isPlaying)
				Stop();
		}

		public virtual void Play() {
			audioSource.Play();
		}

		public virtual void Pause() {
			audioSource.Pause();
		}

		public virtual void UnPause() {
			audioSource.UnPause();
		}

		public virtual void Stop() {
			EventArgs args = EventArgs.Empty;
			OnStopPlayback(args);
		}

		public virtual void Destroy() {
			Destroy(gameObject);
		}

		public abstract void Initialize(AudioPacket packet);

		// EVENT
		public event EventHandler StoppedPlayback;

		protected virtual void OnStopPlayback(EventArgs e) {
			if (StoppedPlayback != null)
				StoppedPlayback(this, e);
		}
	}
}
