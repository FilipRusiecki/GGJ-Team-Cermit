using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollow : MonoBehaviour
{
	public float speed = 15f;
	public GameObject target;
	public Vector3 offset;
	private Vector3 targetPos;
	public Camera cam;

	[Header("Shake multiplier")]
	public bool shake = false;
	public float shakeMultiplier;
	public float shakeExtendor;
	// Use this for initialization
	/// <summary>
	/// Initialises the camera to the targetPos(the player)
	/// </summary>
	void Start() { cam = GetComponent<Camera>(); targetPos = transform.position; }

	/// <summary>
	/// Adds lerp to the targetPos
	/// Starts coRountines for Zoomin, Zoomout and shake the camera
	/// </summary>
	void Update()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position + offset;
			Vector3 targetDirection = (target.transform.position - posNoZ);
			float interpVelocity = targetDirection.magnitude * speed;
			targetPos = (transform.position) + (targetDirection.normalized * interpVelocity * Time.deltaTime);
			transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);
		}
	
		if (shake == true) { StartCoroutine(shakeCam(shakeMultiplier)); }
	}


	/// <summary>
	/// Shakes the camera by adding small amount or random change * the shake multiplier a few times
	/// </summary>
	/// <param name="shakeMultiplier"></param>
	/// <returns></returns>
	IEnumerator shakeCam(float shakeMultiplier)
	{
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		yield return new WaitForSeconds(shakeExtendor);
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		yield return new WaitForSeconds(shakeExtendor);
		transform.localPosition = cam.transform.position + Random.insideUnitSphere * shakeMultiplier;
		shake = false;
	}
}