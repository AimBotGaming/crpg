using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float Strength, Dexterity, Vitality, Charisma, Wisdom;
	public float Health, Stamina, Faith;

	public Transform LeftHandHold, RightHandHold;

	[System.NonSerialized]
	public GameObject Weapon;

	[System.NonSerialized]
	public WeaponsList killingList = new WeaponsList();

	void Start()
	{
		killingList.Initialize ();
		Weapon = (GameObject) Instantiate (Resources.Load (killingList._swords ["shortSword1"].path));
		Weapon.transform.parent = RightHandHold;
		Weapon.transform.position = RightHandHold.position + killingList._swords["shortSword1"].offset;
	}

}