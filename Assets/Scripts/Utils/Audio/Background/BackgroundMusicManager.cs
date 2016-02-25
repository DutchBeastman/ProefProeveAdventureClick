using UnityEngine;

namespace Utils
{
	public class BackgroundMusicManager : MonoBehaviour
	{
		[SerializeField]
		private AudioAssetGroup selection;

		[SerializeField]
		private bool playOnEnable = true;
		[SerializeField]
		private bool loop = true;

		private BackgroundMusicDependency backgroundMusic;

		protected void Awake()
		{
			backgroundMusic = GameDependencies.Get<BackgroundMusicDependency>();
		}

		protected void OnEnable()
		{
			if (playOnEnable)
			{
				Play();
			}
		}

		public void Play()
		{
			if (backgroundMusic == null)
			{
				backgroundMusic = GameDependencies.Get<BackgroundMusicDependency>();
			}

			backgroundMusic.Play(selection , loop);
		}
	}
}
