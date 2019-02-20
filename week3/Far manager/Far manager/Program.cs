using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Far_manager
{
    using Terminal.Gui;   

    class Program
    {
        static void listDir(string path, Window win)
        {
            List<string> dirList = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                dirList.Add("[" + d.Name + "]");
                //d.Name;
            }
            foreach (FileInfo f in dir.GetFiles())
            {
                dirList.Add(f.Name);
                //f.Name;
            }

            var listFiles = new ListView(dirList);
            win.Add(listFiles);
        }
        static void Main(string[] args)
        {
            Application.Init();   
            var top = Application.Top;

	        //left window
            var leftWin = new Window ("DirList") {
	            X = 0,
	            Y = 1, // Leave one row for the toplevel menu

	            // By using Dim.Fill(), it will automatically resize without manual intervention
	            Width =  Dim.Percent (50),
	            Height = Dim.Fill ()
	        };
            top.Add (leftWin);

            //right window
            var rightWin = new Window("View")
            {
                X = Pos.Right(leftWin),
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(rightWin);

            


            listDir("/Users/User/Desktop/PP2Labs/", leftWin);
            Application.Run();
            
        }
    }
}
