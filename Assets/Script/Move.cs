using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move : Joystick {
    void Update() {
        Vector3 moveVector = new Vector3(moveDelta.x, moveDelta.y, 0);
        if (moveDelta.magnitude != 0) {
            player.transform.position += moveVector / Mathf.Sqrt(moveVector.magnitude) / 2500;
        }
    }
    override public void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        moveDelta = Vector2.zero;
    }
}
