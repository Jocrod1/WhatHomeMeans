using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	//what are we following
	public Transform target;

	//zeros out the veolocity
	Vector3 velocity = Vector3.zero;

    public Vector3 Offset;

	// time to follow target
	public float smoothTime = .50f;


    void Start() {
    
    }

	void FixedUpdate()
	{
		//target position
        if(!Damaged)
		    targetPos = target.position;
		//align the camera and the targets z position
        //using smooth damp we will gradually change the camera transform position to the target position based on the camera transform velocity and out smooth time
        if (Isfade) {
            Isfade = false;
            transform.position = target.position + Vector3.forward * -8.76f;
        }
        //else if (Shaking)
          //  OriginalPos = Vector3.SmoothDamp(transform.position, targetPos + Offset, ref velocity, smoothTime);
        else 
            transform.position = Vector3.SmoothDamp(transform.position, targetPos + Offset, ref velocity, smoothTime);

	}
    public bool Shaking;

    public bool Isfade = false;

    public Vector3 OriginalPos;

    public IEnumerator Shake(float duration, float magnitude){

        GameObject Cam = Camera.main.gameObject;
        OriginalPos = Cam.transform.localPosition;

        float elapsed = 0f;

        Shaking = true;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Cam.transform.localPosition = new Vector3(OriginalPos.x + x, OriginalPos.y + y, OriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Shaking = false;

        Cam.transform.localPosition = OriginalPos;

    }

    public Vector3 targetPos;

    public bool Damaged { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration">duration of the force</param>
    /// <param name="Magnitude">how much is going to go(sign is the direction)</param>
    /// <returns></returns>
    public IEnumerator DamageForce(float duration, float Magnitude) {
        GameObject Cam = Camera.main.gameObject;
        Vector3 OriginalPos = Cam.transform.localPosition;

        Damaged = true;

        targetPos = new Vector3(target.localPosition.x + 1f * Magnitude, targetPos.y, targetPos.z);

        yield return new WaitForSeconds(duration);

        Damaged = false;


    }

    public void GetDamage(float ShakeDuration, float ShakeMagnitude, float ForceDuration, float ForceMagnitude) {
        StartCoroutine(Shake(ShakeDuration, ShakeMagnitude));
        StartCoroutine(DamageForce(ForceDuration, ForceMagnitude));
    }
}