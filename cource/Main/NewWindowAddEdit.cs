using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cource.Main;

namespace cource.Main
{
    class NewWindowAddEdit
    {
        public static AddEditWindow CreateWin(int swit, AddEditWindow win)
        {
            win.Opacity = 0;
            WinForm.swit = swit;

            switch (swit)
            {
                case 0:
                    win.Height = 470;
                    break;

                case 1:
                    win.Height = 470;
                    break;

                case 2:
                    win.Height = 320;
                    break;

                case 3:
                    win.Height = 370;
                    break;

                case 4:
                    win.Height = 370;
                    break;
            }

            return win;
        }
    }
}
