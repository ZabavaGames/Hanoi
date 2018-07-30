using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Hanoika {

/// <summary>
/// Класс обрабатывает вывод на экран
/// </summary>
public class Display : MonoBehaviour {

	public Text Count, Input;
	public Button Play, Enter;
	public Image Success;
	public Control Main;
	private int MovesCount;
	private bool CoroutineExecFlag;
	public const float TimeToFly = 0.5f;

	// Use this for initialization
	void Start () {
		Success.gameObject.SetActive (false);
		Play.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/// <summary>
/// Raises the enter button pressed event.
/// Считываем число из поля ввода и запускаем процесс генерации пирамиды.
/// </summary>
	public void OnEnterButtonPressed () {
		int k = 0;
		string s = Input.text;
		if (s != String.Empty)
			k = int.Parse (s);

		if (k > 0) {
			Play.gameObject.SetActive (false);
			Enter.gameObject.SetActive (false);
			Main.Init (k);
			StartCoroutine (StartGame ());
			}

		Success.gameObject.SetActive (false);
		Input.text = String.Empty;
		MovesCount = 0;
		Count.text = MovesCount.ToString();
	}

/// <summary>
/// Подготовка кнопки Play, которая становится доступна для нажатия.
/// </summary>
	private IEnumerator StartGame () {
		while (CoroutineExecFlag)
			yield return null;
		Play.gameObject.SetActive (true);
		Enter.gameObject.SetActive (true);
	}

/// <summary>
/// Raises the play button pressed event.
/// Запускаем решение головоломки. В это время кнопки недоступны.
/// </summary>
	public void OnPlayButtonPressed () {
		Play.gameObject.SetActive (false);
		Enter.gameObject.SetActive (false);
		Success.gameObject.SetActive (false);
		MovesCount = 0;
		Count.text = MovesCount.ToString();
	
		CoroutineExecFlag = false;
		Main.Play ();
		StartCoroutine (EndOfGame ());
	}

/// <summary>
/// По завершении головоломки показываем "Решено".
/// </summary>
	private IEnumerator EndOfGame () {
		while (CoroutineExecFlag)
			yield return null;
		Success.gameObject.SetActive (true);
		Enter.gameObject.SetActive (true);
	}

/// <summary>
/// Поместить диск в указанную башню, увеличить счетчик ходов.
/// </summary>
/// <param name="disk">Disk.</param>
/// <param name="t">T.</param>
	public void PlaceDiskOnStick (Disk disk, Tower t) {
		t.PlaceDisk (disk);
		MovesCount ++;
		Count.text = MovesCount.ToString();
	}

/// <summary>
/// Переместить объект на экране. Используется для перемещения дисков.
/// </summary>
/// <param name="disk">Disk.</param>
/// <param name="x">The x coordinate.</param>
/// <param name="y">The y coordinate.</param>
	public void MoveObject (GameObject disk, float x, float y) {
		StartCoroutine (FlyTo (disk, x, y));
	}

/// <summary>
/// Корутина перемещения дисков ("перелета") с одной позиции на другую.
/// </summary>
/// <returns>The to.</returns>
/// <param name="disk">Disk.</param>
/// <param name="x">The x coordinate.</param>
/// <param name="y">The y coordinate.</param>
	private IEnumerator FlyTo (GameObject disk, float x, float y) {
		while (CoroutineExecFlag)
			yield return null;
		CoroutineExecFlag = true;

		float curtime = 0;
		Vector3 newpos = new Vector3 (x, y, 0);
		Vector3 oldpos = disk.transform.position;
		do {
			disk.transform.position = Vector3.Lerp (oldpos, newpos, curtime/TimeToFly);
			curtime += Time.deltaTime;
			yield return null;
			} while (curtime <= TimeToFly);
		disk.transform.position = newpos;

		CoroutineExecFlag = false;
	}



}
}
