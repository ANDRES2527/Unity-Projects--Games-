﻿using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	
	void Start () {
        DataManagement.dataManagement.currentScore = 0;
        DataManagement.dataManagement.LoadData();
	}
	
}
