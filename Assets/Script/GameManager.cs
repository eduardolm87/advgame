using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

	public List<SpriteRenderer> BGImages = new List<SpriteRenderer>();


	public void ChangeImage(string ImageName)
	{
		SpriteRenderer r = BGImages.FirstOrDefault(x => x.name == ImageName);
		if (r == null)
		{
			Debug.LogError("Error: Not found image " + ImageName);
			return;
		}

		foreach (SpriteRenderer s in BGImages)
		{
			s.enabled = (s.name == r.name);
		}
	}

}
