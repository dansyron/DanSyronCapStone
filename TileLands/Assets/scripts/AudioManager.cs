using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {



	//create instance
	private static AudioManager instance = null;

	public static AudioManager Instance {
		get;
		private set;
	}

	[SerializeField]
	AudioSource sfxSource;
	[SerializeField]
	AudioSource musicSource;
	[SerializeField]
	AudioSource TileSoundSource;
	[SerializeField]
	AudioSource ButtonSounds1;
	[SerializeField]
	AudioSource ButtonSounds2;

	//insert audio clips.
	public AudioClip OceanSound;
	public AudioClip DesertSound;
	public AudioClip OceanTileSound;
	public AudioClip DesertTileSound;
	public AudioClip RotationSwoosh;
	public AudioClip Button1;
	public AudioClip Button2;
	public AudioClip Button3;
	public AudioClip Chime1;
	public AudioClip Chime2;
	public AudioClip MenuSound;
	public AudioClip firework;
	public AudioClip mainMusic;

	// Use this for initialization
	void Awake () {
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;
		Initialize();
	}


	void Initialize()
	{
		//initialize sound files
		OceanSound = (AudioClip)Resources.Load ("Audio/OceanSound");
		DesertSound = (AudioClip)Resources.Load ("Audio/DesertSound");
		OceanTileSound = (AudioClip)Resources.Load ("Audio/WaterSplash");
		DesertTileSound = (AudioClip)Resources.Load ("Audio/RockPillar");
		RotationSwoosh = (AudioClip)Resources.Load ("Audio/RotationSwoosh");
		Button1 = (AudioClip)Resources.Load ("Audio/ButtonPress1");
		Button2 = (AudioClip)Resources.Load ("Audio/ButtonPress2");
		Button3 = (AudioClip)Resources.Load ("Audio/ButtonPress3");
		Chime1 = (AudioClip)Resources.Load ("Audio/tilelands chime 1");
		Chime2 = (AudioClip)Resources.Load ("Audio/tilelands chime 2");
		MenuSound = (AudioClip)Resources.Load ("Audio/MenuWind");
		firework = (AudioClip)Resources.Load ("Audio/firework");

		instance = this;
		Muted = false;



	}
	// Update is called once per frame
	void Update () {
		
	}


	public void PlayOceanSound()
	{
		//load sound into the clip.
		sfxSource.clip = OceanSound;
		sfxSource.loop = true;
		sfxSource.Play ();
	}

	public void PlayMenuSound()
	{
		//load sound into the clip.
		sfxSource.clip = MenuSound;
		sfxSource.loop = true;
		sfxSource.Play ();
	}

	//desert ambient
	public void PlayDesertSound()
	{
		//load sound into the clip.
		sfxSource.clip = DesertSound;
		sfxSource.loop = true;
		sfxSource.Play ();
	}

	public void PlaySplash()
	{
		TileSoundSource.volume = .8f;
		TileSoundSource.clip = OceanTileSound;
		TileSoundSource.PlayOneShot (OceanTileSound);
	}

	public void PlayRockCrunch()
	{
		TileSoundSource.volume = .8f;
		TileSoundSource.clip = DesertTileSound;
		TileSoundSource.PlayOneShot (DesertTileSound);
	}

	public void PlaySwoosh()
	{
		ButtonSounds2.clip = RotationSwoosh;
		ButtonSounds2.PlayOneShot (RotationSwoosh);
	}

	public void PlayFirework()
	{
		ButtonSounds2.clip = firework;
		ButtonSounds2.loop = true;
		ButtonSounds2.Play ();
	}

	//select
	public void PlayButton1()
	{
		ButtonSounds1.clip = Button1;
		ButtonSounds1.PlayOneShot (Button1);
	}

	public void PlayChime1()
	{
		ButtonSounds1.clip = Chime1;
		ButtonSounds1.PlayOneShot (Chime1);
	}

	public void PlayChime2()
	{
		ButtonSounds1.clip = Chime2;
		ButtonSounds1.PlayOneShot (Chime2);
	}

	//depress
	public void PlayButton2()
	{
		ButtonSounds1.clip = Button2;
		ButtonSounds1.PlayOneShot (Button2);
	}

	//back
	public void PlayButton3()
	{
		ButtonSounds1.clip = Button3;
		ButtonSounds1.PlayOneShot (Button3);
	}

	//mutes sounds
	public void MuteAll()
	{
		sfxSource.volume = 0;
		musicSource.volume = 0;
		TileSoundSource.volume = 0;
		ButtonSounds1.volume = 0;
		ButtonSounds2.volume = 0;
		Muted = true;
	}

	//unmutes sounds
	public void unMuteAll()
	{
		sfxSource.volume = 1;
		musicSource.volume = 1;
		TileSoundSource.volume = 1;
		ButtonSounds1.volume = 1;
		ButtonSounds2.volume = 1;
		Muted = false;
	}

	//mutes music
	public void MuteMusic()
	{
		musicSource.volume = 0;
	}

	//unmutes music
	public void UnmuteMusic()
	{
		musicSource.volume = 1;
	}


	//STOPS THE SOUND
	//CAN FADE OUT
	public void StopSound()
	{

	}
		
	//volume for sfx
	public float Volume {
		get;
		set;
	}

	//volume for music
	public float MusicVolume {
		get;
		set;
	}

	public bool Muted {
		get;
		set;
	}
}
