using HarmonyLib;
using ResoniteModLoader;
using Elements.Core;
using FrooxEngine;
using FrooxEngine.CommonAvatar;
using FrooxEngine.Undo;
using Renderite.Shared;


namespace KeyboardRemapper;

public class KeyRemapper : ResoniteMod
{
    internal const string VERSION_CONSTANT = "0.0.1"; 
    public override string Name => "Keyboard Remapper"; 
    public override string Author => "MrTumnus"; 
    public override string Version => VERSION_CONSTANT;

    public override string Link =>
        "https://github.com/TumnusB/KeyboardRemapper";

    //Misc Input
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> devtip_Focus =
        new("Devtip Focus", "Devtip Focus Key", () => Key.F);

    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> devtip_Inspector =
        new("Devtip Inspector", "Devtip Inspector Key", () => Key.I);
    
    //Directional Keys
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> W =
        new("W Key", "Rebind W Key", () => Key.W);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> A =
        new("A Key", "Rebind A Key", () => Key.A);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> S =
        new("S Key", "Rebind S Key", () => Key.S);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> D =
        new("D Key", "Rebind D Key", () => Key.D);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> UpArrow =
        new("UpArrow Key", "Rebind UpArrow", () => Key.UpArrow);

    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> DownArrow =
        new("DownArrow Key", "Rebind DownArrow", () => Key.DownArrow);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> LeftArrow =
        new("LeftArrow Key", "Rebind LeftArrow", () => Key.LeftArrow);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> RightArrow =
        new("RightArrow Key", "Rebind RightArrow", () => Key.RightArrow);
    
    //Alpha Keys
    //C E F M P R T V X Y Z
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> C =
        new("C Key", "Rebind C Key", () => Key.C);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> E =
        new("E Key", "Rebind E Key", () => Key.E);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> F =
        new("F Key", "Rebind F Key", () => Key.F);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> M =
        new("M Key", "Rebind M Key", () => Key.M);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> P =
        new("P Key", "Rebind P Key", () => Key.P);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> R =
        new("R Key", "Rebind R Key", () => Key.R);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> T =
        new("T Key", "Rebind T Key", () => Key.T);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> V =
        new("V Key", "Rebind V Key", () => Key.V);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> X =
        new("X Key", "Rebind X Key", () => Key.X);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Y =
        new("Y Key", "Rebind Y Key", () => Key.Y);
    
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Z =
        new("Z Key", "Rebind Z Key", () => Key.Z);
    
    //Modifier Keys
    // Alt, Control, RightControl, Shift
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Alt =
        new("Alt Key", "Rebind Alt Key", () => Key.Alt);
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Control =
        new("Control Key", "Rebind Control Key", () => Key.Control);
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> RightControl =
        new("RightControl Key", "Rebind RightControl Key", () => Key.RightControl);
    [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Shift =
        new("Shift Key", "Rebind Shift Key", () => Key.Shift);
    
    //Special Keys
   //Delete, Escape, PageDown, PageUp, Print, Space
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Delete =
       new("Delete Key", "Rebind Delete Key", () => Key.Delete);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Escape =
       new("Escape Key", "Rebind Escape Key", () => Key.Escape);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> PageDown =
       new("PageDown Key", "Rebind PageDown Key", () => Key.PageDown);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> PageUp =
       new("PageUp Key", "Rebind PageUp Key", () => Key.PageUp);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Print =
       new("Print Key", "Rebind Print Key", () => Key.Print);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> Space =
       new("Space Key", "Rebind Space Key", () => Key.Space);
   
   //Function Keys
   //F2, F5, F6
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> F2 =
       new("F2 Key", "Rebind F2 Key", () => Key.F2);
   
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> F5 =
       new("F5 Key", "Rebind F5 Key", () => Key.F5);
   
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<Key> F6 =
       new("F6 Key", "Rebind F6 Key", () => Key.F6);
   
   //Mouse Buttons
   //Button4, Button5, Left, Middle, Right
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<MouseButton> MouseButton4 =
       new("Mouse Button 4", "Rebind Mouse Button 4", () => MouseButton.Button4);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<MouseButton> MouseButton5 =
       new("Mouse Button 5", "Rebind Mouse Button 5", () => MouseButton.Button5);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<MouseButton> MouseButtonLeft =
       new("Mouse Button Left", "Rebind Mouse Button Left", () => MouseButton.Left);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<MouseButton> MouseButtonMiddle =
       new("Mouse Button Middle", "Rebind Mouse Button Middle", () => MouseButton.Middle);
   [AutoRegisterConfigKey] private static readonly ModConfigurationKey<MouseButton> MouseButtonRight =
       new("Mouse Button Right", "Rebind Mouse Button Right", () => MouseButton.Right);
   
   
    private static ModConfiguration Config;

    public override void OnEngineInit()
    {
        Config = GetConfiguration();
        Config.Save(true);
        var harmony = new Harmony(
            "com.Tumnus.KeyboardRemapper");
        harmony.PatchAll();

        Config.OnThisConfigurationChanged += OnThisConfigurationChanged;
    }

    private void OnThisConfigurationChanged(ConfigurationChangedEvent configurationChangedEvent)
    {
        Config.Save(true);
    }


    
    [HarmonyPatch(typeof(KeyboardAndMouseBindingGenerator))]
    class KeyboardAndMouseBindingGeneratorPatch
    {
        [HarmonyPatch("Bind")]
        [HarmonyPrefix]
        static bool Prefix(InputGroup group, KeyboardAndMouseBindingGenerator __instance)
        {
            IInputNode<float2> GenerateKeyboardLook()
            {

                return InputNode.Axis(
                        InputNode.Key(Config.GetValue(UpArrow)).Invert(), 
                        InputNode.Key(Config.GetValue(LeftArrow)), 
                        InputNode.Key(Config.GetValue(DownArrow)).Invert(), 
                        InputNode.Key(Config.GetValue(RightArrow)) 
                    )
                    .Gate(true, false, InputNode.Setting((KeyboardLookSettings s) => s.LookEnabled, false))
                    .Multiply(InputNode.Setting((KeyboardLookSettings s) => s.Speed));
            }

            IInputNode<float3> GenerateKeyboardLook3D()
            {
                return GenerateKeyboardLook().YX().XY_();
            }

            void BindKeyboardLook3D(Analog3DAction action)
            {
                action.AddBinding(GenerateKeyboardLook3D().Gate(true, false, InputNode.Key(Config.GetValue(Control)).Invert()));
            }

            void BindKeyboardLook2D(Analog2DAction action)
            {
                action.AddBinding(GenerateKeyboardLook().Gate(true, false, InputNode.Key(Config.GetValue(Control)).Invert()));
            }

            ScreenLocomotionDirection GenerateScreenDirection(float? overrideFast = null, float? overrideSlow = null,
                LocomotionReference? overrideReference = null)
            {
                var dir = new ScreenLocomotionDirection();
                dir.Forward = InputNode.Key(Config.GetValue(W));
                dir.Backward = InputNode.Key(Config.GetValue(S));
                dir.Left = InputNode.Key(Config.GetValue(A));
                dir.Right = InputNode.Key(Config.GetValue(D));
                dir.Up = InputNode.Key(Config.GetValue(Space));
                dir.Down = InputNode.Key(Config.GetValue(C));
                dir.Fast = InputNode.Any(InputNode.MultiTap(new KeyboardInputSource[4]
                {
                    InputNode.Key(Config.GetValue(W)),
                    InputNode.Key(Config.GetValue(A)),
                    InputNode.Key(Config.GetValue(S)),
                    InputNode.Key(Config.GetValue(D))
                }), InputNode.Key(Config.GetValue(Shift)));
                dir.Slow = InputNode.Key(Config.GetValue(Z)).Toggle();
                if (overrideFast.HasValue) dir.FastMultiplier = overrideFast.Value;
                if (overrideSlow.HasValue) dir.SlowMultiplier = overrideSlow.Value;
                if (overrideReference.HasValue) dir.OverrideReference = overrideReference.Value;
                return dir;
            }

            if (!(group is InteractionHandlerInputs commonTool))
            {
                if (!(group is CommonActionsInputs commonActions))
                {
                    if (group is ContextMenuInputs)
                    {
                        return false;
                    }

                    if (!(group is ClipboardInputs clipboard))
                    {
                        if (!(group is PhotoInputs photoInputs))
                        {
                            if (!(group is LaserHoldInputs laserHold))
                            {
                                if (!(group is GlobalActions globalActions))
                                {
                                    if (!(group is UndoInputs worldActions))
                                    {
                                        if (!(group is ScreenInputs screen))
                                        {
                                            if (!(group is ScreenCameraInputs { Look: var look } screenCamera))
                                            {
                                                if (!(group is UICameraInputs { LockCursor: var lockCursor } uiCamera))
                                                {
                                                    if (!(group is FreeformCameraInputs
                                                        {
                                                            LockCursor: var lockCursor2
                                                        } freeformCamera))
                                                    {
                                                        if (!(group is HeadInputs { Crouch: var crouch }))
                                                        {
                                                            if (!(group is GeneralLocomotionInputs generalLocomotion))
                                                            {
                                                                if (!(group is SmoothLocomotionInputs
                                                                    {
                                                                        Move: var move
                                                                    } smoothLocomotion))
                                                                {
                                                                    if (!(group is SmoothThreeAxisLocomotionInputs
                                                                        {
                                                                            Move: var move2
                                                                        } threeAxis))
                                                                    {
                                                                        if (!(group is AnchorReleaseInputs
                                                                                anchorRelease))
                                                                        {
                                                                            if (!(group is AnchorLocomotionInputs
                                                                                    anchorInputs))
                                                                            {
                                                                                if (group is DevToolInputs devtip)
                                                                                {
                                                                                    devtip.Focus.AddBinding(
                                                                                        InputNode.PrimarySecondary(
                                                                                            InputNode.Key(
                                                                                                Config.GetValue(
                                                                                                    devtip_Focus)),
                                                                                            null));
                                                                                    devtip.Inspector.AddBinding(
                                                                                        InputNode.PrimarySecondary(
                                                                                            InputNode.Key(
                                                                                                Config.GetValue(
                                                                                                    devtip_Inspector)),
                                                                                            null));
                                                                                    return false;

                                                                                }

                                                                                UniLog.Warning(
                                                                                    $"Cannot bind {group} to Keyboard & Mouse");
                                                                            }
                                                                            else
                                                                            {
                                                                                anchorInputs.PrimaryAction.AddBinding(
                                                                                    InputNode.Key(Config.GetValue(Space)));
                                                                                anchorInputs.PrimaryAxis.AddBinding(
                                                                                    InputNode.Axis(InputNode.Key(Config.GetValue(W)),
                                                                                        InputNode.Key(Config.GetValue(A)),
                                                                                        InputNode.Key(Config.GetValue(S)),
                                                                                        InputNode.Key(Config.GetValue(D))));
                                                                                anchorInputs.SecondaryAction.AddBinding(
                                                                                    InputNode.Key(Config.GetValue(RightControl)));
                                                                                anchorInputs.SecondaryAxis.AddBinding(
                                                                                    InputNode.Axis(
                                                                                        InputNode.Key(Config.GetValue(UpArrow)),
                                                                                        InputNode.Key(Config.GetValue(LeftArrow)),
                                                                                        InputNode.Key(Config.GetValue(DownArrow)),
                                                                                        InputNode.Key(Config.GetValue(RightArrow))));
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            anchorRelease.Release.AddBinding(
                                                                                InputNode.Key(Config.GetValue(Space)));
                                                                            anchorRelease.ReleaseStrength.AddBinding(
                                                                                InputNode.Key(Config.GetValue(Space)).ToAnalog());
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        move2.AddBinding(GenerateScreenDirection());
                                                                        threeAxis.Jump.AddBinding(
                                                                            InputNode.Key(Config.GetValue(Space)));
                                                                        threeAxis.Align.AddBinding(
                                                                            InputNode.Key(Config.GetValue(X)));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    move.AddBinding(GenerateScreenDirection());
                                                                    smoothLocomotion.Jump.AddBinding(
                                                                        InputNode.Key(Config.GetValue(Space)));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                generalLocomotion.SelfScaleDelta.AddBinding(InputNode
                                                                    .MouseScroll(true).Y()
                                                                    .Gate(InputNode.Key(Config.GetValue(Control)), true));
                                                                generalLocomotion.NextModule.AddBinding(
                                                                    InputNode.Key(Config.GetValue(PageUp)));
                                                                generalLocomotion.PreviousModule.AddBinding(
                                                                    InputNode.Key(Config.GetValue(PageDown)));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            crouch.AddBinding(InputNode.Any(InputNode.Key(Config.GetValue(C)),
                                                                InputNode.Key(Config.GetValue(C)).TapToggle(0.15f)).ToAnalog());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lockCursor2.AddBinding(InputNode.Constant(true).Gate(true, true,
                                                            InputNode.Any(InputNode.Key(Config.GetValue(Control)),
                                                                InputNode.Key(Config.GetValue(Alt))),
                                                            InputNode.MouseButton(Config.GetValue(MouseButtonRight))));
                                                        freeformCamera.CameraLook.AddBinding(InputNode
                                                            .MouseMovement(true).YX().XY_()
                                                            .Multiply(InputNode.Setting(
                                                                (MouseSettings s) => s.ActualLookSpeed, 0f))
                                                            .dT_inv()
                                                            .Gate(InputNode.Key(Config.GetValue(Alt)).Invert())
                                                            .Gate(InputNode.GroupAction<bool>("LockCursor"), true));
                                                        BindKeyboardLook3D(freeformCamera.CameraLook);
                                                        freeformCamera.CameraOrbit.AddBinding(InputNode
                                                            .MouseMovement(true)
                                                            .Multiply(InputNode.Setting(
                                                                (MouseSettings s) => s.ActualLookSpeed, 0f)).dT_inv()
                                                            .Gate(InputNode.Key(Config.GetValue(Alt)))
                                                            .Gate(InputNode.GroupAction<bool>("LockCursor"), true));
                                                        freeformCamera.CameraMove.AddBinding(
                                                            GenerateScreenDirection(4f, null, LocomotionReference.View)
                                                                .Gate(InputNode.GroupAction<bool>("LockCursor"), true));
                                                        freeformCamera.CameraZoom.AddBinding(InputNode.MouseScroll(true)
                                                            .Y().Negate()
                                                            .dT_inv()
                                                            .Gate(InputNode.GroupAction<bool>("LockCursor"), true));
                                                    }
                                                }
                                                else
                                                {
                                                    lockCursor.AddBinding(InputNode.Constant(true).Gate(true, true,
                                                        InputNode.Key(Config.GetValue(Control)),
                                                        InputNode.MouseButton(Config.GetValue(MouseButtonRight))));
                                                    uiCamera.Zoom.AddBinding(InputNode.MouseScroll(true).Y().Negate()
                                                        .dT_inv()
                                                        .Gate(InputNode.Key(Config.GetValue(Control)), true));
                                                    uiCamera.Pan.AddBinding(InputNode.MouseMovement(true)
                                                        .Multiply(InputNode.Setting(
                                                            (MouseSettings s) => s.ActualPanSpeed, 0f)).dT_inv()
                                                        .Gate(InputNode.GroupAction<bool>("LockCursor"), true));
                                                }
                                            }
                                            else
                                            {
                                                look.AddBinding(InputNode.MouseMovement(true)
                                                    .Multiply(InputNode.Setting((MouseSettings s) => s.ActualLookSpeed,
                                                        0f)).dT_inv());
                                                BindKeyboardLook2D(screenCamera.Look);
                                                screenCamera.Pan.AddBinding(
                                                    InputNode.MouseMovement(true).Gate(true, false,
                                                        InputNode.Key(Config.GetValue(Control)),
                                                        InputNode.MouseButton(Config.GetValue(MouseButtonRight))), null, null, 10);
                                                screenCamera.ResetPan.AddBinding(
                                                    InputNode.Constant(true).Gate(false, false,
                                                            InputNode.Key(Config.GetValue(Control)),
                                                            InputNode.MouseButton(Config.GetValue(MouseButtonRight)))
                                                        .MultiTap(2, 0.25f, true), null, null, 10);
                                                screenCamera.ForceHeadLook.AddBinding(InputNode
                                                    .MouseButton(Config.GetValue(MouseButtonRight)).NoBlocks());
                                                screenCamera.AlignHeadLook.AddBinding(InputNode
                                                    .MouseButton(Config.GetValue(MouseButtonRight)).MultiTap().NoBlocks());
                                            }
                                        }
                                        else
                                        {
                                            screen.ToggleFirstAndThirdPerson.AddBinding(InputNode.Key(Config.GetValue(F5)));
                                            screen.ToggleFreeformCamera.AddBinding(InputNode.Key(Config.GetValue(F6)));
                                            screen.Focus.AddBinding(InputNode.Key(Config.GetValue(F))
                                                .Gate(InputNode.Key(Config.GetValue(Control)), true));
                                            screen.Unfocus.AddBinding(InputNode.Key(Config.GetValue(F))
                                                .Gate(InputNode.Key(Config.GetValue(Alt)), true));
                                        }
                                    }
                                    else
                                    {
                                        worldActions.Undo.AddBinding(InputNode.Key(Config.GetValue(Z))
                                            .Gate(InputNode.Key(Config.GetValue(Control)), true));
                                        worldActions.Redo.AddBinding(InputNode.Key(Config.GetValue(Y))
                                            .Gate(InputNode.Key(Config.GetValue(Control)), true));
                                    }
                                }
                                else
                                {
                                    globalActions.ToggleDash.AddBinding(InputNode.Key(Config.GetValue(Escape)));
                                    globalActions.ActivateTalk.AddBinding(InputNode.Key(Config.GetValue(V))
                                        .Gate(InputNode.Key(Config.GetValue(Control)).Invert(), true));
                                    globalActions.ActivateTalk.AddBinding(InputNode.MouseButton(Config.GetValue(MouseButton5)));
                                    globalActions.ToggleMute.AddBinding(InputNode.Key(Config.GetValue(M)));
                                }
                            }
                            else
                            {
                                laserHold.Align.AddBinding(
                                    InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButtonLeft)), null));
                                laserHold.Slide.AddBinding(InputNode.PrimarySecondary(InputNode.MouseScroll(true).Y()
                                        .dT_inv()
                                        .Multiply(
                                            InputNode.Setting((MouseSettings s) => s.ScrollWheelGrabMoveSpeed, 0f)),
                                    null));
                                laserHold.Rotate.AddBinding(InputNode.PrimarySecondary(InputNode.MouseScroll(true).X()
                                        .dT_inv()
                                        .Multiply(
                                            InputNode.Setting((MouseSettings s) => s.ScrollWheelGrabMoveSpeed, 0f)),
                                    null));
                                laserHold.Rotate.AddBinding(InputNode.PrimarySecondary(InputNode.MouseMovement(true)
                                    .Multiply(InputNode.Setting((MouseSettings s) => s.ActualRotateSpeed, 0f)).X()
                                    .Gate(InputNode.All(InputNode.Key(Config.GetValue(Shift)), InputNode.Key(Config.GetValue(E))), true), null));
                                laserHold.FreeformRotateDelta.AddBinding(InputNode.PrimarySecondary(InputNode.XYZ(
                                    InputNode.MouseMovement(true).YX().Multiply(new float2(1f, -1f))
                                        .Multiply(InputNode.Setting((MouseSettings s) => s.ActualFreeformRotateSpeed,
                                            0f))
                                        .Gate(InputNode.All(InputNode.Key(Config.GetValue(Shift)).Invert(), InputNode.Key(Config.GetValue(E))),
                                            true), null), null));
                                laserHold.FreezeCursor.AddBinding(
                                    InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(E)), null));
                                laserHold.ScaleDelta.AddBinding(
                                    InputNode.PrimarySecondary(
                                        InputNode.MouseScroll(true).Y().Gate(InputNode.Key(Config.GetValue(Shift)), true), null),
                                    null, null, 10);
                            }
                        }
                        else
                        {
                            photoInputs.TakePhoto.AddBinding(InputNode.Key(Config.GetValue(Print))
                                .Gate(InputNode.Key(Config.GetValue(Shift)), true));
                            photoInputs.StartTimerPhoto.AddBinding(InputNode.Key(Config.GetValue(Print))
                                .Gate(InputNode.Key(Config.GetValue(Control)), true));
                            photoInputs.TakePhoto.AddBinding(InputNode.Key(Config.GetValue(P)).Gate(InputNode.Key(Config.GetValue(Shift)), true));
                            photoInputs.StartTimerPhoto.AddBinding(InputNode.Key(Config.GetValue(P))
                                .Gate(InputNode.Key(Config.GetValue(Control)), true));
                        }
                    }
                    else
                    {
                        clipboard.Paste.AddBinding(InputNode.KeyRepeat(Config.GetValue(V)).Gate(InputNode.Key(Config.GetValue(Control)), true));
                    }
                }
                else
                {
                    commonActions.Save.AddBinding(
                        InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(S)).Gate(InputNode.Key(Config.GetValue(Control)), true), null));
                    commonActions.Duplicate.AddBinding(
                        InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(D)).Gate(InputNode.Key(Config.GetValue(Control)), true), null));
                    commonActions.Destroy.AddBinding(
                        InputNode.PrimarySecondary(
                            InputNode.Key(Config.GetValue(D))
                                .Gate(InputNode.All(InputNode.Key(Config.GetValue(Shift)), InputNode.Key(Config.GetValue(Control))), true), null),
                        null, null, 10);
                    commonActions.Destroy.AddBinding(InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(Delete)), null));
                }
            }
            else
            {
                commonTool.Interact.AddBinding(
                    InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButtonLeft)), null));
                commonTool.Strength.AddBinding(
                    InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButtonLeft)).ToAnalog(8f), null));
                commonTool.Grab.AddBinding(InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButtonRight)), null));
                commonTool.Menu.AddBinding(InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButtonMiddle)), null));
                commonTool.Secondary.AddBinding(InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(R)), null));
                commonTool.Secondary.AddBinding(InputNode.PrimarySecondary(InputNode.MouseButton(Config.GetValue(MouseButton4)),
                    null));
                commonTool.TouchAxis.AddBinding(InputNode.PrimarySecondary(InputNode.MouseScroll(false), null));
                commonTool.Interact.AddBinding(InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(Y)), null));
                commonTool.Menu.AddBinding(InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(T)), null));
                commonTool.FocusUI.AddBinding(
                    InputNode.PrimarySecondary(
                        InputNode.MouseButton(Config.GetValue(MouseButtonLeft)).Gate(InputNode.Key(Config.GetValue(Control)), true), null), null,
                    null, 10);
                commonTool.ToggleEditMode.AddBinding(InputNode.PrimarySecondary(InputNode.Key(Config.GetValue(F2)), null));
            }
            return false;
        }
    }
}