using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerEquipment playerEquipment;
    public Camera mainCamera;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button clicked!");
            ThrowWeaponAtMouseClick();
        }
    }
    
    void ThrowWeaponAtMouseClick()
    {
        Bomb bomb = playerEquipment.currentWeapon.GetComponent<Bomb>();
        if (bomb != null)
        {
            Debug.Log("Kaster en bombe!");

            // Start eksplosjonstimer på bomben
            bomb.Invoke(nameof(bomb.Explode), bomb.explosionDelay);
        }
            // Få verdensposisjon av museklikket
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f; // Sikre at z-posisjonen er 0

            // Beregn retningen fra spillerens posisjon til museklikket
            Vector2 direction = (mouseWorldPosition - playerEquipment.weaponHolder.position).normalized;

            // Kall ThrowWeapon med beregnet retning
            playerEquipment.ThrowWeapon(direction);
        }
    }
