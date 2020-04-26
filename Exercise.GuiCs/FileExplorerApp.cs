using System;
using Terminal.Gui;

namespace Exercise.GuiCs
{
    public class FileExplorerApp : Toplevel
    {
        public FileExplorerApp()
        {
            Application.Init();

            var top = Application.Top;

            var win = new Window("File explorer")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(90)
            };

            var operations = new Window("Actions")
            {
                X = 0,
                Y = Pos.Bottom(win),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var quit = new Button(1, 0, "Quit")
            {
                Clicked = () =>
                {
                    top.Running = false;
                    Environment.Exit(0);
                }
            };

            var msg = new Button("Show file explorer position")
            {
                X = Pos.Right(quit) + 1,
                Y = 0,
                Clicked = () =>
                {
                    var result = MessageBox.Query(30, 15, "The title",
                        Pos.Top(win).ToString(),
                        "Ok", "Not Ok");
                }
            };

            operations.Add(quit);
            operations.Add(msg);

            top.Add(win);
            top.Add(operations);

            Application.Run();
        }
    }
}
