using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSaves : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        ManageSaves scriptSaveManagement = Resources.LoadAll<GameObject>("Prefabs/@GameToolsManagement")[0].GetComponent<ManageSaves>();
        scriptSaveManagement.Init();
    }
}
