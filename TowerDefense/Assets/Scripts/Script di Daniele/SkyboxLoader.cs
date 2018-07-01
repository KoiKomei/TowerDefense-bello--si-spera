using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxLoader : MonoBehaviour {

    [SerializeField] private Material sky;
	// Use this for initialization
	void Awake () {

        RenderSettings.skybox = sky;
        
	}
	
	
}
