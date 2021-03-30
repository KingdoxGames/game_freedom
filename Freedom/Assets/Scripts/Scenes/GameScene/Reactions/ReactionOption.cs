#region Access
using System.Collections;
using UnityEngine;
using Environment;
using XavHelpTo.Look;
#endregion
/// <summary>
/// Active this only before an <see cref="ReactionDialog"/>
/// </summary>
public class ReactionOption : Reaction
{
    #region Variables
    [Header("Options")]
    public string[] keysOption;
    public Transform tr_parent;

    #endregion
    #region Events
    public override void OnDrawGizmos()
    {
        name = $"Option: ({waiTime} s) -> ";

        //moreLength = moreLength.le
        if (keysOption.Length > Data.OPTIONS_MAX_QTY){

            name += " (ERR : exceeded) ";
        }else{

            foreach (string i in keysOption) name += $" ({i}) ";

            if (keysOption.Length.Equals(0)) name += $" VOID ";
        }

        name += debug_information;

    }
    #endregion
    #region Methods
    protected override void React()
    {
        //base.React();
        //mostramos los botones
        Modal.DisplayOptions(true, true);
        Modal.SetTexts(keysOption);
        // set the texts to shows the options
    }

    protected override IEnumerator WaitReact()
    {
        int response = -1;

        //Si no ha escogido
        while (response.Equals(-1))
        {
            //actualizamos la respuesta cuando esta llegue
            response = Modal.CheckResponse();
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();


        Transform tr = tr_parent.GetChild(response);
        GameObject obj = tr.gameObject;

        obj.SetActive(false);
        obj.SetActive(false);
        yield return new WaitForEndOfFrame();

        //ejecuta lo normal
        yield return StartCoroutine(base.WaitReact());
    }

    #endregion
}
