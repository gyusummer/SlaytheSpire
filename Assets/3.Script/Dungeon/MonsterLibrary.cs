using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLibrary : Singleton<MonsterLibrary>
{
	[SerializeField]
	private GameObject slime_Prefabs;
	public GameObject Slime_Prefabs => slime_Prefabs;
}
