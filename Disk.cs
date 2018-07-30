using UnityEngine;

namespace Hanoika {

/// <summary>
/// Класс диска.
/// </summary>
public class Disk : MonoBehaviour {

	private float Width, Height;
	private Display MainDisplay;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

/// <summary>
/// Set the specified parent, width and height.
/// </summary>
/// <param name="parent">Parent.</param>
/// <param name="width">Width.</param>
/// <param name="height">Height.</param>
	public void Set (Display display, GameObject parent, float width, float height) {
        MainDisplay = display;
        transform.SetParent (parent.transform, true);
		RectTransform rt = this.GetComponent<RectTransform>();
        if (rt != null)
		    rt.sizeDelta = new Vector2(width, height);
	}

/// <summary>
/// Move to the specified x and y.
/// </summary>
/// <param name="x">The x coordinate.</param>
/// <param name="y">The y coordinate.</param>
	public void MoveTo (float x, float y) {
		MainDisplay.MoveObject (this.gameObject, x, y);
	}

}
}
