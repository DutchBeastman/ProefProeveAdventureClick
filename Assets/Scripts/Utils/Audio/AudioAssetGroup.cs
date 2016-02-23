using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Utils
{
	public class AudioAssetGroup : ScriptableObject
	{
		public IEnumerable<AudioAsset> AudioAssets
		{
			get
			{
				return audioAssets;
			}
		}

		public AudioMixerGroup AudioMixerGroup
		{
			get
			{
				return audioMixerGroup;
			}
		}

		[SerializeField]
		private AudioAsset[] audioAssets;
		[SerializeField]
		private AudioMixerGroup audioMixerGroup;

#if UNITY_EDITOR
		[MenuItem("Audio/Create AudioAssetGroup from selection")]
		private static void CreateAudioAssets()
		{
			if(Selection.objects.Length > 0)
			{
				List<AudioAsset> targets = new List<AudioAsset>();

				foreach(Object obj in Selection.objects)
				{
					if(obj.GetType() == typeof(AudioAsset))
					{
						targets.Add(obj as AudioAsset);
					}
				}

				if(targets.Count > 0)
				{
					string path = AssetDatabase.GetAssetPath(targets[0]);

					if(!string.IsNullOrEmpty(path))
					{
						int lastIndex = path.LastIndexOf(Path.DirectorySeparatorChar);

						if(lastIndex <= 0)
						{
							lastIndex = path.LastIndexOf(Path.AltDirectorySeparatorChar);
						}

						if(lastIndex > 0)
						{
							path = path.Substring(0, lastIndex + 1);
							path += "AudioAssetGroup.asset";
						}
						else
						{
							path = EditorUtility.SaveFilePanelInProject("Create AudioAssetGroup", "AudioAssetGroup", "asset", "Create a nw AudioAssetGroup.");

							if(string.IsNullOrEmpty(path))
							{
								return;
							}
						}

						AudioAssetGroup asset = CreateInstance<AudioAssetGroup>();

						asset.audioAssets = new AudioAsset[targets.Count];
						targets.CopyTo(asset.audioAssets);

						AssetDatabase.CreateAsset(asset, path);
						AssetDatabase.SaveAssets();

						Selection.activeObject = asset;
					}
				}				
			}
		}
#endif
	}
}