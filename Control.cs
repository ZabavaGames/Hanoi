using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanoika {

/// <summary>
/// Класс, управляющий башнями и решением.
/// </summary>
public class Control : MonoBehaviour {

	public Tower Tower1, Tower2, Tower3;
	private Tower[] Towers;
	private int NumberOfDisks;
	public Display MainDisplay;
	public Solution1 TaskSolution;


	// Use this for initialization
	void Start () {
		Towers = new Tower[3];
		Towers[0] = Tower1;
		Towers[1] = Tower2;
		Towers[2] = Tower3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/// <summary>
/// Инициализация головоломки с заданным кол-вом диском. Вначале очищает все башни от дисков, оставшихся от предыдущего решения.
/// </summary>
/// <param name="k">int K.</param>
	public void Init (int k) {
		ClearAllTowers ();
		NumberOfDisks = k;
		foreach (Tower t in Towers)
			t.SetTower (k);
		Towers[0].CreateInitialTower (k);
	}

/// <summary>
/// Clears all towers.
/// </summary>
	private void ClearAllTowers () {
		foreach (Tower t in Towers)
			t.ClearTower ();
	}

/// <summary>
/// Запуск решения головоломки.
/// </summary>
	public void Play () {
		if (NumberOfDisks < Solution1.MaxSolutionDifficulty)
			TaskSolution.Run (NumberOfDisks);
	}

/// <summary>
/// Moves the disk from to.
/// Перемещает диск из одной башни в другую, удаляя диск из стека старой башни и добавляя в новой.
/// </summary>
/// <param name="one">One.</param>
/// <param name="two">Two.</param>
	public void MoveDiskFromTo (int one, int two) {
		Tower tower_from, tower_to;
		tower_from = Towers[one-1];
		tower_to = Towers[two-1];
	
		if (tower_from.Count > 0) {
			Disk disk = tower_from.RemoveDisk ();
			if (disk != null) {
				MainDisplay.PlaceDiskOnStick (disk, tower_to);
				}
			}
	}


}
}
