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
        Rect blockZone1;
        Rect blockZone2;
        [SerializeField] Transform joystickRect;
        [SerializeField] Transform jumpButtonRect;
        [SerializeField] float mobileCameraSens = 12f;
        bool isTouch;
        bool isMobile;
        
        private void Start()
        {
#if UNITY_EDITOR
            // Somehow after updating to 2019.3, mouse axes sensitivity decreased, but only in the editor.
            sensitivity *= 10f;
#endif         
            
        }

        private void FixedUpdate()
        {
            var joystickRectTransform = joystickRect.GetComponent<RectTransform>();
            blockZone1 = new Rect(new Vector2(0, 0), joystickRectTransform.sizeDelta + new Vector2(50, 50));
            blockZone1.center = new Vector2(joystickRect.position.x, joystickRect.position.y);

            var jumpButtonRectTransform = jumpButtonRect.GetComponent<RectTransform>();
            blockZone2 = new Rect(new Vector2(0, 0), jumpButtonRectTransform.sizeDelta + new Vector2(50, 50));
            blockZone2.center = new Vector2(jumpButtonRect.position.x, jumpButtonRect.position.y);
        }
        private void LateUpdate()
        {
            if (!isMobile)
            {
                yRot += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
                xRot -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            }
            else
            {
                if (Input.touchCount == 1) // Если есть одно касание на экране
                {
                    Touch touch = Input.GetTouch(0);

                    if ((touch.phase == TouchPhase.Began && !blockZone1.Contains(touch.position))
                        && (touch.phase == TouchPhase.Began && !blockZone2.Contains(touch.position)))
                    {
                        touchStart = touch.position;
                        isTouch = true;
                    }
                    else if (isTouch && touch.phase == TouchPhase.Moved)
                    {
                        touchEnd = touch.position;
                        float touchDeltaX = (touchEnd.x - touchStart.x) * mobileCameraSens * Time.deltaTime;
                        float touchDeltaY = -(touchEnd.y - touchStart.y) * mobileCameraSens * Time.deltaTime;
                        xRot += touchDeltaY;
                        yRot += touchDeltaX;
                        touchStart = touchEnd;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                        isTouch = false;
                }
            }
            xRot = Mathf.Clamp(xRot, 0f, 75f);

            
            Quaternion worldRotation = transform.parent != null ? transform.parent.rotation : Quaternion.FromToRotation(Vector3.up, target.up);
            Quaternion cameraRotation = worldRotation * Quaternion.Euler(xRot, yRot, 0f);
            Vector3 targetToCamera = cameraRotation * new Vector3(0f, 0f, -distance);

            transform.SetPositionAndRotation(target.TransformPoint(0f, verticalOffset, 0f) + targetToCamera, cameraRotation);
        }

        public void SetMobile(bool state)
        {
            isMobile = state;
        }
    }
    
}
