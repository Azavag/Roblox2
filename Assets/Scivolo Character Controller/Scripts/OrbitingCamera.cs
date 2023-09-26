using UnityEngine;
using UnityEngine.XR;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class OrbitingCamera : MonoBehaviour
    {
        public Transform target;

        public float verticalOffset = 0f;

        public float distance = 5f;

        public float sensitivity = 100f;

        private float yRot = 0f;

        private float xRot = 20f;
        Vector2 touchStart, touchEnd;
        private Rect swipeZone;
        public float swipeZonePercentage = 0.75f;


        private void Start()
        {
#if UNITY_EDITOR
            // Somehow after updating to 2019.3, mouse axes sensitivity decreased, but only in the editor.
            sensitivity *= 10f;
#endif

            // Определите границы зоны, в которой свайпы не будут засчитываться
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float zoneWidth = screenWidth * swipeZonePercentage;
            float zoneHeight = screenHeight * swipeZonePercentage;
            float zoneX = (screenWidth - zoneWidth) * 0.5f;
            float zoneY = (screenHeight - zoneHeight) * 0.5f;
            swipeZone = new Rect(zoneX, zoneY, zoneWidth, zoneHeight);
        }

        private void LateUpdate()
        {
            yRot += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            xRot -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            
            xRot = Mathf.Clamp(xRot, 0f, 75f);



            if (Input.touchCount == 1) // Если есть одно касание на экране
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStart = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved && swipeZone.Contains(touchStart))
                {
                    touchEnd = touch.position;
                    float touchDeltaX = (touchEnd.x - touchStart.x)  * Time.deltaTime;
                    float touchDeltaY = -(touchEnd.y - touchStart.y)  * Time.deltaTime;
                    xRot += touchDeltaY;
                    yRot += touchDeltaX;
                    
                }
            }



            Quaternion worldRotation = transform.parent != null ? transform.parent.rotation : Quaternion.FromToRotation(Vector3.up, target.up);
            Quaternion cameraRotation = worldRotation * Quaternion.Euler(xRot, yRot, 0f);
            Vector3 targetToCamera = cameraRotation * new Vector3(0f, 0f, -distance);

            transform.SetPositionAndRotation(target.TransformPoint(0f, verticalOffset, 0f) + targetToCamera, cameraRotation);
        }
    }
}
