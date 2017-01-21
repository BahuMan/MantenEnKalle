using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class BaseWaveFormRenderer : MonoBehaviour {

	private MeshRenderer myRenderer;
	private MeshFilter myMeshFilter;
	protected Mesh mesh;

	// CONFIGURATION OF THE FORM
	public int stepsconfig = 50;
	private int steps;

	public float width = 3;

	public float uvxrepeat = 5;
	public float uvyrepeat = 2;

	// Data structure
	private int[] triangles;
	private Vector3[] vertices;
	private Vector2[] uvs;

	// Use this for initialization
	void Start () {
	}

	public void InitMesh () {
		myRenderer = GetComponent<MeshRenderer> ();
		myMeshFilter = GetComponent<MeshFilter> ();
		mesh = new Mesh ();

		// Make the mesh arrays
		steps = stepsconfig;
		vertices = new Vector3[(steps+1)*2];
		triangles = new int[steps*6];

		for (int i = 0; i < steps; i++) {
			int topleft = i*2;
			int bottomleft = i*2+1;
			int topright = (i+1)*2;
			int bottomright = (i+1)*2+1;
			triangles[i*6] = topleft;
			triangles[i*6+1] = topright;
			triangles[i*6+2] = bottomright;
			triangles[i*6+3] = topleft;
			triangles[i*6+4] = bottomright;
			triangles[i*6+5] = bottomleft;
		}

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		myMeshFilter.mesh = mesh;

		// Fill in the uv also
		uvs = new Vector2[(stepsconfig + 1)*2];
		for (int i = 0; i < steps; i++) {
			float x = uvxrepeat * i / steps;
			uvs [i * 2] = new Vector2 (x, 0);
			uvs[i*2+1] = new Vector2 (x, -1);
		}
		mesh.uv = uvs;
	}

	/**
	 * Returns two floats
	 *  => x = bottom of wave
	 *  => y = top of wave
	 */
	public delegate Vector2 GetUpDown(float t);

	public void UpdateWave(GetUpDown waveDef) {
		for (int i = 0; i < steps+1; i++) {
			float x = -width/2 + (width * i / steps);

			float t = i*1f / steps;

			Vector2 waverange = waveDef(t);

			vertices[i*2] = new Vector3(x, waverange.y, 0);
			vertices[i*2+1] = new Vector3(x, waverange.x, 0);
		}
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;
	}
}
