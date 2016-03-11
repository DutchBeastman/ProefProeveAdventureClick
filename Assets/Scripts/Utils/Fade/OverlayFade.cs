using UnityEngine;
using System.Collections;

namespace Utils
{
	public class OverlayFade : MonoBehaviour
	{
		[SerializeField]
		public float timeAdd = 0.05f;

		private float lerpTimer;

		[SerializeField]
		private SpriteRenderer spriteRend;
		[SerializeField]
		private Color32 spriteBlack = new Color32(0,0,0,255);
		[SerializeField]
		private Color32 spriteTransparent = new Color32(255,255,255,0);

		private Color32 lerpedColor;

		[HideInInspector]
		public bool fadeIn;
		[HideInInspector]
		public bool fadeOut;

		protected virtual void Awake()
		{
			spriteRend = GetComponent<SpriteRenderer>();
            spriteRend.color = spriteTransparent;
			fadeIn = false;
            fadeOut = true;

		}
		protected virtual void Update()
		{
			
			if (fadeOut)
			{
				lerpTimer += timeAdd;
				lerpedColor = Color32.Lerp(spriteBlack , spriteTransparent , lerpTimer);
				spriteRend.color = lerpedColor;
				if (lerpTimer > 1)
				{
					fadeOut = false;
				}
			}
			else if (fadeIn)
			{
				lerpTimer += timeAdd;
				lerpedColor = Color32.Lerp(spriteTransparent , spriteBlack , lerpTimer);
				spriteRend.color = lerpedColor;
				if (lerpTimer > 1)
				{
					fadeIn = false;
				}
			}
		}

		public void FadeOut()
		{
			fadeIn = false;
			fadeOut = true;
			lerpTimer = 0;
			Debug.Log("FadeOut");
		}
		public void FadeIn()
		{
			fadeOut = false;
			fadeIn = true;
			lerpTimer = 0;
			Debug.Log("FadeIn");
		}
	}
}