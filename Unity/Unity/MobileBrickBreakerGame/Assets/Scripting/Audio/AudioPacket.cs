using UnityEngine;

namespace Andtech.Audio {

	public class AudioPacket {
		public AudioClip clip;
		public float volume;
		public bool loop;

		public AudioPacket(AudioClip clip) : this(clip, 1) {}

		public AudioPacket(AudioClip clip, float volume) : this(clip, volume, false) { }

		public AudioPacket(AudioClip clip, float volume, bool loop) {
			this.clip = clip;
			this.volume = volume;
			this.loop = loop;
		}
	}

	public class AudioPacket2D : AudioPacket{
		public float pan;

		public AudioPacket2D(AudioClip clip) : this(clip, 1) {}

		public AudioPacket2D(AudioClip clip, float volume) : this(clip, volume, false) {}

		public AudioPacket2D(AudioClip clip, float volume, bool loop) : this(clip, volume, loop, 0) {}

		public AudioPacket2D(AudioClip clip, float volume, bool loop, float pan) : base(clip, volume, loop) {
			this.pan = pan;
		}
	}

	public class AudioPacket3D : AudioPacket {
		public Vector3 position;

		public AudioPacket3D(AudioClip clip, Vector3 position) : this(clip, position, 1) {}

		public AudioPacket3D(AudioClip clip, Vector3 position, float volume) : this(clip, position, volume, false) {}

		public AudioPacket3D(AudioClip clip, Vector3 position, float volume, bool loop) : base(clip, volume, loop) {
			this.position = position;
		}
	}
}