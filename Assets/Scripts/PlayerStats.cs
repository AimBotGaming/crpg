using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float Strength, Dexterity, Vitality, Charisma, Wisdom;
	public float Health, Stamina, Faith;

	public Transform LeftHandHold, RightHandHold;

	[System.NonSerialized]
	public GameObject Weapon;

	[System.NonSerialized]
	public WeaponsList _weaponsList;

	void Awake()
	{
		_weaponsList = gameObject.AddComponent<WeaponsList> ();
	}

	void Start()
	{
		_weaponsList.Initialize ();
		Weapon = (GameObject) Instantiate (Resources.Load (_weaponsList._swords ["shortSword1"].path));
		Weapon.transform.parent = RightHandHold;
		Weapon.transform.localPosition = _weaponsList._swords["shortSword1"].offset;
		Weapon.transform.localRotation = Quaternion.Euler (0.0f, -90.0f, 0.0f);
	}

}