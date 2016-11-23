using System;
using System.Collections;
using UnityEngine;

namespace Andtech.Audio {

	public class AudioManager : MonoBehaviour {
		public bool musicOn = true;
		public bool soundOn = true;

		private static GameObject soundPlayer2DPrefab;
		private static GameObject soundPlayer3DPrefab;
		private static AudioManager that;
		private static SoundPlayer2D soundPlayerMusic;
		private static Hashtable soundPlayers;

		private const string SOUND_PLAYER_2D_PREFAB_PATH = "Audio/Sound Player 2D";
		private const string SOUND_PLAYER_3D_PREFAB_PATH = "Audio/Sound Player 3D";

		protected virtual void Awake() {
			Initialize(this);
		}

		protected static void Initialize(AudioManager audioManagerScript) {
			that = audioManagerScript;
			soundPlayer2DPrefab = Resources.Load(SOUND_PLAYER_2D_PREFAB_PATH) as GameObject;
			soundPlayer3DPrefab = Resources.Load(SOUND_PLAYER_3D_PREFAB_PATH) as GameObject;
			soundPlayers = new Hashtable();
			GameObject music = Instantiate(soundPlayer2DPrefab);
			music.name = "MUSIC";
			soundPlayerMusic = music.GetComponent<SoundPlayer2D>();
		}

		public static void PlaySound(AudioPacket2D packet) {
			if (!that.soundOn)
				return;
			
			GameObject soundPlayer = Instantiate(soundPlayer2DPrefab);
			SoundPlayer2D soundPlayerScript = soundPlayer.GetComponent<SoundPlayer2D>();
			soundPlayerScript.Initialize(packet);
			soundPlayerScript.Play();
			soundPlayerScript.StoppedPlayback += DestroySoundPlayer;
			soundPlayers.Add(soundPlayerScript, soundPlayerScript);
		}

		public static void PlaySound(AudioPacket3D packet) {
			if (!that.soundOn)
				return;

			GameObject soundPlayer = Instantiate(soundPlayer3DPrefab);
			SoundPlayer3D soundPlayerScript = soundPlayer.GetComponent<SoundPlayer3D>();
			soundPlayerScript.Initialize(packet);
			soundPlayerScript.Play();
			soundPlayerScript.StoppedPlayback += DestroySoundPlayer;
			soundPlayers.Add(soundPlayerScript, soundPlayerScript);
		}

		public static void StopAllSounds() {
			foreach (SoundPlayer soundPlayerScript in soundPlayers) {
				soundPlayerScript.Destroy();
			}
			soundPlayers.Clear();
		}

		public static void PlayMusic(AudioPacket2D packet) {
			if (!that.musicOn)
				return;

			soundPlayerMusic.Initialize(packet);
			soundPlayerMusic.Play();
		}

		public static void StopMusic() {
			soundPlayerMusic.Pause();
		}

		// HANDLER
		protected static void DestroySoundPlayer(object sender, EventArgs e) {
			soundPlayers.Remove(sender);
			(sender as SoundPlayer).Destroy();
		}
	}
}
