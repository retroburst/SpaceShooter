using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy by time.
/// Destroys game objects based
/// on a given lifetime. 
/// </summary>
public class DestroyByTime : MonoBehaviour
{
	public float lifetime;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		Destroy (gameObject, lifetime);
	}
	
}
