
namespace Andtech.Audio {

	public class SoundPlayer2D : SoundPlayer {

		public override void Initialize(AudioPacket packet) {
			audioSource.clip = packet.clip;
			audioSource.volume = packet.volume;
			audioSource.loop = packet.loop;
			AudioPacket2D packet2D = packet as AudioPacket2D;
			audioSource.panStereo = packet2D.pan;
		}
	}
}
