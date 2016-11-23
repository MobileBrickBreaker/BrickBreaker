
namespace Andtech.Audio {

	public class SoundPlayer3D : SoundPlayer {

		public override void Initialize(AudioPacket packet) {
			audioSource.clip = packet.clip;
			audioSource.volume = packet.volume;
			audioSource.loop = packet.loop;
			AudioPacket3D packet3D = packet as AudioPacket3D;			
			transform.position = packet3D.position;
		}
	}
}
