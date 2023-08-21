using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SimpleShooty.Player
{
    public class VirtualJoyStickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image joyStickBGImg, joyStickImg;
        [SerializeField] private float one, three;

        private Vector2 joyStickInput;

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                joyStickBGImg.rectTransform, eventData.position,
                eventData.pressEventCamera, out joyStickInput))
            {
                joyStickInput.x = joyStickInput.x / joyStickBGImg.rectTransform.sizeDelta.x;
                joyStickInput.y = joyStickInput.y / joyStickBGImg.rectTransform.sizeDelta.y;

                if(joyStickInput.magnitude > one)
                {
                    joyStickInput = joyStickInput.normalized;
                }

                joyStickImg.rectTransform.anchoredPosition = new Vector2(
                    joyStickInput.x * (joyStickBGImg.rectTransform.sizeDelta.x / three),
                    joyStickInput.y * (joyStickBGImg.rectTransform.sizeDelta.y / three));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            joyStickInput = Vector2.zero;
            joyStickImg.rectTransform.anchoredPosition = Vector2.zero;
        }

        public float GetHorizontalInput()
        {
            return joyStickInput.x;
        }

        public float GetVerticalInput()
        {
            return joyStickInput.y;
        }
    }
}