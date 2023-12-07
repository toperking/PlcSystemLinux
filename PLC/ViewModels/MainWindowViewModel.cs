using DynamicData;
using PLC.ViewModels;
using PLC.ViewModels.Page;
using ReactiveUI;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLC.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string DateTimes { get; set; } = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        
        public ICommand HomePage { get; set; }
        public ICommand SettingPage { get; set; }
        public ICommand MontorPage { get; set; }

        // The default is the first page
        private PageViewModelBase _CurrentPage ;

        /// <summary>
        /// Gets the current page. The property is read-only
        /// </summary>
        public PageViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        private string _TitleText = "";

        public string TitleText {
            get { return _TitleText; } 
            
            private set { this.RaiseAndSetIfChanged(ref _TitleText, value); }
        }
        // A read.only array of possible pages
        private readonly PageViewModelBase[] Pages =
        {
            new VHomePageViewModel(),
            new VSettingPageViewModel(),
            new VMotorPageViewModel(),
        };

        private readonly string[] TitleTexts = {
            "主畫面",
            "設定畫面",
            "監視畫面"

        };

        public MainWindowViewModel()
        {
            GetTitleText(Pages[0]);
            HomePage = ReactiveCommand.Create<string>(openHomePage);
            SettingPage = ReactiveCommand.Create<string>(openSetingPage);
            MontorPage = ReactiveCommand.Create<string>(openMontorPage);

            var th = new Thread(doGetDate);
            th.IsBackground = false;
            th.Start();
        }

        private async void doGetDate(object? obj)
        {
            while (true)
            {
                await Task.Delay(1);
                DateTimes = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                this.RaisePropertyChanged("DateTimes");
            }
        }
        private void GetTitleText(PageViewModelBase page) {

            if (page == null) return;
            CurrentPage = page;
            TitleText =  TitleTexts[Pages.IndexOf(CurrentPage)];
        }
        private void openMontorPage(string arge)
        {
             GetTitleText(Pages[2]);
        }

        private void openSetingPage(string arge)
        {
            GetTitleText(Pages[1]);

        }

        private void openHomePage(string arge)
        {
            GetTitleText(Pages[0]);     
        }

       

       

       

       
    }
}