using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMissionManager : MonoBehaviour
{
    [SerializeField] List<ObjectMove> objectMoveList = new List<ObjectMove>();
    [SerializeField] List<ObjectOpen> objectOpenList = new List<ObjectOpen>();

    private void Start()
    {
        ObjectOpen[] objectOpenScripts = FindObjectsOfType<ObjectOpen>();
        ObjectMove[] objectMoveScripts = FindObjectsOfType<ObjectMove>();

        objectOpenList.AddRange(objectOpenScripts);
        objectMoveList.AddRange(objectMoveScripts);
    }

    public bool AreAllObjectsClosed()
    {
        foreach (ObjectMove move in objectMoveList)
        {
            if (move.isOpen)
            {
                return false;
            }
        }

        foreach (ObjectOpen open in objectOpenList)
        {
            if (open.isOpen)
            {
                return false;
            }
        }

        return true;
    }

    void CheckAllObjects()
    {
        if (AreAllObjectsClosed())
        {
            
            Debug.Log("Todos los objetos est�n cerrados.");
        }
        else
        {
            
            Debug.Log("Al menos un objeto est� abierto.");
        }
    }

    void CheckForDessertTime()
    {
        // Aqu� debes verificar si el �tem "Dessert" est� en el inventario.
        // Puedes hacer esto de la manera que tengas implementado tu sistema de inventario.
        // Supongamos que tienes una clase de inventario llamada "InventoryManager" que tiene un m�todo "HasItem".

        if (InventoryManager.Instance.HasItem(ObjectType.Dessert))
        {
            // Realiza la acci�n si tienes el �tem "Dessert" en el inventario.
            Debug.Log("�Tienes el �tem 'Dessert' en el inventario!");
        }
        else
        {
            Debug.Log("No tienes el �tem 'Dessert' en el inventario.");
        }
    }

    void FasterDetective()
    {
        float currentTime = Timer.Instance.currentTime;
        float totalTime = ((int)GameManager.instance.actualdifficulty);
        float fiftyPercentOfTotal = totalTime * 0.5f;

        if (currentTime > fiftyPercentOfTotal)
        {
            Debug.Log("El tiempo restante es superior al 50% del total.");
        }
        else
        {
            Debug.Log("El tiempo restante es igual o inferior al 50% del total.");
        }
    }

    public void FinalCheck()
    {
        CheckAllObjects();
        CheckForDessertTime();
        FasterDetective();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FinalCheck();
        }
    }
}
