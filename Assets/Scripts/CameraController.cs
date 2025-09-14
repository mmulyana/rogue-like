using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float moveSpped;

    public Transform target;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), moveSpped * Time.deltaTime);
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
