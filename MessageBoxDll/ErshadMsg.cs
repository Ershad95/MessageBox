using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
namespace MessageBoxDll
{
   public class ErshadMsg
    {
        MainWindow main = new MainWindow();

        #region varaible
        double up;
        private double down;
        DispatcherTimer d = new DispatcherTimer();
        static Btn ebtn = Btn.Ok;
       static  string addicn = null;
       static Eicn eicn = Eicn.error;
       static  Diraction dir = Diraction.LTR;
       static Result res = Result.none;
       static Ecolor col = Ecolor.white;
       
        #endregion



        public enum Diraction
        {
            LTR,
            RTL
        }
        public enum Ecolor
        {
            green,
            red,
            yellow,
            black,
            white
        }

        public enum Btn
        {
           Ok,
           Ok_no,
           Yes_no
        }
        public enum Eicn
        {
            warning,
            error,
            information,
            qestion
        }
        public enum Result
        {
            ok,
            yes,
            no,
            none
        }
   

       public ErshadMsg()
        {
            
        }
       public ErshadMsg(string Msg)
        {
            main.txtmsg.Text = Msg;
            //IMessage();
           // main.ShowDialog();
            
        }
       public ErshadMsg(string Msg,string Title)
        {
            main.txtmsg.Text = Msg;
            main.title.Content = Title;
           // IMessage();
           // main.ShowDialog();
          
        }
       public ErshadMsg(string Msg, string Title,Btn b,Eicn i,Diraction d,Ecolor c)
        {
            main.txtmsg.Text = Msg;
            main.title.Content = Title;
            ebtn = b;
            eicn = i;
            dir = d;
            col = c;
           // IMessage();
           // main.ShowDialog();
            
        }

         void IMessage()
        {
          up = main.rec_header.Margin.Top;
          down = main.rec_footer.Margin.Bottom;

            d.Interval = new TimeSpan(0, 0, 0, 0, 5);
            d.Tick += Tick;
            d.Start();
         

            main.btn1.Click += Btn_Click;
            main.btn2.Click += Btn_Click;
            main.btn3.Click += Btn_Click;


            main.btnClose.MouseLeftButtonUp +=close;
            main.X.MouseLeftButtonDown += close;

            main.btn1.KeyDown += key_enter;
            main.btn2.KeyDown += key_enter;
            main.btn3.KeyDown += key_enter;

            switch (dir)
            {
                case Diraction.LTR:
                    main.FlowDirection = System.Windows.FlowDirection.LeftToRight;
                    break;
                case Diraction.RTL:
                    main.FlowDirection = System.Windows.FlowDirection.RightToLeft;
                    break;
                default:
                    main.FlowDirection = System.Windows.FlowDirection.LeftToRight;
                    break;
           
            }
            switch(col)
            {
                case Ecolor.black:
                   main.txtmsg.Foreground = new SolidColorBrush(Color.FromScRgb(1, 0, 0, 0));
                    main.title.Foreground = new SolidColorBrush(Color.FromScRgb(1, 0, 0, 0));
                    break;
                case Ecolor.white:
                    main.txtmsg.Foreground = new SolidColorBrush(Color.FromScRgb(1, 1, 1, 1));
                    main.title.Foreground = new SolidColorBrush(Color.FromScRgb(1,1,1,1));
                    break;
                case Ecolor.green:
                    main.txtmsg.Foreground = new SolidColorBrush(Color.FromScRgb(1, 0, 1, 0));
                    main.title.Foreground = new SolidColorBrush(Color.FromScRgb(1, 0,1,0));
                    break;
                case Ecolor.red:
                    main.txtmsg.Foreground = new SolidColorBrush(Color.FromScRgb(1, 1, 0, 0));
                    main.title.Foreground = new SolidColorBrush(Color.FromScRgb(1,1,0,0));
                    break;
                case Ecolor.yellow:
                    main.txtmsg.Foreground = new SolidColorBrush(Color.FromScRgb(1, 1, 1, 0));
                    main.title.Foreground = new SolidColorBrush(Color.FromScRgb(1, 1,1,0));
                    break;

            }
            if (dir == Diraction.LTR)
            {
                switch (ebtn)
                {
                    case Btn.Ok:
                        main.btn1.Visibility = System.Windows.Visibility.Visible;
                        main.btn2.Visibility = System.Windows.Visibility.Hidden;
                        main.btn3.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case Btn.Ok_no:
                        main.btn1.Visibility = System.Windows.Visibility.Visible;
                        main.btn2.Visibility = System.Windows.Visibility.Visible;
                        main.btn3.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case Btn.Yes_no:
                        main.btn1.Visibility = System.Windows.Visibility.Hidden;
                        main.btn2.Visibility = System.Windows.Visibility.Visible;
                        main.btn3.Visibility = System.Windows.Visibility.Visible;
                        break;
                }
            }
            else if(dir == Diraction.RTL)
            {
                main.btn1.Content = "باشه";
                main.btn2.Content = "نه";
                main.btn3.Content = "انصراف";
                switch (ebtn)
                {
                    case Btn.Ok:
                        main.btn1.Visibility = System.Windows.Visibility.Hidden;
                        main.btn2.Visibility = System.Windows.Visibility.Hidden;
                        main.btn3.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case Btn.Ok_no:
                        main.btn1.Visibility = System.Windows.Visibility.Visible;
                        main.btn2.Visibility = System.Windows.Visibility.Visible;
                        main.btn3.Visibility = System.Windows.Visibility.Hidden;
                        break;
                    case Btn.Yes_no:
                        main.btn2.Visibility = System.Windows.Visibility.Hidden;
                        main.btn1.Visibility = System.Windows.Visibility.Visible;
                        main.btn3.Visibility = System.Windows.Visibility.Visible;
                        break;
                }
            }
            switch(eicn)
            {
                case Eicn.error:
                    addicn = "red.png";
                    break;
                case Eicn.information:
                    addicn = "green.png";
                    break;
                case Eicn.warning:
                    addicn = "yellow.png";
                    break;
                case Eicn.qestion:
                    addicn = "information.png";
                    break;
            }
            if(addicn !=null)
                    main.Icon.Source = new BitmapImage(new Uri(addicn, UriKind.Relative));
        }




        private void Tick(object sender, EventArgs e)
        {
            main.btn1.Visibility = System.Windows.Visibility.Hidden;
            main.rec_header.Margin = new System.Windows.Thickness(0, up-=1, 0, 0);
            main.rec_footer.Margin = new System.Windows.Thickness(0,down+=1.2,0,0);
          
            if(up<-70)
            {
                d.Stop();
                main.btn1.Visibility = System.Windows.Visibility.Visible;
                main.rec_body.Visibility = System.Windows.Visibility.Visible;
                main.btnClose.Visibility = System.Windows.Visibility.Visible;
                main.X.Visibility = System.Windows.Visibility.Visible;
                main.title.Visibility = System.Windows.Visibility.Visible;
                main.Icon.Visibility = System.Windows.Visibility.Visible;
                main.txtmsg.Visibility = System.Windows.Visibility.Visible;
            }
        }




        private void key_enter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string id = ((Button)sender).Name;
            switch(id)
            {
                case "btn1":
                    res = Result.ok;
                    break;
                case "btn2":
                    res = Result.yes;
                    break;
                case "btn3":
                    res = Result.no;
                    break;
                default:
                    res = Result.none;
                    break;
                    
            }

            feedback(res);
            
        }

        public int feedback(Result r)
        {
            switch(r)
            {
                case Result.no:
                    return 0;
                case Result.yes:
                    return 1;
                case Result.ok:
                    return 1;
                case Result.none:
                    return -1;
            }
            return -1000;
        }

        private void close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            main.Close();
        }

        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string id = ((Button)sender).Name;

           
            switch(id)
            {
                case "btn1":
                    res = Result.ok;
                    break;
                case "btn2":
                    res = Result.yes;
                    break;
                case "btn3":
                    res = Result.no;
                    break;
                default:
                    res = Result.none;
                    break;
            }
            feedback(res);
            main.Close();
        }


        #region Show Display()
        public void Display()
        {
            IMessage();
            main.ShowDialog();
        }
        public void Display(string Message)
        {
            main.txtmsg.Text = Message;
            IMessage();
            main.ShowDialog();
        }
        public void Display(string Message,string title)
        {
            main.txtmsg.Text = Message;
            main.title.Content = title;
            IMessage();
            main.ShowDialog();
        }
        public void Display(string Message, string Title, Btn btn, Eicn icn,Diraction d,Ecolor c)
        {
            main.txtmsg.Text = Message;
            main.title.Content = Title;
            col = c;
            ebtn = btn;
            col = c;
            eicn = icn;
            dir = d;
            IMessage();
            main.ShowDialog();
        }
        public void Display(string Message, string Title, Eicn icn, Ecolor c)
        {
            main.txtmsg.Text = Message;
            main.title.Content = Title;
            col = c;
            eicn = icn;
            IMessage();
            main.ShowDialog();
        }
        #endregion Show Display()
    }
}
