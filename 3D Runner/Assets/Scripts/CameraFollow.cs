using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	[SerializeField] float camDistance;
	[SerializeField] float camHeight;
	[SerializeField] float targetHeight;
	[SerializeField] float smoothing;
    [SerializeField] Transform target;

    void Reset()
    {
        camDistance = 2.5f;
        camHeight = 2.5f;
        smoothing = 5f;
        targetHeight = 1.5f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void LateUpdate()
	{
		float newRotation = Mathf.LerpAngle(transform.eulerAngles.y , target.eulerAngles.y , smoothing * Time.deltaTime);
		Quaternion currentRotation = Quaternion.Euler(0f , newRotation , 0f);
		
		Vector3 pos = target.position;
		pos -= currentRotation * Vector3.forward * camDistance;
		pos.y = camHeight;
		transform.position = pos;
		
		transform.LookAt(target.position + new Vector3(0f , targetHeight , 0f));
	}
}
