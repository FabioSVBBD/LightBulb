using UnityEngine;
using System.Collections;

public class GrappleInputManager : MonoBehaviour {
	
	GrappleScript grapple;
	public Camera cam;

	public float angleStep = 1;
	/* The angle around the target that the rope can attach to
	 * i.e 90 means 90 degrees clockwise + 90 counter clockwise.*/
	[Range(0.0f,360.0f)]
	public float angleTolerance = 90;
	private bool isAttached = false;

	public AudioSource hookSound;
	
	void Start()
	{
		grapple = GetComponent<GrappleScript>();
		cam = Camera.main;
	}
	
	void Update()
	{
		UpdateInput();
	}
	
	private void UpdateInput () {
		if(Input.GetMouseButtonDown(0))
		{
			if (isAttached)
            {
				grapple.ReleaseRope();
				isAttached = false;
				return;
			}

			// Find mouse position
			Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6);
			Vector2 mouseClick = cam.ScreenToWorldPoint(mouseInput);

			// Find ray direction and raycast
			Vector2 rayDirection = mouseClick - (Vector2)this.transform.position;
            bool didHit = Physics.Raycast((Vector3)this.transform.position, rayDirection, out RaycastHit hit, grapple.grapplingHookRange, ~(1 << grapple.playerLayer));
            float angle = angleStep;
			Quaternion rot;

			// If the raycast does not hit anything, loop raycast until object is hit
			while (hit.collider == null && angle < angleTolerance)
			{
				rot = Quaternion.AngleAxis(angle, Vector3.forward);
				Physics.Raycast((Vector3)this.transform.position, rot * rayDirection, out hit, grapple.grapplingHookRange, ~(1 << grapple.playerLayer));

				if (hit.collider != null)
					break;

				rot = Quaternion.AngleAxis(-angle, Vector3.forward);
				Physics.Raycast((Vector3)this.transform.position, rot * rayDirection, out hit, grapple.grapplingHookRange, ~(1 << grapple.playerLayer));
				angle += angleStep;

			}
			// if something is hit, and that is not the player
			if (hit.collider != null && hit.collider.gameObject.layer != grapple.playerLayer)
			{
				hookSound.Play();
				grapple.AttachRope(hit.point);
			}

			isAttached = true;
		}

		// Setting reeling and paying out
		grapple.reeling_in = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
		grapple.paying_out = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);


	}
}
