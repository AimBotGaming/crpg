using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Klasa przechwująca wszystkie obiekty bedące bronią, klasyfikująca je co do obrażeń, wytrzymałości
 * wymagań, nazwy, buffów. 
 **/

public class Sword
{
	public string path;
	public Vector3 offset;
}

public class WeaponsList : MonoBehaviour
{
	public Dictionary<string, Sword> _swords = new Dictionary<string, Sword>();

	public void Initialize()
	{
		AddSword("shortSword1");
	}

	public void AddSword(string path)
	{
		Sword temp = new Sword();
		temp.path = path;
		temp.offset = new Vector3(0.09f, -0.04f, 0.1f);

		_swords ["shortSword1"] = temp;
	}
}
