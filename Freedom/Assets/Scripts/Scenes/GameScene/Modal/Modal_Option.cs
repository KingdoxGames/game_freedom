#region Access
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
using XavHelpTo.Look;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo.Set;
using Environment;
#endregion

public partial class Modal {
    #region Variable
    private Button[] btn_options;
    private TextTranslationController[] controllers;
    private CanvasGroup canvas_parent_options;
    private int response = -1;
    [Header("_Options")]
    public Transform tr_options;// parent of buttons
    #endregion
    #region Partial Actions
    /// <summary>
    /// Based on the <see cref="tr_options"/> finds and set in <see cref="controllers"/> the childs of <seealso cref="TextTranslationController"/>
    /// </summary>
    partial void StartOptions(){
        response = -1;
        // recogemos el padre del canvas
        tr_options.parent.Component(out canvas_parent_options);

        int qty = Data.OPTIONS_MAX_QTY;
        qty.NewIn(out btn_options);
        qty.NewIn(out controllers);

        tr_options.Components(out btn_options);

        for (int x = 0; x < qty; x++)
        {
            tr_options.GetChild(x).Component(out btn_options[x]);

            btn_options[x]
                .transform
                .GetChild(0).GetChild(0)
                .Component(out controllers[x], false);
        }

    }
    #endregion
    #region Method
    /// <summary>
    /// Shows the options, can appear in solo
    /// </summary>
    public static void DisplayOptions(bool wantDisplay, bool soloAppear = false){
        _.canvas_parent_options.alpha = wantDisplay.ToInt();

        int alpha = (!soloAppear).ToInt();

        //poder ocultar name, text opyions y continueSign?
        _.canvas_name.alpha = alpha;
        _.canvas_text.alpha = alpha;
        _.canvas_continueSign.alpha = alpha;
        _.canvas_img_namechat.alpha = alpha;

        DisplayModal(wantDisplay);
    }
    /// <summary>
    /// Response of an button when any was been pressed
    /// </summary>
    public void PressedButton(int i){
        if (_.canvas_parent_options.alpha.Equals(0)) return; // 🛡 Patch
        //Debug.Log("Boton presionado = " + i);
        _.canvas_parent_options.alpha = 0;
        DisplayModal(false);
        _.response = i;
    }
    /// <summary>
    /// Dependiendo de la cantidad de 
    /// </summary>
    public static void SetTexts(params string[] optionsKey) => _._SetTexts(optionsKey);
    private void _SetTexts(params string[] optionsKey){

        for (int i = 0; i < controllers.Length; i++){

            bool condition = i.IsOnBounds(optionsKey);
            GameObject obj = tr_options.GetChild(i).gameObject;

            obj.SetActive(true);
            if (condition){
                controllers[i].key = optionsKey[i];
                controllers[i].RefreshText();

            }
            else{
                controllers[i].ClearText();
            }
            obj.SetActive(condition);

        }
        
    }


    /// <summary>
    /// Shows the status actual, if exist a change returns the value and set in -1(default in this case)
    /// </summary>
    public static int CheckResponse(){
        int val =  _.response;
        if (!_.response.Equals(-1)) _.response = -1;
        return val;
    }
    #endregion
}