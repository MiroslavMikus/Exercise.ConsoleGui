using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace Exercise.GuiCs
{
    public class FileExplorerApp : ITopHost
    {
        public string Name => "File explorer";

        public Toplevel Top()
        {
            var top = new Toplevel()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var win = new Window(Name)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Percent(90)
            };

            var scroll = new ScrollView(win.Frame);

            List<string> data = Enumerable.Range(0, 200).Select(a => Guid.NewGuid().ToString()).ToList();

            var list = new ListView(data);

            scroll.Add(list);

            win.Add(scroll);

            var operations = CreateOperationsView(top, win);

            top.Add(win, operations);

            return top;
        }

        private Window CreateOperationsView(Toplevel top, Window win)
        {
            var operations = new Window("Actions")
            {
                X = 0,
                Y = Pos.Bottom(win),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var quit = new Button(1, 0, "Quit")
            {
                Clicked = Program.Start
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
            return operations;
        }
    }
}
