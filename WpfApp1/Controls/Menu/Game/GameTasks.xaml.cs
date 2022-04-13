using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesertRage.Controls.Menu.Game
{
    /// <summary>
    /// Логика взаимодействия для GameTasks.xaml
    /// </summary>
    public partial class GameTasks : UserControl
    {
        public GameTasks()
        {
            InitializeComponent();
        }

        //#region Tasks Members
        //private void ShowSomeTasks(Label[] labs, Image[] imgs,
        //    in string[] texts, in string[] bmps)
        //{
        //    AnyShowX(labs);
        //    AnyShowX(imgs);
        //    FastTextChange(labs, texts);
        //    FastImgChange(BmpersToX(bmps), imgs);
        //}

        //private void ShowSomeTasks(Label labs, Image imgs,
        //    in string texts, in string bmps)
        //{
        //    AnyShowX(labs, imgs);
        //    labs.Content = texts;
        //    imgs.Source = Bmper(bmps);
        //}

        //private void RealTasks()
        //{
        //    string[] TasksText = { Txts.Goals.T1, Txts.Goals.T2, Txts.Goals.T3,
        //        Txts.Goals.T4, Txts.Goals.T5, Txts.Goals.T6, Txts.Goals.T7,
        //        Txts.Goals.T8, Txts.Goals.T9, Txts.Goals.T10 };
        //    string[] uriSources = new string[] { Paths.Static.Menu.MTasks.UsualTask,
        //        Paths.Static.Menu.MTasks.Completed };
        //    switch (Ray.MenuTask)
        //    {
        //        case 0:
        //            ShowSomeTasks(Task1, Task1Img, TasksText[0], uriSources[0]);
        //            break;
        //        case 1:
        //            ShowSomeTasks(new Label[] { Task1, Task2 },
        //                new Image[] { Task1Img, Task2Img },
        //                new string[] { TasksText[0], TasksText[1] },
        //                new string[] { uriSources[1], uriSources[0] });
        //            break;
        //        case 2:
        //            ShowSomeTasks(new Label[] { Task1, Task2, Task3 },
        //                new Image[] { Task1Img, Task2Img, Task3Img },
        //                new string[] { TasksText[0], TasksText[1], TasksText[2] },
        //                new string[] { uriSources[1], uriSources[1], uriSources[0] });
        //            break;
        //        case 3:
        //            ShowSomeTasks(new Label[] { Task1, Task2, Task3, Task4 },
        //                new Image[] { Task1Img, Task2Img, Task3Img, Task4Img },
        //                new string[] { TasksText[0], TasksText[1],
        //                    TasksText[2], TasksText[3] },
        //                new string[] { uriSources[1], uriSources[1],
        //                    uriSources[1], uriSources[0] });
        //            break;
        //        case 4:
        //            ShowSomeTasks(Task1, Task1Img, TasksText[4], uriSources[0]);
        //            break;
        //        case 5:
        //            ShowSomeTasks(new Label[] { Task1, Task2 },
        //                new Image[] { Task1Img, Task2Img },
        //                new string[] { TasksText[4], TasksText[5] },
        //                new string[] { uriSources[1], uriSources[0] });
        //            break;
        //        case 6:
        //            ShowSomeTasks(new Label[] { Task1, Task2, Task3 },
        //                new Image[] { Task1Img, Task2Img, Task3Img },
        //                new string[] { TasksText[4], TasksText[5], TasksText[6] },
        //                new string[] { uriSources[1], uriSources[1], uriSources[0] });
        //            break;
        //        case 7:
        //            ShowSomeTasks(Task1, Task1Img, TasksText[7], uriSources[0]);
        //            break;
        //        case 8:
        //            ShowSomeTasks(new Label[] { Task1, Task2 },
        //                new Image[] { Task1Img, Task2Img },
        //                new string[] { TasksText[7], TasksText[8] },
        //                new string[] { uriSources[1], uriSources[0] });
        //            break;
        //        default:
        //            ShowSomeTasks(Task1, Task1Img, TasksText[9], uriSources[0]);
        //            break;
        //    }
        //}

        //private void MiniTasks()
        //{
        //    string[] TasksText = { Txts.Goals.E1, Txts.Goals.E2, Txts.Goals.E3 };
        //    string[] uriSources = new string[] {
        //        Paths.Static.Menu.MTasks.ExperTask,
        //        Paths.Static.Menu.MTasks.Completed };
        //    if (CurrentLocation < 3)
        //        ShowSomeTasks(Task5, Task5Img, TasksText[CurrentLocation],
        //            uriSources[Ray.MiniTask ? 1 : 0]);
        //}
        //#endregion
    }
}
