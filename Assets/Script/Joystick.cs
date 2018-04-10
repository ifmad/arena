using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image backgroundImage;
    public Image joystickImage;
    public Transform player;
    protected Vector2 moveDelta;
    private float movementSpeed = 1.0f;

    void Start() {
        moveDelta = Vector3.zero;
        backgroundImage = GetComponent<Image>();
    }

    private Vector3 calculateMoveDelta() {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        return new Vector3(x, y, 0) * movementSpeed * Time.deltaTime;
    }

    public void OnDrag(PointerEventData eventData) {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out moveDelta)) {
            if (moveDelta.magnitude > 45) { moveDelta = moveDelta.normalized * 45; }
            dragJoystickImage(moveDelta);
        }
    }

    virtual public void OnPointerUp(PointerEventData eventData) {
        dragJoystickImage(Vector2.zero);
    }

    virtual public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    private void dragJoystickImage(Vector2 anchorDelta) {
        joystickImage.rectTransform.anchoredPosition = anchorDelta;
    }
}
