using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shoot : Joystick {
    public Transform projectile;
    void Update() {
        player.transform.rotation = Quaternion.FromToRotation(new Vector3(0, 1), -moveDelta);
    }
    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        projectile.GetComponent<SpriteRenderer>().enabled = false;
        Rigidbody2D bulletInstance = Instantiate(projectile.GetComponent<Rigidbody2D>(),
            projectile.transform.position,
            Quaternion.FromToRotation(new Vector3(0, 1), -moveDelta)) as Rigidbody2D;
        bulletInstance.GetComponent<SpriteRenderer>().enabled = true;
        bulletInstance.transform.localScale = projectile.lossyScale;// / 10;
        bulletInstance.AddForce(-moveDelta * 3);
    }

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        projectile.GetComponent<SpriteRenderer>().enabled = true;
    }
}
