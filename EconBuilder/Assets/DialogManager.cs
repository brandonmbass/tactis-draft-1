using System.Collections;
using System.Collections.Generic;
using Truncon.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog {
    public string Text { get; set; }
    public OrderedDictionary<string, DialogResult> Options = new OrderedDictionary<string, DialogResult>();
}

public class DialogResult
{
    public static DialogResult Res0 = new DialogResult { Result = 0 };
    public static DialogResult Res1 = new DialogResult { Result = 1 };

    public int Result;
    public Dialog ResultDialog;
}

public class DialogManager : GlobalBehavior {
    // Lets a dialog reference itself
    private static DialogResult SelfReference = new DialogResult { };

	void Start () {
        //BrandonIsATool = new Dialog
        //{
        //    Text = "I've been a blacksmith all my life, so I know tools. And Brandon is DEFINITELY a tool.",
        //    Options = {
        //    { "He sure is! ", DialogResult.Res0 },
        //    { "I don't think that's right...", new DialogResult { ResultDialog = new Dialog
        //            {
        //                Text = "...are you sure? I'm pretty confident he's a tool.",
        //                Options =
        //                {
        //                    { "Yep, definitely not a tool.", SelfReference},
        //                    { "You are the expert. Brandon is a tool.", null }
        //                }
        //            }
        //        }
        //    }
        //}
        //};
    }

    public void RunDialog(Dialog dialog, CharacterBase character)
    {
        // TODO: return a result, somehow (hard because this is async)
        UIManager.DialogContainer.gameObject.SetActive(true);
        UIManager.DialogText.GetComponent<Text>().text = dialog.Text;
        UIManager.DialogImage.GetComponent<Image>().sprite = character.Portrait;
        UIManager.DialogAnswer1Text.GetComponent<Text>().text = dialog.Options.GetKey(0);
        UIManager.DialogAnswer2Text.GetComponent<Text>().text = dialog.Options.GetKey(1);
        UIManager.DialogAnswer1.GetComponent<Button>().onClick.AddListener(() => {
            var result = dialog.Options[0];
            if (result.ResultDialog == null && result != SelfReference)
            {
                // Somehow save result result.Result
                UIManager.DialogContainer.gameObject.SetActive(false);
                return;
            }

            // Run sub-dialog
            RunDialog(result == SelfReference ? dialog : result.ResultDialog, character);
        });

        UIManager.DialogAnswer2.GetComponent<Button>().onClick.AddListener(() => {
            var result = dialog.Options[1];
            if (result.ResultDialog == null && result != SelfReference)
            {
                // Somehow save result result.Result
                UIManager.DialogContainer.gameObject.SetActive(false);
                return;
            }

            // Run sub-dialog
            RunDialog(result == SelfReference ? dialog : result.ResultDialog, character);
        });

    }

    // All dialogs go here; will need to break out for organization sake at some point perhaps
    public static Dialog BrandonIsATool = new Dialog {
        Text = "I've been a blacksmith all my life, so I know tools. And Brandon is DEFINITELY a tool.",
        Options = {
            { "He sure is! ", DialogResult.Res0 },
            { "I don't think that's right...", new DialogResult { ResultDialog = new Dialog
                    {
                        Text = "...are you sure? I'm pretty confident he's a tool.",
                        Options =
                        {
                            { "Yep, definitely not a tool.", SelfReference},
                            { "You are the expert. Brandon is a tool.", DialogResult.Res1 }
                        }
                    }
                }
            }
        }
    };
}
