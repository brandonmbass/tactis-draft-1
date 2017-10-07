using System;
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

    public void RunDialog(Dialog dialog, CharacterBase character, Action<int> callback)
    {
        // Clean up previous bindings
        UIManager.DialogAnswer1.GetComponent<Button>().onClick.RemoveAllListeners();
        UIManager.DialogAnswer2.GetComponent<Button>().onClick.RemoveAllListeners();

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
                callback(result.Result);
                return;
            }

            // Run sub-dialog
            RunDialog(result == SelfReference ? dialog : result.ResultDialog, character, callback);
        });

        UIManager.DialogAnswer2.GetComponent<Button>().onClick.AddListener(() => {
            var result = dialog.Options[1];
            if (result.ResultDialog == null && result != SelfReference)
            {
                // Somehow save result result.Result
                UIManager.DialogContainer.gameObject.SetActive(false);
                callback(result.Result);
                return;
            }

            // Run sub-dialog
            RunDialog(result == SelfReference ? dialog : result.ResultDialog, character, callback);
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

    public static Dialog LumberjackGreeting = new Dialog
    {
        Text = "Ho there! You look like a good strong lad - maybe help me knock down some trees?",
        Options = {
            { "Will do! ", DialogResult.Res0 },
            { "Sounds fun! ", DialogResult.Res0 }
        }
    };

    public static Dialog GuardGreeting = new Dialog
    {
        Text = "Greetings citizen! Feel at ease in Cityville, as us guards are here to keep you...to keep you...",
        Options = {
            { "It seems you need some time to collect yourself - I'll leave you alone.", DialogResult.Res0 },
            { "...is everything okay?", new DialogResult { ResultDialog = new Dialog
                {
                    Text = @"Well...it's kind of shameful to admit, but even though we are here to protect the citizens, we don't have
                         the equipment to do so! If someone could bring us 10 arrows, we could protect the citizens, and even offer a handsome reward.",
                    Options =
                    {
                        { "Wow, I hope someone (else) brings you those supplies. Now I'm kinda worried.", DialogResult.Res0},
                        { "Hmm, I know a bit about fletching - I'll see if I cant help!", DialogResult.Res1 }
                    }
                }
            }}
        }
    };
}
