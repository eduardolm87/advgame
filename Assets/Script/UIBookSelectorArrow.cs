using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBookSelectorArrow : MonoBehaviour
{
	public Scrollbar Scroll;
	public float Quantity;

	public void OnClick()
	{
		Scroll.value += Quantity;
	}
}
