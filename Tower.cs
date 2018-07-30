using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hanoika {

/// <summary>
/// Класс описывает башню из дисков.
/// </summary>
public class Tower : MonoBehaviour {

	public int Count;
	public Disk DiskPrefab;
    public Display MainDisplay;
	private GameObject Stick;
	private Stack<Disk> Disks;

	private float TowerHeight, DiskMaxWidth, DiskMinWidth, DiskMaxHeight, Hstep, Wstep;


	// Use this for initialization
	void Start () {
		Disks = new Stack<Disk>();
		Stick = this.gameObject;
		TowerHeight = Stick.GetComponent<RectTransform>().rect.height;
		DiskMaxHeight = DiskPrefab.GetComponent<RectTransform>().rect.height;
		DiskMaxWidth = DiskPrefab.GetComponent<RectTransform>().rect.width;
		DiskMinWidth = DiskMaxWidth / 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/// <summary>
/// Очистить башню, удалив физически из нее все диски.
/// </summary>
	public void ClearTower () {
		while (Count > 0) {
			Disk temp = RemoveDisk ();
			if (temp != null)
				Destroy (temp.gameObject);
			}
	}

/// <summary>
/// Creates the initial tower.
/// Создает башню из заданного кол-ва дисков, копируя из префаба, с выбором случайного цвета.
/// </summary>
/// <param name="k">K.</param>
	public void CreateInitialTower (int k) {
	//	SetTower (k);
		for (int i = 1; i <= k; i++) {
			Disk temp = Instantiate (DiskPrefab);
			temp.name += i.ToString();
			temp.GetComponent<Image>().color = UnityEngine.Random.ColorHSV ();

			PlaceDisk (temp);
			}
	}

/// <summary>
/// Задаем параметры башни, которые влияют на размеры дисков.
/// </summary>
/// <param name="k">K.</param>
	public void SetTower (int k) {
		if (TowerHeight / k < DiskMaxHeight)
			Hstep = (TowerHeight/k);
		else
			Hstep = DiskMaxHeight;
		Wstep = (DiskMaxWidth - DiskMinWidth) / k;
	}

/// <summary>
/// Добавляем диск в стек башни.
/// </summary>
/// <param name="disk">Disk.</param>
	private void AddDisk (Disk disk) {
		Disks.Push (disk);	
		Count = Disks.Count;
	}

/// <summary>
/// Убираем диск из стека, возвращаем ссылку на объект.
/// </summary>
/// <returns>The disk.</returns>
	public Disk RemoveDisk () {
		Disk d = Disks.Pop ();
		Count = Disks.Count;
		return d;
	}

/// <summary>
/// Размещаем диск в башне. Высота и ширина подбираются в соответствии с кол-вом дисков, чтобы получилась пирамида.
/// Диск перемещается со старого места в новые координаты своего места в башне.
/// </summary>
/// <param name="disk">Disk.</param>
	public void PlaceDisk (Disk disk) {
		int k = Count;
		float x, y, width, height;

		AddDisk (disk);

        // инициализируем диск
		width = DiskMaxWidth - k * Wstep;
		height = Hstep;
		disk.Set (MainDisplay, Stick, width, height);

		// двигаем диск
		x = Stick.transform.position.x;
		y = Stick.transform.position.y + k * Hstep - TowerHeight / 2;
		disk.MoveTo (x, y);
	}


}
}
