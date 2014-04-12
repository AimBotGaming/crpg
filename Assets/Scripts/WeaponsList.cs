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
        AddSword("shs1", new Vector3(0.05f, -0.01f, 0.0f));
	}

	public void AddSword(string path, Vector3 off)
	{
		Sword temp = new Sword();
		temp.path = path;
		temp.offset = off;

		_swords [path] = temp;
	}
}
