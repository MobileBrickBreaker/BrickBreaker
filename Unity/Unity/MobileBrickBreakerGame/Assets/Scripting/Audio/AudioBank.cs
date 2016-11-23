using System.Collections.Generic;
using UnityEngine;

namespace Andtech.Audio {

	public class AudioBank : MonoBehaviour {
		public AudioClip[] soundClips;
		public AudioClip[] musicClips;

		private static IDictionary<string, AudioClip> bankSound;
		private static IDictionary<string, AudioClip> bankMusic;

		protected virtual void Awake() {
			Initialize(this);
		}

		protected static void Initialize(AudioBank audioBankScript) {
			bankSound = new Dictionary<string, AudioClip>(audioBankScript.soundClips.Length);
			foreach (AudioClip clip in audioBankScript.soundClips) {
				if (clip == null)
					continue;

				bankSound.Add(clip.name, clip);
			}
			bankMusic = new Dictionary<string, AudioClip>(audioBankScript.musicClips.Length);
			foreach (AudioClip clip in audioBankScript.musicClips) {
				if (clip == null)
					continue;

				bankMusic.Add(clip.name, clip);
			}
		}

		public static AudioClip GetSound(string name) {
			AudioClip value;
			if (!bankSound.TryGetValue(name, out value)) {
				Debug.LogWarning("No such sound clip with name: " + name);
				return null;
			}

			return value;
		}

		public static AudioClip GetSoundRandom(params string[] names) {
			int index = (int)(Random.value * names.Length);
			return GetSound(names[index]);
		}

		public static AudioClip GetMusic(string name) {
			AudioClip value;
			if (!bankMusic.TryGetValue(name, out value)) {
				Debug.LogWarning("No such music clip with name: " + name);
				return null;
			}

			return value;
		}

		public static AudioClip GetMusicRandom(params string[] names) {
			int index = (int)(Random.value * names.Length);
			return GetMusic(names[index]);
		}
	}
}
