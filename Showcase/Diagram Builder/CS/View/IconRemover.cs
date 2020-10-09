// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconRemover.cs" company="">
//   
// </copyright>
// <summary>
//   Window icons removing logic.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.View
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;

    /// <summary>
    ///     Window icons removing logic.
    /// </summary>
    public static class IconRemover
    {
        /// <summary>
        ///     The exmodelframe.
        /// </summary>
        private const int Exmodelframe = 0x0001;

        /// <summary>
        ///     The exstyle.
        /// </summary>
        private const int Exstyle = -20;

        /// <summary>
        ///     The framechanged.
        /// </summary>
        private const int Framechanged = 0x0020;

        /// <summary>
        ///     The nomove.
        /// </summary>
        private const int Nomove = 0x0002;

        /// <summary>
        ///     The nosize.
        /// </summary>
        private const int Nosize = 0x0001;

        /// <summary>
        ///     The nozorder.
        /// </summary>
        private const int Nozorder = 0x0004;

        /// <summary>
        /// This method will remove the window maximize and minimize icon.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        public static void RemoveIcon(Window window)
        {
            IntPtr win = new WindowInteropHelper(window).Handle;
            int extendedStyle = GetWindowLong(win, Exstyle);
            SetWindowLong(win, Exstyle, extendedStyle | Exmodelframe);
            SetWindowPos(win, IntPtr.Zero, 0, 0, 0, 0, Nomove | Nosize | Nozorder | Framechanged);
        }

        /// <summary>
        /// The get window long.
        /// </summary>
        /// <param name="win">
        /// The win.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr win, int index);

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="win">
        /// The win.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        /// <param name="wParam">
        /// The w param.
        /// </param>
        /// <param name="lParam">
        /// The l param.
        /// </param>
        /// <returns>
        /// The <see cref="IntPtr"/>.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr win, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// The set window long.
        /// </summary>
        /// <param name="win">
        /// The win.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="newStyle">
        /// The new style.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr win, int index, int newStyle);

        /// <summary>
        /// The set window pos.
        /// </summary>
        /// <param name="win">
        /// The win.
        /// </param>
        /// <param name="InsertAfter">
        /// The insert after.
        /// </param>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(
            IntPtr win,
            IntPtr InsertAfter,
            int x,
            int y,
            int width,
            int height,
            uint flags);
    }
}