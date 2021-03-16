#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
#endregion
/// <summary>
/// Este script se encargara del manejo de 3 acciones:
/// - los dialogos
/// - los objetos
/// - Cambios a otros Actos/Eventos/partes, etc
/// </summary>
public class EventManager : MonoBehaviour
{
    #region Variables
    private static  EventManager _;
    #endregion
    #region Event
    private void Awake()
    {
        this.Singleton(ref _,false);
    }
    #endregion
    #region
    #endregion


}

//FLUJO => Interactable => EventManager => Dialog/Item/Event/act