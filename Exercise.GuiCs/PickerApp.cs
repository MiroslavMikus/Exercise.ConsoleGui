using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Terminal.Gui;

namespace Exercise.GuiCs
{
    public class PickerApp : Toplevel
    {
        private readonly Dictionary<int, ITopHost> _apps = new Dictionary<int, ITopHost>();

        public PickerApp()
        {
            _apps[0] = new DefaultDemoApp();
            _apps[1] = new FileExplorerApp();

            Application.Init();

            var top = Application.Top;

            // Creates the top-level window to show
            var win = new Window("Picker")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            var options = new RadioGroup(1, 1, new[] { "Default demo", "File explorer" });

            var confirm = new Button(1, 4, "OK")
            {
                Clicked = () =>
                {
                    Application.Run(_apps[options.Selected].Top());
                }
            };

            var quit = new Button(1, 5, "Quit")
            {
                Clicked = () =>
                {
                    top.Running = false;
                    Environment.Exit(0);
                }
            };

            win.Add(options, confirm, quit);

            Application.Run();
        }
    }
}
