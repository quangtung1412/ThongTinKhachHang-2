using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace AGRIBANKHD.Utilities
{
    class FormatForm
    {
        #region Enumerations
        public enum RestrictionType
        {
            EntireArea,
            ClientArea,
            MdiClientarea
        }
        public enum SystemMenuClose
        {
            Enabled,
            Disabled,
            Hidden
        }
        #endregion

        #region Constructor
        public void SetFormFormat(Form MdiClientForm, Form RestrictToForm, RestrictionType RestrictToType, bool UseBorders, SystemMenuClose HandleSystemMenuClose)
        {
            //InitializeComponent();
            switch (RestrictToType)
            {
                case RestrictionType.EntireArea:
                    RectangleLimit = RestrictToForm.Bounds;
                    break;
                case RestrictionType.ClientArea:
                    RectangleLimit = RestrictToForm.RectangleToScreen(RestrictToForm.ClientRectangle);
                    break;
                default:
                    RectangleLimit = RestrictToForm.RectangleToScreen(RestrictToForm.ClientRectangle);
                    // Find the MdiClient control and adjust the rectangle accordingly
                    foreach (Control thisControl in RestrictToForm.Controls)
                    {
                        if (thisControl is MdiClient)
                        {
                            RectangleLimit.Offset(thisControl.Bounds.X, thisControl.Bounds.Y);
                            RectangleLimit.Height = thisControl.Bounds.Height;
                            RectangleLimit.Width = thisControl.Bounds.Width;
                            break;
                        }
                    }
                    break;
            }
            if (UseBorders)
            {
                // Get the border size
                int BorderWidth = SystemInformation.Border3DSize.Width;
                // Offset to allow for borders
                RectangleLimit.Offset(BorderWidth, BorderWidth);
                RectangleLimit.Height -= BorderWidth * 2;
                RectangleLimit.Width -= BorderWidth * 2;
            }
            IntPtr hMenu;
            switch (HandleSystemMenuClose)
            {
                case SystemMenuClose.Disabled:
                    hMenu = GetSystemMenu(MdiClientForm.Handle, false);
                    if (hMenu != IntPtr.Zero)
                    {
                        EnableMenuItem(hMenu, SC_CLOSE, MF_GRAYED);
                        //btnCancel.Enabled = false;
                        handleAltF4 = true;
                    }
                    break;
                case SystemMenuClose.Hidden:
                    hMenu = GetSystemMenu(MdiClientForm.Handle, false);
                    if (hMenu != IntPtr.Zero)
                    {
                        EnableMenuItem(hMenu, SC_CLOSE, MF_GRAYED);
                        int n = GetMenuItemCount(hMenu);
                        if (n > 0)
                        {
                            RemoveMenu(hMenu, n - 1, MF_DISABLED | MF_BYPOSITION);
                            RemoveMenu(hMenu, n - 2, MF_DISABLED | MF_BYPOSITION);
                            DrawMenuBar(MdiClientForm.Handle);
                            //btnCancel.Enabled = false;
                            handleAltF4 = true;
                        }
                    }
                    break;
                default:
                    handleAltF4 = false;
                    break;
            }
            // Set MaximumSize in case this form is too big.
            MdiClientForm.MaximumSize = RectangleLimit.Size;
        }
        #endregion

        #region RECT Structure
        // Indicates that the members of the type are to be laid out in unmanaged memory
        // in the same order in which they appear in the managed type definition. [MSDN]
        [StructLayout(LayoutKind.Sequential)]
        // Rectangle structure for marshalling
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            #region Constructor
            public RECT(int _Left, int _Top, int _Right, int _Bottom)
            {
                Left = _Left;
                Top = _Top;
                Right = _Right;
                Bottom = _Bottom;
            }
            #endregion

            #region Conversions
            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
            public static RECT FromRectangle(Rectangle rectangle)
            {
                return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }
            #endregion

            #region Operator overloads
            public static implicit operator Rectangle(RECT rect)
            {
                return rect.ToRectangle();
            }
            public static implicit operator RECT(Rectangle rect)
            {
                return FromRectangle(rect);
            }
            #endregion
        }
        #endregion

        #region Constants
        // Close button / Context Menu / Form Moving Constants
        private const int MF_GRAYED = 0x0001;
        private const int MF_DISABLED = 0x0002;
        private const int MF_BYPOSITION = 0x0400;
        private const int MF_REMOVE = 0x1000;
        private const int SC_CLOSE = 0xf060;
        private const int WM_NCLBUTTONDOWN = 0x00a1;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_MOVING = 0x0216;
        private const int WM_ENTERSIZEMOVE = 0x0231;
        #endregion

        #region Variables
        private bool handleAltF4;

        #region Rectangle Variables
        // Holds the rectangle based on form passed to constructor
        private Rectangle RectangleLimit;
        // Mouse cursor allowable rectangle
        private Rectangle ClipRectangle;
        #endregion

        #endregion

        #region Interop Functions
        // Windows Close button / Context Menu functions
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, int uIDEnableItem, int uEnable);
        [DllImport("user32.Dll")]
        public static extern IntPtr RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32.Dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("User32.Dll")]
        public static extern IntPtr DrawMenuBar(IntPtr hwnd);
        #endregion

        #region Overridden Functions
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4:
                        {
                            return handleAltF4;
                        }
                }
            }
            // process all others as normal
            return false;
        }
        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case WM_NCLBUTTONDOWN:
        //            // Title bar left clicked so set mouse cursor rectangle based on current position
        //            ClipRectangle = new Rectangle(
        //                RectangleLimit.X + (Cursor.Position.X - Location.X),
        //                RectangleLimit.Y + (Cursor.Position.Y - Location.Y),
        //                RectangleLimit.Width - Width,
        //                RectangleLimit.Height - Height);
        //            break;
        //        case WM_ENTERSIZEMOVE:
        //            // Move or size event so clip the mouse cursor
        //            Cursor.Clip = ClipRectangle;
        //            break;
        //        case WM_MOVING:
        //            // Form has moved so get current form rectangle
        //            RECT rectangle = (RECT)Marshal.PtrToStructure(
        //                m.LParam, typeof(RECT));

        //            // Compare form rectangle position and marshal allowed position if necessary
        //            if (rectangle.Left < RectangleLimit.Left)
        //            {
        //                rectangle.Right = RectangleLimit.Left + Width;
        //                rectangle.Left = RectangleLimit.Left;
        //                Marshal.StructureToPtr(rectangle, m.LParam, true);
        //            }

        //            if (rectangle.Top < RectangleLimit.Top)
        //            {
        //                rectangle.Bottom = RectangleLimit.Top + Height;
        //                rectangle.Top = RectangleLimit.Top;
        //                Marshal.StructureToPtr(rectangle, m.LParam, true);
        //            }

        //            if (rectangle.Right > RectangleLimit.Right)
        //            {
        //                rectangle.Left = RectangleLimit.Right - Width;
        //                rectangle.Right = RectangleLimit.Right;
        //                Marshal.StructureToPtr(rectangle, m.LParam, true);
        //            }

        //            if (rectangle.Bottom > RectangleLimit.Bottom)
        //            {
        //                rectangle.Top = RectangleLimit.Bottom - Height;
        //                rectangle.Bottom = RectangleLimit.Bottom;
        //                Marshal.StructureToPtr(rectangle, m.LParam, true);
        //            }
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}
        #endregion
    }
}
