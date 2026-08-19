// Decompiled with JetBrains decompiler
// Type: TowerDefense.Controls
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
  public class Controls
  {
    public static int P1LogicalIndex = -1;
    public static int P2LogicalIndex = -1;
    public static int P3LogicalIndex = -1;
    public static int P4LogicalIndex = -1;
    public static int MCLogicalIndex = -1;
    public static GamePadState[] gamepad = new GamePadState[6];
    public static GamePadState[] oldGamepad = new GamePadState[6];
    public static GamePadButtons[] upDownButtons = new GamePadButtons[6];
    public static GamePadButtons[] downUpButtons = new GamePadButtons[6];

    public Controls() => this.UpdateEnd();

    public static void ResetNonMC()
    {
      if (Controls.P1LogicalIndex != Controls.MCLogicalIndex)
        Controls.P1LogicalIndex = -1;
      if (Controls.P2LogicalIndex != Controls.MCLogicalIndex)
        Controls.P2LogicalIndex = -1;
      if (Controls.P3LogicalIndex != Controls.MCLogicalIndex)
        Controls.P3LogicalIndex = -1;
      if (Controls.P4LogicalIndex == Controls.MCLogicalIndex)
        return;
      Controls.P4LogicalIndex = -1;
    }

    public void UpdateStart()
    {
      Controls.gamepad[0] = GamePad.GetState(PlayerIndex.One);
      Controls.gamepad[1] = GamePad.GetState(PlayerIndex.Two);
      Controls.gamepad[2] = GamePad.GetState(PlayerIndex.Three);
      Controls.gamepad[3] = GamePad.GetState(PlayerIndex.Four);
    }

    public void UpdateEnd()
    {
      Controls.UpdateButtonUpDown(PlayerEnum.P1);
      Controls.UpdateButtonUpDown(PlayerEnum.P2);
      Controls.UpdateButtonUpDown(PlayerEnum.P3);
      Controls.UpdateButtonUpDown(PlayerEnum.P4);
      Controls.UpdateButtonUpDown(PlayerEnum.MC);
      Controls.UpdateButtonDownUp(PlayerEnum.P1);
      Controls.UpdateButtonDownUp(PlayerEnum.P2);
      Controls.UpdateButtonDownUp(PlayerEnum.P3);
      Controls.UpdateButtonDownUp(PlayerEnum.P4);
      Controls.UpdateButtonDownUp(PlayerEnum.MC);
      Controls.oldGamepad[0] = GamePad.GetState(PlayerIndex.One);
      Controls.oldGamepad[1] = GamePad.GetState(PlayerIndex.Two);
      Controls.oldGamepad[2] = GamePad.GetState(PlayerIndex.Three);
      Controls.oldGamepad[3] = GamePad.GetState(PlayerIndex.Four);
    }

    public static bool MCSet() => Controls.MCLogicalIndex != -1;

    public static bool P1Set() => Controls.P1LogicalIndex != -1;

    public static bool P2Set() => Controls.P2LogicalIndex != -1;

    public static bool P3Set() => Controls.P3LogicalIndex != -1;

    public static bool P4Set() => Controls.P4LogicalIndex != -1;

    public static GamePadDPad Dpad(PlayerEnum i)
    {
      GamePadDPad gamePadDpad = new GamePadDPad();
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index == -1 || index >= 4 ? gamePadDpad : Controls.gamepad[index].DPad;
    }

    public static GamePadDPad DpadOld(PlayerEnum i)
    {
      GamePadDPad gamePadDpad = new GamePadDPad();
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index == -1 || index >= 4 ? gamePadDpad : Controls.oldGamepad[index].DPad;
    }

    public static GamePadDPad DpadUpDown(PlayerEnum i)
    {
      GamePadDPad gamePadDpad1 = Controls.Dpad(i);
      GamePadDPad gamePadDpad2 = Controls.DpadOld(i);
      return new GamePadDPad(gamePadDpad1.Up != ButtonState.Released || gamePadDpad2.Up != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Down != ButtonState.Released || gamePadDpad2.Down != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Left != ButtonState.Released || gamePadDpad2.Left != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Right != ButtonState.Released || gamePadDpad2.Right != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed);
    }

    public static GamePadDPad DpadDownUp(PlayerEnum i)
    {
      GamePadDPad gamePadDpad1 = Controls.Dpad(i);
      GamePadDPad gamePadDpad2 = Controls.DpadOld(i);
      return new GamePadDPad(gamePadDpad1.Up != ButtonState.Pressed || gamePadDpad2.Up != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Down != ButtonState.Pressed || gamePadDpad2.Down != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Left != ButtonState.Pressed || gamePadDpad2.Left != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Right != ButtonState.Pressed || gamePadDpad2.Right != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed);
    }

    public static GamePadThumbSticks ThumbSticks(PlayerEnum i)
    {
      GamePadThumbSticks gamePadThumbSticks = new GamePadThumbSticks();
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index == -1 || index >= 4 ? gamePadThumbSticks : Controls.gamepad[index].ThumbSticks;
    }

    public static GamePadThumbSticks ThumbSticksOld(PlayerEnum i)
    {
      GamePadThumbSticks gamePadThumbSticks = new GamePadThumbSticks();
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index == -1 || index >= 4 ? gamePadThumbSticks : Controls.oldGamepad[index].ThumbSticks;
    }

    public static GamePadDPad DpadThumbSticks(PlayerEnum i) => new GamePadDPad((double) Controls.ThumbSticks(i).Left.Y > 0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticks(i).Left.Y < -0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticks(i).Left.X < -0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticks(i).Left.X > 0.5 ? ButtonState.Pressed : ButtonState.Released);

    public static GamePadDPad DpadThumbSticksOld(PlayerEnum i) => new GamePadDPad((double) Controls.ThumbSticksOld(i).Left.Y > 0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticksOld(i).Left.Y < -0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticksOld(i).Left.X < -0.5 ? ButtonState.Pressed : ButtonState.Released, (double) Controls.ThumbSticksOld(i).Left.X > 0.5 ? ButtonState.Pressed : ButtonState.Released);

    public static GamePadDPad DpadThumbSticksUpDown(PlayerEnum i)
    {
      GamePadDPad gamePadDpad1 = Controls.DpadThumbSticks(i);
      GamePadDPad gamePadDpad2 = Controls.DpadThumbSticksOld(i);
      return new GamePadDPad(gamePadDpad1.Up != ButtonState.Released || gamePadDpad2.Up != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Down != ButtonState.Released || gamePadDpad2.Down != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Left != ButtonState.Released || gamePadDpad2.Left != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Right != ButtonState.Released || gamePadDpad2.Right != ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed);
    }

    public static GamePadDPad DpadThumbSticksDownUp(PlayerEnum i)
    {
      GamePadDPad gamePadDpad1 = Controls.DpadThumbSticks(i);
      GamePadDPad gamePadDpad2 = Controls.DpadThumbSticksOld(i);
      return new GamePadDPad(gamePadDpad1.Up != ButtonState.Pressed || gamePadDpad2.Up != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Down != ButtonState.Pressed || gamePadDpad2.Down != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Left != ButtonState.Pressed || gamePadDpad2.Left != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed, gamePadDpad1.Right != ButtonState.Pressed || gamePadDpad2.Right != ButtonState.Released ? ButtonState.Released : ButtonState.Pressed);
    }

    private static GamePadButtons internalButton(int logicalIndex)
    {
      GamePadButtons gamePadButtons = new GamePadButtons();
      return logicalIndex == -1 || logicalIndex >= 4 ? gamePadButtons : Controls.gamepad[logicalIndex].Buttons;
    }

    public static GamePadButtons Button(PlayerEnum i)
    {
      int logicalIndex = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          logicalIndex = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          logicalIndex = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          logicalIndex = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          logicalIndex = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          logicalIndex = Controls.MCLogicalIndex;
          break;
      }
      return Controls.internalButton(logicalIndex);
    }

    private static GamePadButtons internalButtonOld(int logicalIndex)
    {
      GamePadButtons gamePadButtons = new GamePadButtons();
      return logicalIndex == -1 || logicalIndex >= 4 ? gamePadButtons : Controls.oldGamepad[logicalIndex].Buttons;
    }

    public static GamePadButtons ButtonOld(PlayerEnum i)
    {
      int logicalIndex = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          logicalIndex = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          logicalIndex = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          logicalIndex = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          logicalIndex = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          logicalIndex = Controls.MCLogicalIndex;
          break;
      }
      return Controls.internalButtonOld(logicalIndex);
    }

    public static GamePadButtons ButtonUpDown(PlayerEnum i)
    {
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index != -1 ? Controls.upDownButtons[index] : new GamePadButtons();
    }

    public static GamePadButtons ButtonDownUp(PlayerEnum i)
    {
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      return index != -1 ? Controls.downUpButtons[index] : new GamePadButtons();
    }

    public static void UpdateButtonUpDown(PlayerEnum i)
    {
      GamePadButtons gamePadButtons1 = Controls.Button(i);
      GamePadButtons gamePadButtons2 = Controls.ButtonOld(i);
      Buttons buttons1 = (Buttons) 0;
      Buttons buttons2 = gamePadButtons1.A != ButtonState.Released || gamePadButtons2.A != ButtonState.Pressed ? buttons1 : buttons1 | Buttons.A;
      Buttons buttons3 = gamePadButtons1.B != ButtonState.Released || gamePadButtons2.B != ButtonState.Pressed ? buttons2 : buttons2 | Buttons.B;
      Buttons buttons4 = gamePadButtons1.Back != ButtonState.Released || gamePadButtons2.Back != ButtonState.Pressed ? buttons3 : buttons3 | Buttons.Back;
      Buttons buttons5 = gamePadButtons1.BigButton != ButtonState.Released || gamePadButtons2.BigButton != ButtonState.Pressed ? buttons4 : buttons4 | Buttons.BigButton;
      Buttons buttons6 = gamePadButtons1.LeftShoulder != ButtonState.Released || gamePadButtons2.LeftShoulder != ButtonState.Pressed ? buttons5 : buttons5 | Buttons.LeftShoulder;
      Buttons buttons7 = gamePadButtons1.LeftStick != ButtonState.Released || gamePadButtons2.LeftStick != ButtonState.Pressed ? buttons6 : buttons6 | Buttons.LeftStick;
      Buttons buttons8 = gamePadButtons1.RightShoulder != ButtonState.Released || gamePadButtons2.RightShoulder != ButtonState.Pressed ? buttons7 : buttons7 | Buttons.RightShoulder;
      Buttons buttons9 = gamePadButtons1.RightStick != ButtonState.Released || gamePadButtons2.RightStick != ButtonState.Pressed ? buttons8 : buttons8 | Buttons.RightStick;
      Buttons buttons10 = gamePadButtons1.Start != ButtonState.Released || gamePadButtons2.Start != ButtonState.Pressed ? buttons9 : buttons9 | Buttons.Start;
      Buttons buttons11 = gamePadButtons1.X != ButtonState.Released || gamePadButtons2.X != ButtonState.Pressed ? buttons10 : buttons10 | Buttons.X;
      Buttons buttons12 = gamePadButtons1.Y != ButtonState.Released || gamePadButtons2.Y != ButtonState.Pressed ? buttons11 : buttons11 | Buttons.Y;
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      if (index == -1)
        return;
      Controls.upDownButtons[index] = new GamePadButtons(buttons12);
    }

    public static void UpdateButtonDownUp(PlayerEnum i)
    {
      GamePadButtons gamePadButtons1 = Controls.Button(i);
      GamePadButtons gamePadButtons2 = Controls.ButtonOld(i);
      Buttons buttons1 = (Buttons) 0;
      Buttons buttons2 = gamePadButtons1.A != ButtonState.Pressed || gamePadButtons2.A != ButtonState.Released ? buttons1 : buttons1 | Buttons.A;
      Buttons buttons3 = gamePadButtons1.B != ButtonState.Pressed || gamePadButtons2.B != ButtonState.Released ? buttons2 : buttons2 | Buttons.B;
      Buttons buttons4 = gamePadButtons1.Back != ButtonState.Pressed || gamePadButtons2.Back != ButtonState.Released ? buttons3 : buttons3 | Buttons.Back;
      Buttons buttons5 = gamePadButtons1.BigButton != ButtonState.Pressed || gamePadButtons2.BigButton != ButtonState.Released ? buttons4 : buttons4 | Buttons.BigButton;
      Buttons buttons6 = gamePadButtons1.LeftShoulder != ButtonState.Pressed || gamePadButtons2.LeftShoulder != ButtonState.Released ? buttons5 : buttons5 | Buttons.LeftShoulder;
      Buttons buttons7 = gamePadButtons1.LeftStick != ButtonState.Pressed || gamePadButtons2.LeftStick != ButtonState.Released ? buttons6 : buttons6 | Buttons.LeftStick;
      Buttons buttons8 = gamePadButtons1.RightShoulder != ButtonState.Pressed || gamePadButtons2.RightShoulder != ButtonState.Released ? buttons7 : buttons7 | Buttons.RightShoulder;
      Buttons buttons9 = gamePadButtons1.RightStick != ButtonState.Pressed || gamePadButtons2.RightStick != ButtonState.Released ? buttons8 : buttons8 | Buttons.RightStick;
      Buttons buttons10 = gamePadButtons1.Start != ButtonState.Pressed || gamePadButtons2.Start != ButtonState.Released ? buttons9 : buttons9 | Buttons.Start;
      Buttons buttons11 = gamePadButtons1.X != ButtonState.Pressed || gamePadButtons2.X != ButtonState.Released ? buttons10 : buttons10 | Buttons.X;
      Buttons buttons12 = gamePadButtons1.Y != ButtonState.Pressed || gamePadButtons2.Y != ButtonState.Released ? buttons11 : buttons11 | Buttons.Y;
      int index = -1;
      switch (i)
      {
        case PlayerEnum.P1:
          index = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          index = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          index = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          index = Controls.P4LogicalIndex;
          break;
        case PlayerEnum.MC:
          index = Controls.MCLogicalIndex;
          break;
      }
      if (index == -1)
        return;
      Controls.downUpButtons[index] = new GamePadButtons(buttons12);
    }

    public static bool CheckForMCJoin()
    {
      if (Controls.MCLogicalIndex != -1)
        return false;
      if (Controls.P1LogicalIndex != -1)
      {
        Controls.MCLogicalIndex = Controls.P1LogicalIndex;
        return true;
      }
      if (Controls.P2LogicalIndex != -1)
      {
        Controls.MCLogicalIndex = Controls.P2LogicalIndex;
        return true;
      }
      if (Controls.P3LogicalIndex != -1)
      {
        Controls.MCLogicalIndex = Controls.P3LogicalIndex;
        return true;
      }
      if (Controls.P4LogicalIndex != -1)
      {
        Controls.MCLogicalIndex = Controls.P4LogicalIndex;
        return true;
      }
      for (int logicalIndex = 0; logicalIndex < 6; ++logicalIndex)
      {
        if (Controls.internalButton(logicalIndex).Start == ButtonState.Released && Controls.internalButtonOld(logicalIndex).Start == ButtonState.Pressed)
        {
          Controls.MCLogicalIndex = logicalIndex;
          return true;
        }
      }
      return false;
    }

    public static bool CheckForMCLeave()
    {
      bool flag = false;
      if (Controls.MCLogicalIndex == -1)
        return false;
      if (Controls.MCLogicalIndex == 0 && !GamePad.GetState(PlayerIndex.One).IsConnected)
        flag = true;
      if (Controls.MCLogicalIndex == 1 && !GamePad.GetState(PlayerIndex.Two).IsConnected)
        flag = true;
      if (Controls.MCLogicalIndex == 2 && !GamePad.GetState(PlayerIndex.Three).IsConnected)
        flag = true;
      if (Controls.MCLogicalIndex == 3 && !GamePad.GetState(PlayerIndex.Four).IsConnected)
        flag = true;
      if (flag)
        Controls.MCLogicalIndex = -1;
      return flag;
    }

    public static bool CheckForPlayerJoin(PlayerEnum i)
    {
      int num;
      switch (i)
      {
        case PlayerEnum.P1:
          num = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          num = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          num = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          num = Controls.P4LogicalIndex;
          break;
        default:
          return false;
      }
      if (num != -1)
        return false;
      if (Controls.MCLogicalIndex != -1 && Controls.P1LogicalIndex != Controls.MCLogicalIndex && Controls.P2LogicalIndex != Controls.MCLogicalIndex && Controls.P3LogicalIndex != Controls.MCLogicalIndex && Controls.P4LogicalIndex != Controls.MCLogicalIndex)
      {
        num = Controls.MCLogicalIndex;
      }
      else
      {
        for (int logicalIndex = 0; logicalIndex < 6; ++logicalIndex)
        {
          if (Controls.internalButton(logicalIndex).Start == ButtonState.Released && Controls.internalButtonOld(logicalIndex).Start == ButtonState.Pressed && logicalIndex != Controls.P1LogicalIndex && logicalIndex != Controls.P2LogicalIndex && logicalIndex != Controls.P3LogicalIndex && logicalIndex != Controls.P4LogicalIndex)
          {
            num = logicalIndex;
            break;
          }
        }
      }
      if (num == -1)
        return false;
      switch (i)
      {
        case PlayerEnum.P1:
          Controls.P1LogicalIndex = num;
          break;
        case PlayerEnum.P2:
          Controls.P2LogicalIndex = num;
          break;
        case PlayerEnum.P3:
          Controls.P3LogicalIndex = num;
          break;
        case PlayerEnum.P4:
          Controls.P4LogicalIndex = num;
          break;
      }
      return true;
    }

    public static bool CheckForPlayerLeave(PlayerEnum i)
    {
      int num;
      switch (i)
      {
        case PlayerEnum.P1:
          num = Controls.P1LogicalIndex;
          break;
        case PlayerEnum.P2:
          num = Controls.P2LogicalIndex;
          break;
        case PlayerEnum.P3:
          num = Controls.P3LogicalIndex;
          break;
        case PlayerEnum.P4:
          num = Controls.P4LogicalIndex;
          break;
        default:
          return false;
      }
      bool flag = false;
      if (num == -1)
        return false;
      if (num == 0 && !GamePad.GetState(PlayerIndex.One).IsConnected)
        flag = true;
      if (num == 1 && !GamePad.GetState(PlayerIndex.Two).IsConnected)
        flag = true;
      if (num == 2 && !GamePad.GetState(PlayerIndex.Three).IsConnected)
        flag = true;
      if (num == 3 && !GamePad.GetState(PlayerIndex.Four).IsConnected)
        flag = true;
      if (flag)
      {
        switch (i)
        {
          case PlayerEnum.P1:
            Controls.P1LogicalIndex = -1;
            break;
          case PlayerEnum.P2:
            Controls.P2LogicalIndex = -1;
            break;
          case PlayerEnum.P3:
            Controls.P3LogicalIndex = -1;
            break;
          case PlayerEnum.P4:
            Controls.P4LogicalIndex = -1;
            break;
        }
      }
      return flag;
    }
  }
}
