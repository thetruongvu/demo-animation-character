using UnityEngine;

public class WeaponHand : MonoBehaviour
{
    [SerializeField] GameObject[] weaponPrefabs;

    int curIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SwapWeapon();
        }
    }

    void SwapWeapon()
    {
        curIndex++;
        if (curIndex >= weaponPrefabs.Length)
        {
            curIndex = 0;
        }
        Transform heldWeapon = transform.Find("Weapon");
        if (heldWeapon)
        {
            Destroy(heldWeapon.gameObject);
        }

        GameObject goSwap = Instantiate(weaponPrefabs[curIndex], transform.position, Quaternion.identity, transform) as GameObject;
        goSwap.name = "Weapon";
    }
}
