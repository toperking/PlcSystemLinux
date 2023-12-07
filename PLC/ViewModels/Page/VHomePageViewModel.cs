using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLC.ViewModels.Page
{
    public class VHomePageViewModel : PageViewModelBase
    {
        public ICommand StartButton { get; set; }
        public ICommand StopButton { get; set; }
        public ICommand OriginButton { get; set; }
        public ICommand AlramButton { get; set; }

        private IBrush _ColorBtnStart;
        private IBrush _ColorBtnStop;
        private IBrush _ColorBtnOrigin;
        private IBrush _ColorBtnAlram;

        public IBrush ColorBtnStart
        {
            get { return _ColorBtnStart; }
            set {this.RaiseAndSetIfChanged(ref _ColorBtnStart, value);}
        }
        public IBrush ColorBtnStop
        {
            get { return _ColorBtnStop; }
            set { this.RaiseAndSetIfChanged(ref _ColorBtnStop, value); }
        }
        public IBrush ColorBtnOrigin
        {
            get { return _ColorBtnOrigin; }
            set { this.RaiseAndSetIfChanged(ref _ColorBtnOrigin, value); }
        }
        public IBrush ColorBtnAlram
        {
            get { return _ColorBtnAlram; }
            set { this.RaiseAndSetIfChanged(ref _ColorBtnAlram, value); }
        }
        private List<IBrush> buttons = new List<IBrush>();
        private void DispiseButton() {
            ColorBtnStart = Brush.Parse("Black");
            ColorBtnStop = Brush.Parse("Black");
            ColorBtnOrigin = Brush.Parse("Black");
            ColorBtnAlram = Brush.Parse("Black");
        }
        private void ChangeButtonColor() {
            DispiseButton();
        }
        public VHomePageViewModel()
        {
            DispiseButton();


            StartButton = ReactiveCommand.Create<string>(doStartButton);
            StopButton = ReactiveCommand.Create<string>(doStopButton);
            OriginButton = ReactiveCommand.Create<string>(doOriginButton);
            AlramButton = ReactiveCommand.Create<string>(doAlramButton);

        }

        private void doAlramButton(string arge)
        {
            DispiseButton();
            ColorBtnAlram = Brush.Parse("Green");
        }

        private void doOriginButton(string arge)
        {
            DispiseButton();
            ColorBtnOrigin = Brush.Parse("Green");
        }

        private void doStopButton(string arge)
        {
            DispiseButton();
            ColorBtnStop = Brush.Parse("Green");
        }

        private void doStartButton(string arge)
        {
            DispiseButton();
            ColorBtnStart = Brush.Parse("Green");
        }
    }
}
