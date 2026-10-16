using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target_p; 
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private Vector3 Offset = new Vector3(0, 1.5f, 0); 

    [SerializeField] private float sensitivityX = 4.0f;
    [SerializeField] private float sensitivityY = 2.0f;
    [SerializeField] private float minYAngle = -20.0f;
    [SerializeField] private float maxYAngle = 60.0f;

    private float currentX = 0.0f;
    private float currentY = 20.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (target_p != null)
        {
            currentX = target_p.transform.eulerAngles.y;
        }
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        if (target_p == null) return;

        Quaternion camRotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 positionOffset = camRotation * new Vector3(0, 0, -distance);

        transform.position = target_p.transform.position + Offset + positionOffset;
        transform.LookAt(target_p.transform.position + Offset);

        //rotacion
        //target_p.rotation = Quaternion.Euler(0f, currentX, 0f);
        target_p.GetComponent<PlayerMovement>().RotateCharacter(currentX);
    }
}