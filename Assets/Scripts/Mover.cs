using UnityEngine;
using System.Collections;

/// <summary>
/// Mover. Responsible for moving
/// rigid bodies based on speed.
/// </summary>
public class Mover : MonoBehaviour
{
	private Rigidbody rb = null;
	public float speed = 1.0f;

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}

