using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public List<WeaponController> ArmasIniciales= new List<WeaponController>();

    public Transform weaponParentSocket;
    public Transform defaultWaponPosition;
    public Transform AimingPosition;

    public int activeWeaponIndex { get; private set; }

    private WeaponController[] weaponSlots = new WeaponController[3];

    // Start is called before the first frame update
    void Start()
    {
        activeWeaponIndex = -1;

        foreach (WeaponController ArmasIniciales in ArmasIniciales)
        {
            AddWeapon(ArmasIniciales);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }
    }

    private void CambiarArma(int p_waponIndex)
    {
        if (p_waponIndex != activeWeaponIndex && p_waponIndex >= 0)
        {
            weaponSlots[p_waponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_waponIndex;
        }
    }

    private void AddWeapon(WeaponController p_waponPrefab)
    {
        weaponParentSocket.position = defaultWaponPosition.position;

        //Añadir arma al player, pero no se muestra.

        for (int i = 0; i<weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
            {
                WeaponController weaponClone = Instantiate(p_waponPrefab, weaponParentSocket);
                weaponClone.gameObject.SetActive(false);


                weaponSlots[i] = weaponClone;
                return;
            }
        }
    }
}
