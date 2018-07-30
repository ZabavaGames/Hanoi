using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hanoika {

public class Solution : MonoBehaviour {

	public Display MainDisplay;
	public int MaxSolutionDifficulty;
	

	// Use this for initialization
	void Start () {
		MaxSolutionDifficulty = 64;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Run (int k) {
 		RecursiveSolution(k);
	}

	private static void RecursiveSolution(int k) {
		Debug.Log("Рекурсивное решение для " + k + " дисков");
		Stack<int> One = new Stack<int>(), 
					Two = new Stack<int>(), 
					 Three = new Stack<int>();
		for (int i = 0; i < k; i++)
			One.Push (k-i);
	//	ShowAllTowers (One, Two, Three);

		try {
			Hanoika_Rekursivka (k, One, Two, Three);
			}
		catch (Exception error) {
	        Debug.Log("Ошибка: " + error.Message);
    	}

		ShowAllTowers (One, Two, Three);
	}

	private static void Hanoika_Rekursivka(int k, Stack<int> one, Stack<int> two, Stack<int> three) {
		if (k == 0) return;
		else {
			Hanoika_Rekursivka(k - 1, one, three, two);
			MoveTo (one, three);
			Hanoika_Rekursivka(k - 1, two, one, three);
			}
	}

	private static void MoveTo (Stack<int> one, Stack<int> two) {
	//	Debug.Log("Переложить диск из " + one + " в " + two);
		two.Push (one.Pop ());
	}

	private static void ShowAllTowers (Stack<int> one, Stack<int> two, Stack<int> three) {
		ShowHanoiTower (one);
		ShowHanoiTower (two);
		ShowHanoiTower (three);
	}

	private static void ShowHanoiTower (Stack<int> one) {
		int[] Temp = one.ToArray ();
		foreach (int i in Temp) {
			Debug.Log (i);
		}
		Debug.Log ("Empty");
	}


	}
}
