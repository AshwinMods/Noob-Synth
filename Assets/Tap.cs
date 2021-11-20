using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[SelectionBase]
public class Tap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] int index = -1;
	public void OnPointerDown(PointerEventData eventData)
	{
		WaveGenerator.Down(index);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		WaveGenerator.Up(index);
	}

	[SerializeField] int offset = 0;
	[SerializeField] bool setOffset;
	private void OnValidate()
	{
		if (index < 0)
			index = transform.GetSiblingIndex();
		if (setOffset)
		{
			setOffset = false;
			index += offset;
		}
	}
}
