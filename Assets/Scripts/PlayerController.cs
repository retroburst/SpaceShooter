using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a boundary.
/// </summary>
[System.Serializable]
public class Boundary
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

/// <summary>
/// Player controller. Responsible for
/// reacting to player input and controlling
/// the player game object with respect to
/// input.
/// </summary>
public class PlayerController : MonoBehaviour
{
	private const string INPUT_FIRE = "Fire1";
	private const string AXIS_HORIZONTAL = "Horizontal";
	private const string AXIS_VERTICAL = "Vertical";
	private Rigidbody rb = null;
	private AudioSource audioWeaponFire = null;
	public float Speed = 0.0f;
	public Boundary boundary = null;
	public float tilt = 0.0f;
	public GameObject shot = null;
	public Transform shotSpawn = null;
	private float nextFire = 0.0f;
	public float fireRate = 0.5f;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		audioWeaponFire = GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		if (Input.GetButton (INPUT_FIRE) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
			audioWeaponFire.Play ();
		}
	}
	
	/// <summary>
	/// Fixeds update for physics calculations.
	/// </summary>
	private void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis (AXIS_HORIZONTAL);
		float moveVertical = Input.GetAxis (AXIS_VERTICAL);
		rb.velocity = (new Vector3 (moveHorizontal, 0.0f, moveVertical) * Speed);
		float newX = Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax);
		float newY = Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax);
		rb.position = new Vector3 (newX, 0.0f, newY);
		rb.rotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, rb.velocity.x * -tilt));
	}

}
