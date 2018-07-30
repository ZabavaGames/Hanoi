using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hanoika {

/// <summary>
/// Класс реализует решение головоломки.
/// </summary>
public class Solution1 : MonoBehaviour {

	public const int MaxSolutionDifficulty = 64;
	public Control Main;

	// Use this for initialization
	void Start () {
	//	MaxSolutionDifficulty = 64;
	}
	
/// <summary>
/// Запуск решения.
/// </summary>
/// <param name="k">K.</param>
	public void Run (int k) {
 		RecursiveSolution (k, 1, 2, 3);
	}

/// <summary>
/// Рекурсивный вариант решения.
/// </summary>
/// <param name="k">K.</param>
/// <param name="one">One.</param>
/// <param name="two">Two.</param>
/// <param name="three">Three.</param>
	private void RecursiveSolution (int k, int one, int two, int three) {
		if (k == 0) return;
		else {
			RecursiveSolution (k - 1, one, three, two);
			MoveTo (one, three);
			RecursiveSolution (k - 1, two, one, three);
			}
	}

/// <summary>
/// Перемещение диска из башни в башню.
/// </summary>
/// <param name="one">One.</param>
/// <param name="two">Two.</param>
	private void MoveTo (int one, int two) {
		Main.MoveDiskFromTo (one, two);
	}


	}
}
