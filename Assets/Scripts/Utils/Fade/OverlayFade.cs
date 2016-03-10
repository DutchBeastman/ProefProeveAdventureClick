using UnityEngine;
using System.Collections;

namespace Utils
{
	public class OverlayFade : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer spriteRend;

		[SerializeField]
		private Color32 spriteBlack = new Color32(0,0,0,255);
		[SerializeField]
		private Color32 spriteTransparent = new Color32(255,255,255,0);

		private Color32 lerpedColor;

		protected virtual void Update()
		{

		}

		protected virtual void Awake()
		{
			spriteRend = GetComponent<SpriteRenderer>();
            spriteRend.color = spriteTransparent;

		}

		public IEnumerator FadeOut()
		{
			yield return new WaitForSeconds(0.1f);
			lerpedColor = Color32.Lerp(spriteBlack , spriteTransparent , 0.1f);
			spriteRend.color = lerpedColor;
		}
		public IEnumerator FadeIn()
		{
			yield return new WaitForSeconds(0.1f);
			lerpedColor = Color32.Lerp(spriteTransparent , spriteBlack , 0.5f);
			spriteRend.color = lerpedColor;
			Debug.Log("jdalf");
		}
	}
}