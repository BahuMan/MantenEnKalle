using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSortingLayer : MonoBehaviour {

	public string sortingLayer;
	public int orderInLayer;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().sortingLayerName = sortingLayer;
		GetComponent<Renderer> ().sortingOrder = orderInLayer;
	}
}
