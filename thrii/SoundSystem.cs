using System.Collections.Generic;
using SFML.Audio;
using System;

namespace thrii
{
	public class MusicEntry
	{
		public Music Music { get; set; }

		public MusicEntry(string a)
		{
			Music = new Music(a);
		}

		public void Play()
		{
			Music.Volume = Settings.Volume;
			Music.Play();
		}

		public void Stop()
		{
			Music.Stop();
		}
	}

	public class SoundSystem : System
	{
		MusicEntry backgroundMusic;
		Sound gemSound;
		Sound destroyerSound;
		Sound boomSound;
		Random random;

		public SoundSystem(Engine e) : base(e) 
		{
			random = new Random();

			backgroundMusic = getRandomSong();
			backgroundMusic.Play();

			gemSound = new Sound(new SoundBuffer(Assets.GemSound));
			destroyerSound = new Sound(new SoundBuffer(Assets.DestroyerSound));
			boomSound = new Sound(new SoundBuffer(Assets.BoomSound));
		}

		MusicEntry getRandomSong()
		{
			return new MusicEntry(Assets.Music[random.Next(Assets.Music.Count)]);
		}

		public override void Update()
		{
			if (backgroundMusic.Music.Status == SoundStatus.Stopped)
			{
				backgroundMusic = getRandomSong();
				backgroundMusic.Play();
			}

			foreach (string audioFile in engine.Playlist)
			{
				if (audioFile == Assets.GemSound)
				{
					gemSound.Volume = Settings.Volume;
					gemSound.Play();
				}
				else if (audioFile == Assets.DestroyerSound)
				{
					destroyerSound.Volume = Settings.Volume;
					destroyerSound.Play();
				}
				else if (audioFile == Assets.BoomSound)
				{
					boomSound.Volume = Settings.Volume;
					boomSound.Play();
				}
			}

			engine.Playlist.Clear();
		}

		public void StopAll()
		{
			backgroundMusic.Stop();
		}
	}
}
